﻿// <auto-generated />
using FWPS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FWPS.Migrations
{
    [DbContext(typeof(FwpsDbContext))]
    [Migration("20180401191635_AddMailItem")]
    partial class AddMailItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FWPS.Models.IpItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Ip");

                    b.Property<DateTime>("LastModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("IpItems");
                });

            modelBuilder.Entity("FWPS.Models.LightItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Command");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsOn");

                    b.Property<bool>("IsRun");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<DateTime>("SleepTime");

                    b.Property<DateTime>("WakeUpTime");

                    b.HasKey("Id");

                    b.ToTable("LightItems");
                });

            modelBuilder.Entity("FWPS.Models.LoginItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("LoginItems");
                });

            modelBuilder.Entity("FWPS.Models.MailItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("From");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Subject");

                    b.Property<string>("To");

                    b.HasKey("Id");

                    b.ToTable("MailItems");
                });

            modelBuilder.Entity("FWPS.Models.SnapBoxItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<bool>("MailReceived");

                    b.Property<string>("PowerLevel");

                    b.Property<string>("ReceiverEmail");

                    b.HasKey("Id");

                    b.ToTable("SnapBoxItems");
                });
#pragma warning restore 612, 618
        }
    }
}
