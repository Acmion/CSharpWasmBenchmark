using Benchmarking.Core;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class MultiplicationInt : Benchmark
    {
        public override int[] Parameters { get; set; } = { 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000 };

        public override string InitializationDescription => "Generates a list of random ints.";
        public override string BenchmarkDescription => "Multiplies each number of the list.";

        public override string ResultDescription => "The result of the multiplication.";
        public override string ParameterDescription => "The number of ints to multiply.";

        public override void Initialize(int parameter)
        {
            MultiplicationIntInitialize(parameter);
        }

        public override object Execute()
        {
            return MultiplicationIntExecute();
        }

        [DllImport("MultiplicationInt")]
        static extern void MultiplicationIntInitialize(int iterations);

        [DllImport("MultiplicationInt")]
        static extern int MultiplicationIntExecute();
    }
}
