using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;


/// <summary> 
/// Classe que reconhece a jogada StraightFlush do Poker.
/// Royal: Cartas em sequência do mesmo naipe sem ser de 10 até 13 mais o Às.
/// Wanii1 2025-05-13
/// </summary>
public class StraightFlush : Hands
{
    public StraightFlush(List<Card> cards) : base(cards) { }


    public override bool find()
    {

        //O naipe da primeira carta da sequencia.
        String naipe = "";
        int count1 = 0; //Contador para o numero de cartas.
        int count2 = 0; 
        int count3 = 0;
        int card_num = 0; //Integer para salvar a ultima carta olhada
        //Array de posições a serem checadas por sequencia.
        int[] values = [0, 0, 0, 0, 0];


        //Lista final a ser enviada.
        List<Card> card_tmp = new List<Card>();

        //Procuramos no histogramas por alguns casos.
        for (int i = 0; i < 13; i++)
        {
            //Se for a primeira carta encontrada salvamos seu valor e pulando para o proximo loop
            if (histogram.data[i].Count == 1 && count1 == 0)
            {
                values[count1] = i;
                count1++;
                card_num = i;
                continue;
            }
            //Comparamos a cartual atual para a anterior para vermos se há uma diferença maior de 1.
            int difference = i - card_num;

            //Se houver cartas na posição e a diferença for igual salvamos o naipe da carta e adiconamos seu valor na lista.
            if (histogram.data[i].Count > 0 && difference == 1)
            {
                naipe = histogram.data[i][0].suit.ToString();
                values[count1] = i;
                card_num = i;
                count1++;

            }
            //Se ha diferençar for maior que um salvamos essa carta como primeira na sequencia e pulamos para o proximo loop.
            if (histogram.data[i].Count > 0 && difference != 1)
            {
                values[0] = i;
                count1 = 1;
                card_num = i;
                continue;
            }
            //Se acharmos 5 cartas em sequencia saimos do loop.
            if (count1 >= 5) break;

        }

        // Se tiver uma sequencia verifica se elas são do mesmo naipe e as separa.
        if (count1 >= 5)
        {
            for (int c = 0; c < 5; c++)
            {
                Suit s = Enum.Parse<Suit>(naipe);
                if (histogram.data[values[c]].Count == 1)
                {
                    if (histogram.data[values[c]][0].suit == s)
                    {
                        card_tmp.Add(new Card(histogram.data[values[c]][0]));
                    }
                }
                else
                {
                    int card_count = histogram.data[values[c]].Count;
                    for (int x = 0; x < card_count; x++)
                    {
                        if (histogram.data[values[c]][x].suit == s)
                        {
                            count2++;
                            card_tmp.Add(new Card(histogram.data[values[c]][x]));
                        }
                    }
                }
            }
        }
        //Na lista final procuramos por cartas do jogador.
        foreach (Card c in card_tmp)
        {
            if (!c.on_table)
            {
                count3++;
            }
        }
        //Se houver carta do jogador e todas forem do mesmo naipe, retornamos como true e enviamos a lista de cartas.
        if (count3 != 0 && count2 == 5)
        {
            hand_find = new List<Card>(card_tmp);
            return true;
        }

        return false;
    }
}