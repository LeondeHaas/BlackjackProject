using System;
using System.Collections.Generic;

// This class represents a deck of playing cards.
public class Deck
{
    private List<Card> cards;  // List to store the cards in the deck
    private Random random;  // Random number generator for shuffling the deck

    public Deck()
    {
        random = new Random();
        cards = new List<Card>();

        // Initialize the deck with 52 cards
        string[] suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
        string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        // Loop through each suit and rank to create the cards
        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                // Set the value of the card based on the rank
                // If rank is a number, parse it as an integer; otherwise, set value as 10 for face cards
                int value = Int32.TryParse(rank, out int result) ? result : (rank == "Ace" ? 11 : 10);

                // Create a new card with the suit, rank, and value, and add it to the deck
                cards.Add(new Card(suit, rank, value));
            }
        }
    }

    public void Shuffle()
    {
        // Shuffle the cards in the deck
        for (int i = cards.Count - 1; i > 0; i--)
        {
            // Generate a random index between 0 and i (inclusive)
            int j = random.Next(i + 1);

            // Swap the cards at indices i and j
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

        // Deal the topmost card from the deck by removing it from the list
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}
