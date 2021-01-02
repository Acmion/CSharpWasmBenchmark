using Benchmarking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpWasmBenchmark.Pages.cs_runtime.api
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
