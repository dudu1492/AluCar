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
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioDAO _funcionarioDAO;
        private readonly UserManager<UsuarioLogado>
            _userManager;
        private readonly SignInManager<UsuarioLogado>
            _signManager;

        public FuncionarioController(FuncionarioDAO funcionarioDAO,
            UserManager<UsuarioLogado> userManager,
            SignInManager<UsuarioLogado> signInManager)
        {
            _funcionarioDAO = funcionarioDAO;
            _userManager = userManager;
            _signManager = signInManager;
        }

        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_funcionarioDAO.ListarTodos());
        }

        public IActionResult Cadastrar()
        {
            Funcionario f = new Funcionario();
            if (TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco =
                    JsonConvert.DeserializeObject<Endereco>
                    (resultado);
                f.Endereco = endereco;
            }
            return View(f);
        }

        [HttpPost]
        public IActionResult BuscarCep(Funcionario f)
        {
            string url = "http://apps.widenet.com.br/busca-cep/api/cep/" +
                f.Endereco.code + ".json";
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);

            return RedirectToAction(nameof(Cadastrar));
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(Funcionario f)
        {
            if (ModelState.IsValid)
            {
                UsuarioLogado usuarioLogado = new UsuarioLogado
                {
                    Email = f.Email,
                    UserName = f.Email
                };
                IdentityResult result = await _userManager.
                    CreateAsync(usuarioLogado, f.Senha);

                if (result.Succeeded)
                {
                    await _signManager.SignInAsync(usuarioLogado,
                        isPersistent: false);
                    if (_funcionarioDAO.Cadastrar(f))
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Este e-mail já está sendo utilizado!");
                }
                AdicionarErros(result);
            }
            return View(f);
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
        public async Task<IActionResult> Login(Funcionario f)
        {
            var result = await _signManager.
                PasswordSignInAsync(f.Email,
                f.Senha, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Falha no login!");
            return View();
        }
    }
}