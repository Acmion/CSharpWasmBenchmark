using Benchmarking.Core;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class StringConcatenationWithBuilder : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000 * 5, 2000 * 5, 3000 * 5, 4000 * 5, 5000 * 5, 6000 * 5, 7000 * 5, 8000 * 5, 9000 * 5, 10000 * 5 };

        public override string InitializationDescription => "";
        public override string BenchmarkDescription => "Concatenates a single character to a string a certain number of times using a StringBuilder.";

        public override string ResultDescription => "The middle character of the concatenated string.";
        public override string ParameterDescription => "The number of characters to concatenate.";

        public override void Initialize(int parameter)
        {
            StringConcatenationWithBuilderInitialize(parameter);
        }

        public override object Execute()
        {
            return StringConcatenationWithBuilderExecute();
        }

        [DllImport("StringConcatenationWithBuilder")]
        static extern void StringConcatenationWithBuilderInitialize(int iterations);

        [DllImport("StringConcatenationWithBuilder")]
        static extern char StringConcatenationWithBuilderExecute();
    }
}
