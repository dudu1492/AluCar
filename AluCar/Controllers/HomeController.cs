using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using AluCar.Utils;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace AluCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly VeiculoDAO _veiculoDAO;
        private readonly MarcaDAO _marcaDAO;
        private readonly ItemVendaDAO _itemVendaDAO;
        private readonly UtilsSession _utilsSession;

        public HomeController(VeiculoDAO veiculoDAO,
            MarcaDAO marcaDAO, ItemVendaDAO itemVendaDAO,
            UtilsSession utilsSession)
        {
            _veiculoDAO = veiculoDAO;
            _marcaDAO = marcaDAO;
            _itemVendaDAO = itemVendaDAO;
            _utilsSession = utilsSession;
        }
        public IActionResult Index(int? id)
        {
            ViewBag.Marcas = _marcaDAO.ListarTodos();
            if (id == null)
            {
                return View(_veiculoDAO.ListarTodos());
            }
            return View(_veiculoDAO.BuscarVeiculosPorMarca(id));
        }
        public IActionResult Detalhes(int id)
        {
            return View(_veiculoDAO.BuscarPorId(id));
        }
        public IActionResult AdicionarAoAlugar(int id)
        {
            Veiculo v = _veiculoDAO.BuscarPorId(id);
            ItemVenda i = new ItemVenda
            {
                Veiculo = v,
                Quantidade = 1,
                Preco = v.Valor.Value,
                CarrinhoId = _utilsSession.RetonarCarrinhoId()
            };
            //Gravar o objeto na tabela
            _itemVendaDAO.Cadastrar(i);
            return RedirectToAction("Alugar");
        }
        public IActionResult RemoverDoAluguel(int id)
        {
            _itemVendaDAO.Remover(id);
            return RedirectToAction("Alugar");
        }
        public IActionResult Aluguel()
        {
            ViewBag.TotalCarrinho = _itemVendaDAO.
                RetornarTotalCarrinho(_utilsSession.RetonarCarrinhoId());

            return View(_itemVendaDAO.
                ListarItensPorCarrinhoId
                (_utilsSession.RetonarCarrinhoId()));
        }
        public IActionResult AumentarQuantidade(int id)
        {
            _itemVendaDAO.AumentarQuantidade(id);
            return RedirectToAction("Alugar");
        }
        public IActionResult DiminuirQuantidade(int id)
        {
            _itemVendaDAO.DiminuirQuantidade(id);
            return RedirectToAction("Alugar");
        }
    }
}