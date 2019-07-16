﻿using LocadoraSolutis.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraSolutis.Models;

namespace LocadoraSolutis.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly LocadoraContext _context;

        public FilmeRepository(LocadoraContext context)
        {
            _context = context;
        }

        public bool CadastrarFilme(Filme filme)
        {
            try
            {
                _context.Filmes.Add(filme);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

        public void EditarFilme(Filme filme)
        {
            try
            {
                _context.Filmes.Update(filme);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private Filme BuscarFilmeporCodigo(int codigo)
        {
            return _context.Filmes.FirstOrDefault(m => m.CodigoFilme == codigo);
        }

        public bool RemoverFilme(int codigo)
        {
            try
            {
                var filme = _context.Filmes.First(m => m.CodigoFilme == codigo);
                if(filme != null)
                {
                    _context.Filmes.Remove(filme);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
            
        }

        IEnumerable<Filme> IFilmeRepository.RetornarBibliotecaFilmes()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Filme> IFilmeRepository.RetornarFilmesSemEstoque()
        {
            throw new NotImplementedException();
        }
    }
}
