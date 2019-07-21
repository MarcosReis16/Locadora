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
    [Route("api/aluguel")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelRepository _repository;

        public AluguelController(IAluguelRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Aluguel
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Aluguel/5
        [HttpGet("{id}", Name = "GetAluguelCliente")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Aluguel
        [HttpPost]
        public IActionResult Post(int idCliente, IEnumerable<Filme> filmes)
        {
            try
            {
                Aluguel aluguel = new Aluguel(idCliente);
                aluguel.RealizarEmprestimo(filmes);
                _repository.CriarAluguel(aluguel);
                return Ok(aluguel);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT: api/Aluguel/5
        [HttpPut("{id}")]
        public IActionResult Put(Aluguel aluguel, bool renovar)
        {
            try
            {
                if (!renovar)
                    aluguel.RealizarDevolucao();

                else
                    aluguel.RenovarEmprestimo();

                _repository.AlterarAluguel(aluguel);

                return Ok(aluguel);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
