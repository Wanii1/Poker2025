using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
        int count2 = 0;
        int count3 = 0;
        int card_num = 0;
        int [] values = [0,0,0,0,0];

        List<Card> card_tmp = new List<Card>();


        for (int i = 0; i < 13; i++)
        {
            if (histogram.data[i].Count == 1 && count1 == 0)
            {
                values[count1] = i;
                count1++;
                card_num = i;
                Console.WriteLine("Goated");
                Console.ReadKey();
                continue;
            }

            int difference = i - card_num;
            if (histogram.data[i].Count > 0 && difference == 1)
            {
                Console.WriteLine("Goated");
                Console.ReadKey();
                naipe = histogram.data[i][0].suit.ToString();
                values[count1] = i;
                card_num = i;
                count1++;
                
            }
           if (histogram.data[i].Count > 0 && difference != 1)
            {
                values[0] = i;
                count1 = 1;
                card_num = i;
                continue;
            }
            if (count1 >= 5) break;

        }

        // Se tiver uma sequencia verifica se elas são do mesmo naipe e as separa.
        if (count1 >= 5){
            for (int c = 0; c < 5; c++)
            {   
                Suit s = Enum.Parse<Suit>(naipe);
                if (histogram.data[values[c]].Count == 1)
                {
                    if(histogram.data[values[c]][0].suit == s)
                    {
                        card_tmp.Add(new Card(histogram.data[values[c]][0]));
                    }
                }
                else
                {
                    int card_count = histogram.data[values[c]].Count;
                    for (int x = 0; x < card_count; x++)
                    {
                        if(histogram.data[values[c]][x].suit == s)
                        {
                            count2++;
                            card_tmp.Add(new Card(histogram.data[values[c]][x]));
                        }
                    }
                }
            }
        }

        foreach (Card c in card_tmp){
            if (!c.on_table){
                count3++;
            }
        }
        if (count3 != 0 && count2 == 5)
        {
            hand_find = new List<Card>(card_tmp);
            return true;
        }

        return false;
    }
}