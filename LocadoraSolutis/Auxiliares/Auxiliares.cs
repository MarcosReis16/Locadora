using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Auxiliares
{
    public enum Genero : int
    {
        Aventura,
        Romance,
        Ação,
        Suspense,
        Drama,
        Terror,
        Infantil,
        Documentário
    }

    public enum FaixaEtaria : int
    {
        Livre = 0,
        Dez = 10,
        Catorze = 14,
        Dezesseis = 16,
        Dezoito = 18
    }
}