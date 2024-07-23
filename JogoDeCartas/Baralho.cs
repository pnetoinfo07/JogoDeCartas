using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeCartas
{
    public class Baralho
    {
        public List<Carta> baralhoList { get; set; }
        public int NumeroCartas { get; set; }

        public Baralho(int numCartas)
        {
            baralhoList = new List<Carta>();
            NumeroCartas = numCartas;
            CriarBaralho();
        }
        public void CriarBaralho()
        {
            string[] naipesDisponiveis = { "espadas", "paus", "ouros", "copas" };
            foreach (string naipe in naipesDisponiveis)
            {
                for (int i = 1; i <= 13; i++)
                {
                    baralhoList.Add(new Carta(naipe, i.ToString()));
                }
            }
        }
        public void Embaralhar()
        {
            baralhoList = baralhoList.OrderBy(x => Guid.NewGuid()).ToList();
        }
        public void DistribuirCartas(Jogador j)
        {
            for (int i = 0; i < NumeroCartas; i++)
            {
                DistribuirProximaCarta(j);
            }
        }

        public void DistribuirProximaCarta(Jogador j)
        {
            Carta c = baralhoList.FirstOrDefault();
            j.Cartas.Add(c);
            baralhoList.Remove(c);
        }

        public void MostrarCartasBaralho()
        {
            foreach (Carta carta in baralhoList)
            {
                carta.ExibirCarta();
            }
        }
    }
}
