using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    public class DictionaryAccessString : Benchmark
    {
        public override int[] Parameters { get; set; } = { 100000, 200000, 300000, 400000, 500000, 600000, 700000, 800000, 900000, 1000000 };

        public override string InitializationDescription => "Generates a dictionary of random strings as keys with random ints as values.";
        public override string BenchmarkDescription => "Randomly accesses half of the keys and sums their respective values.";

        public override string ResultDescription => "The sum of the values of the accessed keys.";
        public override string ParameterDescription => "The number of items in the dictionary.";

        public Random Random = null!;
        public Dictionary<string, int> Dictionary = null!;
        public List<string> DictionaryKeys = null!;

        public override void Initialize(int parameter)
        {
            var n = (int)parameter;

            Random = new Random(n);
            Dictionary = new Dictionary<string, int>();
            DictionaryKeys = new List<string>();

            for (var i = 0; i < n; i++)
            {
                var val = (int)(Random.NextDouble() * 1000000);
                var key = i + ":" + val;

                Dictionary[key] = val;
                DictionaryKeys.Add(key);
            }
        }

        public override object Execute()
        {
            var sum = 0;
            var c = Dictionary.Count;

            for (var i = 0; i < c; i++) 
            {
                var key = DictionaryKeys[Random.Next(c)];
                sum += Dictionary[key];
            }

            return sum;
        }
    }
}
