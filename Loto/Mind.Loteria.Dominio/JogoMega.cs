using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mind.Loteria.Dominio
{
    public class JogoMega : IJogo
    {
        public int id { get;  }
        public DateTime data { get;  }
        public int[] dezenas { get;  }

        public JogoMega(int id, DateTime data, int[] dezenas) 
        {
            this.id = id;
            this.data = data;
            this.dezenas = dezenas;
        }

        public override string ToString() => id.ToString() + " | " + data.ToString() + " | " + dezenas.ToString();

        public void AdicionarNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public void AdicionarNumero(int id, DateTime data, int[] numeros)
        {
            var novoJogo = new JogoMega(id, data, dezenas);
        }        
    }
}
