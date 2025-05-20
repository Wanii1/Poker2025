using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;


/// <summary> 
/// Classe que reconhece a jogada Pair do Poker.
/// Pair: o par de cartas mais alto do jogador.
/// Wanii1 2025-05-20
/// </summary>
public class Pair : Hands
{   

    int count1 = 0;
    public Pair(List<Card> cards) : base(cards) { }

    public override bool find()
    {
        //Lista Final a ser enviada.
        List<Card> card_tmp = new List<Card>();


        //Procuramos inversamente no histograma por pares. 
        for (int i = 13; i > 0; i--)
        {
            //Nas posições que houverem duas ou mais cartas vemos cada carta e a adicionamos na lista de cartas.
            if (histogram.data[i].Count >= 2)
            {
                var card_count = histogram.data[i].Count;
                for (int c = 0; c < card_count; c++)
                {
                    card_tmp.Add(histogram.data[i][c]);
                }
                //Para cada carta na lista de cartas verificamos se há uma carta do jogador, se houver adicionamos um contador.
                foreach (Card c in card_tmp)
                {
                    if (!c.on_table)
                    {
                        count1++;
                        break;
                    }

                }
            }
            //Se no final do loop não houver cartas do jogador na lista a limpamos para o proximo loop.
            if (count1 == 0) card_tmp.Clear();
        }
        //Se houver carta do jogador retornamos true e fornecemos a lista com o par.
        if (count1 >= 1)
        {
            hand_find = new List<Card>(card_tmp);
            return true;
        }
        return false;
    }
}