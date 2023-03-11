using System;
using System.Collections.Generic;
using System.Text;
using Benchmarking.Core;

namespace Benchmarking.Benchmarks
{
    public class ListInsert : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

        public override string InitializationDescription => "Generates a list of random ints.";
        public override string BenchmarkDescription => "Inserts 20% more values to the beginning of the list.";

        public override string ResultDescription => "The middle value of the list.";
        public override string ParameterDescription => "The length of the list.";

        public Random Random = null!;
        public List<int> List = null!;

        public override void Initialize(int parameter)
        {
            var n = (int)parameter;

            Random = new Random(n);
            List = new List<int>(n);

            for (var i = 0; i < n; i++) 
            {
                List.Add((int)(Random.NextDouble() * 1000000));
            }
        }

        public override object Execute()
        {
            var c = List.Count;

            for (var i = 0; i < c / 5; i++) 
            {
                List.Insert(i, 0);
            }

            return List[List.Count / 2];
        }
    }
}
