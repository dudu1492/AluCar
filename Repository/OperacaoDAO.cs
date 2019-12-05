using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class OperacaoDAO : IRepository<Operacao>
    {
        private readonly Context ctx;
        public OperacaoDAO(Context context)
        {
            ctx = context;
        }

        public bool CadastrarOperacao(Operacao o)
        {
            if (o != null)
            {
                ctx.Operacoes.Add(o);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Operacao BuscarOperacaoPorId(Operacao o)
        {
            return ctx.Operacoes.FirstOrDefault(OperacaoCadastrada => OperacaoCadastrada.OperacaoId.Equals(o.OperacaoId));
        }

        public List<Operacao> BuscarTodasOperacoes()
        {
            return ctx.Operacoes.Include(x => x.Cliente).Include(x => x.Funcionario).Include(x => x.Veiculo).ToList(); 
        }

        public List<Operacao> BuscarOperacoesPorCliente(string NomeCliente)
        {
            return ctx.Operacoes.Include("Cliente").Where(x => x.Cliente.Nome.Contains(NomeCliente)).ToList();
        }

        public List<Operacao> BuscarOperacoesPorClienteEmAberto(string NomeCliente)
        {
            return ctx.Operacoes.Include("Cliente").Where(x => x.Cliente.Nome.Contains(NomeCliente) && x.Finalizado.Equals(false)).ToList();
        }

        public List<Operacao> BuscarOperacoesEmAberto(bool a)
        {
            return ctx.Operacoes.Include(x => x.Cliente).Include(x => x.Funcionario).Include(x => x.Veiculo).Where(x => x.Finalizado.Equals(a)).ToList();
        }

        public bool AlterarOperacoes(Operacao o)
        {
            ctx.Operacoes.Update(o);
            ctx.SaveChanges();
            if (o == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
            
        }

        public List<Operacao> ListarOperacoes()
        {
            return ctx.Operacoes.ToList();
        }

        public Operacao BuscarOperacaoPorId(int id)
        {
            return ctx.Operacoes.Find(id);
        }

        public bool Cadastrar(Operacao objeto)
        {
            throw new NotImplementedException();
        }

        public List<Operacao> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Operacao BuscarPorId(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
