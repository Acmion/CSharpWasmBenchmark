using Benchmarking.Core;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class SummationDouble : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000000, 2000000, 3000000, 4000000, 5000000, 6000000, 7000000, 8000000, 9000000, 10000000 };

        public override string InitializationDescription => "Generates a list of random doubles.";
        public override string BenchmarkDescription => "Sums each number of the list.";

        public override string ResultDescription => "The result of the summation.";
        public override string ParameterDescription => "The number of doubles to sum.";

        public override void Initialize(int parameter)
        {
            SummationDoubleInitialize(parameter);
        }

        public override object Execute()
        {
            return SummationDoubleExecute();
        }

        [DllImport("SummationDouble")]
        static extern void SummationDoubleInitialize(int iterations);

        [DllImport("SummationDouble")]
        static extern double SummationDoubleExecute();
    }
}
