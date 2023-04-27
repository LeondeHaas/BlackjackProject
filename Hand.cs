using System.Collections.Generic;

// This class represents a hand of playing cards.
public class Hand
{
    private List<Card> cards;

    public Hand()
    {
        cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public int GetHandValue()
    {
        int value = 0;
        int numAces = 0;

        foreach (Card card in cards)
        {
            value += card.Value;

            if (card.Rank == "Ace")
            {
                numAces++;
            }
        }

        // Adjust the value if there are aces in the hand
        while (value > 21 && numAces > 0)
        {
            value -= 10;
            numAces--;
        }

        return value;
    }

    public void Clear()
    {
        cards.Clear();
    }

    public List<Card> GetCards()
    {
        return cards;
    }
}
