using Benchmarking.Core;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class ListDelete : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

        public override string InitializationDescription => "Generates a list of random ints.";
        public override string BenchmarkDescription => "Deletes 20% of the values from the beginning of the list.";

        public override string ResultDescription => "The middle value of the list.";
        public override string ParameterDescription => "The length of the list.";

        public override void Initialize(int parameter)
        {
            ListDeleteInitialize(parameter);
        }

        public override object Execute()
        {
            return ListDeleteExecute();
        }

        [DllImport("ListDelete")]
        static extern void ListDeleteInitialize(int iterations);

        [DllImport("ListDelete")]
        static extern int ListDeleteExecute();
    }
}
