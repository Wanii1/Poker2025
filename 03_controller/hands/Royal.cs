using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;


/// <summary> 
/// Classe que reconhece a jogada Royal do Poker.
/// Royal: Cartas em sequência do mesmo naipe sendo de 10 até 13 mais o Às.
/// m4rc3lo 2025-04-26
/// </summary>
public class Royal : Hands
{
    public Royal(List<Card> cards) : base(cards) { }


    public override bool find()
    {
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        bool palyer_card = false; //Tsk tsk tsk...
        int[] values = [10, 11, 12, 13, 1];
        //Suit naipe;
        List<Card> cards_tmp = new List<Card>();

        // verifica se existem cartas nas posições 
        for (int i = 0; i < 5; i++)
        {
            if (histogram.data[values[i]].Count > 0)
                count1++;
        }


        if (count1 == 5)
        {// existem cartas nas posições esperadas

            //identifica a primeira carta individual na sequencia
            // separa o naipe e interrompe o for
            string naipe = "";
            for (int i = 0; i < 5; i++)
            {
                if (histogram.data[values[i]].Count == 1)
                {
                    naipe = histogram.data[values[i]][0].suit.ToString();
                    i = 5;
                }
            }

            // separa as cartas de mesmo naipe
            for (int i = 0; i < 5; i++)
            {
                if (histogram.data[values[i]].Count == 1)
                {
                    cards_tmp.Add(new Card(histogram.data[values[i]][0]));
                    count2++;
                }
                else
                {
                    Suit s = Enum.Parse<Suit>(naipe);
                    foreach (Card c in histogram.data[values[i]])
                    {
                        if (c.suit == s)
                        {
                            cards_tmp.Add(new Card(c));
                            count2++;
                        }
                    }
                }
            }
            //Se houver 5 cartas do mesmo naipe verifica se elas são da primeira carta na sequencia.
            if (count2 == 5)
            {
                foreach (Card c in cards_tmp)
                {
                    if (c.suit == Enum.Parse<Suit>(naipe))
                    {
                        count3++;
                        if (!c.on_table)
                        {
                            palyer_card = true;
                        }
                    }
                }
            }
            //Se todas forem do mesmo naipe e se houver uma carta do "palyer" retornamos como true.
            if (count3++ == 5 && palyer_card)
            {
                hand_find = new List<Card>(cards_tmp);
                return true;
            }
            else
                return false;
        }
        else
        {
            return false;
        }
    }

}
