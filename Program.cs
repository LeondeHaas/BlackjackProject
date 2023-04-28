using System;

class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Blackjack!");
        Console.WriteLine("A small tut");

        // Create a new deck and shuffle it
        Deck deck = new Deck();
        deck.Shuffle();

        // Create the dealer and player
        Dealer dealer = new Dealer();
        Player player = new Player("Player");

        // Deal initial cards
        player.AddCardToHand(deck.Deal());
        dealer.AddCardToHand(deck.Deal());
        player.AddCardToHand(deck.Deal());
        dealer.AddCardToHand(deck.Deal());

        // Play the game
        PlayGame(deck, dealer, player);

        Console.WriteLine("Thank you for playing!");
    }

    static void PlayGame(Deck deck, Dealer dealer, Player player)
    {
        bool gameOver = false;

        while (!gameOver)
        {
            Console.WriteLine();
            Console.WriteLine($"Dealer's Hand: {GetHandString(dealer)}");
            Console.WriteLine($"Player's Hand: {GetHandString(player)}");
            Console.WriteLine();

            // Check if player or dealer has blackjack
            if (player.GetHandValue() == 21 || dealer.GetHandValue() == 21)
            {
                gameOver = true;
                DetermineWinner(dealer, player);
                break;
            }

            // Player's turn
            string choice = GetPlayerChoice();

            if (choice.ToLower() == "hit")
            {
                player.AddCardToHand(deck.Deal());
                int playerHandValue = player.GetHandValue();

                if (playerHandValue > 21)
                {
                    gameOver = true;
                    Console.WriteLine("Player busts! Dealer wins.");
                    break;
                }
            }
            else if (choice.ToLower() == "stand")
            {
                // Dealer's turn
                while (dealer.ShouldHit())
                {
                    dealer.AddCardToHand(deck.Deal());
                }

                int dealerHandValue = dealer.GetHandValue();
                int playerHandValue = player.GetHandValue();

                Console.WriteLine();
                Console.WriteLine($"Dealer's Hand: {GetHandString(dealer)}");
                Console.WriteLine($"Player's Hand: {GetHandString(player)}");
                Console.WriteLine();

                if (dealerHandValue > 21 || dealerHandValue < playerHandValue)
                {
                    Console.WriteLine("Player wins!");
                }
                else if (dealerHandValue > playerHandValue)
                {
                    Console.WriteLine("Dealer wins!");
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }

                gameOver = true;
            }
        }
    }

    static string GetHandString(Player player)
    {
        string handString = "";

        foreach (Card card in player.Hand.GetCards())
        {
            handString += $"{card.Rank} of {card.Suit}, ";
        }

        handString = handString.TrimEnd(',', ' ');
        return handString;
    }

    static string GetPlayerChoice()
    {
        while (true)
        {
            Console.WriteLine("Choose an action: (hit/stand)");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "hit" || choice.ToLower() == "stand")
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    static void DetermineWinner(Dealer dealer, Player player)
    {
        int dealerHandValue = dealer.GetHandValue();
        int playerHandValue = player.GetHandValue();

        Console.WriteLine();
        Console.WriteLine($"Dealer's Hand: {GetHandString(dealer)}");
        Console.WriteLine($"Player's Hand: {GetHandString(player)}");
        Console.WriteLine();

        if (dealerHandValue > 21 && playerHandValue > 21)
        {
            Console.WriteLine("Both dealer and player bust. It's a tie!");
        }
        else if (dealerHandValue > 21)
        {
            Console.WriteLine("Dealer busts! Player wins!");
        }
        else if (playerHandValue > 21)
        {
            Console.WriteLine("Player busts! Dealer wins!");
        }
        else if (dealerHandValue > playerHandValue)
        {
            Console.WriteLine("Dealer wins!");
        }
        else if (dealerHandValue < playerHandValue)
        {
            Console.WriteLine("Player wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}