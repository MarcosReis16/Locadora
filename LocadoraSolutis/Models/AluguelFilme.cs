using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraSolutis.Models
{
    public class AluguelFilme
    {
        public int IdFilme { get; set; }
        public Filme Filme { get; set; }
        public int IdAluguel { get; set; }
        public Aluguel Aluguel { get; set; }

        public AluguelFilme()
        {

        }

        public AluguelFilme(Filme filme, Aluguel aluguel)
        {
            this.IdFilme = filme.IdFilme;
            this.IdAluguel = aluguel.IdAluguel;
            this.Filme = filme;
            this.Aluguel = aluguel;
        }

    }

}
