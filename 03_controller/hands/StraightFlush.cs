using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;

public class StraightFlush : Hands
{
    public StraightFlush (List<Card> cards) : base(cards){}


    public override bool find()
    {
        String naipe = "";
        int count1 = 0;
        int player_card_count = 0;
        List<Card> hand_tmp = new List<Card>();
        List <Card> card_tmp = new List<Card>();
        for (int i = 0; i > 13; i++)
        {
            if (histogram.data[i].Count > 0){
                for (int c = 0; c > 4; c++)
                {
                    hand_tmp.Add(new Card(histogram.data[i][c]));
                }

            }
        }

        foreach(Card c in hand_tmp){
            if (count1 == 0){
                naipe = c.suit.ToString();
                count1++;
                continue;
            }
            Suit s = Enum.Parse<Suit>(naipe);
            if (count1 <= 2 && c.suit != s){
                count1 = 1;
                naipe = c.suit.ToString();
                continue;
            }
            if (c.suit == s){
                count1++;
                card_tmp.Add(new Card(c));
            }
        }
        
        if (count1 >= 5)
        {
            foreach (Card c in card_tmp)
            {
                if (!c.on_table)
                    player_card_count++;
            }
            if (player_card_count > 1){
                hand_find = new List<Card>(hand_tmp);
                return true;
            }
        }

        return false;
    }
}