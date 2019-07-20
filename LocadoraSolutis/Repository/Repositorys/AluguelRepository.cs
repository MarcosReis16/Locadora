using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraSolutis.Models;

namespace LocadoraSolutis.Repository
{
    public class AluguelRepository : IAluguelRepository
    {
        public bool realizaDevolucao(string cpf)
        {
            throw new NotImplementedException();
        }

        public bool realizaEmprestimo(Aluguel aluguel)
        {
            throw new NotImplementedException();
        }

        public bool renovaDataEmprestimo(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
