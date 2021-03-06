﻿using System;
using System.Collections.Generic;

namespace RouletteGame.Legacy
{
    public interface IRoulette
    {
        void Spin();
        Field GetResult();
    }

    public class Roulette : IRoulette
    {
        private readonly List<Field> _fields;
        private Field _result;
        private IRandom _randomEngine;

        public Roulette() : this(null) { }
        public Roulette(IRandom randomEngine)
        {
            _randomEngine = randomEngine;
            _fields = new List<Field>
            {
                new Field(0, Field.Green),
                new Field(1, Field.Red),
                new Field(2, Field.Black),
                new Field(3, Field.Red),
                new Field(4, Field.Black),
                new Field(5, Field.Red),
                new Field(6, Field.Black),
                new Field(7, Field.Red),
                new Field(8, Field.Black),
                new Field(9, Field.Red),
                new Field(10, Field.Black),
                new Field(11, Field.Black),
                new Field(12, Field.Red),
                new Field(13, Field.Black),
                new Field(14, Field.Red),
                new Field(15, Field.Black),
                new Field(16, Field.Red),
                new Field(17, Field.Black),
                new Field(18, Field.Red),
                new Field(19, Field.Red),
                new Field(20, Field.Black),
                new Field(21, Field.Red),
                new Field(22, Field.Black),
                new Field(23, Field.Red),
                new Field(24, Field.Black),
                new Field(25, Field.Red),
                new Field(26, Field.Black),
                new Field(27, Field.Red),
                new Field(28, Field.Black),
                new Field(29, Field.Black),
                new Field(30, Field.Red),
                new Field(31, Field.Black),
                new Field(32, Field.Red),
                new Field(33, Field.Black),
                new Field(34, Field.Red),
                new Field(35, Field.Black),
                new Field(36, Field.Red)
            };

            _result = _fields[0];
        }

        public void Spin()
        {
            var n = _randomEngine?.Next(0, 37) ?? new Random().Next(0, 37); 
            _result = _fields[(int) n];
        }

        public Field GetResult()
        {
            return _result;
        }
    }

    public interface IRandom
    {
        uint Next(int first, int second);
    }

    public class StubRandom : IRandom
    {
        private readonly uint _nextNumber;
        public StubRandom(uint nextNumber)
        {
            _nextNumber = nextNumber;
        }
        public uint Next(int first, int second)
        {
            return _nextNumber;
        }
    }

    public class Random : IRandom
    {
        public bool hasbeenCalled { get; set; }
        public uint Next(int first, int second)
        {
            hasbeenCalled = true;
            return (uint) new System.Random().Next(first, second);
        }
    }
}