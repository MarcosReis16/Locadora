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
        public Guid IdAluguel { get; set; }
        
        public Guid IdCliente { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucao { get; set; }

        public bool StatusEmprestimo { get; set; }

        public Cliente Cliente { get; set; }

        public List<AluguelFilme> AluguelFilmes { get; set; }

        public Aluguel()
        {

        }
        public Aluguel(Guid idCliente)
        {
            this.IdCliente = idCliente;
            this.StatusEmprestimo = true;
            this.ValorTotal = 0;
            this.DataEmprestimo = DateTime.Now.Date;
            this.DataDevolucao = this.DataEmprestimo.AddDays(5);
        }

        public void RenovarEmprestimo()
        {
            this.DataDevolucao = this.DataDevolucao.AddDays(3);
            this.ValorTotal += this.ValorTotal;
            this.StatusEmprestimo = true;

        }

        public void RealizarEmprestimo(IEnumerable<Filme> filmes)
        {
            this.AluguelFilmes = new List<AluguelFilme>();
            this.StatusEmprestimo = true;
            this.DataEmprestimo = DateTime.Now.Date;
            this.DataDevolucao = this.DataEmprestimo.AddDays(5);

            foreach(var filme in filmes)
            {
                this.AluguelFilmes.Add(new AluguelFilme(filme, this));
                this.ValorTotal += filme.ValorEmprestimo;
                filme.QtdEstoque -= 1;

            }
        }

        public void RealizarDevolucao(IEnumerable<Filme> filmes)
        {
            this.StatusEmprestimo = false;
            foreach(var filme in filmes)
            {
                filme.QtdEstoque += 1;
            }
            
        }
    }
}
