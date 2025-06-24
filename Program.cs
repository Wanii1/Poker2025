using System.Diagnostics.Metrics;

/// <summary>
/// Representa uma pessoa no sistema.
/// </summary>
/// <author>m4rc3lo</author>
/// <created>2025-04-26</created>

namespace poker_2025;
using poker_2025.model;
using poker_2025.view;
using poker_2025.controller;
using poker_2025.controller.hands;
using System.Runtime.CompilerServices;
using System.Formats.Asn1;
using poker_2025.cards;

/// <summary> 
/// Classe que define o ponto de entrada do projeto.
/// Reconhecimento das mãos de poker (texas hold'em).
/// m4rc3lo 2025-04-26
/// </summary>
class Program
{
    /// <summary>
    /// Método principal que define a execução do projeto.
    /// </summary>
    /// <param name="args">
    /// array de argumentos para a execução (dotnet run).
    /// </param>
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("RECONHECIMENTO DAS MÃOS DE POKER - 2025");
        Console.WriteLine("MODALIDADE CONSIDERADA: TEXAS HOLD'EM");

        List<Card> cards = Dealer.DealHand(); //Puxamos as cartas do round.
        //Separamos elas em duas pilhas diferentes
        List<Card> player_one_cards = Dealer.DealPlayerOne(cards); 
        List<Card> player_two_cards = Dealer.DealPlayerTwo(cards);

        //Para cada player vemos as 10 possiveis mãos e retornamos seu valor, sua lista, e uma string informando a mão achada.
        var player_one_hand = FindHand(player_one_cards);
        var player_two_hand = FindHand(player_two_cards);
        //Para quando o jogador 1 vencer.
        if (player_one_hand.value > player_two_hand.value)
        {
            Console.WriteLine("Jogador 1 venceu!!\nPrecione uma tecla para mostrar as cartas da rodada:");
            Console.ReadKey();
            Console.WriteLine(player_one_hand.name + " Encontrado!!");
            Show.show_cards(player_one_hand.cards);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("O jogador 2 tirou um " + player_two_hand.name + "\nMais sorte na proxima!");

        }
        //Para quando o jogador 2 vencer.
        else if (player_two_hand.value > player_one_hand.value)
        {
            Console.WriteLine("Jogador 2 venceu!!\nPrecione uma tecla para mostrar as cartas da rodada:");
            Console.ReadKey();
            Console.WriteLine(player_two_hand.name + " Encontrado!!");
            Show.show_cards(player_two_hand.cards);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("O jogador 1 tirou um " + player_one_hand.name + "\nMais sorte na proxima!");


        }
        //Para quando há empate.
        else
        {
            Console.WriteLine("Espera...\nUm empate? Sério?");
            Console.WriteLine("Ambos o jogadores tiraram um " + player_one_hand.name + "!!");
            Show.show_cards(cards);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Mais sorte na proxima!");
        }
        
    }
    /// <summary>
    /// Método para achar as mãos da rodada.
    /// </summary>
    /// <param name="value"> Valor da mão. </param>
    /// <param name="cards"> Lista a ser analizada. </param>
    /// <param name="name"> Nome da mão. </param>
    static (int value, List<Card> cards, string name) FindHand(List<Card> player_hand)
    {
        int hand_value = 0;
        Royal royal = new Royal(player_hand);
        StraightFlush straightFlush = new StraightFlush(player_hand);
        Poker poker = new Poker(player_hand);
        FullHouse fullHouse = new FullHouse(player_hand);
        Flush flush = new Flush(player_hand);
        Straight straight = new Straight(player_hand);
        ThreeKind threeKind = new ThreeKind(player_hand);
        TwoPairs twoPairs = new TwoPairs(player_hand);
        Pair pair = new Pair(player_hand);
        HighCard highCard = new HighCard(player_hand);

        bool is_royal = royal.find(), is_straight_flush = straightFlush.find(), is_poker = poker.find();
        bool is_full_house = fullHouse.find(), is_flush = flush.find(), is_straight = straight.find();
        bool is_three_kind = threeKind.find(), is_two_pairs = twoPairs.find(), is_pair = pair.find();
        bool is_high_card = highCard.find();

        if (is_royal)
        {
            return (10, royal.hand_find, "Royal Straight Flush");
        }
        else if (is_straight_flush)
        {
            return (9, straightFlush.hand_find, "Straight Flush");
        }
        else if (is_poker)
        {
            return (8, poker.hand_find, "Poker!! (Aka Quadra)");
        }
        else if (is_full_house)
        {
            return (7, fullHouse.hand_find, "Full House");

        }
        else if (is_flush)
        {
            return (6, flush.hand_find, "Flush");
        }
        else if (is_straight)
        {
            return (5, straight.hand_find, "Straight");
        }
        else if (is_three_kind)
        {
            return (4, threeKind.hand_find, "Trinca");
        }
        else if (is_two_pairs)
        {
            return (3, twoPairs.hand_find, "Dois Pares");
        }
        else if (is_pair)
        {
            return (2, pair.hand_find, "Par");
        }
        else if (is_high_card)
        {
            return (1, highCard.hand_find, "Carta alta");
        }
        else
        {
            return (hand_value, player_hand, "Nada encontrado  :(");
        }
    }
}