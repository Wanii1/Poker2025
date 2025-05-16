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

        List<Card> cards = Load.load_hand();
        Royal royal = new Royal(cards);
        StraightFlush straightFlush = new StraightFlush(cards);
        FullHouse fullHouse = new FullHouse(cards);
        Flush flush = new Flush(cards);

        bool is_royal = royal.find(), is_full_house = fullHouse.find(), is_straight_flush = straightFlush.find();
        bool is_flush = flush.find();

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
        else
        {
            Console.WriteLine("Mão não Encontrada: precione uma tecla par mostrar");
            Console.ReadKey();
            Show.show_cards(cards);
        }
    }
}