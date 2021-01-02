using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acmion.CshtmlComponent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CSharpWasmBenchmark.Components
{
    [HtmlTargetElement("NavItem", TagStructure = TagStructure.WithoutEndTag)]
    public class NavItem : CshtmlComponentBase
    {
        [HtmlAttributeName("Href")]
        public string Href { get; set; } = "";

        [HtmlAttributeName("Content")]
        public string Content { get; set; } = "";

        [HtmlAttributeNotBound]
        public bool IsActive { get; set; }

        public NavItem(IHtmlHelper htmlHelper) : base(htmlHelper)
        {
        }

        protected override Task ProcessComponent(TagHelperContext context, TagHelperOutput output)
        {
            IsActive = HtmlHelper.ViewContext.HttpContext.Request.Path.Value == Href;

            return base.ProcessComponent(context, output);
        }
    }
}
