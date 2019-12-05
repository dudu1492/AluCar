using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ClienteDAO : IRepository<Cliente>
    {
        private readonly Context ctx;
        public ClienteDAO(Context context)
        {
            ctx = context;
        }

        public bool Cadastrar(Cliente c)
        {
            if (BuscarPorEmail(c) == null)
            {
                ctx.Clientes.Add(c);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        internal IEnumerable<Cliente> BuscarClientesPorParteDoNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarClientePorNome(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault(ClienteCadastrado => ClienteCadastrado.Nome.Equals(c.Nome));
        }

        public List<Cliente> BuscarClientesPorParteDoNome(Cliente c)
        {
            return ctx.Clientes.Where(x => x.Nome.Contains(c.Nome)).ToList();
        }

        public Cliente BuscarPorEmail(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault
                (x => x.Email.Equals(c.Email));
        }

        public bool RemoverCliente(Cliente c)
        {
            ctx.Clientes.Remove(c);
            ctx.SaveChanges();
            if (c == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool AlterarCliente(Cliente c)
        {
            ctx.Clientes.Update(c);
            ctx.SaveChanges();
            if (c == null)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        public List<Cliente> ListarClientes()
        {
            return ctx.Clientes.ToList();
        }

        public Cliente BuscarClientePorId(int id)
        {
            return ctx.Clientes.Find(id);
        }

        public List<Cliente> ListarTodos()
        {
            return ctx.Clientes.ToList();
        }

        public Cliente BuscarPorId(int? id)
        {
            return ctx.Clientes.Find(id);
        }
    }
}
