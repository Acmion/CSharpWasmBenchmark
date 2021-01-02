using Benchmarking.Benchmarks;
using System;

namespace Benchmarking
{
    public abstract class Benchmark
    {
        public abstract int[] Parameters { get; set; }
        
        public abstract string InitializationDescription { get; }
        public abstract string BenchmarkDescription { get; }

        public abstract string ResultDescription { get; }
        public abstract string ParameterDescription { get; }

        public abstract void Initialize(int parameter);

        public abstract object Execute();

        public string ToJson() 
        {
            return $@"{{ ""{nameof(InitializationDescription)}"": ""{InitializationDescription}"", ""{nameof(BenchmarkDescription)}"": ""{BenchmarkDescription}"", ""{nameof(ResultDescription)}"": ""{ResultDescription}"", ""{nameof(ParameterDescription)}"": ""{ParameterDescription}"" }}";
        }
    }
}
