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
        // Add a card to the hand
        cards.Add(card);
    }

    public int GetHandValue()
    {
        int value = 0;
        int numAces = 0;

        foreach (Card card in cards)
        {
            // Add the value of each card to the total hand value
            value += card.Value;

            if (card.Rank == "Ace")
            {
                // Count the number of Aces in the hand
                numAces++;
            }
        }

        // Adjust the value if there are aces in the hand and the total value exceeds 21
        while (value > 21 && numAces > 0)
        {
            value -= 10;
            numAces--;
        }

        // Return the final hand value
        return value;
    }

    public void Clear()
    {
        // Clear the hand by removing all cards
        cards.Clear();
    }

    public List<Card> GetCards()
    {
        // Return a list of cards in the hand
        return cards;
    }
}
