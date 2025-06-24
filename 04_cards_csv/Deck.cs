
using System;
using System.Collections.Generic;
using poker_2025.model;
namespace poker_2025.cards;

/// <summary> 
/// Essa classe gera um baralho de 52 cartas.
/// Wanii1 2025-06-23
/// </summary>
public class Deck
{
    /// <summary>
    /// Método que gera o baralho para ser usado pela classe Dealer.
    /// </summary>
    public static List<Card> GetCards()
    {
        List<Card> deck = new List<Card>(); //Cria uma nova lista para guardar o baralho.
        for (int s = 0; s < 4; s++) //Para cada naipe.
        {
            for (int v = 1; v < 13; v++) //Para cada valor de 1 a 13. 
            {
                Card c = new Card(v, (Suit)s, true, 0); //Cria uma carta.
                deck.Add(c); //Adiciona na lista.
            }
        }

        return deck;
    }
}