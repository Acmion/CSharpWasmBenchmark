using Benchmarking;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace CSharpRuntime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# Runtime Benchmark");

            foreach (var c in BenchmarkCategory.All) 
            {
                var dirPath = BenchmarkSettings.BenchmarkingDataDirectoryPath + "/" + typeof(Program).Namespace;

                Directory.CreateDirectory(dirPath);

                Console.WriteLine("Running " + c.Name + "...");

                File.WriteAllText(dirPath + "/" + c.Name + ".json", BenchmarkRunner.RunBenchmarkCategoryToJson(c));
            }

            Console.WriteLine("Benchmarks completed.");
        }
    }
}
