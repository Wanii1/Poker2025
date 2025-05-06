/// <summary>
/// Enumeração para representar naipes de cartas.
/// </summary>
/// <author>m4rc3lo</author>
/// <created>2025-04-26</created>namespace poker_2025.model;
/// <summary>
/// Define e padroniza os nomes de naipes.
/// </summary>
public enum Suit
{
    Hearts,     // ♥ 
    Diamonds,   // ♦ 
    Clubs,      // ♣ 
    Spades      // ♠
}

/// <summary>
/// Classe auxiliar para formatar cartas em strings, para mostrar no terminal.
/// </summary>
/// <param name="v">Para o valor numérico da carta.</param>
/// <param name="s">Para o naipe da carta.</param>
/// <param name="t">Para o status: true na mesa, false na mão do jogador </param>
public static class SuitExtensions
{

    /// <summary>
    /// Método para converter o tipo do naipe em síbolo.
    /// </summary>
    /// <param name="suit">Tipo Suit do naipe específico.</param>
    public static char to_symbol(this Suit suit)
    {
        return suit switch
        {
            Suit.Hearts   => '\u2665', // ♥
            Suit.Diamonds => '\u2666', // ♦
            Suit.Clubs    => '\u2663', // ♣
            Suit.Spades   => '\u2660', // ♠
            _ => '?'
        };
    }
    
    /// <summary>
    /// Método para converter o tipo do naipe em texto direto.
    /// </summary>
    /// <param name="suit">Tipo Suit do naipe específico.</param>
    public static string to_friendly_name(this Suit suit)
    {
        return suit switch
        {
            Suit.Hearts   => "Hearts",
            Suit.Diamonds => "Diamonds",
            Suit.Clubs    => "Clubs",
            Suit.Spades   => "Spades",
            _ => "Desconhecido"
        };
    }
}