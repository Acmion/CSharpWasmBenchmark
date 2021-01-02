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
    [HtmlTargetElement("BenchmarkCategoryVisualizer", TagStructure = TagStructure.WithoutEndTag)]
    public class BenchmarkCategoryVisualizer : CshtmlComponentBase
    {
        [HtmlAttributeName("BenchmarkCategory")]
        public BenchmarkCategory BenchmarkCategory { get; set; } = null!;

        [HtmlAttributeName("Interactive")]
        public bool Interactive { get; set; } = true;

        [HtmlAttributeName("BrowserMatters")]
        public bool BrowserMatters { get; set; } = true;

        public static string RunBenchmarksButtonClass => "run-benchmarks-button";
        public static string DownloadBenchmarkDataButtonClass => "download-benchmark-data-button";

        public string RunBenchmarksButtonId => BenchmarkCategory.Name + "-" + RunBenchmarksButtonClass;
        public string DownloadBenchmarkDataButtonId => BenchmarkCategory.Name + "-" + DownloadBenchmarkDataButtonClass;

        public BenchmarkCategoryVisualizer(IHtmlHelper htmlHelper) : base(htmlHelper)
        {
        }
    }
}
