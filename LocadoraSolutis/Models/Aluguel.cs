using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraSolutis.Models
{
    public class Aluguel
    {
        public int IdAluguel { get; private set; }
        public int IdCliente { get; set; }
        public List<Filme> Filmes { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime DataEmprestimo { get; private set; }

        public DateTime DataDevolucao { get; set; }

        public Aluguel(int id, List<Filme> filmes, DateTime dataemprestimo)
        {
            this.IdCliente = id;
            this.Filmes = filmes;
            this.DataEmprestimo = dataemprestimo;
        }
    }
}
