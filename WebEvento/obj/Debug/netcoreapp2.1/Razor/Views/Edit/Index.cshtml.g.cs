#pragma checksum "D:\MvcProject\WebEvento\WebEvento\WebEvento\Views\Edit\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53ccb8f09e97e966f84f12d0ebaba1b239c579d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Edit_Index), @"mvc.1.0.view", @"/Views/Edit/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Edit/Index.cshtml", typeof(AspNetCore.Views_Edit_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53ccb8f09e97e966f84f12d0ebaba1b239c579d6", @"/Views/Edit/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ef6ad91415ccde4286eb92868bf285fd165d6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Edit_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\MvcProject\WebEvento\WebEvento\WebEvento\Views\Edit\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(90, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\MvcProject\WebEvento\WebEvento\WebEvento\Views\Edit\Index.cshtml"
 if (ViewBag.Message != null)
{

#line default
#line hidden
            BeginContext(126, 105, true);
            WriteLiteral("    <script type=\"text/javascript\">\r\n          //  window.onload = function () {\r\n                alert(\"");
            EndContext();
            BeginContext(232, 15, false);
#line 11 "D:\MvcProject\WebEvento\WebEvento\WebEvento\Views\Edit\Index.cshtml"
                  Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(247, 38, true);
            WriteLiteral("\");\r\n          //  };\r\n    </script>\r\n");
            EndContext();
#line 14 "D:\MvcProject\WebEvento\WebEvento\WebEvento\Views\Edit\Index.cshtml"
}

#line default
#line hidden
            BeginContext(288, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591