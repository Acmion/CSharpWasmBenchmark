using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarking.Benchmarks
{
    public class ListSortDouble : Benchmark
    {
        public override int[] Parameters { get; set; } = { 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000 };

        public override string InitializationDescription => "Generates a list of random doubles.";
        public override string BenchmarkDescription => "Sorts the list.";

        public override string ResultDescription => "The middle value of the sorted list.";
        public override string ParameterDescription => "The length of the list.";

        public Random Random = null!;
        public List<double> List = null!;

        public override void Initialize(int parameter)
        {
            var n = (int)parameter;

            Random = new Random(n);
            List = new List<double>(n);

            for (var i = 0; i < n; i++) 
            {
                List.Add(Random.NextDouble() * 1000000);
            }
        }

        public override object Execute()
        {
            List.Sort();

            return List[List.Count / 2];
        }
    }
}
