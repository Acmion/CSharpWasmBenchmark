using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Benchmarking;
using Benchmarking.Core;

namespace CWasm.Benchmarks
{
    public class ListInsert : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

        public override string InitializationDescription => "Generates a list of random ints.";
        public override string BenchmarkDescription => "Inserts 20% more values to the beginning of the list.";

        public override string ResultDescription => "The middle value of the list.";
        public override string ParameterDescription => "The length of the list.";

        public override void Initialize(int parameter)
        {
            ListInsertInitialize(parameter);
        }

        public override object Execute()
        {
            return ListInsertExecute();
        }

        [DllImport("ListInsert")]
        static extern void ListInsertInitialize(int iterations);

        [DllImport("ListInsert")]
        static extern int ListInsertExecute();
    }
}
