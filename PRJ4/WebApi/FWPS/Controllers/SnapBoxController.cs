﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FWPS.Data;
using FWPS.Models;
using Microsoft.AspNetCore.Mvc;

namespace FWPS.Controllers
{
	[Route("api/[Controller]")]
	public class SnapBoxController : Controller
	{
		private readonly FwpsDbContext _context;
	    private List<IObserver<SnapBoxItem>> _observers;

		public SnapBoxController(FwpsDbContext context)
		{
			_context = context;
            _observers = new List<IObserver<SnapBoxItem>>();

			if (_context.SnapBoxItems.Any() == false)
			{
				_context.SnapBoxItems.Add(new SnapBoxItem() { PowerLevel = "100", MailReceived = false, ReceiverEmail = "simonvu@post.au.dk"});
				_context.SaveChanges();
			}
		}


		[HttpGet]
		public IEnumerable<SnapBoxItem> GetAll()
		{
			return _context.SnapBoxItems.ToList();

		}


		[HttpGet("{id:int}", Name = "GetSnapBox")]
		public IActionResult GetById(long id)
		{
			var item = _context.SnapBoxItems.FirstOrDefault(t => t.Id == id);
			{
				if (item == null)
				{
					return NotFound();
				}
			}
			return new ObjectResult(item);
		}



		[HttpPost]
		public IActionResult Create([FromBody] SnapBoxItem item)
		{
			if (item == null)
				return BadRequest();

		    if (item.PowerLevel == null)
		        return BadRequest("Powerlevel null");
		    if (item.MailReceived == true && item.ReceiverEmail == null)
		        return BadRequest("No ReceiverEmail specified");

			_context.SnapBoxItems.Add(item);
			_context.SaveChanges();

            if (item.MailReceived)
            {
                MailSender ms = new MailSender(_context);
                ms.SendSnapBoxMail(item);
            }

			return CreatedAtRoute("GetSnapBox", new { id = item.Id }, item);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var item = _context.SnapBoxItems.FirstOrDefault(o => o.Id == id);
			if (item == null)
			{
				return NotFound();
			}

			_context.SnapBoxItems.Remove(item);
			_context.SaveChanges();
			return new NoContentResult();
		}


	}
}
