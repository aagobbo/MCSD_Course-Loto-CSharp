using System;
using System.Linq;

namespace Mind.Loteria.Dominio
{
    public interface IGeradorNumerosLoteria
    {
        int[] GerarNumeros(int qtdDezenas, int minDezena, int MaxDezena);
    }

    public class GeradorMegaSena : IGeradorNumerosLoteria
    {
        public int[] GerarNumeros(int qtdDezenas, int minDezena, int maxDezena)
        {
            int[] dezena = new int[qtdDezenas];
            var i = 0;
            while (i != qtdDezenas)
            {
                Random randomico = new Random();
                var numRandomico = randomico.Next(minDezena, maxDezena);
                if (!dezena.Contains(numRandomico))
                    dezena[i++] = numRandomico;
            }

            return dezena;
        }
    }
}

