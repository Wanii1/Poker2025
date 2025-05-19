using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;

public class Flush : Hands
{
    public Flush(List<Card> cards) : base(cards){}

    public override bool find()
    {
        int count1 = 0, count2 = 0;
        List<Card> player_cards = new List<Card>();
        List<Card> table_cards = new List<Card>();
        List<Card> card_tmp = new List<Card>();
        List<int> index = new List<int>();
        for (int i = 0; i < 13; i++)
        {
            if (histogram.data[i].Count > 1)
            {
                var card_count = histogram.data[i].Count;
                for (int x = 0; x < card_count; x++)
                {
                    Console.Write(histogram.data[i][x]);
                    Console.ReadKey();
                    if (!histogram.data[i][x].on_table) player_cards.Add(new Card(histogram.data[i][x]));
                    else table_cards.Add(new Card(histogram.data[i][0]));
                }
            }
            if (histogram.data[i].Count == 1)
            {
                if (!histogram.data[i][0].on_table) player_cards.Add(new Card(histogram.data[i][0]));
                else table_cards.Add(new Card(histogram.data[i][0]));

            }
        }

        foreach (Card c in player_cards)
        {
            Suit s = c.suit;
            card_tmp.Add(new Card(c));
            index.Add(c.value);
            count1 = 1;
            foreach (Card t in table_cards)
            {
                if (t.suit == s)
                {
                    card_tmp.Add(new Card(t));
                    index.Add(t.value);
                    count1++;
                }
            }
            if (count1 >= 5) break;
            else
            {
                card_tmp.Clear();
                index.Clear();
            }
        }
        int last_value = 0;
        foreach (int idx in index)
        {
            if (last_value == 0)
            {
                count2++;
                last_value = idx;
                continue;
            } 
            int difference = last_value - idx;
            if (difference <= 1) count2++;

            last_value = idx;
        }
        if (count2 < 5 && count1 >= 5)
        {
            hand_find = new List<Card>(card_tmp);
            return true;
        }
        return false;
    
    }
}