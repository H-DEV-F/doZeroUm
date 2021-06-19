using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio, IContatoRepositorio contatoRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _contatoRepositorio = contatoRepositorio;
        }

        #region cliente
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
        #endregion

        #region contato
        [Route("Contato/{id?}"), HttpGet]
        public async Task<IActionResult> ObterContato([FromRoute] int id = 0)
        {
            if (id != 0)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var contatos = _contatoRepositorio.ObterPorId(id);
                if (contatos == null) return NotFound();
                return Ok(contatos);
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

        [Route("Contato/ClienteId/{id?}"), HttpGet]
        public async Task<IActionResult> ObterContatoPorClienteId([FromRoute] int id = 0)
        {
            if (id != 0)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var contatos = _contatoRepositorio.ObterTodos().Where(c => c.ClienteId == id).ToList();
                if (contatos.Count() < 0) return NotFound();
                return Ok(contatos);
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

        [Route("Contato"), HttpPost]
        public async Task<IActionResult> AdicionarContato([FromBody] Contato contato)
        {
            if (!ModelState.IsValid) return BadRequest();
            _contatoRepositorio.Adicionar(contato);
            return Ok(contato);
        }

        [Route("Contato/{id}"), HttpPut]
        public async Task<IActionResult> AlterarContato([FromRoute] int id, [FromBody] Contato contato)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != contato.Id) BadRequest("Os ids são diferentes");
            _contatoRepositorio.Atualizar(contato);
            return Ok(contato);
        }

        [Route("Contato/{id}"), HttpDelete]
        public async Task<IActionResult> RemoverContato([FromBody] Contato contato)
        {
            if (!ModelState.IsValid) return BadRequest();
            _contatoRepositorio.Remover(contato);
            return Ok("Excluído com sucesso");
        }
        #endregion
    }
}
