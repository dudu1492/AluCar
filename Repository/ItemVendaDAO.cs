using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ItemVendaDAO : IRepository<ItemVenda>
    {
        private readonly Context ctx;
        public ItemVendaDAO(Context context)
        {
            ctx = context;
        }
        public ItemVenda BuscarPorId(int? id)
        {
            return ctx.ItensVenda.Find(id);
        }
        public bool Cadastrar(ItemVenda i)
        {
            ItemVenda itemAux = ctx.ItensVenda.
                FirstOrDefault(x => x.Veiculo.VeiculoId == i.Veiculo.VeiculoId &&
                x.CarrinhoId.Equals(i.CarrinhoId));
            if (itemAux == null)
            {
                ctx.ItensVenda.Add(i);
            }
            else
            {
                itemAux.Quantidade++;
            }
            ctx.SaveChanges();
            return true;
        }
        public List<ItemVenda> ListarTodos()
        {
            return ctx.ItensVenda.ToList();
        }
        public List<ItemVenda> ListarItensPorCarrinhoId(string carrinhoId)
        {
            return ctx.ItensVenda.
                Include(x => x.Veiculo.Marca).
                Where(x => x.CarrinhoId.Equals(carrinhoId)).
                ToList();
        }

        public double RetornarTotalCarrinho(string carrinhoId)
        {
            return ctx.ItensVenda.
                Where(x => x.CarrinhoId.Equals(carrinhoId)).
                Sum(x => x.Quantidade * x.Preco);
        }

        public void Remover(int id)
        {
            ctx.ItensVenda.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }
        public void Alterar(ItemVenda i)
        {
            ctx.ItensVenda.Update(i);
            ctx.SaveChanges();
        }

        public void AumentarQuantidade(int id)
        {
            ItemVenda i = BuscarPorId(id);
            i.Quantidade++;
            Alterar(i);
        }

        public void DiminuirQuantidade(int id)
        {
            ItemVenda i = BuscarPorId(id);
            if (i.Quantidade > 1)
            {
                i.Quantidade--;
                Alterar(i);
            }
        }
    }
}
