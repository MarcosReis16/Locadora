using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Repository
{
    public interface IAluguelRepository
    {
        Aluguel CriarAluguel(Aluguel aluguel);
        Aluguel AlterarAluguel(Aluguel aluguel);

        IEnumerable<Aluguel> ObterAluguelPorCliente(Guid idCliente);

        IEnumerable<Aluguel> ObterAluguelPendentePorCliente(Guid idCliente);

        IEnumerable<Aluguel> ObterAluguelPendente();

        Aluguel ObterAluguelPorId(Guid idAluguel);

        IEnumerable<Aluguel> ObterAlugueis();
    }
}
