using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks
{
    public class NewtonsMethodSecondDegree : Benchmark
    {
        public override int[] Parameters { get; set; } = { 100000, 200000, 300000, 400000, 500000, 600000, 700000, 800000, 900000, 1000000 };

        public override string InitializationDescription => "";
        public override string BenchmarkDescription => "Solves a root of a second degree function with a certain number of iterations.";

        public override string ResultDescription => "The found root.";
        public override string ParameterDescription => "The number of iterations.";

        public int Iterations;

        public override void Initialize(int parameter)
        {
            Iterations = (int)parameter;
        }

        public override object Execute()
        {
            var h = 0.001;
            var currentRoot = 0.0;

            for (var i = 0; i < Iterations; i++) 
            {
                var derivative = (Function(currentRoot + h) - Function(currentRoot)) / h;

                currentRoot = currentRoot - Function(currentRoot) / derivative;
            }

            return currentRoot;
        }

        public double Function(double x) 
        {
            return 5 * x * x - 3 * x + 7;
        }
    }
}
