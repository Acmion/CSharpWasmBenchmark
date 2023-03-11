using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benchmarking.Core;

namespace Benchmarking.Benchmarks
{
    public class StringConcatenation : Benchmark
    {
        public override int[] Parameters { get; set; } = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };

        public override string InitializationDescription => "";
        public override string BenchmarkDescription => "Concatenates a single character to a string a certain number of times.";

        public override string ResultDescription => "The middle character of the concatenated string.";
        public override string ParameterDescription => "The number of characters to concatenate.";

        public int CharCount = 0;
        public string Characters = "";

        public override void Initialize(int parameter)
        {
            CharCount = (int)parameter;
            Characters = "abcdefghijklmnopqrstuvwxyz";
        }

        public override object Execute()
        {
            var res = "";

            for (var i = 0; i < CharCount; i++) 
            {
                res += Characters[i % Characters.Length];
            }

            return res.ToString()[CharCount / 2];
        }
    }
}
