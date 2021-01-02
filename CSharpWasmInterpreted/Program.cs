using Benchmarking;
using System;
using System.Linq;

namespace CSharpWasmInterpreted
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == int.MaxValue)
            {
                // Will never, in practice, be executed, but the linker will not delete the referenced methods.

                RunBenchmarkCategory(new string[0]);
            }

            Console.WriteLine("C# Wasm Interpreted");
            Console.WriteLine("Available benchmark categories: " + string.Join(", ", BenchmarkCategory.All.Select(bc => bc.Name)));
        }

        public static string RunBenchmarkCategory(string[] args)
        {
            var benchmarkCategory = args[0];

            return BenchmarkRunner.RunBenchmarkCategoryToJson(BenchmarkCategory.All.First(bc => bc.Name == benchmarkCategory));
        }
    }
}
