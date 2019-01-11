

using Mind.Loteria.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mind.Loteria.Apresentacao
{
    class Program
    {
        public static Mega Mega { get; set; }

        public static void Main(string[] args)
        {
            int resultado;
            do
            {
                resultado = validaOpcao(GeraMenu());
                ExecutaOpcao(resultado);
            } while (resultado != 0);
        }

        private static void ExecutaOpcao(int resultado)
        {
            if (resultado == 1)
            {
                AdicionarJogo();
            }
            else if (resultado == 2)
            {
                Sortear();
            }
            else if (resultado == 3)
            {
                ListarVencedores(6);
            }
            else if (resultado == 4)
            {
                ListarVencedores();
            }
            else if (resultado == 5)
            {
                GerarJogos();
            }
            else if (resultado == 6)
            {
                ListarVencedores(5);
            }
            else if (resultado == 7)
            {
                ListarVencedores(4);
            }

        }

        private static void ListarVencedores(int jogo)
        {
            throw new NotImplementedException();
        }

        private static void GerarJogos()
        {
            Console.WriteLine("Digite as dezenas separadas por , ou 0 para retornar ao menu anterior:");
            var comando = Console.ReadLine();

            int valor;
            bool isNum = int.TryParse(comando, out valor);
            if ((string.IsNullOrEmpty(comando)) || (!isNum) || (valor < 0))
            {
                Console.Clear();
                MensagemConsole("Valor inválido, pressione ENTER para retornar");
                Console.ReadLine();
            }
            else
            {
                var jogos = Mega.GerarJogos(valor);
                foreach (IJogo jogo in jogos)
                {
                    Console.WriteLine(value: "O jogo de Mega Sena foi incluso com sucesso: " + jogo.ToString());
                }

                MensagemConsole("Pressione ENTER para retornar");

            }
        }

        private static void ListarVencedores()
        {
            throw new NotImplementedException();
        }

        private static void Sortear()
        {
            var geradorNumeros = new GeradorMegaSena();
            if (Mega == null)
                Mega = new Mega(geradorNumeros);
            Mega.Sortear();
            MensagemConsole("O número da Mega Sena sorteado foi: " + Mega.NumerosSorteados.ToString() + ". Pressione ENTER para retornar ao menu anterior.");
        }

        private static int AdicionarJogo()
        {
            do
            {
                Console.WriteLine("Digite as dezenas separadas por , ou 0 para retornar ao menu anterior:");
                var comando = Console.ReadLine();

                if (comando.Equals("0")) { return 0; }

                var entrada = comando.Split(',');

                if (entrada.Length.Equals(0))
                {
                    ApresentaErro();
                    continue;
                }

                int[] dezenas = GerarLista(entrada);
                if (dezenas == null)
                {
                    ApresentaErro();
                    continue;
                }

                if (dezenas.Count() != 6)
                {
                    ApresentaErro("No momento o sistema só trabalho com jogos da Mega Sena, jogos com quantidades diferentes de dezenas não são compatíveis.");
                    continue;
                }

                var bilhete = Mega.AddBilhete(dezenas);

                MensagemConsole("O jogo de Mega Sena foi incluso com sucesso: " + bilhete.ToString() + ". Pressione ENTER para retornar ao menu anterior.");
                return 1;
            } while (1 == 1);
        }

        private static int[] GerarLista(string[] entrada)
        {
            int[] lista = null;

            foreach (string parte in entrada)
            {
                int i;
                if (int.TryParse(parte, out i))
                {
                    if (lista.Contains(i))
                        return null;
                    lista[lista.Count()] = i;
                }
                else
                {
                    return null;
                }
            }

            return lista;
        }

        private static void MensagemConsole(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.ReadLine();
            //Console.Clear();
        }

        private static void ApresentaErro()
        {
            MensagemConsole("Entrada inválida de dados. Pressione ENTER para tentar novamente.");
        }

        private static void ApresentaErro(string mensagem)
        {
            MensagemConsole(mensagem + " Pressione ENTER para tentar novamente.");
        }

        private static int validaOpcao(string opcao)
        {
            int valor;
            bool isNum = int.TryParse(opcao, out valor);
            if ((string.IsNullOrEmpty(opcao)) || (!isNum) || (valor < 0) || (valor > 7))
            {
                Console.Clear();
                MensagemConsole("Valor inválido, pressione ENTER para retornar");
                return -1;
            }
            return valor;
        }

        private static string GeraMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Adicionar Jogo");
            Console.WriteLine("2 - Sortear");
            Console.WriteLine("3 - Listar Vencedores Sena");
            Console.WriteLine("4 - Listar Perdedores");
            Console.WriteLine("5 - Gerar Jogos");
            Console.WriteLine("6 - Listar Vencedores Quina");
            Console.WriteLine("7 - Listar Vencedores Quadra");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();
            return opcao;
        }
    }
}
