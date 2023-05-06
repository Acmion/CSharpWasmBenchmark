using System.Linq;
using Benchmarking.Benchmarks;

namespace Benchmarking.Core
{
    public class BenchmarkCategory : IBenchmarkCategory
    {
        public string Name { get; set; }
        public Benchmark[] Benchmarks { get; set; }

        public BenchmarkCategory(string name, Benchmark[] benchmarks) 
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

        public static BenchmarkCategory ArrayBenchmarks { get; } = new BenchmarkCategory(nameof(ArrayBenchmarks), new Benchmark[]
        {
            new ArraySortInt(), new ArraySortDouble(), new ArraySortIntQuick()
        });

        public static BenchmarkCategory ListBenchmarks { get; } = new BenchmarkCategory(nameof(ListBenchmarks), new Benchmark[]
        {
            new ListSortInt(), new ListSortDouble(),
            new ListInsert(), new ListDelete(),
        });

        public static BenchmarkCategory MathBenchmarks { get; } = new BenchmarkCategory(nameof(MathBenchmarks), new Benchmark[]
        {
            new SummationInt(), new SummationDouble(),
            new MultiplicationInt(), new MultiplicationDouble(),
            new NewtonsMethodSecondDegree(), new NewtonsMethodThirdDegree(),
        });

        public static BenchmarkCategory StringBenchmarks { get; } = new BenchmarkCategory(nameof(StringBenchmarks), new Benchmark[]
        {
            new StringConcatenation(), new StringConcatenationWithBuilder(),
        });

        public static BenchmarkCategory DictionaryBenchmarks { get; } = new BenchmarkCategory(nameof(DictionaryBenchmarks), new Benchmark[]
        {
            new DictionaryAccessInt(), new DictionaryAccessString()
        });

        public static BenchmarkCategory[] All { get; } = { ArrayBenchmarks, ListBenchmarks, MathBenchmarks, StringBenchmarks, DictionaryBenchmarks };
    }

}
