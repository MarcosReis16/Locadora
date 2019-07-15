using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LocadoraSolutis.Auxiliares;

namespace LocadoraSolutis.Models
{
    public class Filme
    {
        [Key]
        public int CodigoFilme { get; private set; }

        public string NomeFilme { get; private set; }

        public Genero GeneroFilme { get; private set; }

        public FaixaEtaria FaixaEtariaFilme { get; private set; }

        public decimal ValorEmprestimo { get; set; }

        public int QtdEstoque { get; set; }

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
