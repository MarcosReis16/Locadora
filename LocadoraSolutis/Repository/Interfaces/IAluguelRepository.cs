using LocadoraSolutis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraSolutis.Repository
{
    interface IAluguelRepository
    {
        bool realizaEmprestimo(Aluguel aluguel);
        bool renovaDataEmprestimo(string cpf);
        bool realizaDevolucao(string cpf);
    }
}
