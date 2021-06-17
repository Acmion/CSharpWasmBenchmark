using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    public class MultiplicationDouble : Benchmark
    {
        public override int[] Parameters { get; set; } = { 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000 };

        public override string InitializationDescription => "Generates a list of random doubles.";
        public override string BenchmarkDescription => "Multiplies each number of the list.";

        public override string ResultDescription => "The result of the multiplication.";
        public override string ParameterDescription => "The number of doubles to multiply.";

        public Random Random = null!;
        public List<double> List = null!;

        public override void Initialize(int parameter)
        {
            var n = (int)parameter;

            Random = new Random(n);
            List = new List<double>(n / 1000);

            for (var i = 0; i < n / 1000; i++)
            {
                List.Add(Random.NextDouble());
            }
        }

        public override object Execute()
        {
            var res = 1.0;
            var c = List.Count;

            for(var j = 0; j < 1000; j++)
                for (var i = 0; i < c; i++) 
                {
                    res *= List[i];
                }

            return res;
        }
    }
}
