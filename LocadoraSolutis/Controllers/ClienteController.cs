using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraSolutis.Models;
using LocadoraSolutis.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraSolutis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resultado = _repository.RetornaBibliotecaClientes();

                if (resultado.Any())
                    return Ok(resultado);

                return NotFound();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{nome}", Name = "Get")]
        public IActionResult Get(string nome)
        {
            try
            {
                var resultado = _repository.RetornaClientePorNome(nome);

                if (resultado.Any())
                    return Ok();

                return NotFound();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            try
            {
                _repository.CadastraCliente(cliente);
                return Ok(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(Cliente cliente)
        {
            try
            {
                _repository.EditaCliente(cliente);
                return Ok(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
        [HttpDelete("{codigo}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var apagou = _repository.RemoveCliente(id);

                if (apagou)
                    return Ok();

                return NotFound(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
