using System;
using System.Collections.Generic;

// This class represents a deck of playing cards.
public class Deck
{
    private List<Card> cards;
    private Random random;

    public Deck()
    {
        random = new Random();
        cards = new List<Card>();

        // Initialize the deck with 52 cards
        string[] suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
        string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                int value = Int32.TryParse(rank, out int result) ? result : (rank == "Ace" ? 11 : 10);
                cards.Add(new Card(suit, rank, value));
            }
        }
    }

    public void Shuffle()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card Deal()
    {
        if (cards.Count == 0)
        {
            throw new InvalidOperationException("Deck is empty. Cannot deal a card.");
        }

        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}
