using Acmion.CshtmlComponent;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpWasmBenchmark.Components
{
    [HtmlTargetElement("BenchmarkCategoryBatchActions", TagStructure = TagStructure.WithoutEndTag)]
    public class BenchmarkCategoryBatchActions : CshtmlComponentBase
    {
        public BenchmarkCategoryBatchActions(IHtmlHelper htmlHelper) : base(htmlHelper)
        {
        }
    }
}
