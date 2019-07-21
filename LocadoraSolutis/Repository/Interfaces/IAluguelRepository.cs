using LocadoraSolutis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraSolutis.Repository
{
    public interface IAluguelRepository
    {
        void CriarAluguel(Aluguel aluguel);
        Aluguel AlterarAluguel(Aluguel aluguel);

        IEnumerable<Aluguel> ObterAluguelPorCliente(int idCliente);

        IEnumerable<Aluguel> ObterAluguelPendentePorCliente(int idCliente);

        IEnumerable<Aluguel> ObterAluguelPendente();
    }
}
