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
                Console.WriteLine(exibicaoCartas);
            }
        }
    }
}
