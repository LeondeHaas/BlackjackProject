// This class represents a player in the game.
using System;

public class Player
{
    public string Name { get; set; }  // Property to get or set the player's name
    public Hand Hand { get; }  // Property to access the player's hand

    public Player(string name)
    {
        Name = name;
        Hand = new Hand();  // Create a new instance of the Hand class for the player's hand
    }

    public void AddCardToHand(Card card)
    {
        Hand.AddCard(card);  // Add a card to the player's hand by invoking the AddCard() method of the Hand class
    }

    public int GetHandValue()
    {
        return Hand.GetHandValue();  // Get the value of the player's hand by invoking the GetHandValue() method of the Hand class
    }

    public void ClearHand()
    {
        Hand.Clear();  // Clear the player's hand by invoking the Clear() method of the Hand class
    }
}
