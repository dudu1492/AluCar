#pragma checksum "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\Funcionario\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "225ed24f5cebe95083d98e30c0b7b300934236b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Funcionario_Index), @"mvc.1.0.view", @"/Views/Funcionario/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Funcionario/Index.cshtml", typeof(AspNetCore.Views_Funcionario_Index))]
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
#line 1 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\_ViewImports.cshtml"
using AluCar;

#line default
#line hidden
#line 2 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\_ViewImports.cshtml"
using Domain;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"225ed24f5cebe95083d98e30c0b7b300934236b7", @"/Views/Funcionario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55b7ea6d37d216f66defebf7d3578d93fd2becda", @"/Views/_ViewImports.cshtml")]
    public class Views_Funcionario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Funcionario>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cadastrar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 2 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\Funcionario\Index.cshtml"
  
    DateTime dataHora = ViewBag.DataHora;

#line default
#line hidden
            BeginContext(76, 42, true);
            WriteLiteral("\r\n<h2>Gerenciamento de Funcionários</h2>\r\n");
            EndContext();
            BeginContext(118, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b27cfcf237d848879a5dc6cb70898460", async() => {
                BeginContext(165, 21, true);
                WriteLiteral("Cadastrar Funcionário");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(190, 336, true);
            WriteLiteral(@"

<table style=""margin-bottom:15px;margin-top:15px""
       class=""table table-hover table-striped"">
    <thead>
        <tr class=""table-active"">
            <th>Nome</th>
            <th>E-mail</th>
            <th>Senha</th>
            <th>CPF</th>
            <th>Criado em</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 21 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\Funcionario\Index.cshtml"
         foreach (Funcionario item in Model)
        {

#line default
#line hidden
            BeginContext(583, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(614, 9, false);
#line 24 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\Funcionario\Index.cshtml"
           Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(623, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(647, 10, false);
#line 25 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\Funcionario\Index.cshtml"
           Write(item.Email);

#line default
#line hidden
            EndContext();
            BeginContext(657, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(681, 10, false);
#line 26 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\Funcionario\Index.cshtml"
           Write(item.Senha);

#line default
#line hidden
            EndContext();
            BeginContext(691, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(715, 8, false);
#line 27 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\Funcionario\Index.cshtml"
           Write(item.CPF);

#line default
#line hidden
            EndContext();
            BeginContext(723, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(747, 13, false);
#line 28 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\Funcionario\Index.cshtml"
           Write(item.CriadoEm);

#line default
#line hidden
            EndContext();
            BeginContext(760, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 30 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\Funcionario\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(793, 63, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<p>\r\n    <b>Dados atualizados em: </b> ");
            EndContext();
            BeginContext(857, 8, false);
#line 34 "C:\Users\Eduardo\source\repos\AluCar\AluCar\Views\Funcionario\Index.cshtml"
                             Write(dataHora);

#line default
#line hidden
            EndContext();
            BeginContext(865, 6, true);
            WriteLiteral("\r\n</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Funcionario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
