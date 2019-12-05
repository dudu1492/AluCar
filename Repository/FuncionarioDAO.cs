using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class FuncionarioDAO : IRepository<Funcionario>
    {
        private readonly Context ctx;
        public FuncionarioDAO(Context context)
        {
            ctx = context;
        }

        public bool Cadastrar(Funcionario f)
        {
            if (BuscarPorEmail(f) == null)
            {
                ctx.Funcionarios.Add(f);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Funcionario BuscarPorEmail(Funcionario f)
        {
            return ctx.Funcionarios.FirstOrDefault
                (x => x.Email.Equals(f.Email));
        }

        internal IEnumerable<Funcionario> BuscarFuncionariosPorParteDoNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Funcionario BuscarFuncionarioPorNome(Funcionario f)
        {
            return ctx.Funcionarios.FirstOrDefault(FuncionarioCadastrado => FuncionarioCadastrado.Nome.Equals(f.Nome));
        }

        public List<Funcionario> BuscarFuncionariosPorParteDoNome(Funcionario f)
        {
            return ctx.Funcionarios.Where(x => x.Nome.Contains(f.Nome)).ToList();
        }


        public bool RemoverFuncionario(Funcionario f)
        {
            ctx.Funcionarios.Remove(f);
            ctx.SaveChanges();
            if (f == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool AlterarFuncionario(Funcionario f)
        {
            ctx.Funcionarios.Update(f);
            ctx.SaveChanges();
            if (f == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Funcionario> ListarFuncionario()
        {
            return ctx.Funcionarios.ToList();
        }

        public Funcionario BuscarFuncionarioPorId(int id)
        {
            return ctx.Funcionarios.Find(id);
        }

        public List<Funcionario> ListarTodos()
        {
            return ctx.Funcionarios.ToList();
        }

        public Funcionario BuscarPorId(int? id)
        {
            return ctx.Funcionarios.Find(id);
        }
    }
}
