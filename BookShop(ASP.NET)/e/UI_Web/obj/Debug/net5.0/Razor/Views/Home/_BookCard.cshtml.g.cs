#pragma checksum "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44d7afdbc365f23032dbcf1f275e3ed3313f38c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__BookCard), @"mvc.1.0.view", @"/Views/Home/_BookCard.cshtml")]
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
#line 1 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\_ViewImports.cshtml"
using UI_Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\_ViewImports.cshtml"
using UI_Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
using Services.Abstractions.Dto.StoreBook;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44d7afdbc365f23032dbcf1f275e3ed3313f38c8", @"/Views/Home/_BookCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2de302e4f241fbaefd2a4d3a1c1de703c2ba5a29", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__BookCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StoreBookDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/home/addToCart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\" style=\"width: 28rem; margin: 15px; background-color: #FEF5ED;\">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-text\">Назва: ");
#nullable restore
#line 7 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                    Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h6 class=\"card-text\">Автор(-и): ");
#nullable restore
#line 8 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                        Write(Model.Authors);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Ціна: ");
#nullable restore
#line 9 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                   Write(Model.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Кількість екземплярів в магазині: ");
#nullable restore
#line 10 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                                               Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Жанр: ");
#nullable restore
#line 11 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                   Write(Model.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Видавництво: ");
#nullable restore
#line 12 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                          Write(Model.PublishOffice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Рік видання: ");
#nullable restore
#line 13 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                          Write(Model.PublishYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44d7afdbc365f23032dbcf1f275e3ed3313f38c86891", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 806, "\"", 823, 1);
#nullable restore
#line 15 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
WriteAttributeValue("", 814, Model.Id, 814, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <button class=\"btn btn-success\">Додати до кошика</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 20 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\" style=\"width: 28rem; margin: 15px; background-color: #FEF5ED;\">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-text\">Назва: ");
#nullable restore
#line 25 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                    Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h6 class=\"card-text\">Автор(-и): ");
#nullable restore
#line 26 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                        Write(Model.Authors);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Ціна: ");
#nullable restore
#line 27 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                   Write(Model.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Кількість екземплярів в магазині: ");
#nullable restore
#line 28 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                                               Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Жанр: ");
#nullable restore
#line 29 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                   Write(Model.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Видавництво: ");
#nullable restore
#line 30 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                          Write(Model.PublishOffice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Рік видання: ");
#nullable restore
#line 31 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
                                          Write(Model.PublishYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 34 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Home\_BookCard.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StoreBookDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
