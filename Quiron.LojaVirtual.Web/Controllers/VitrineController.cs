using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio repositorio;
        private int produtosPorPagina = 3;
        
        // GET: Vitrine
        public ActionResult ListarProdutos(int pagina = 1)
        {
            repositorio = new ProdutosRepositorio();

            var produtos = repositorio.Produtos.Take(10).OrderBy(p => p.Nome).Skip((pagina - 1) * produtosPorPagina).Take(produtosPorPagina);

            return View(produtos);
        }
    }
}