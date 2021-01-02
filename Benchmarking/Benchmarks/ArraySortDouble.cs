using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarking.Benchmarks
{
    public class ArraySortDouble : Benchmark
    {
        public override int[] Parameters { get; set; } = { 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000 };

        public override string InitializationDescription => "Generates an array of random doubles.";
        public override string BenchmarkDescription => "Sorts the array.";

        public override string ResultDescription => "The middle value of the sorted array.";
        public override string ParameterDescription => "The length of the array that is sorted.";

        public Random Random;

        public double[] NumberArray = null!;

        public ArraySortDouble()
        {
            Random = new Random(0);
        }

        public override void Initialize(int parameter)
        {
            var n = (int)parameter;

            NumberArray = new double[n];

            for (var i = 0; i < n; i++) 
            {
                NumberArray[i] = Random.NextDouble() * 1000000;
            }
        }

        public override object Execute()
        {
            Array.Sort(NumberArray);

            return NumberArray[NumberArray.Length / 2];
        }
    }
}
