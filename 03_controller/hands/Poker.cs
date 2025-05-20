using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;

/// <summary> 
/// Classe que reconhece a jogada Poker(Four of a Kind) do Poker.
/// Poker: quatro cartas do mesmo valor.
/// Wanii1 2025-05-16
/// </summary>
public class Poker : Hands
{
    public Poker(List<Card> cards) : base(cards) { }

    public override bool find()
    {
        int count1 = 0;
        //Lista final a ser enviada.
        List<Card> four_kind = new List<Card>();

        //Procuramos inversamente no histograma pela quadra com maior valor.
        for (int i = 13; i > 0; i--)
        {
            if (histogram.data[i].Count == 4)
            {
                //Para cada carta na posição verificamos se ela é do player, independente disso adicionamos na lista de quadra.
                for (int c = 0; c < 4; c++)
                {
                    if (!histogram.data[i][c].on_table) count1++;
                    four_kind.Add(histogram.data[i][c]);
                }
            }
            //Caso haja qualquer outra posição com menos de 4 cartas vemos se há uma do jogador, se houver adicionamos a lista também.
            else
            {
                int card_count = histogram.data[i].Count;
                for (int c = 0; c < card_count; c++)
                {
                    if (!histogram.data[i][c].on_table) four_kind.Add(histogram.data[i][c]);
                }
            }

        }
        //Se na quadra houver ao menos uma carta do jogador retornamos como true e fornecemos a lista de cartas.
        if (count1 >= 1)
        {
            hand_find = new List<Card>(four_kind);
            return true;
        }
        return false;
    }
}