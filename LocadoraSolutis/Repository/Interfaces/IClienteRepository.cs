using LocadoraSolutis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraSolutis.Repository
{
    interface IClienteRepository
    {
        bool CadastraCliente(Cliente cliente);
        void EditaCliente(Cliente cliente);
        bool RemoveCliente(int codigo);
        IEnumerable<Cliente> RetornaBibliotecaClientes();
        IEnumerable<Cliente> RetornaClientesInadimplentes();
    }
}
