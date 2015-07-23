using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
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
        private int produtosPorPagina = 8;
        
        // GET: Vitrine
        public ActionResult ListarProdutos(int pagina = 1)
        {
            repositorio = new ProdutosRepositorio();            

            ProdutosViewModel model = new ProdutosViewModel()
            {
                Produtos = repositorio.Produtos.OrderBy(p => p.Descricao).Skip((pagina - 1) * produtosPorPagina).Take(produtosPorPagina),
                
                Paginacao = new Paginacao()
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = produtosPorPagina,
                    ItensTotal = repositorio.Produtos.Count()
                }                
            };            

            return View(model);
        }

    }
}