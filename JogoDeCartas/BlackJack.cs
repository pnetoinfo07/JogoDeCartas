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

        public BlackJack() {

            BaralhoNovo = new Baralho(2);
            Jogadores = new List<Jogador>();

            Console.WriteLine("Quantos jogadores vão jogar?");
            int numJogadores = int.Parse(Console.ReadLine());
            int id = Jogadores.Count == 0? 1 : Jogadores.Max(x => x.Id) + 1;    
            
            for (int i = 0; i < numJogadores; i++)
            {
                Jogador j =  new Jogador();
                j.CriarJogadorPreenchido(id);
                Jogadores.Add(j);
            }
        }

        public void RealizarMao()
        {
            IniciarRodada();
            foreach (Jogador j in Jogadores)
            {
                Console.WriteLine($"{j.Nome} realize a sua jogada, sua mão é a abaixo" );
                j.MostrarMaoJogador();
                Console.WriteLine("Deseja receber mais uma carta?");
                string resposta = Console.ReadLine();
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
