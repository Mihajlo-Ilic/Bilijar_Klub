#pragma checksum "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a710e81bcdaa6007e3b6b110deaa7e42cff74868"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Musterija_PregledLicnihTermina), @"mvc.1.0.view", @"/Views/Musterija/PregledLicnihTermina.cshtml")]
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
#line 1 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\_ViewImports.cshtml"
using Get_Projekat;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\_ViewImports.cshtml"
using Get_Projekat.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a710e81bcdaa6007e3b6b110deaa7e42cff74868", @"/Views/Musterija/PregledLicnihTermina.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ae37461f426cea88c032e95496baaecf1447d5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Musterija_PregledLicnihTermina : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Get_Projekat.Models.ViewModels.LicniTermini>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Musterija", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "brisiTermin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "izmeniTermin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/microsoft/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
  
        Layout = "_UserLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">



    <div class=""container2 "" style=""background:rgba(0,0,0,0.9);border-radius:10px"">
        <table id =""tabela"" class=""table text-white"">
              <thead>
                <tr>
                  <th scope=""col"">id_stola</th>
                  <th scope=""col"">sto</th>
                  <th scope=""col"">datum</th>
                  <th scope=""col"">od</th>
                  <th scope=""col"">do</th>
                </tr>
              </thead>
          <tbody>

");
#nullable restore
#line 26 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
               foreach (var item in Model)
              {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr");
            BeginWriteAttribute("id", " id=", 823, "", 841, 1);
#nullable restore
#line 28 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
WriteAttributeValue("", 827, item.TerminId, 827, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                      <td >");
#nullable restore
#line 29 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
                      Write(item.StoId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                      <td >");
#nullable restore
#line 30 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
                      Write(item.StoName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                      <td >");
#nullable restore
#line 31 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
                      Write(item.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                      <td >");
#nullable restore
#line 32 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
                      Write(item.Start);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                      <td >");
#nullable restore
#line 33 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
                      Write(item.End);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                      <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a710e81bcdaa6007e3b6b110deaa7e42cff748689284", async() => {
                WriteLiteral("-");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
                                                                                                                         WriteLiteral(item.TerminId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a710e81bcdaa6007e3b6b110deaa7e42cff7486811936", async() => {
                WriteLiteral("izmeni");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
                                                                                                                             WriteLiteral(item.TerminId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 37 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
              }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n          </tbody>\r\n        </table>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a710e81bcdaa6007e3b6b110deaa7e42cff7486814936", async() => {
                WriteLiteral("Nazad");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a710e81bcdaa6007e3b6b110deaa7e42cff7486816210", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>
    ""use strict"";


var connection = new signalR.HubConnectionBuilder().withUrl(""/Hub"").build();


connection.start();

connection.on(""NovTerminAdmin"", function (message) {

    console.log(message)


    var t = document.getElementById('tabela').getElementsByTagName('tbody')[0];
    var red = t.insertRow(0);
    red.id = message.terminId;

    var c0 = red.insertCell(0);
    c0.appendChild( document.createTextNode(message.stoId));

    var c1 = red.insertCell(1);
    c1.appendChild( document.createTextNode(message.stoName));

    var c2 = red.insertCell(2);
    c2.appendChild( document.createTextNode(message.date));

    var c3 = red.insertCell(3);
    c3.appendChild( document.createTextNode(message.start));

    var c4 = red.insertCell(4);
    c4.appendChild( document.createTextNode(message.end));

    var c8 = red.insertCell(5);

    var dugme = document.createElement(""a"");
    dugme.textContent = ""izmeni"";
    dugme.classList.add(""btn"");
    dugme.classLi");
            WriteLiteral("st.add(\"btn-warning\");\r\n\r\n    var p1 = \'");
#nullable restore
#line 92 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
         Write(Url.Action("izmeniTermin","Musterija"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    var p2 = message.terminId;\r\n    dugme.href = p1 + \'/\' + p2;\r\n\r\n\r\n    var dugme2 = document.createElement(\"a\");\r\n    dugme2.textContent = \"-\";\r\n    dugme2.classList.add(\"btn\");\r\n    dugme2.classList.add(\"btn-danger\");\r\n\r\n    var p11 = \'");
#nullable restore
#line 102 "C:\Users\Mihajlo\source\repos\Get_Projekat\Get_Projekat\Views\Musterija\PregledLicnihTermina.cshtml"
          Write(Url.Action("brisiTermin","Musterija"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    var p22 = message.terminId;
    dugme2.href = p11 + '/' + p22;
   

    
    c8.appendChild(dugme2);
    c8.appendChild(dugme);
});

connection.on(""IzmeniTerminAdmin"", function (message) {

    console.log(message)


    var t = document.getElementById('tabela').getElementsByTagName('tbody')[0];

    var red = document.getElementById(message.terminId);

    if(red != null){

        var c0 = red.cells[0];
        c0.innerHTML  = '';
        c0.appendChild( document.createTextNode(message.stoId));

        var c1 = red.cells[1];
        c1.innerHTML  = '';
        c1.appendChild( document.createTextNode(message.stoName));

        var c2 = red.cells[2];
        c2.innerHTML  = '';
        c2.appendChild( document.createTextNode(message.date));

        var c3 = red.cells[3];
        c3.innerHTML  = '';
        c3.appendChild( document.createTextNode(message.start));

        var c4 = red.cells[4];
        c4.innerHTML  = '';
        c4.appendChild( document.createT");
            WriteLiteral(@"extNode(message.end));


    }

 
});

connection.on(""IzbrisiTerminAdmin"", function (id) {

    console.log(id)


    var t = document.getElementById('tabela').getElementsByTagName('tbody')[0];

    var red = document.getElementById(id);

    if(red != null)
        red.remove();
   

 
});


</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Get_Projekat.Models.ViewModels.LicniTermini>> Html { get; private set; }
    }
}
#pragma warning restore 1591