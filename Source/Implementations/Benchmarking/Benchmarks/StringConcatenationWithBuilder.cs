using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    public class StringConcatenationWithBuilder : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000 * 5, 2000 * 5, 3000 * 5, 4000 * 5, 5000 * 5, 6000 * 5, 7000 * 5, 8000 * 5, 9000 * 5, 10000 * 5 };

        public override string InitializationDescription => "";
        public override string BenchmarkDescription => "Concatenates a single character to a string a certain number of times using a StringBuilder.";

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
            var res = new StringBuilder();

            for (var i = 0; i < CharCount; i++) 
            {
                res.Append(Characters[i % Characters.Length]);
            }

            return res.ToString()[CharCount / 2];
        }
    }
}
