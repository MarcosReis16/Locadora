using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraSolutis.Models
{
    public class Aluguel
    {
        
        
        public int IdAluguel { get; private set; }
        
        public int IdCliente { get; set; }

        
        public List<Filme> CodigoFilmes { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime DataEmprestimo { get; }

        public DateTime DataDevolucao { get; set; }

        public bool StatusEmprestimo { get; set; }

        public Aluguel(int id, List<int> filmes)
        {
            this.IdCliente = id;
            this.CodigoFilmes = filmes;
            this.DataEmprestimo = DateTime.Now.Date;
            this.DataDevolucao = this.DataEmprestimo.AddDays(5);
        }
    }
}
