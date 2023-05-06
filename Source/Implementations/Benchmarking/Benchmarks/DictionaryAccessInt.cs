using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benchmarking.Core;

namespace Benchmarking.Benchmarks
{
    public class DictionaryAccessInt : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

        public override string InitializationDescription => "Generates a dictionary of random ints as keys with random ints as values.";
        public override string BenchmarkDescription => "Randomly accesses half of the keys and sums their respective values.";

        public override string ResultDescription => "The sum of the values of the accessed keys.";
        public override string ParameterDescription => "The number of items in the dictionary.";

        public Random Random = null!;
        public Dictionary<int, int> Dictionary = null!;
        public List<int> DictionaryKeys = null!;

        public override void Initialize(int parameter)
        {
            var n = (int)parameter;

            Random = new Random(n);
            Dictionary = new Dictionary<int, int>();
            DictionaryKeys = new List<int>();

            for (var i = 0; i < n; i++)
            {
                var val = (int)(Random.NextDouble() * 1000000);

                Dictionary[i] = val;
                DictionaryKeys.Add(i);
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
