using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class VeiculoDAO : IRepository<Veiculo>
    {
        private readonly Context ctx;
        public VeiculoDAO(Context context)
        {
            ctx = context;
        }

        public bool Cadastrar(Veiculo v)
        {
            if (BuscarVeiculoPorPlaca(v) == null)
            {
                ctx.Veiculos.Add(v);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        internal static IEnumerable<Veiculo> BuscarVeiculosPorParteDoNome(string nome)
        {
            throw new NotImplementedException();
        }


        public Veiculo BuscarVeiculoPorPlaca(Veiculo v)
        {
            return ctx.Veiculos.FirstOrDefault(VeiculoCadastrado => VeiculoCadastrado.Placa.Equals(v.Placa));
        }

        public Veiculo BuscarVeiculoPorPlaca(string PlacaVeiculo)
        {
            return ctx.Veiculos.FirstOrDefault(VeiculoCadastrado => VeiculoCadastrado.Placa.Equals(PlacaVeiculo));
        }

        public Veiculo BuscarVeiculoPorNome(Veiculo v)
        {
            return ctx.Veiculos.FirstOrDefault(VeiculoCadastrado => VeiculoCadastrado.Nome.Equals(v.Nome));
        }

        public List<Veiculo> BuscarVeiculosPorParteDoNome(Veiculo v)
        {
            return ctx.Veiculos.Include("Marca").Where(x => x.Nome.Contains(v.Nome)).ToList();
        }

        public List<Veiculo> BuscarTodosVeiculos()
        {
            return ctx.Veiculos.Include("Marca").ToList();
        }

        public List<Veiculo> BuscarTodosVeiculosLivres(bool a)
        {
            return ctx.Veiculos.Include("Marca").Where(x => x.Alugado.Equals(a) && x.Manutencao.Equals(false)).ToList();
        }

        public List<Veiculo> BuscarTodosVeiculosRodados(bool a)
        {
            return ctx.Veiculos.Include("Marca").Where(x => x.Manutencao.Equals(a) && x.Alugado.Equals(false)).ToList();
        }

        public List<Veiculo> BuscarVeiculosLivresPorMarca(string m)
        {
            return ctx.Veiculos.Include("Marca").Where(x => x.Marca.Nome.Contains(m) && x.Alugado.Equals(false) && x.Manutencao.Equals(false)).ToList();
        }

        public List<Veiculo> BuscarVeiculosPorMarcaRodados(string m, bool a)
        {
            return ctx.Veiculos.Include("Marca").Where(x => x.Marca.Nome.Contains(m) && x.Manutencao.Equals(a) && x.Alugado.Equals(false)).ToList();
        }

        public List<Veiculo> BuscarVeiculosPorMarca(string m)
        {
            return ctx.Veiculos.Include("Marca").Where(x => x.Marca.Nome.Contains(m)).ToList();
        }

        public List<Veiculo> BuscarVeiculosPorMarca(int? id)
        {
            return ctx.Veiculos.Include(x => x.Marca).Where(x => x.Marca.MarcaId == id).ToList();
        }

        public bool RemoverVeiculo(Veiculo v)
        {
            ctx.Veiculos.Remove(v);
            ctx.SaveChanges();
            if (v == null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool RemoverVeiculo(int? id)
        {
            ctx.Veiculos.Remove(BuscarPorId(id));
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

        public bool AlterarVeiculo(Veiculo v)
        {
            if(v.ProxManut < v.Quilometragem)
            {
                v.Manutencao = true;
            }
            ctx.Veiculos.Update(v);
            ctx.SaveChanges();
            if(v == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
            
        }

        public List<Veiculo> ListarVeiculos()
        {
            return ctx.Veiculos.ToList();
        }

        public Veiculo BuscarVeiculoPorId(int id)
        {
            return ctx.Veiculos.Find(id);
        }

        public List<Veiculo> ListarTodos()
        {
            return ctx.Veiculos.ToList();
        }

        public Veiculo BuscarPorId(int? id)
        {
            return ctx.Veiculos.Find(id);
        }
    }
}
