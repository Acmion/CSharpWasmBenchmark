﻿using Benchmarking.Core;
using System;
using System.Collections.Generic;

namespace Benchmarking.Benchmarks
{
    public class MultiplicationInt : Benchmark
    {
        public override int[] Parameters { get; set; } = { 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000 };

        public override string InitializationDescription => "Generates a list of random ints.";
        public override string BenchmarkDescription => "Multiplies each number of the list.";

        public override string ResultDescription => "The result of the multiplication.";
        public override string ParameterDescription => "The number of ints to multiply.";

        public Random Random = null!;
        public List<int> List = null!;

        public override void Initialize(int parameter)
        {
            var n = (int)parameter;

            Random = new Random(n);
            List = new List<int>(n / 100);

            for (var i = 0; i < n / 100; i++)
            {
                List.Add((Random.Next(0, 100)));
            }
        }

        public override object Execute()
        {
            var res = 0;
            var c = List.Count;

            for(var j = 0; j < 100; j++)
                for (var i = 0; i < c; i++) 
                {
                    res += List[i] * i;
                }

            return res;
        }
    }
}
