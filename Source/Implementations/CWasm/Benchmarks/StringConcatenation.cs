using Benchmarking.Core;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class StringConcatenation : Benchmark
    {
        public override int[] Parameters { get; set; } = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };

        public override string InitializationDescription => "";
        public override string BenchmarkDescription => "Concatenates a single character to a string a certain number of times.";

        public override string ResultDescription => "The middle character of the concatenated string.";
        public override string ParameterDescription => "The number of characters to concatenate.";

        public override void Initialize(int parameter)
        {
            StringConcatenationInitialize(parameter);
        }

        public override object Execute()
        {
            return StringConcatenationExecute();
        }

        [DllImport("StringConcatenation")]
        static extern void StringConcatenationInitialize(int iterations);

        [DllImport("StringConcatenation")]
        static extern char StringConcatenationExecute();
    }
}
