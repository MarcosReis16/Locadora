using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Auxiliares;

namespace Locadora.Models
{
    public class Filme
    {
        [Key]
        public Guid IdFilme { get; set; }

        public int CodigoFilme { get; set; }

        public string NomeFilme { get; set; }

        public Genero GeneroFilme { get; set; }

        public FaixaEtaria FaixaEtariaFilme { get; set; }

        public decimal ValorEmprestimo { get; set; }

        public int QtdEstoque { get; set; }

        public List<AluguelFilme> AluguelFilmes { get; set; }

        public Filme()
        {

        }
        public Filme(int codigo, string nome, Genero genero, FaixaEtaria faixa, decimal valor, int qtd)
        {

            this.CodigoFilme = codigo;
            this.NomeFilme = nome;
            this.GeneroFilme = genero;
            this.FaixaEtariaFilme = faixa;
            this.ValorEmprestimo = valor;
            this.QtdEstoque = qtd;

        }


    }
}
