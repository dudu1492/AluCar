using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/Veiculo")]
    [ApiController]
    public class VeiculoAPIController : ControllerBase
    {
      
        private readonly VeiculoDAO _veiculoDAO;
        public VeiculoAPIController(VeiculoDAO veiculoDAO)
        {
            _veiculoDAO = veiculoDAO;
        }

        
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_veiculoDAO.ListarTodos());
        }
        
        [HttpGet]
        [Route("BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Veiculo v = _veiculoDAO.BuscarPorId(id);
            if (v != null)
            {
                return Ok(v);
            }
            return NotFound(new { msg = "Veiculo não encontrado!" });
        }

        
        [HttpGet]
        [Route("BuscarPorMarca/{id}")]
        public IActionResult BuscarPorCategoria([FromRoute] int id)
        {
            List<Veiculo> veiculos =
                _veiculoDAO.BuscarVeiculosPorMarca(id);
            if (veiculos.Count > 0)
            {
                return Ok(veiculos);
            }
            return NotFound(new { msg = "Essa busca não encontrou nenhum resultado!" });
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody]Veiculo v)
        {
            if (ModelState.IsValid)
            {
                if (_veiculoDAO.Cadastrar(v))
                {
                    return Created("", v);
                }
                return Conflict(new { msg = "Esse veiculo já existe!" });
            }
            return BadRequest(ModelState);
        }
    }
}