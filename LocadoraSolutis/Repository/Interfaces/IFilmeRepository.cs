using LocadoraSolutis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraSolutis.Repository
{
    interface IFilmeRepository
    {
        bool CadastrarFilme(Filme filme);
        IEnumerable<Filme> RetornarBibliotecaFilmes();
        IEnumerable<Filme> RetornarFilmesSemEstoque();
        void EditarFilme(int codigo);
        bool RemoverFilme(int codigo);

        Filme BuscarFilmePorCodigo(int codigo);

        

    }
}
