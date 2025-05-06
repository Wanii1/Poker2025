/// <summary>
/// Representa uma pessoa no sistema.
/// </summary>
/// <author>m4rc3lo</author>
/// <created>2025-04-26</created>

using System;
using System.Collections.Generic;
namespace poker_2025.model;

/// <summary>
///  Classe para representar uma entidade carta no projeto.
/// </summary>
public class Card 
{   
    /// <summary>
    /// Campos de dados que permite acesso de leituta (propriedades)
    /// Representam características que um objerto do tipo Card pode assumir.
    /// </summary>
    /// <value>suit</value>
    public Suit suit     {get;} 
    public int value     {get;}
    public bool on_table {get;}
        
    /// <summary>
    /// Construtor padrão da classe.
    /// </summary>
    /// <param name="v">Para o valor numérico da carta.</param>
    /// <param name="s">Para o naipe da carta.</param>
    /// <param name="t">Para o status: true na mesa, false na mão do jogador </param>
    public Card(int v, Suit s, bool t)
    { 
        value    = v;
        suit     = s;
        on_table = t;
    }

    /// <summary>
    /// Construtor de cópia. Cria um novo objeto distinto/independente do parâmetro passado.
    /// </summary>
    /// <param name="c">Objeto Card a ser copiado.</param>    
    public Card(Card c)
    {
        this.suit     = c.suit;
        this.value    = c.value;
        this.on_table = c.on_table;
    }

    /// <summary>
    /// Sobreescrevce o método ToString herdado de object.
    /// </summary>
    /// <returns>Retorna a representação textual da carta. ex: A ♥ Table </returns>
    public override string ToString()
    {
        string valueDisplay = value switch
        {
            1  => "A",
            11 => "J",
            12 => "Q",
            13 => "K",
            _ => value.ToString()
        };
        
        return $"{valueDisplay}\t{suit.to_symbol()}\t{(on_table ? "M" : "J")}";        
        // Alternativa mais descritiva:
        // return $"{valueDisplay} of {Suit.ToFriendlyName()} {Suit.ToSymbol()}";
    }
} // fim da struct <Card>
// fim do namespacce <structs.model>