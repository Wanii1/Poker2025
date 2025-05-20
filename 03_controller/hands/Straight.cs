using poker_2025.controller;
using poker_2025.model;


/// <summary> 
/// Classe que reconhece a jogada Straight do Poker.
/// Straight: Cartas em sequência sem ser do naipe.
/// Davi7 2025-05-17
/// </summary>
namespace poker_2025.controller.hands

{
    public class Straight : Hands
    {
        public Straight(List<Card> cards) : base(cards) { }

        public override bool find()
        {
            List<Card> cards_tmp = new List<Card>();
            bool player_card = false;

            // Cria um array booleano para marcar os valores presentes (A = 1 ou 14)
            bool[] values_present = new bool[15]; // Índices de 1 a 14 (14 será para o Ás alto)

            for (int i = 1; i <= 13; i++)
            {
                if (histogram.data[i].Count > 0)
                    values_present[i] = true;
            }

            // Trata o Ás como alto também (14)
            if (values_present[1])
                values_present[14] = true;

            // Verifica todas as possíveis sequências de 5 cartas consecutivas
            for (int i = 1; i <= 10; i++)
            {
                bool is_sequence = true;
                for (int j = 0; j < 5; j++)
                {
                    if (!values_present[i + j])
                    {
                        is_sequence = false;
                        break;
                    }
                }

                if (is_sequence)
                {
                    cards_tmp.Clear();
                    player_card = false;

                    for (int j = 0; j < 5; j++)
                    {
                        int current_value = (i + j == 14) ? 1 : i + j;
                        List<Card> candidates = histogram.data[current_value];

                        // Escolhe a melhor carta (prioriza a que está na mão)
                        Card selected = candidates.FirstOrDefault(c => !c.on_table) ?? candidates[0];

                        cards_tmp.Add(new Card(selected));
                        if (!selected.on_table)
                            player_card = true;
                    }

                    if (player_card)
                    {
                        hand_find = new List<Card>(cards_tmp);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}