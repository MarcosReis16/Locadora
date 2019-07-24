using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Contexto;
using Locadora.Models;

namespace Locadora.Repository
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
            using (var transacao = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();
                    transacao.Commit();

                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
            
        }

        public void EditaCliente(Cliente cliente)
        {
            using(var transacao = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Clientes.Update(cliente);
                    _context.SaveChanges();
                    transacao.Commit();
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }

        public bool RemoveCliente(Guid idCliente)
        {
            using(var transacao = _context.Database.BeginTransaction())
            {
                try
                {
                    var cliente = _context.Clientes.First(m => m.IdCliente == idCliente);
                    if (cliente != null)
                    {
                        _context.Clientes.Remove(cliente);
                        _context.SaveChanges();
                        transacao.Commit();
                        return true;
                    }
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }

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
