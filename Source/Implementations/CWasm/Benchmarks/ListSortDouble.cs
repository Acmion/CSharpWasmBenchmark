using Benchmarking.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class ListSortDouble : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

        public override string InitializationDescription => "Generates a list of random doubles.";
        public override string BenchmarkDescription => "Sorts the list.";

        public override string ResultDescription => "The middle value of the sorted list.";
        public override string ParameterDescription => "The length of the list.";

        public override void Initialize(int parameter)
        {
            ListSortDoubleInitialize(parameter);
        }

        public override object Execute()
        {
            return ListSortDoubleExecute();
        }

        [DllImport("ListSortDouble")]
        static extern void ListSortDoubleInitialize(int iterations);

        [DllImport("ListSortDouble")]
        static extern double ListSortDoubleExecute();
    }
}
