#pragma checksum "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6972d37acc31e348f85b073dcaf225932e8cc186"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_DetailsOrder), @"mvc.1.0.view", @"/Views/Admin/DetailsOrder.cshtml")]
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
#line 1 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
using Services.Abstractions.Dto.Order;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
using UI_Web.Models.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
using Domain.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6972d37acc31e348f85b073dcaf225932e8cc186", @"/Views/Admin/DetailsOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2de302e4f241fbaefd2a4d3a1c1de703c2ba5a29", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_DetailsOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/admin/deleteOrder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin: 5px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/admin/editOrder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/admin/addToArchive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 7 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
  var user = await userManager.FindByIdAsync(Model.MyUserId.ToString());
    ViewData["Title"] = "Адмін - деталі замовлення";

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    body {\r\n        background-color: #D3E4CD;\r\n    }\r\n</style>\r\n");
#nullable restore
#line 14 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
 if (Model.IsCompleted == true)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\" style=\"width: 28rem; margin: 15px; background-color: #FEF5ED;\">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-text\">Ім\'я\': ");
#nullable restore
#line 18 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                    Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h5 class=\"card-text\">Прізвище: ");
#nullable restore
#line 19 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                       Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h5 class=\"card-text\">Номер телефону: ");
#nullable restore
#line 20 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                             Write(user.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h5 class=\"card-text\">Електронна адреса: ");
#nullable restore
#line 21 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                                Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h6 class=\"card-text\">Сума: ");
#nullable restore
#line 22 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                   Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Виконано: ");
#nullable restore
#line 23 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                       Write(Model.IsCompleted);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Дата оформлення замовлення: ");
#nullable restore
#line 24 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                                         Write(Model.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Адреса: ");
#nullable restore
#line 25 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                     Write(Model.Adress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Місто: ");
#nullable restore
#line 26 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                    Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-text\">Поштовий індекс: ");
#nullable restore
#line 27 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                              Write(Model.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <div style=\"display: flex; justify-content: center;\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6972d37acc31e348f85b073dcaf225932e8cc18610491", async() => {
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 1439, "\"", 1456, 1);
#nullable restore
#line 30 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
WriteAttributeValue("", 1447, Model.Id, 1447, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <button class=\"btn btn-success\">Видалити</button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 36 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
}
else{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card\" style=\"width: 28rem; margin: 15px; background-color: #FEF5ED;\">\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-text\">Ім\'я\': ");
#nullable restore
#line 40 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <h5 class=\"card-text\">Прізвище: ");
#nullable restore
#line 41 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                   Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <h5 class=\"card-text\">Номер телефону: ");
#nullable restore
#line 42 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                         Write(user.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <h5 class=\"card-text\">Електронна адреса: ");
#nullable restore
#line 43 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                            Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <h6 class=\"card-text\">Сума: ");
#nullable restore
#line 44 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                               Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        <h6 class=\"card-text\">Виконано: ");
#nullable restore
#line 45 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                   Write(Model.IsCompleted);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        <h6 class=\"card-text\">Дата оформлення замовлення: ");
#nullable restore
#line 46 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                                     Write(Model.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        <h6 class=\"card-text\">Адреса: ");
#nullable restore
#line 47 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                 Write(Model.Adress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        <h6 class=\"card-text\">Місто: ");
#nullable restore
#line 48 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        <h6 class=\"card-text\">Поштовий індекс: ");
#nullable restore
#line 49 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
                                          Write(Model.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        <div style=\"display: flex; justify-content: center;\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6972d37acc31e348f85b073dcaf225932e8cc18616467", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 2562, "\"", 2579, 1);
#nullable restore
#line 52 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
WriteAttributeValue("", 2570, Model.Id, 2570, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <button class=\"btn btn-success\">Видалити</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6972d37acc31e348f85b073dcaf225932e8cc18618617", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 2799, "\"", 2816, 1);
#nullable restore
#line 56 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
WriteAttributeValue("", 2807, Model.Id, 2807, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <button class=\"btn btn-success\">Редагувати</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6972d37acc31e348f85b073dcaf225932e8cc18620769", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 3042, "\"", 3059, 1);
#nullable restore
#line 60 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
WriteAttributeValue("", 3050, Model.Id, 3050, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <button class=\"btn btn-success\">Виконати</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 66 "C:\Users\Bohdan\OneDrive\Рабочий стол\Book_Land\BookShop(ASP.NET)\e\UI_Web\Views\Admin\DetailsOrder.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<MyUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
