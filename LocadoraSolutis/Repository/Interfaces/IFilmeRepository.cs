using LocadoraSolutis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraSolutis.Repository
{
    interface IFilmeRepository
    {
        bool cadastraFilme(Filme filme);
        IEnumerable<Filme> retornaBibliotecaFilmes();
        IEnumerable<Filme> retornaFilmesSemEstoque();
        void editaFilme(int codigo);
        bool removeFilme(int codigo);

        

    }
}
