using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;


/// <summary> 
/// Classe que reconhece a jogada Two Pairs.
/// Two Pairs: Jogada de dois pares de par.
/// Wanii1 2025-05-19
/// </summary>
public class TwoPairs : Hands
{
    public TwoPairs(List<Card> cards) : base(cards) { }

    public override bool find()
    {

        int count1 = 0; //Contador para o numeros de pares do jogador
        int count2 = 0; //Contador para o numero de pares.


        List<Card> pairs = new List<Card>(); //Lista dos pares.
        List<Card> hand = new List<Card>(); //Lista final a ser enviada
        List<int> index = new List<int>(); //Lista dos valores das cartas do jogador para serem verificadas depois.


        //procuramos no histograma por pares.
        for (int i = 0; i < 13; i++)
        {
            int card_count = histogram.data[i].Count;
            //Se houver mais de duas cartas numa posição verificamos se uma delas é do jogador.
            //Se for adicionamos mais 1 no contador e adicionamos seu valor na lista de valores.
            if (histogram.data[i].Count >= 2)
            {
                for (int card = 0; card < card_count; card++)
                {
                    if (!histogram.data[i][card].on_table)
                    {
                        index.Add(i);
                        count1++;
                    }
                    pairs.Add(histogram.data[i][card]);
                }
                count2++;
                continue;
            }

        }
        //Se não houver ao menos dois pares ou duas cartas do jogador saimos do codigo.
        if (count2 < 2 || count1 <= 1) return false;
        //Se houver mais de 2 pares e ao menos duas cartas do jogador nesses pares seguimos.
        else
        {

            foreach (int c in index)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (!hand.Contains(histogram.data[c][i]))
                        hand.Add(histogram.data[c][i]);
                }
            }
            hand_find = new List<Card>(hand);
            return true;
        }
    }
}