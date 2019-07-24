using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class AluguelFilme
    {
        public Guid IdFilme { get; set; }
        public Filme Filme { get; set; }
        public Guid IdAluguel { get; set; }
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
