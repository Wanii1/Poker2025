using poker_2025.model;

namespace poker_2025.controller;
/// <summary>
/// Contrato para objetos que podem “falar”.
/// </summary>
public abstract class Hands
{
    /// <summary>
    /// Cópia da lista de cartas de entrada.
    /// </summary>
    protected List<Card>? cards_; 
    
    /// <summary>
    /// Histograma relacionado a lista de entrada.
    /// </summary>
    protected Histogram histogram{ get; }
    
    /// <summary>
    /// Se a mão específica for encontra, fica armazenada aqui.
    /// A lista fica vazia no caso contrário.
    /// </summary>
    public List<Card> hand_find{get; set;}
    
    /// <summary>
    /// Método a ser implementado nas classes específicas.
    /// </summary>
    public Hands(List<Card> cards)
    {
        cards_ = new List<Card>();
        foreach (var card in cards)
            cards_.Add(new Card(card)); 
        
        histogram = new Histogram(cards_);
        histogram.make_histogram();
        hand_find = new List<Card>();
    }
    
    /// <summary>
    /// Método a ser implementado nas classes específicas.
    /// </summary>
    public abstract bool find();
}
