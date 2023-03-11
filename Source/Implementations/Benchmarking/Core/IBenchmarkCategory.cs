namespace Benchmarking.Core;

public interface IBenchmarkCategory
{
    string Name { get; set; }
    Benchmark[] Benchmarks { get; set; }
    string ToJson();
}