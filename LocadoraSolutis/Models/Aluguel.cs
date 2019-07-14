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
        
        [Key]
        public int IdAluguel { get; private set; }
        [ForeignKey("IdCliente")]
        public int IdCliente { get; set; }
        [ForeignKey("codigoFilmes")]
        public List<int> codigoFilmes { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime DataEmprestimo { get; private set; }

        public DateTime DataDevolucao { get; set; }

        public Aluguel(int id, List<int> filmes, DateTime dataemprestimo)
        {
            this.IdCliente = id;
            this.codigoFilmes = filmes;
            this.DataEmprestimo = dataemprestimo;
        }
    }
}
