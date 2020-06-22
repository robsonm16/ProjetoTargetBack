using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetApi.Entity;
using TargetApi.Interfaces.Repository;

namespace TargetApi.Controllers
{
    
    [ApiController]
    
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        [AllowAnonymous]
        [HttpGet("GetClientes")]
        public IActionResult GetClientes()
        {
            try
            {
                return Ok(_clienteRepository.GetTodos());

            }
            catch (Exception)
            {

                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet("GetCliente/{id}")]
        public IActionResult GetCliente(Guid id)
        {
            try
            {
                return Ok( _clienteRepository.GetCliente(id));

            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public IActionResult Create(tb_cli_cliente cliente)
        {
            try
            {
                _clienteRepository.Adicionar(cliente);
                return Ok(cliente);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpPut("Update")]
        public IActionResult Update(tb_cli_cliente cliente)
        {
            try
            {
                _clienteRepository.Atualizar(cliente);
                return Ok(cliente);
            }
            catch (Exception)
            {

                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpDelete("Deletar")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                tb_cli_cliente cliente = _clienteRepository.GetCliente(id);
                _clienteRepository.Remover(cliente);
                return Ok();
            }
            catch (Exception)
            {

                return new StatusCodeResult(500);
            }
        }
    }
}
