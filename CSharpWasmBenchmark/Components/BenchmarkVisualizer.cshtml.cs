using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acmion.CshtmlComponent;
using Benchmarking;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CSharpWasmBenchmark.Components
{
    [HtmlTargetElement("BenchmarkVisualizer", TagStructure = TagStructure.WithoutEndTag)]
    public class BenchmarkVisualizer : CshtmlComponentBase
    {
        [HtmlAttributeName("Benchmark")]
        public Benchmark Benchmark { get; set; } = null!;

        public string Id => Benchmark.GetType().Name;
        public string CSharpSourceCodeUrl => Program.BenchmarkingRootUrl + "/Benchmarks/" + Id + ".cs";
        public string JavaScriptSourceCodeUrl => Program.BenchmarkingRootUrl + "/Benchmarks/" + Id + ".js";

        public BenchmarkVisualizer(IHtmlHelper htmlHelper) : base(htmlHelper)
        {
        }
    }
}
