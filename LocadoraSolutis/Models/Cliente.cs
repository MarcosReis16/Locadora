using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Cliente
    {
        [Key]
        public Guid IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CPFCliente { get; set; }

        public List<Aluguel> Alugueis { get; set; }

        public Cliente()
        {

        }
        public Cliente(string nome, string cpf)
        {
            this.NomeCliente = nome;
            this.CPFCliente = cpf;
        }
        
    }
}
