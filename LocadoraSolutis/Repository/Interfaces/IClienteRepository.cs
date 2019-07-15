using LocadoraSolutis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraSolutis.Repository
{
    interface IClienteRepository
    {
        bool cadastraCliente(Cliente cliente);
        void editaCliente(int codigo);
        bool removeCliente(int codigo);
        IEnumerable<Cliente> retornaBibliotecaClientes();
        IEnumerable<Cliente> retornaClientesInadimplentes();
    }
}
