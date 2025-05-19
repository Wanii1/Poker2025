using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;

public class Poker : Hands
{
    public Poker(List<Card> cards) : base(cards) { }

    public override bool find()
    {
        int count1 = 0;
        List<Card> four_kind = new List<Card>();

        for (int i = 13; i > 0; i--)
        {
            if (histogram.data[i].Count == 4)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (!histogram.data[i][c].on_table) count1++;
                    four_kind.Add(histogram.data[i][c]);
                }
            }
            else
            {
                int card_count = histogram.data[i].Count;
                for (int c = 0; c < card_count; c++)
                { 
                    if (!histogram.data[i][c].on_table)four_kind.Add(histogram.data[i][c]);
                }
            }

        }
        if (count1 >= 1)
        {
            hand_find = new List<Card>(four_kind);
            return true;
        }
        return false;
    }
}