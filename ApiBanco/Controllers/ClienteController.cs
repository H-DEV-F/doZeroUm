using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiBanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [Route("{id?}"), HttpGet]
        public async Task<IActionResult> Obter([FromRoute] int id = 0)
        {
            if (id != 0)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var cliente = _clienteRepositorio.ObterPorId(id);
                if (cliente == null) return NotFound();
                return Ok(cliente);
            }
            else 
            {
                try
                {
                    return Ok(_clienteRepositorio.ObterTodos());
                }
                catch (Exception ex) 
                {
                    return BadRequest(ex.ToString());
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid) return BadRequest();
            _clienteRepositorio.Adicionar(cliente);
            return Ok(cliente);
        }

        [Route("{id}"), HttpPut]
        public async Task<IActionResult> Alterar([FromRoute] int id, [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != cliente.Id) BadRequest("Os ids são diferentes");
            _clienteRepositorio.Atualizar(cliente);
            return Ok(cliente);
        }

        [Route("{id}"), HttpDelete]
        public async Task<IActionResult> Remover([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid) return BadRequest();
            _clienteRepositorio.Remover(cliente);
            return Ok("Excluído com sucesso");
        }
    }
}
