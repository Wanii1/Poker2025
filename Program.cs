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
        #region testes
        /*
        List<Card> cards = Load.load_hand();
        List<Card>[] hitogram = Histogram.get_histogram(cards);

        Console.WriteLine("Pressione uma tecla para ver a lista de carta carregadas.");
        Console.ReadKey();
        Show.show_cards(cards);

        Console.WriteLine("Pressione uma tecla para ver o histograma relacionado.");
        Console.ReadKey();
        Show.show_histogram(hitogram);
        */
        #endregion

        List<Card> cards = Dealer.deal_hand();
        List<Card> player_one_card = Dealer.deal_player_one(cards);
        List<Card> player_two_card = Dealer.deal_player_two(cards);

        Royal royal = new Royal(cards);
        StraightFlush straightFlush = new StraightFlush(cards);
        Poker poker = new Poker(cards);
        FullHouse fullHouse = new FullHouse(cards);
        Flush flush = new Flush(cards);
        Straight straight = new Straight(cards);
        ThreeKind threeKind = new ThreeKind(cards);
        TwoPairs twoPairs = new TwoPairs(cards);
        Pair pair = new Pair(cards);
        HighCard highCard = new HighCard(cards);

        bool is_royal = royal.find(),is_straight_flush = straightFlush.find(),is_poker = poker.find();
        bool is_full_house = fullHouse.find(), is_flush = flush.find(), is_straight = straight.find();
        bool is_three_kind = threeKind.find(), is_two_pairs = twoPairs.find(), is_pair = pair.find();
        bool is_high_card = highCard.find();

        if (is_royal)
        {
            Console.WriteLine("Royal Encontrado: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(royal.hand_find);
        }
        else if (is_straight_flush)
        {
            Console.WriteLine("Straight Flush Encontrado: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(straightFlush.hand_find);
        }
        else if (is_poker)
        {
            Console.WriteLine("Quadra Encontrada: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(poker.hand_find);
        }
        else if (is_full_house)
        {
            Console.WriteLine("Full House encontrado: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(fullHouse.hand_find);

        }
        else if (is_flush)
        {
            Console.WriteLine("Flush encontrado: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(flush.hand_find);
        }
        else if (is_straight)
        {
            Console.WriteLine("Straight encontrado: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(straight.hand_find);   
        }
        else if (is_three_kind)
        {
            Console.WriteLine("Trinca encontrado: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(threeKind.hand_find);
        }
        else if (is_two_pairs)
        {
            Console.WriteLine("Two Pairs encontrado: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(twoPairs.hand_find);
        }
        else if (is_pair)
        {
            Console.WriteLine("Pair encontrado: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(pair.hand_find);
        }
        else if (is_high_card)
        {
            Console.WriteLine("High Card encontrado: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(highCard.hand_find);
        }
        else
        {
            Console.WriteLine("Mão não Encontrada: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(cards);
        }
    }
}