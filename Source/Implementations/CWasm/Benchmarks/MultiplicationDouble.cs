using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Benchmarking;
using Benchmarking.Core;

namespace CWasm.Benchmarks
{
    public class MultiplicationDouble : Benchmark
    {
        public override int[] Parameters { get; set; } = { 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000 };

        public override string InitializationDescription => "Generates a list of random doubles.";
        public override string BenchmarkDescription => "Multiplies each number of the list.";

        public override string ResultDescription => "The result of the multiplication.";
        public override string ParameterDescription => "The number of doubles to multiply.";
        
        public override void Initialize(int parameter)
        {
            MultiplicationDoubleInitialize(parameter);
        }

        public override object Execute()
        {
            return MultiplicationDoubleExecute();
        }

        [DllImport("MultiplicationDouble")]
        static extern void MultiplicationDoubleInitialize(int iterations);

        [DllImport("MultiplicationDouble")]
        static extern double MultiplicationDoubleExecute();
    }
}
