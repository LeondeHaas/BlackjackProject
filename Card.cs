// This class represents a single playing card.
public class Card
{
    public string Suit { get; set; } // Suit of the card (e.g., Hearts, Diamonds, Spades, Clubs)
    public string Rank { get; set; } // Rank of the card (e.g., Ace, 2, 3, ..., King)
    public int Value { get; set; } // Numeric value of the card (e.g., 2-10 = face value, Ace = 1 or 11, Face cards = 10)

    public Card(string suit, string rank, int value)
    {
        Suit = suit;
        Rank = rank;
        Value = value;
    }
}
