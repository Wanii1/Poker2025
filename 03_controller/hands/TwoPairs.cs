using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;

public class TwoPairs : Hands
{
    public TwoPairs(List<Card> cards) : base(cards) { }

    public override bool find()
    {

        int count1 = 0;

        List<Card> pairs = new List<Card>();
        List<Card> hand = new List<Card>();
        List<int> index = new List<int>();

        for (int i = 0; i < 13; i++)
        {
            int card_count = histogram.data[i].Count;
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
                continue;
            }

        }

        if (count1 <= 1) return false;
        else
        {
            
            foreach (int c in index)
            {
                for (int i = 0; i < 2; i++)
                {
                    hand.Add(histogram.data[c][i]);
                }
            }
            hand_find = new List<Card>(hand);
            return true;
        }
    }
}