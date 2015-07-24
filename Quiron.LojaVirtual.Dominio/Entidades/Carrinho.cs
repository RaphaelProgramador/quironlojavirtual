using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{    
    public class Carrinho
    {
        private readonly List<ItemCarrinho> itens = new List<ItemCarrinho>();

        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = itens.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item != null)            
                item.Quantidade += quantidade;            
            else            
                itens.Add(new ItemCarrinho() { Produto = produto, Quantidade = quantidade });            
        }

        public void RemoverItem(Produto produto)
        {
            itens.RemoveAll(p => p.Produto.ProdutoId == produto.ProdutoId);
        }

        public decimal ObterValorTotal()
        {
            return itens.Sum(i => i.Produto.Preco * i.Quantidade);
        }

        public void LimparCarrinho()
        {
            itens.Clear();
        }

        public IEnumerable<ItemCarrinho> ItensCarrinho 
        {
            get { return itens; }
        }

    }
}
