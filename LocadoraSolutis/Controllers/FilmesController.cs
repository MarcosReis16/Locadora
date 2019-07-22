using LocadoraSolutis.Models;
using LocadoraSolutis.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LocadoraSolutis.Controllers
{
    [Route("api/filme")]
    [ApiController]
    public class FilmesController : ControllerBase
    {

        private readonly IFilmeRepository _repository;

        public FilmesController(IFilmeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Filmes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resultado = _repository.RetornarBibliotecaFilmes();

                if (resultado.Any())
                    return Ok(resultado);

                return NotFound();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: api/Filmes/5
        [HttpGet("{codigo}", Name = "GetFilmesCodigo")]
        public IActionResult Get(int codigo)
        {
            try
            {
                var resultado = _repository.BuscarFilmePorCodigo(codigo);

                if(resultado != null)
                    return Ok(resultado);

                return NotFound(codigo);

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        // POST: api/Filmes
        [HttpPost]
        public IActionResult Post([FromBody] Filme filme)
        {
            try
            {
                _repository.CadastrarFilme(filme);
                return Ok(filme);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT: api/Filmes/5
        [HttpPut("{id}")]
        public IActionResult Put(Filme filme)
        {
            try
            {
                _repository.EditarFilme(filme);
                return Ok(filme);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }




        // DELETE: api/ApiWithActions/5
        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            try
            {
                var apagou = _repository.RemoverFilme(codigo);

                if(apagou)
                    return Ok();

                return NotFound(codigo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
