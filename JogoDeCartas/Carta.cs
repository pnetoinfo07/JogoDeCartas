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
        }

        public string Valor { get; set; }
        public string Naipe { get; set; }

        public void ConverterNumeroInteiroParaValorCarta(string num)
        {
            switch (num)
            {
                case "1":
                    Valor = "A";
                    break;
                case "11":
                    Valor = "J";
                    break;
                case "12":
                    Valor = "Q";
                    break;
                case "13":
                    Valor = "K";
                    break;
                default:
                    Valor = num;
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
            return $"{Valor} {ConverterNaipeParaSimbolo()}";
        }
    }
}
