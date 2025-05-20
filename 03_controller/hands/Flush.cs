using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Windows.Markup;
using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;


/// <summary> 
/// Classe que reconhece a jogada Flush do Poker.
/// Flush: cartas do mesmo naipe sem estar em sequência.
/// <author>Wanii1</author> 2025-05-16
/// </summary>
public class Flush : Hands
{
    public Flush(List<Card> cards) : base(cards) { }

    public override bool find()
    {
        int count1 = 0, count2 = 0;
        //Cartas do Jogador.
        List<Card> player_cards = new List<Card>(); 
        //Cartas da Mesa.
        List<Card> table_cards = new List<Card>(); 
        //Lista final das cartas a serem enviadas.
        List<Card> card_tmp = new List<Card>();
        //Lista de posições do histograma para comparar o naipe.
        List<int> index = new List<int>();


        //Procuramos posições que tenham mais de uma carta ou exatamente uma carta.
        for (int i = 0; i < 13; i++)
        {
            //No caso de mais de um carta em uma posição, pegamos o total de cartas e separamos por cartas do jogador e da mesa.
            if (histogram.data[i].Count > 1)
            {

                var card_count = histogram.data[i].Count;
                for (int x = 0; x < card_count; x++)
                {
                    if (!histogram.data[i][x].on_table) player_cards.Add(new Card(histogram.data[i][x]));
                    else table_cards.Add(new Card(histogram.data[i][0]));
                }
            }
            //Caso haja apenas uma carta a deixamos separada também na listas de cartas do jogador ou da mesa.
            if (histogram.data[i].Count == 1)
            {
                if (!histogram.data[i][0].on_table) player_cards.Add(new Card(histogram.data[i][0]));
                else table_cards.Add(new Card(histogram.data[i][0]));

            }
        }


        //Para cada carta do jogador verificamos se o naipe é o mesmo com as outras.
        foreach (Card c in player_cards)
        {

            //Naipe da carta.
            Suit s = c.suit;
            //Adcionamos a carta na mão vencedora.
            card_tmp.Add(new Card(c));
            //Adicionamos os valores nessa lista para a checagem de sequencia depois.
            index.Add(c.value);
            count1 = 1;
            //comparamos o naipe da carta do jogador com cada carta da mesa, se for o mesmo adcionamos o contador.
            //Se houver mais ou cinco cartas do mesmo naipe, seguimos em frente.
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
                //Limpamos as listas para o proximo loop.
                card_tmp.Clear();
                index.Clear();
            }
        }

        //Comparamos cada valor da lista Index com o anterior, se a diferença for menos ou igual há um adcionamos mais um no contador.
        //Se no final houver menos de 5 no contador, há um flush.
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
            //Retornamos true e fornecemos a lista de cartas.
            hand_find = new List<Card>(card_tmp);
            return true;
        }
        return false;

    }
}