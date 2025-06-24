using System;
using System.Collections.Generic;
using poker_2025.model;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Runtime.CompilerServices;
namespace poker_2025.cards;

/// <summary> 
/// Essa classe embaralha, atribui e destribui cartas.
/// Wanii1 2025-06-23
/// </summary>
public class Dealer
{
    /// <summary>
    /// Método que atribui as cartas a mesa e aos dois jogadores presentes na simulação.
    /// </summary>
    public static List<Card> DealHand()
    {
        List<Card> cards = Deck.GetCards(); //Puxamos o baralho gerado pela Classe Deck.
        cards = GenerateRandomLoop(cards); //Embaralhamos ela.
        List<Card> round_deck = new List<Card>(); //Lista de Cartas a ser enviada.
        Stack<Card> deck = new Stack<Card>(cards); //Transformamos a lista de cartas do baralho em stack para usar o método Pop.
        for (int i = 0; i < 5; i++) round_deck.Add(deck.Pop()); //Pegamos as primeiras cinco cartas, essas seram da mesa.
        for (int i = 0; i < 2; i++) //Para as proximas duas atribuimos ao jogador 1.
        {
            Card c = deck.Pop();
            c.on_table = false;
            c.player = 1;
            round_deck.Add(c);

        }
        for (int i = 0; i < 2; i++) //Para as proximas duas atribuimos ao jogador 2.
        {
            Card c = deck.Pop();
            c.on_table = false;
            c.player = 2;
            round_deck.Add(c);

        }
        return round_deck; //Fim do método, retornamos a lista de cartas da rodada.
    }
    /// <summary>
    /// Método que embaralha as cartas.
    /// Originado do code-maze.com
    /// </summary>
    public static List<Card> GenerateRandomLoop(List<Card> listToShuffle)
    {
        Random _rand = new Random(); //Criamos uma random
        for (int i = listToShuffle.Count - 1; i > 0; i--) //Pegamos o total da lista menos 1 e repitimos até que chegue ao ultimo item.
        {
            var k = _rand.Next(i + 1);  //Pegamos um valor aleatorio que seja menor que a posição atual mais 1.
            var value = listToShuffle[k];  //Pegamos uma carta desse valor aleatorio.
            //Trocamos suas posições.
            listToShuffle[k] = listToShuffle[i]; 
            listToShuffle[i] = value;
        }

        return listToShuffle; // retornamos a lista embaralhada.
    }

    /// <summary>
    /// Método que separa e tornar as cartas da mesa com as cartas do player 1.
    /// </summary>
    public static List<Card> DealPlayerOne(List<Card> total_cards)
    {
        List<Card> player_hand = new List<Card>();
        foreach (Card c in total_cards)
        {
            if (c.player == 1 || c.on_table) player_hand.Add(c);
        }
        return player_hand;
    }
    /// <summary>
    /// Método que separa e tornar as cartas da mesa com as cartas do player 2.
    /// </summary>
    public static List<Card> DealPlayerTwo(List<Card> total_cards)
    {
        List<Card> player_hand = new List<Card>();
        foreach (Card c in total_cards)
        {
            if (c.player == 2 || c.on_table) player_hand.Add(c);
        }
        return player_hand;
    }
}