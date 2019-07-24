using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Repository
{
    public interface IClienteRepository
    {
        void CadastraCliente(Cliente cliente);
        void EditaCliente(Cliente cliente);
        bool RemoveCliente(Guid idCliente);
        IEnumerable<Cliente> RetornaBibliotecaClientes();
        IEnumerable<Cliente> RetornaClientesInadimplentes();

        IEnumerable<Cliente> RetornaClientePorNome(string nome);
    }
}
