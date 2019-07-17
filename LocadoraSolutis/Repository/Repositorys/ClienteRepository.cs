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

        public bool cadastraCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public void editaCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool removeCliente(int codigo)
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
                Console.WriteLine(e.Message);
            }
            return false;
            
        }

        public IEnumerable<Cliente> retornaBibliotecaClientes()
        {
            return _context.Clientes.OrderBy(m => m.NomeCliente).ToList();
        }

        public IEnumerable<Cliente> retornaClientesInadimplentes()
        {
            throw new NotImplementedException();
        }
    }
}
