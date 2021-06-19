using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiBanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgenciaController : ControllerBase
    {
        private readonly IAgenciaRepositorio _agenciaRepositorio;
        public AgenciaController(IAgenciaRepositorio agenciaRepositorio)
        {
            _agenciaRepositorio = agenciaRepositorio;
        }

        [Route("{id?}"), HttpGet]
        public async Task<IActionResult> Obter([FromRoute] int id = 0)
        {
            if (id != 0)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var contato = _agenciaRepositorio.ObterPorId(id);
                if (contato == null) return NotFound();
                return Ok(contato);
            }
            else
            {
                try
                {
                    return Ok(_agenciaRepositorio.ObterTodos());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Agencia agencia)
        {
            if (!ModelState.IsValid) return BadRequest();
            _agenciaRepositorio.Adicionar(agencia);
            return Ok(agencia);
        }

        [Route("{id}"), HttpPut]
        public async Task<IActionResult> Alterar([FromRoute] int id, [FromBody] Agencia agencia)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != agencia.Id) BadRequest("Os ids são diferentes");
            _agenciaRepositorio.Atualizar(agencia);
            return Ok(agencia);
        }

        [Route("{id}"), HttpDelete]
        public async Task<IActionResult> Remover([FromBody] Agencia agencia)
        {
            if (!ModelState.IsValid) return BadRequest();
            _agenciaRepositorio.Remover(agencia);
            return Ok("Excluído com sucesso");
        }
    }
}
