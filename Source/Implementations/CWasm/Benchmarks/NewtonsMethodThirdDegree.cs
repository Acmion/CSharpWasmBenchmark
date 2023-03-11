using System.Runtime.InteropServices;
using Benchmarking;
using Benchmarking.Core;

namespace CWasm.Benchmarks
{
    public class NewtonsMethodThirdDegree : Benchmark
    {
        public override int[] Parameters { get; set; } = { 100000, 200000, 300000, 400000, 500000, 600000, 700000, 800000, 900000, 1000000 };

        public override string InitializationDescription => "";
        public override string BenchmarkDescription => "Solves a root of a third degree function with a certain number of iterations.";

        public override string ResultDescription => "The found root.";
        public override string ParameterDescription => "The number of iterations.";

        public override void Initialize(int parameter)
        {
            NewtonsMethodThirdDegreeInitialize(parameter);
        }

        public override object Execute()
        {
            return NewtonsMethodThirdDegreeExecute();
        }

        [DllImport("NewtonsMethodThirdDegree")]
        static extern void NewtonsMethodThirdDegreeInitialize(int iterations);

        [DllImport("NewtonsMethodThirdDegree")]
        static extern double NewtonsMethodThirdDegreeExecute();
    }
}
