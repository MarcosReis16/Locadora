using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraSolutis.Contexto;
using LocadoraSolutis.Models;

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
            try
            {
                _context.Alugueis.Update(aluguel);
                _context.SaveChanges();
                return aluguel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void CriarAluguel(Aluguel aluguel)
        {
            try
            {
                _context.Alugueis.Add(aluguel);
                _context.SaveChanges();
                
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Aluguel> ObterAluguelPendente()
        {
            try
            {
                return _context.Alugueis
                     .Where(m => m.StatusEmprestimo == true && m.DataDevolucao < DateTime.Today).ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Aluguel> ObterAluguelPendentePorCliente(int idCliente)
        {
            try
            {
                return _context.Alugueis
                     .Where(m => m.StatusEmprestimo == true && m.DataDevolucao < DateTime.Today && m.IdCliente == idCliente).ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Aluguel> ObterAluguelPorCliente(int idCliente)
        {
            try
            {
                return _context.Alugueis
                     .Where(m => m.IdCliente == idCliente).ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
