using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiBanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        [Route("{id?}"), HttpGet]
        public async Task<IActionResult> Obter([FromRoute] int id = 0)
        {
            if (id != 0)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var contato = _contatoRepositorio.ObterPorId(id);
                if (contato == null) return NotFound();
                return Ok(contato);
            }
            else
            {
                try
                {
                    return Ok(_contatoRepositorio.ObterTodos());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Contato contato)
        {
            if (!ModelState.IsValid) return BadRequest();
            _contatoRepositorio.Adicionar(contato);
            return Ok(contato);
        }

        [Route("{id}"), HttpPut]
        public async Task<IActionResult> Alterar([FromRoute] int id, [FromBody] Contato contato)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != contato.Id) BadRequest("Os ids são diferentes");
            _contatoRepositorio.Atualizar(contato);
            return Ok(contato);
        }

        [Route("{id}"), HttpDelete]
        public async Task<IActionResult> Remover([FromBody] Contato contato)
        {
            if (!ModelState.IsValid) return BadRequest();
            _contatoRepositorio.Remover(contato);
            return Ok("Excluído com sucesso");
        }
    }
}
