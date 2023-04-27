// This class represents a player in the game.
using System;

public class Player
{
    public string Name { get; set; }
    public Hand Hand { get; }

    public Player(string name)
    {
        Name = name;
        Hand = new
Hand();
    }
public void AddCardToHand(Card card)
    {
        Hand.AddCard(card);
    }

    public int GetHandValue()
    {
        return Hand.GetHandValue();
    }

    public void ClearHand()
    {
        Hand.Clear();
    }
}