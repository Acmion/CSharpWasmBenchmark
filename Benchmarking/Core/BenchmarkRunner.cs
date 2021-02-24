using Benchmarking.Benchmarks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmarking
{
    public static class BenchmarkRunner
    {
        public static int IterationCount { get; } = 10;

        public static BenchmarkData RunBenchmarkCategory(BenchmarkCategory benchmarkCategory)
        {
            var data = new List<BenchmarkInstanceData>();

            foreach (var benchmark in benchmarkCategory.Benchmarks)
            {
                // Uncomment to make debugging faster.
                // Or to fix Blazor Wasm Interpreted memory error.
                //for (var i = 0; i < benchmark.Parameters.Length; i++)
                //{
                //    benchmark.Parameters[i] /= 10;
                //}

                var dataPoints = new List<BenchmarkExecuteDataPoint>(benchmark.Parameters.Length * IterationCount);

                foreach (var parameter in benchmark.Parameters) 
                {
                    // Init and warmup.
                    benchmark.Initialize(parameter);
                    benchmark.Execute();

                    var sw = new Stopwatch();

                    // Clean garbage.
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    for (var i = 0; i < IterationCount; i++) 
                    {
                        benchmark.Initialize(parameter);

                        sw.Restart();

                        var res = benchmark.Execute();

                        sw.Stop();
                        
                        dataPoints.Add(new BenchmarkExecuteDataPoint(parameter, sw.ElapsedMilliseconds, res));
                    }
                }

                data.Add(new BenchmarkInstanceData(benchmark.GetType().Name, benchmark.InitializationDescription, benchmark.BenchmarkDescription, 
                                                   benchmark.ParameterDescription, benchmark.ResultDescription, dataPoints));
            }

            return new BenchmarkData(benchmarkCategory.Name, IterationCount, data);
        }

        public static string RunBenchmarkCategoryToJson(BenchmarkCategory benchmarkCategory) 
        {
            return RunBenchmarkCategory(benchmarkCategory).ToJson();
        }
    }
}
