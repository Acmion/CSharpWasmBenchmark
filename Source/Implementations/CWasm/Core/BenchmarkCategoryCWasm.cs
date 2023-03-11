using Benchmarking.Core;
using CWasm.Benchmarks;
using System.Linq;

namespace CWasm.Core
{
    public class BenchmarkCategoryCWasm : IBenchmarkCategory
    {
        public string Name { get; set; }
        public Benchmark[] Benchmarks { get; set; }

        public BenchmarkCategoryCWasm(string name, Benchmark[] benchmarks) 
        {
            Name = name;
            Benchmarks = benchmarks;
        }

        public string ToJson() 
        {
            var benchmarksJson = string.Join(", ", Benchmarks.Select(b => b.ToJson()));

            return $@"{{ ""{nameof(Name)}"": ""{Name}"", ""{nameof(Benchmarks)}"": [ {benchmarksJson} ] }}";
        }

        // ------------------------------------------------------
        // ------------------------------------------------------
        // ------------------------------------------------------

        public static BenchmarkCategoryCWasm ArrayBenchmarks { get; } = new BenchmarkCategoryCWasm(nameof(ArrayBenchmarks), new Benchmark[]
        {
            new ArraySortInt(), new ArraySortDouble(), new ArraySortIntQuick()
        });

        public static BenchmarkCategoryCWasm ListBenchmarks { get; } = new BenchmarkCategoryCWasm(nameof(ListBenchmarks), new Benchmark[]
        {
            new ListSortInt(), new ListSortDouble(),
            new ListInsert(), new ListDelete(),
        });

        public static BenchmarkCategoryCWasm MathBenchmarks { get; } = new BenchmarkCategoryCWasm(nameof(MathBenchmarks), new Benchmark[]
        {
            new SummationInt(), new SummationDouble(),
            new MultiplicationInt(), new MultiplicationDouble(),
            new NewtonsMethodSecondDegree(), new NewtonsMethodThirdDegree(),
        });

        public static BenchmarkCategoryCWasm StringBenchmarks { get; } = new BenchmarkCategoryCWasm(nameof(StringBenchmarks), new Benchmark[]
        {
            new StringConcatenation(), new StringConcatenationWithBuilder(),
        });

        public static BenchmarkCategoryCWasm DictionaryBenchmarks { get; } = new BenchmarkCategoryCWasm(nameof(DictionaryBenchmarks), new Benchmark[]
        {
            new DictionaryAccessInt(), new DictionaryAccessString()
        });

        public static BenchmarkCategoryCWasm[] All { get; } = { ArrayBenchmarks, ListBenchmarks, MathBenchmarks, StringBenchmarks, DictionaryBenchmarks };
    }
}
