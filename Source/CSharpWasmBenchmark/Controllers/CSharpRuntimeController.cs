using System.Linq;
using Benchmarking.Core;
using Microsoft.AspNetCore.Mvc;

namespace CSharpWasmBenchmark.Controllers
{
    [Route("api/cs-runtime")]
    public class CSharpRuntimeController : Controller
    {
        public string Get(string benchmarkCategory)
        {
            var bc = BenchmarkCategory.All.First(b => b.Name == benchmarkCategory);

            return BenchmarkRunner.RunBenchmarkCategoryToJson(bc);
        }
    }
}
