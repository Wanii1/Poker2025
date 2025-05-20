using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;

public class Pair : Hands
{
    int count1 = 0;
    public Pair(List<Card> cards) : base(cards) { }

    public override bool find()
    {
        List<Card> card_tmp = new List<Card>();

        for (int i = 13; i > 0; i--)
        {
            if (histogram.data[i].Count >= 2)
            {
                var card_count = histogram.data[i].Count;
                for (int c = 0; c < card_count; c++)
                {
                    card_tmp.Add(histogram.data[i][c]);
                }
            }
            foreach (Card c in card_tmp)
            {
                if (!c.on_table)
                {
                    count1++;
                    break;
                }

            }
            if (count1 == 0) card_tmp.Clear(); 
        }
        if (count1 >= 1)
        {
            hand_find = new List<Card>(card_tmp);
            return true;
        }
        return false;
    }
}