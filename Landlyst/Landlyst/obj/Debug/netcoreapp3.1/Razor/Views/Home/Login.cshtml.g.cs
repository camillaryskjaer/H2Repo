#pragma checksum "C:\Users\MartinRiehnMadsen\source\repos\H2Repo\Landlyst\Landlyst\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f1c5a566def44871a2dc87a770b3ed7137f219a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Login), @"mvc.1.0.view", @"/Views/Home/Login.cshtml")]
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
#line 1 "C:\Users\MartinRiehnMadsen\source\repos\H2Repo\Landlyst\Landlyst\Views\_ViewImports.cshtml"
using Landlyst;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MartinRiehnMadsen\source\repos\H2Repo\Landlyst\Landlyst\Views\_ViewImports.cshtml"
using Landlyst.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f1c5a566def44871a2dc87a770b3ed7137f219a", @"/Views/Home/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f687e61126f0c76e370010e7c68d53cda143edc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Landlyst.DataHandling.DataModel.Login>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\MartinRiehnMadsen\source\repos\H2Repo\Landlyst\Landlyst\Views\Home\Login.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"text-align:center\">\r\n    <h1>\r\n        Login\r\n    </h1>\r\n    <br />\r\n    <br />\r\n\r\n    <div>\r\n");
#nullable restore
#line 14 "C:\Users\MartinRiehnMadsen\source\repos\H2Repo\Landlyst\Landlyst\Views\Home\Login.cshtml"
         using (Html.BeginForm("Login", "Home"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h4>Initialer</h4>\r\n");
#nullable restore
#line 17 "C:\Users\MartinRiehnMadsen\source\repos\H2Repo\Landlyst\Landlyst\Views\Home\Login.cshtml"
       Write(Html.TextBoxFor(m => m.Initials));

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\MartinRiehnMadsen\source\repos\H2Repo\Landlyst\Landlyst\Views\Home\Login.cshtml"
                                             ;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br />\r\n            <h4>Password</h4>\r\n");
#nullable restore
#line 20 "C:\Users\MartinRiehnMadsen\source\repos\H2Repo\Landlyst\Landlyst\Views\Home\Login.cshtml"
       Write(Html.PasswordFor(m => m.Password));

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\MartinRiehnMadsen\source\repos\H2Repo\Landlyst\Landlyst\Views\Home\Login.cshtml"
                                              ;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br />\r\n            <br />\r\n            <button type=\"submit\" id=\"SubmitBtn\">\r\n                Login\r\n            </button>\r\n");
#nullable restore
#line 26 "C:\Users\MartinRiehnMadsen\source\repos\H2Repo\Landlyst\Landlyst\Views\Home\Login.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Landlyst.DataHandling.DataModel.Login> Html { get; private set; }
    }
}
#pragma warning restore 1591
