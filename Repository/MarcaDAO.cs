using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class MarcaDAO : IRepository<Marca>
    {
        private readonly Context ctx;
        public MarcaDAO(Context context)
        {
            ctx = context;
        }

        public bool Cadastrar(Marca m)
        {
            if (BuscarMarcaPorNome(m) == null)
            {
                if (m.Nome != null || m.Detalhes != null)
                { 
                ctx.Marcas.Add(m);
                ctx.SaveChanges();
                return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        internal IEnumerable<Marca> BuscarMarcaPorParteDoNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Marca BuscarMarcaPorNome(Marca m)
        {
            return ctx.Marcas.FirstOrDefault(MarcaCadastrada => MarcaCadastrada.Nome.Equals(m.Nome));
        }

        public List<Marca> BuscarMarcasPorParteDoNome(Marca m)
        {
            return ctx.Marcas.Where(x => x.Nome.Contains(m.Nome)).ToList();
        }

        public bool RemoverMarca(Marca m)
        {
            ctx.Marcas.Remove(m);
            ctx.SaveChanges();
            if (m == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoverMarca(int? id)
        {
            ctx.Marcas.Remove(BuscarPorId(id));
            ctx.SaveChanges();
            if (id == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool AlterarMarca(Marca m)
        {
            ctx.Marcas.Update(m);
            ctx.SaveChanges();
            if (m == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Marca> BuscarTodasMarcas()
        {
            return ctx.Marcas.ToList();
        }

        public List<Marca> ListarMarcas() => ctx.Marcas.ToList();

        public Marca BuscarMarcaPorId(int id)
        {
            return ctx.Marcas.Find(id);
        }

        public List<Marca> ListarTodos()
        {
            return ctx.Marcas.ToList();
        }

        public Marca BuscarPorId(int? id)
        {
            return ctx.Marcas.Find(id);
        }
    }
}
