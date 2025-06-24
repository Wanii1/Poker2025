
using System;
using System.Collections.Generic;
using poker_2025.model;
namespace poker_2025.cards;

public class Deck
{
    public static List<Card> get_cards()
    {
        List<Card> deck = new List<Card>(); 
        for (int s = 0; s < 4; s++)
        {
            for (int v = 0; v < 13; v++)
            {
                Card c = new Card(v, (Suit)s, true, 0);
                deck.Add(c);
            }
        }

        return deck; 
    }
}