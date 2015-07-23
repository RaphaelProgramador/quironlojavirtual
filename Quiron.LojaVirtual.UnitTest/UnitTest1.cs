using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Web.Models;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.HtmlHelpers;


namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestQuiron
    {
        [TestMethod]
        public void Pode_Gerar_Paginacao_Test()
        {
            //Arrange
            HtmlHelper html = null;
            
            Paginacao paginacao = new Paginacao()
            {
                PaginaAtual = 2,
                ItensTotal = 28,
                ItensPorPagina = 10
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act
            MvcHtmlString result = html.PageLinks(paginacao, paginaUrl);

            //Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                            + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", result.ToString());

        }
    }
}
