using Mind.Loteria.Dominio;

namespace Mind.Loteria.Tests.Unit
{
    class GeradorNumerosMock : IGeradorNumerosLoteria
    {
        public int[] GerarNumeros(int qtdDezenas, int minDezena, int MaxDezena)
        {
            return new int[6] { 1, 2, 3, 4, 5, 6 };
        }
    }
}
