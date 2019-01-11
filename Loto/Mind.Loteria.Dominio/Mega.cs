using System;
using System.Collections.Generic;
using System.Linq;

namespace Mind.Loteria.Dominio
{
    public class Mega : ILoteria<JogoMega>
    {
        public int[] NumerosSorteados => this.numerosSorteados.ToArray();
        private List<int> numerosSorteados;

        const int QtdDezenas = 6;
        const int MinDezena = 1;
        const int maxDezena = 60;

        public JogoMega Sorteado { get; }
        public IList<JogoMega> Bilhetes { get; }
                
        private IGeradorNumerosLoteria geradorNumerosLoteria;

        public Mega(IGeradorNumerosLoteria geradorNumerosLoteria)
        {
            this.geradorNumerosLoteria = geradorNumerosLoteria;
            this.numerosSorteados = new List<int>();
            Bilhetes = new List<JogoMega>();
        }
        
        public void Sortear() => this.numerosSorteados.AddRange(geradorNumerosLoteria.GerarNumeros(QtdDezenas, MinDezena, maxDezena));

        public int[] Surpresinha() => geradorNumerosLoteria.GerarNumeros(QtdDezenas, MinDezena, maxDezena);

        public JogoMega AddBilhete(int[] dezenas)
        {
            JogoMega bilhete = new JogoMega(this.Bilhetes.Count+1, DateTime.Now, dezenas);
            Bilhetes.Add(bilhete);
            return bilhete;
        }

        public IList<JogoMega> ListarVencedores() => this.Bilhetes.Where(jogo => jogo.dezenas.All(n => this.numerosSorteados.Contains(n))).ToList();

        public IList<JogoMega> ListarPerdedores() => this.Bilhetes.Where(jogo => jogo.dezenas.Except(this.numerosSorteados).Count()>0).ToList();

        public IList<JogoMega> GerarJogos(int quantidade)
        {
            IList<JogoMega> jogos = new List<JogoMega>();

            for (int i = 0; i < quantidade; i++)
            {
                jogos.Add(this.AddBilhete(Surpresinha()));
            }

            return jogos;
        }

    }
}