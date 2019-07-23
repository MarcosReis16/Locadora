using LocadoraSolutis.Models;
using LocadoraSolutis.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraSolutis.Controllers
{
    [Route("api/aluguel")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelRepository _repositoryAluguel;
        private readonly IFilmeRepository _repositoryFilme;
        

        public AluguelController(IAluguelRepository repositoryAluguel, IFilmeRepository repositoryFilme)
        {
            _repositoryAluguel = repositoryAluguel;
            _repositoryFilme = repositoryFilme;
        }

        // GET: api/Aluguel
        [HttpGet]
        public IActionResult Get()
        {
            var alugueis = _repositoryAluguel.ObterAlugueis();
            if (alugueis.Any())
                return Ok(alugueis);
            return NotFound();
        }

        // GET: api/Aluguel/5
        [HttpGet("{id}", Name = "GetAluguelCliente")]
        public IActionResult Get(Guid idCliente)
        {
            var alugueis = _repositoryAluguel.ObterAluguelPorCliente(idCliente);

            if(alugueis.Any())
                return Ok(alugueis);

            return NotFound(idCliente);
        }

        // POST: api/Aluguel
        [HttpPost]
        public IActionResult Post(Guid idCliente, [FromBody] IEnumerable<Filme> filmes)
        {
            try
            {
                Aluguel aluguel = new Aluguel(idCliente);
                aluguel.RealizarEmprestimo(filmes);
                aluguel = _repositoryAluguel.CriarAluguel(aluguel);
                filmes = aluguel.AluguelFilmes.Select(m => m.Filme).ToList();
                foreach (var filme in filmes)
                {
                    _repositoryFilme.EditarFilme(filme);
                }
                return Ok(aluguel);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT: api/Aluguel/5
        [HttpPut]
        public IActionResult Put(Guid idAluguel, bool renovar)
        {
            try
            {
                var aluguel = _repositoryAluguel.ObterAluguelPorId(idAluguel);
                if (!renovar)
                {
                    var filmes = aluguel.AluguelFilmes.Select(m => m.Filme).ToList();
                    aluguel.RealizarDevolucao(filmes);
                    foreach(var filme in filmes)
                    {
                        _repositoryFilme.EditarFilme(filme);
                    }
                    
                }

                else
                    aluguel.RenovarEmprestimo();

                _repositoryAluguel.AlterarAluguel(aluguel);

                return Ok(aluguel);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
