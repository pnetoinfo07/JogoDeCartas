using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeCartas
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Carta> Cartas { get; set; }
        public int SomaValorDasCartas { get; set; }
        public bool Estourou { get; set; }
        public Jogador()
        {
            Cartas = new List<Carta>();
        }

        public void MostrarMaoJogador()
        {            
            if (Cartas.Count > 0)
            {
                string exibicaoCartas = string.Empty;
                foreach (Carta c in Cartas)
                {
                    exibicaoCartas += c.FormatarValorCartaExibicao() + " - ";                    
                }
                exibicaoCartas = exibicaoCartas.Remove(exibicaoCartas.LastIndexOf('-'), 1);
                SomarMaoJogador();
                exibicaoCartas += $" = {SomaValorDasCartas}"; 
                Console.WriteLine(exibicaoCartas);
            }
        }

        public void SomarMaoJogador()
        {
            SomaValorDasCartas = Cartas.Sum(x => x.Valor);
        }

        public Jogador CriarJogadorPreenchido(int id)
        {
            Id = id;
            Console.WriteLine("Digite seu nome");
            Nome = Console.ReadLine();
            return this;
        }
    }
}
