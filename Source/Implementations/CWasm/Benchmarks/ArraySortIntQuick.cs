using Benchmarking.Core;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class ArraySortIntQuick : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

        public override string InitializationDescription => "Generates an array of random ints.";
        public override string BenchmarkDescription => "Sorts the array with a custom implemented Middle Point Pivot Quicksort <a href='https://github.com/TheAlgorithms/C-Sharp'>(source)</a>.";

        public override string ResultDescription => "The middle value of the sorted array.";
        public override string ParameterDescription => "The length of the array that is sorted.";

        public override void Initialize(int parameter)
        {
            ArraySortIntQuickInitialize(parameter);
        }

        public override object Execute()
        {
            return ArraySortIntQuickExecute();
        }

        [DllImport("ArraySortIntQuick")]
        static extern void ArraySortIntQuickInitialize(int iterations);

        [DllImport("ArraySortIntQuick")]
        static extern int ArraySortIntQuickExecute();
    }
}
