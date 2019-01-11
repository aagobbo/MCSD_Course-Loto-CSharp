using System;

namespace Mind.Loteria.Dominio
{
    public interface IJogo
    {
        int id { get;  }
        DateTime data { get;  }
        int[] dezenas { get;  }

        void AdicionarNumero(int numero);
        void AdicionarNumero(int id, DateTime data, int[] numeros);
    }
}
