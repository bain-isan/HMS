#pragma checksum "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb4fe86e7097fb5df2417edd28c779fdf5a43964"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Guest_ViewAll), @"mvc.1.0.view", @"/Views/Guest/ViewAll.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb4fe86e7097fb5df2417edd28c779fdf5a43964", @"/Views/Guest/ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4b38080ad3dc6b6a015d86f98af6d0cb8ff65f4", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Guest_ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HotelManagementSystem.Data.Guests.Guest>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
  
    ViewData["Sstem"] = "Guest Management System";
    ViewData["Controller"] = "Guest";
    ViewData["Title"] = "ViewAll - Guest Management System";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ViewAll</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb4fe86e7097fb5df2417edd28c779fdf5a439644066", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n");
#nullable restore
#line 14 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
 if(Model != null){

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 19 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
               Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 22 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 25 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
               Write(Html.DisplayNameFor(model => model.MemberCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 28 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
               Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 31 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
               Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 34 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
               Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 37 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
               Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 43 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 47 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 50 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 53 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
                   Write(Html.DisplayFor(modelItem => item.MemberCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 56 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
                   Write(Html.ActionLink("Edit", "UpdateCheck", new { number = item.MemberCode }));

#line default
#line hidden
#nullable disable
            WriteLiteral("  |\r\n                        ");
#nullable restore
#line 69 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { number = item.MemberCode }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 72 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 75 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
}
else{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>No Guest...</h1>\r\n");
#nullable restore
#line 78 "C:\Users\user\Desktop\DotNet Core\DotNet Core Assignment\HotelManagementSystem\HotelManagementSystem\Views\Guest\ViewAll.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HotelManagementSystem.Data.Guests.Guest>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
