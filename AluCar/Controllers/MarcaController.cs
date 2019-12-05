using System;
using System.Collections.Generic;
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
    public class MarcaController : Controller
    {
        private readonly MarcaDAO _marcaDAO;
        private readonly IHostingEnvironment _hosting;

        public MarcaController(MarcaDAO marcaDAO, IHostingEnvironment hosting)
        {
            _marcaDAO = marcaDAO;
            _hosting = hosting;
        }
        
        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_marcaDAO.ListarTodos());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Marca m)
        {
            if (_marcaDAO.Cadastrar(m))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError
                ("", "Essa marca já existe!!!");
            return View(m);
        }

        public IActionResult Remover(int? id)
        {
            if (id != null)
            {
                _marcaDAO.RemoverMarca(id);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Alterar(int? id)
        {
            return View(_marcaDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Marca m)
        {
            return RedirectToAction("Index");
        }
    }
}