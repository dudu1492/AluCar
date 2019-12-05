using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace AluCar.Controllers
{
    public class VeiculoController : Controller
    { 
        private readonly VeiculoDAO _veiculoDAO;
        private readonly MarcaDAO _marcaDAO;
        private readonly IHostingEnvironment _hosting;

        public VeiculoController(VeiculoDAO veiculoDAO,
            MarcaDAO marcaDAO, IHostingEnvironment hosting)
        {
            _veiculoDAO = veiculoDAO;
            _marcaDAO = marcaDAO;
            _hosting = hosting;
        }
        
        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_veiculoDAO.ListarTodos());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Marcas = new SelectList
                (_marcaDAO.ListarTodos(), "MarcaId",
                "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Veiculo v, int drpMarcas,
            IFormFile fupImagem)
        {
            ViewBag.Marcas = new SelectList
                (_marcaDAO.ListarTodos(), "MarcaId",
                "Nome");

            if (ModelState.IsValid)
            {
                if (fupImagem != null)
                {
                    string arquivo = Guid.NewGuid().ToString() +
                        Path.GetExtension(fupImagem.FileName);
                    string caminho = Path.Combine(_hosting.WebRootPath,
                        "alucarimagens", arquivo);
                    fupImagem.CopyTo(
                        new FileStream(caminho, FileMode.Create));
                    v.Imagem = arquivo;
                }
                else
                {
                    v.Imagem = "semimagem.jpg";
                }

                v.Marca =_marcaDAO.BuscarPorId(drpMarcas);

                if (_veiculoDAO.Cadastrar(v))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError
                    ("", "Esse veiculo já existe!!!");
                return View(v);
            }
            return View(v);
        }

        public IActionResult Remover(int? id)
        {
            if (id != null)
            {
                _veiculoDAO.RemoverVeiculo(id);
            }
            else
            {
            }
            return RedirectToAction("Index");
        }
        public IActionResult Alterar(int? id)
        {
            ViewBag.Marcas = new SelectList
                (_marcaDAO.ListarTodos(), "MarcaId",
                "Nome");
            return View(_veiculoDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Veiculo v)
        {
            return RedirectToAction("Index");
        }
    }
}