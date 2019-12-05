using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;

namespace AluCar.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDAO _clienteDAO;
        private readonly UserManager<UsuarioLogado>
            _userManager;
        private readonly SignInManager<UsuarioLogado>
            _signManager;

        public ClienteController(ClienteDAO clienteDAO,
            UserManager<UsuarioLogado> userManager,
            SignInManager<UsuarioLogado> signInManager)
        {
            _clienteDAO = clienteDAO;
            _userManager = userManager;
            _signManager = signInManager;
        }

        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_clienteDAO.ListarTodos());
        }

        public IActionResult Cadastrar()
        {
            Cliente c = new Cliente();
            if (TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco =
                    JsonConvert.DeserializeObject<Endereco>
                    (resultado);
                c.Endereco = endereco;
            }
            return View(c);
        }

        [HttpPost]
        public IActionResult BuscarCep(Cliente c)
        {
            string url = "http://apps.widenet.com.br/busca-cep/api/cep/" +
                c.Endereco.code + ".json";
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);

            return RedirectToAction(nameof(Cadastrar));
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(Cliente c)
        {
            if (ModelState.IsValid)
            {
                UsuarioLogado usuarioLogado = new UsuarioLogado
                {
                    Email = c.Email,
                    UserName = c.Email
                };
                IdentityResult result = await _userManager.
                    CreateAsync(usuarioLogado, c.Senha);

                if (result.Succeeded)
                {
                    await _signManager.SignInAsync(usuarioLogado,
                        isPersistent: false);
                    if (_clienteDAO.Cadastrar(c))
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Este e-mail já está sendo utilizado!");
                }
                AdicionarErros(result);
            }
            return View(c);
        }

        private void AdicionarErros(IdentityResult result)
        {
            foreach (var erro in result.Errors)
            {
                ModelState.AddModelError
                    ("", erro.Description);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Cliente c)
        {
            var result = await _signManager.
                PasswordSignInAsync(c.Email,
                c.Senha, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Falha no login!");
            return View();
        }
    }
}