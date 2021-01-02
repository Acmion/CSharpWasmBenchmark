using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    public class SummationInt : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000000, 2000000, 3000000, 4000000, 5000000, 6000000, 7000000, 8000000, 9000000, 10000000 };

        public override string InitializationDescription => "Generates a list of random ints.";
        public override string BenchmarkDescription => "Sums each number of the list.";

        public override string ResultDescription => "The result of the summation.";
        public override string ParameterDescription => "The number of ints to sum.";

        public Random Random = null!;
        public List<int> List = null!;

        public override void Initialize(int parameter)
        {
            var n = (int)parameter;

            Random = new Random(n);
            List = new List<int>(n);

            for (var i = 0; i < n; i++)
            {
                List.Add((int)(Random.NextDouble() * 100));
            }
        }

        public override object Execute()
        {
            var res = 0;
            var c = List.Count;

            for (var i = 0; i < c; i++) 
            {
                res += List[i];
            }

            return res;
        }
    }
}
