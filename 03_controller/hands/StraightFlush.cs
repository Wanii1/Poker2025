using poker_2025.controller;
using poker_2025.model;
namespace poker_2025.controller.hands;

public class StraightFlush : Hands
{
    public StraightFlush (List<Card> cards) : base(cards){}


    public override bool find()
    {

        return false;
    }
}