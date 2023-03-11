using Benchmarking.Core;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class SummationInt : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000000, 2000000, 3000000, 4000000, 5000000, 6000000, 7000000, 8000000, 9000000, 10000000 };

        public override string InitializationDescription => "Generates a list of random ints.";
        public override string BenchmarkDescription => "Sums each number of the list.";

        public override string ResultDescription => "The result of the summation.";
        public override string ParameterDescription => "The number of ints to sum.";

        public override void Initialize(int parameter)
        {
            SummationIntInitialize(parameter);
        }

        public override object Execute()
        {
            return SummationIntExecute();
        }

        [DllImport("SummationInt")]
        static extern void SummationIntInitialize(int iterations);

        [DllImport("SummationInt")]
        static extern int SummationIntExecute();
    }
}
