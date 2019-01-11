using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mind.Loteria.Dominio
{
    
    public interface ILoteria<T> where T : IJogo
    {
        int[] NumerosSorteados { get; }

        void Sortear();

        T AddBilhete(int[] dezenas);

        string ToString();

        IList<T> GerarJogos(int quantidade);
        
        IList<T> ListarVencedores();

        IList<T> ListarPerdedores();

        
    }
}
