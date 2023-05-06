using Benchmarking.Core;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class NewtonsMethodSecondDegree : Benchmark
    {
        public override int[] Parameters { get; set; } = { 100000, 200000, 300000, 400000, 500000, 600000, 700000, 800000, 900000, 1000000 };

        public override string InitializationDescription => "";
        public override string BenchmarkDescription => "Solves a root of a second degree function with a certain number of iterations.";

        public override string ResultDescription => "The found root.";
        public override string ParameterDescription => "The number of iterations.";

        public override void Initialize(int parameter)
        {
            NewtonsMethodSecondDegreeInitialize(parameter);
        }

        public override object Execute()
        {
            return NewtonsMethodSecondDegreeExecute();
        }

        [DllImport("NewtonsMethodSecondDegree")]
        static extern void NewtonsMethodSecondDegreeInitialize(int iterations);

        [DllImport("NewtonsMethodSecondDegree")]
        static extern double NewtonsMethodSecondDegreeExecute();
    }
}
