using System;
using System.Collections.Generic;
using poker_2025.model;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Runtime.CompilerServices;
namespace poker_2025.cards;

public class Dealer
{
    public static List<Card> deal_hand()
    {
        List<Card> cards = Deck.get_cards();
        cards = GenerateRandomLoop(cards);
        List<Card> round_deck = new List<Card>();
        Stack<Card> deck = new Stack<Card>(cards);
        for(int i = 0; i < 5; i++) round_deck.Add(deck.Pop());
        for (int i = 0; i < 2; i++)
        {
            Card c = deck.Pop();
            c.on_table = false;
            c.player = 1;
               
        }
        for (int i = 0; i < 2; i++)
        {
            Card c = deck.Pop();
            c.on_table = false;
            c.player = 2;   
        }
        return cards;
    }
    public static List<Card> GenerateRandomLoop(List<Card> listToShuffle)
    {
        Random _rand = new Random();
        for (int i = listToShuffle.Count - 1; i > 0; i--)
        {
            var k = _rand.Next(i + 1);
            var value = listToShuffle[k];
            listToShuffle[k] = listToShuffle[i];
            listToShuffle[i] = value;
        }

        return listToShuffle;
    }
    public static List<Card> deal_player_one(List<Card> total_cards)
    {
        foreach 
        return something;
    }
}