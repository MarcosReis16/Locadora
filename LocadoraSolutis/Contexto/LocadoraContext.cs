using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraSolutis.Models;

namespace LocadoraSolutis.Contexto
{
    public class LocadoraContext : DbContext
    {

        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }



    }
}
