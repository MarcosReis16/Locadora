using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraSolutis.Contexto;
using LocadoraSolutis.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraSolutis.Repository
{
    public class AluguelRepository : IAluguelRepository
    {
        private readonly LocadoraContext _context;

        public AluguelRepository(LocadoraContext context)
        {
            _context = context;
        }
        public Aluguel AlterarAluguel(Aluguel aluguel)
        {
            using(var transacao = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Alugueis.Update(aluguel);
                    _context.SaveChanges();
                    transacao.Commit();
                    return aluguel;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }

        public Aluguel CriarAluguel(Aluguel aluguel)
        {
            using(var transacao = _context.Database.BeginTransaction())
            {
                try
                {
                    var resultado = _context.Alugueis.Attach(aluguel);
                    resultado.State = EntityState.Added;
                    _context.SaveChanges();
                    transacao.Commit();
                    return resultado.Entity;
                
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }

        public IEnumerable<Aluguel> ObterAluguelPendente()
        {
            
            try
            {
                return _context.Alugueis
                        .Where(m => m.StatusEmprestimo == true && m.DataDevolucao < DateTime.Today)
                        .Include(m => m.AluguelFilmes)
                        .ThenInclude(c => c.Filme)
                        .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            
        }

        public Aluguel ObterAluguelPorId(Guid idAluguel)
        {

            try
            {
                return _context.Alugueis
                        .Where(m => m.IdAluguel == idAluguel)
                        .Include(m => m.AluguelFilmes)
                        .ThenInclude(c => c.Filme)
                        .FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        public IEnumerable<Aluguel> ObterAluguelPendentePorCliente(Guid idCliente)
        {
            
            try
            {
                return _context.Alugueis
                        .Where(m => m.StatusEmprestimo == true && m.DataDevolucao < DateTime.Today && m.IdCliente == idCliente)
                        .Include(m => m.AluguelFilmes)
                        .ThenInclude(c => c.Filme)
                        .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            
        }

        public IEnumerable<Aluguel> ObterAluguelPorCliente(Guid idCliente)
        {
            
            try
            {
                return _context.Alugueis
                        .Where(m => m.IdCliente == idCliente)
                        .Include(m => m.AluguelFilmes)
                        .ThenInclude(c => c.Filme)
                        .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public IEnumerable<Aluguel> ObterAlugueis()
        {
            return _context.Alugueis
                        .Include(m => m.AluguelFilmes)
                        .ThenInclude(c => c.Filme)
                        .ToList();
        }
    }
}
