using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaRepositorio _contaRepositorio;
        public ContaController(IContaRepositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
        }

        [Route("{id?}"), HttpGet]
        public async Task<IActionResult> Obter([FromRoute] int id = 0)
        {
            if (id != 0)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var conta = _contaRepositorio.ObterPorId(id);
                if (conta == null) return NotFound();
                return Ok(conta);
            }
            else
            {
                try
                {
                    return Ok(_contaRepositorio.ObterTodos());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Conta conta)
        {
            if (!ModelState.IsValid) return BadRequest();
            _contaRepositorio.Adicionar(conta);
            return Ok(conta);
        }

        [Route("{id}"), HttpPut]
        public async Task<IActionResult> Alterar([FromRoute] int id, [FromBody] Conta conta)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != conta.Id) BadRequest("Os ids são diferentes");
            _contaRepositorio.Atualizar(conta);
            return Ok(conta);
        }

        [Route("{id}"), HttpDelete]
        public async Task<IActionResult> Remover([FromBody] Conta conta)
        {
            if (!ModelState.IsValid) return BadRequest();
            _contaRepositorio.Remover(conta);
            return Ok("Excluído com sucesso");
        }
    }
}
