using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;

public class HighCard : Hands
{
    
    public HighCard(List<Card> cards) : base(cards) { }

    public override bool find()
    {

        List<Card> card_tmp = new List<Card>();

        if (histogram.data[1].Count == 1)
        {
            if (!histogram.data[1][0].on_table)
            {
                card_tmp.Add(histogram.data[1][0]);
                hand_find = new List<Card>(card_tmp);
                return true;
            }
        }
        for (int i = 13; i <= 2; i--)
        {
            var card_count = histogram.data[i].Count;
            if (histogram.data[i].Count > 0)
            {
                for (int c = 0; c < card_count; c++)
                {
                    if (!histogram.data[i][c].on_table)
                    {
                        card_tmp.Clear();
                        card_tmp.Add(histogram.data[i][c]);
                        hand_find = new List<Card>(card_tmp);
                        break;
                    }
                    
                }
            }
        }
        return true;
    }
}
