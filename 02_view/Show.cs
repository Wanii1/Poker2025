/// <summary>
/// Representa uma pessoa no sistema.
/// </summary>
/// <author>m4rc3lo</author>
/// <created>2025-03-15</created>

using System;
using System.Collections.Generic;
using poker_2025.model;

namespace poker_2025.view
{
    /// <summary>
    ///  Classe para mostrar cartas no console. Usa os metodo ToString de Card.
    /// </summary>

    public class Show //  classe para mostrar cartas no contexto do projeto
    {
        /// <summary>
        /// Método para mostrar uma lista de cartas no terminal.
        /// </summary>
        /// <param name="cards_">Lista de objetos do tipo Card.</param>        
        public static void show_cards(List<Card> cards_)
        {
            //Console.Clear(); // limpa a tela
            Console.WriteLine("##################################################");
            //Console.WriteLine("Uma lista de cartas!");
            Console.WriteLine("--------------------------------------------------");
            foreach (var card_ in cards_) // para cada item <card_> na coleção <cards_>
            {// mostra a representação em texto da carta
                //if (card_.value >= 2 && card_.value < 10) // se o valor for menor do que 10, adiciona um 0 na frente
                //    Console.WriteLine("0" + card_.ToString());
                //else
                //    Console.WriteLine("_" + card_.ToString());
                Console.WriteLine(card_.ToString());
            }
            //Console.WriteLine("--------------------------------------------------");
        }//fim do método <show_cards>

        //recebe um array de listas do tipo <Card>
        public static void show_histogram(List<Card>[] histogram_)
        {
            Console.Clear();
            Console.WriteLine("##################################################");
            Console.WriteLine("Um array de listas de cartas!");
            Console.WriteLine("--------------------------------------------------");
            // <histogram_.Length> indica a quantidade de posições no array
            // trabalhamos com 14 posições w
            for(int i = 1 ; i < histogram_.Length ; i++)
            {// só as posições de 1 até 13 podem ter cartas
                if(histogram_[i].Count != 0)
                {// se não for uma lista vazia:
                    Console.WriteLine($"index [{i}]:");
                    // cada posição não vazia do array vai ter uma lista
                    // que pode ter de 1 até 4 cartas (4 naipes ...)
                    foreach (var card in histogram_[i]) // mostra a representação em texto da carta
                        Console.WriteLine("\t[carta]: " + " " + card.ToString());
                }
            }
            Console.WriteLine("--------------------------------------------------");
        }// fim do método <show_histogram>    
    }// fim da classe <Show>
}// fim do name space <structs.view>