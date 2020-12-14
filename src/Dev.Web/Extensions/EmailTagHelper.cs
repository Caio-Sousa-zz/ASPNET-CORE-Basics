using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dev.Web.Extensions
{
    public class EmailTagHelper: TagHelper
    {
        public string EmailDomain { get; set; } = "gmail.helper.com";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Link
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}