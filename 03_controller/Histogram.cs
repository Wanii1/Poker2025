/// <summary>
/// Representa uma pessoa no sistema.
/// </summary>
/// <author>m4rc3lo</author>
/// <created>2025-03-15</created>

using System;
using System.Collections.Generic;
using poker_2025.model;
namespace poker_2025.controller // segue o padrão de momenclatura dos diretórios do projeto
{
    /// <summary>
    ///  Classe que define a estrutura base para os algoritmos de recohecimento.
    /// </summary>
    public class Histogram // classe que monta a estrutura para análise
    {   
        private readonly List<Card> cards;   
        public List<Card>[] data { get; }
        public Histogram(List<Card> c_)
        {   //inicializa um array de listas de cartas
            // podendo ter cartas nas posições de 1 até 13
            data = new List<Card>[14]; // array fixo de 14 posições
            cards = c_;
        }//List<Card> cards
        
        /// <summary>
        /// Método para gerar o histotgrama. Recebe uma lista de cartas de distribui no array.
        /// </summary>
        /// <param name="cards">Lista de objetos do tipo Card.</param>
        /// <returns>Retorna um array de listas de cartas.</returns>
        public void make_histogram()
        { //
            for (int i = 0; i < 14; i++) // para cada uma das 14 posições
                data[i] = new List<Card>(); // criar lista vazia em cada posição do array

            for (int i = 0; i < cards.Count; i++)
            {
                // cria uma cópia da carta da vez
                Card card_copy = new Card(cards[i].value, cards[i].suit, cards[i].on_table, cards[i].player);
                // salva na var aux <card_value> o valor numérico da carta
                int card_value = card_copy.value;
                // usa <card_value> para acessar a posição no array 
                //(valor numperico da carta -> índice no array)
                data[card_value].Add(card_copy); // adiciona a carta na lista específica
            }
        } // fim do método <get_histogram>
    } // fim da classe <Histogram>
}// fim do namespace <structs.controller>

//pseudocódigo
/********************************************************************************************
separa as cartas nas listas pelo array
a decisão de qual posição a carta vai no array se dá pelo seu valor numérico
uma carta de valor numérico 6, vai na lista que se encontra no ídice [6]
separação:
     1 - para cada carta na lista faça:
        1.1 armazenar o valor numérico da carta em uma var aux
        1.2 criar uma cópia da carta
        1.3 adiciona a cópia da carta na lista que estiver na posição de mesmo valor em aux
    end do
split_end
*********************************************************************************************/