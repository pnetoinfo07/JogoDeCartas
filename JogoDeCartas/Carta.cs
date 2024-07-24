using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeCartas
{
    public class Carta
    {
        public Carta(string naipe, string valor)
        {
            Naipe = naipe;
            ConverterNumeroInteiroParaValorCarta(valor);
            Valor = int.Parse(valor);
        }

        public string Nome { get; set; }
        public string Naipe { get; set; }
        public int Valor { get; set; }

        public void ConverterNumeroInteiroParaValorCarta(string num)
        {
            switch (num)
            {
                case "1":
                    Nome = "A";
                    break;
                case "11":
                    Nome = "J";
                    break;
                case "12":
                    Nome = "Q";
                    break;
                case "13":
                    Nome = "K";
                    break;
                default:
                    Nome = num;
                    break;
            }
        }
        public string ConverterNaipeParaSimbolo()
        {
            switch (Naipe)
            {
                case "espadas":
                    return "♠";
                case "paus":
                    return "♣";
                case "ouros":
                    return "♦";
                case "copas":
                    return "♥";
            }
            return Naipe;
        }
        public void ExibirCarta()
        {
            Console.WriteLine(FormatarValorCartaExibicao());
        }

        public string FormatarValorCartaExibicao()
        {
            return $"{Nome} {ConverterNaipeParaSimbolo()}";
        }
    }
}
