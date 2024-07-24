using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeCartas
{
    public class BlackJack
    {
        public Baralho BaralhoNovo { get; set; }
        public List<Jogador> Jogadores { get; set; }

        public BlackJack()
        {

            BaralhoNovo = new Baralho(2);
            Jogadores = new List<Jogador>();

            Console.WriteLine("Quantos jogadores vão jogar?");
            int numJogadores = int.Parse(Console.ReadLine());
            int id = Jogadores.Count == 0 ? 1 : Jogadores.Max(x => x.Id) + 1;

            for (int i = 0; i < numJogadores; i++)
            {
                Jogador j = new Jogador();
                j.CriarJogadorPreenchido(id);
                Jogadores.Add(j);
            }
        }

        public void RealizarMao()
        {
            IniciarRodada();
            foreach (Jogador j in Jogadores)
            {
                Console.WriteLine($"{j.Nome} realize a sua jogada, sua mão é a abaixo");
                j.MostrarMaoJogador();
                bool desejaOutraCarta = true;
                while (desejaOutraCarta)
                {
                    Console.WriteLine("Deseja receber mais uma carta?");
                    string resposta = Console.ReadLine();
                    desejaOutraCarta = VerificarSeJogadoresDesejaMaisUmaCarta(resposta);
                    if (desejaOutraCarta)
                    {
                        BaralhoNovo.DistribuirProximaCarta(j);
                        j.MostrarMaoJogador();
                    }

                    desejaOutraCarta = PularJogadaCasoJogadorEstoure(j, desejaOutraCarta);
                }
                Console.WriteLine("Finalizando a sua jogada...Vamos passar para o próximo jogador");
                Console.WriteLine("digite uma tecla qualquer para passar a vez ...");
                Console.ReadLine();
                Console.Clear();
            }
            CalcularResultadoFinal();
        }
        public void CalcularResultadoFinal()
        {
            int ultimoValor = 0;
            Console.WriteLine("VENCEDOR DA RODADA");
            foreach (Jogador j in Jogadores.OrderByDescending(x => x.SomaValorDasCartas))
            {
                if (ultimoValor > 0 && ultimoValor != j.SomaValorDasCartas)
                {
                    return;
                }

                if (!j.Estourou)
                {
                    Console.WriteLine($"Jogador Vencedor: {j.Nome} - Mão do Jogador:");
                    j.MostrarMaoJogador();
                    ultimoValor = j.SomaValorDasCartas;
                }
            }
        }
        private static bool PularJogadaCasoJogadorEstoure(Jogador j, bool desejaOutraCarta)
        {
            if (j.SomaValorDasCartas > 21)
            {
                Console.WriteLine("Você estourou...");
                j.Estourou = true;
                desejaOutraCarta = false;
            }

            return desejaOutraCarta;
        }

        private bool VerificarSeJogadoresDesejaMaisUmaCarta(string resposta)
        {
            while (true)
            {
                if (resposta.ToLower() == "sim"
                || resposta.ToLower() == "pode"
                || resposta.ToLower() == "s"
                || resposta.ToLower() == "ss"
                || resposta.ToLower() == "true")
                {
                    return true;
                }
                else if (resposta.ToLower() == "não"
                || resposta.ToLower() == "nao"
                || resposta.ToLower() == "n"
                || resposta.ToLower() == "nn"
                || resposta.ToLower() == "false")
                {
                    return false;
                }
                Console.WriteLine("Não entendi um comando digite um válido");
                Console.WriteLine("Deseja receber mais uma carta?");
                resposta = Console.ReadLine();
            }
        }

        private void IniciarRodada()
        {
            BaralhoNovo.Embaralhar();
            foreach (Jogador j in Jogadores)
            {
                BaralhoNovo.DistribuirCartas(j);
            }
        }
    }
}
