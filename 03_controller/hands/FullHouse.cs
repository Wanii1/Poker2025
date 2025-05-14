using System.Text.RegularExpressions;
using poker_2025.model;

namespace poker_2025.controller.hands;

public class FullHouse : Hands
{
    public FullHouse(List<Card> cards) : base(cards) {}

    public override bool find()
    {
        int player_card_count = 0;

        int count1 = 0;
        int count2 = 0;
        
        List<Card> three_cards = new List<Card>();
        List<Card> pair_cards = new List<Card>();
        List<Card> hand_tmp = new List<Card>();

        for (int i = 0; i < 13; i++)
        {
            if (histogram.data[i].Count == 3)
            {
                for(int x = 0; x < 3; x++){
                    count1++;
                    three_cards.Add(new Card(histogram.data[i][x]));
                     hand_tmp.Add(new Card(histogram.data[i][x]));
                }
            }
            if (histogram.data[i].Count == 2)
            {
                for (int x = 0; x < 2; x++)
                {
                    count2++;
                    pair_cards.Add(new Card(histogram.data[i][x]));
                     hand_tmp.Add(new Card(histogram.data[i][x]));
                }
            }
        }

       foreach(Card c in three_cards)
       {
        if (!c.on_table)
            player_card_count++;
       }
       foreach(Card c in pair_cards)
       {
        if (!c.on_table)
            player_card_count++;
       }

       if (player_card_count > 0 && count1 == 3 && count2 == 2)
       {
            hand_find = new List<Card>(hand_tmp);
            return true;
       }
        return false;

    }
}
