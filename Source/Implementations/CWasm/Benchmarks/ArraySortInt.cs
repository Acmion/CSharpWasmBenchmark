using Benchmarking.Core;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class ArraySortInt : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

        public override string InitializationDescription => "Generates an array of random ints.";
        public override string BenchmarkDescription => "Sorts the array.";

        public override string ResultDescription => "The middle value of the sorted array.";
        public override string ParameterDescription => "The length of the array that is sorted.";

        public override void Initialize(int parameter)
        {
            ArraySortIntInitialize(parameter);
        }

        public override object Execute()
        {
            return ArraySortIntExecute();
        }

        [DllImport("ArraySortInt")]
        static extern void ArraySortIntInitialize(int iterations);

        [DllImport("ArraySortInt")]
        static extern int ArraySortIntExecute();
    }
}
