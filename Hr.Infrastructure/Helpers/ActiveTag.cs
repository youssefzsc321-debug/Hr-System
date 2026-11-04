using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Helpers
{
    [HtmlTargetElement("a", Attributes = "active-when")]
    public class ActiveTag : TagHelper
    {
        public string? ActiveWhen { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContextData { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrEmpty(ActiveWhen))
                return;

            var currentController = ViewContextData?.RouteData.Values["controller"]?.ToString() ?? string.Empty;

            if (currentController.Equals(ActiveWhen, StringComparison.OrdinalIgnoreCase))
            {
                if (output.Attributes.ContainsName("class"))
                    output.Attributes.SetAttribute("class", $"{output.Attributes["class"].Value} active");
                else
                    output.Attributes.SetAttribute("class", "active");

                var parentContext = context;
                
            }
        }
    }
}