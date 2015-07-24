using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class CarrinhoTest
    {
        [TestMethod]
        public void PodeAdicionarItensNoCarrinho()
        {
            //Arrange            
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Descricao = "Bola de Futebol",
                Categoria = "Futebol"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Descricao = "Bola de Basquete",
                Categoria = "Basquete"
            };

            Carrinho carrinho = new Carrinho();

            

            //Act
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
            Assert.AreEqual(itens[0].Quantidade, 2);
            Assert.AreEqual(itens[1].Quantidade, 3);


            
        }

        [TestMethod]
        public void PodeAdicionarProdutoExistenteNoCarrinho()
        {
            //Arrange            
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Descricao = "Bola de Futebol",
                Categoria = "Futebol"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Descricao = "Bola de Basquete",
                Categoria = "Basquete"
            };

            Carrinho carrinho = new Carrinho();

            //Act
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);
            ItemCarrinho[] itens = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }

        [TestMethod]
        public void PodeRemoverItensDoCarrinho()
        {
            //Arrange            
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Descricao = "Bola de Futebol",
                Categoria = "Futebol"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Descricao = "Bola de Basquete",
                Categoria = "Basquete"
            };

            Carrinho carrinho = new Carrinho();

            //Act
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);
            int qtdItensAntesRemover = carrinho.ItensCarrinho.Count();

            carrinho.RemoverItem(produto1);

            int qtdItensDepoisRemover = carrinho.ItensCarrinho.Count();

            //Assert
            Assert.AreEqual(qtdItensAntesRemover, 2);
            Assert.AreEqual(qtdItensDepoisRemover, 1);


            
        }

        [TestMethod]
        public void PodeCalcularValorTotal()
        {
            //Arrange            
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Descricao = "Bola de Futebol",
                Categoria = "Futebol",
                Preco = 50
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Descricao = "Bola de Basquete",
                Categoria = "Basquete",
                Preco = 100
            };

            Carrinho carrinho = new Carrinho();

            //Act
            carrinho.AdicionarItem(produto1, 3);
            carrinho.AdicionarItem(produto2, 2);          

            //Assert
            Assert.AreEqual(carrinho.ObterValorTotal(), 350);
        }

        [TestMethod]
        public void PodeLimparItensDoCarrinho()
        {
            //Arrange            
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Descricao = "Bola de Futebol",
                Categoria = "Futebol",
                Preco = 50
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Descricao = "Bola de Basquete",
                Categoria = "Basquete",
                Preco = 100
            };

            Carrinho carrinho = new Carrinho();

            //Act
            carrinho.AdicionarItem(produto1, 3);
            carrinho.AdicionarItem(produto2, 2);

            int qtdAntesLimpar = carrinho.ItensCarrinho.Count();

            carrinho.LimparCarrinho();

            int qtdDepoisLimpar = carrinho.ItensCarrinho.Count();

            //Assert
            Assert.AreEqual(qtdAntesLimpar, 2);
            Assert.AreEqual(qtdDepoisLimpar, 0);
        }

    }
}
