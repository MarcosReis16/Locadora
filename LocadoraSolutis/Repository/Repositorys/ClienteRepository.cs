using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraSolutis.Contexto;
using LocadoraSolutis.Models;

namespace LocadoraSolutis.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LocadoraContext _context;

        public ClienteRepository(LocadoraContext context)
        {
            _context = context;
        }

        public void CadastraCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public void EditaCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool RemoveCliente(int codigo)
        {
            try
            {
                var cliente = _context.Clientes.First(m => m.IdCliente == codigo);
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return false;
            
        }

        public IEnumerable<Cliente> RetornaBibliotecaClientes()
        {
            return _context.Clientes.OrderBy(m => m.NomeCliente).ToList();
        }

        public IEnumerable<Cliente> RetornaClientePorNome(string nome)
        {
            return _context.Clientes.Where(m => m.NomeCliente.Contains(nome)).ToList();
        }

        public IEnumerable<Cliente> RetornaClientesInadimplentes()
        {
            return _context.Alugueis
                .Where(m => m.StatusEmprestimo == true && m.DataDevolucao < DateTime.Today)
                .Select(m => m.Cliente).ToList();
        }


    }
}
