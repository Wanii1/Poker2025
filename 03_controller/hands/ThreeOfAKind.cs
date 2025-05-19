using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;

public class ThreeKind: Hands
{
    public ThreeKind(List<Card> cards) : base(cards) { }

    public override bool find()
    {
        int count1 = 0;
        List<Card> three_kind = new List<Card>();

        for (int i = 13; i > 0; i--)
        {
            if (histogram.data[i].Count == 3)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (!histogram.data[i][c].on_table) count1++;
                    three_kind.Add(histogram.data[i][c]);
                }
                foreach (Card c in three_kind)
                {
                    if (!c.on_table)
                    {
                        count1++;
                        break;
                    }

                }
            }
            if (count1 < 1) three_kind.Clear();

        }
        if (count1 >= 1)
        {
            hand_find = new List<Card>(three_kind);
            return true;
        }
        return false;
    }
}