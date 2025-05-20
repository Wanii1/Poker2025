using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;

/// <summary> 
/// Classe que reconhece a jogada Three of a Kind do Poker.
/// Three of a Kind: Jogada de três cartas do mesmo valor.
/// Wanii1 2025-05-19
/// </summary>
public class ThreeKind: Hands
{
    public ThreeKind(List<Card> cards) : base(cards) { }

    public override bool find()
    {
        int count1 = 0;

        //Lista final a ser enviada.
        List<Card> three_kind = new List<Card>();


        //Procuramos no histograma por Trincas.
        for (int i = 13; i > 0; i--)
        {
            //No caso de um trinca verificamos primeiro se nela há uma carta do jogador.
            //Idependente se houver adicionamos a trinca na lista.
            if (histogram.data[i].Count == 3)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (!histogram.data[i][c].on_table) count1++;
                    three_kind.Add(histogram.data[i][c]);
                }
                //Apos verificamos na lista de se há cartas do jogador. Se houver  saimos do loop.
                foreach (Card c in three_kind)
                {
                    if (!c.on_table)
                    {
                        count1++;
                        break;
                    }

                }
            }
            //Se não houver carta do jogador na trinca, limpamos a lista para o proximo loop.
            if (count1 < 1) three_kind.Clear();

        }
        //Verificamos se ao menos uma carta do jogador, se houve retornamos como true e enviamos a lista.
        if (count1 >= 1)
        {
            hand_find = new List<Card>(three_kind);
            return true;
        }
        return false;
    }
}