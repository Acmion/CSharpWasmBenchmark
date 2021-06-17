class BenchmarkRunner
{
    static RunBenchmarkCategory(benchmarkCategory)
    {
        var data = [];

        for(var benchmark of benchmarkCategory.Benchmarks)
        {
            var dataPoints = [];

            for(var parameter of benchmark.Parameters)
            {
                // Init and warmup.
                benchmark.Initialize(parameter);
                benchmark.Execute();

                for (var i = 0; i < BenchmarkRunner.IterationCount; i++) 
                {
                    benchmark.Initialize(parameter);

                    var t0 = performance.now();

                    var res = benchmark.Execute();

                    var t1 = performance.now();

                    dataPoints.push(new BenchmarkExecuteDataPoint(parameter, t1 - t0, res));
                }
            }

            data.push(new BenchmarkInstanceData(benchmark.constructor.name, benchmark.InitializationDescription, benchmark.BenchmarkDescription,
                benchmark.ParameterDescription, benchmark.ResultDescription, dataPoints));
        }

        return new BenchmarkData(benchmarkCategory.Name, BenchmarkRunner.IterationCount, data);
    }

    static RunBenchmarkCategoryToJson(benchmarkCategory)
    {
        return BenchmarkRunner.RunBenchmarkCategory(benchmarkCategory).ToJson();
    }
}

BenchmarkRunner.IterationCount = 10;