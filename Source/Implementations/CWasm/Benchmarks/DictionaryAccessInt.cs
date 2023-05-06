using Benchmarking.Core;
using System.Runtime.InteropServices;

namespace CWasm.Benchmarks
{
    public class DictionaryAccessInt : Benchmark
    {
        public override int[] Parameters { get; set; } = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

        public override string InitializationDescription => "Generates a dictionary of random ints as keys with random ints as values.";
        public override string BenchmarkDescription => "Randomly accesses half of the keys and sums their respective values.";

        public override string ResultDescription => "The sum of the values of the accessed keys.";
        public override string ParameterDescription => "The number of items in the dictionary.";

        public override void Initialize(int parameter)
        {
            DictionaryAccessIntInitialize(parameter);
        }

        public override object Execute()
        {
            return DictionaryAccessIntExecute();
        }

        [DllImport("DictionaryAccessInt")]
        static extern void DictionaryAccessIntInitialize(int iterations);

        [DllImport("DictionaryAccessInt")]
        static extern int DictionaryAccessIntExecute();
    }
}
