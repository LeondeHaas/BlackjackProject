public class Dealer : Player
{
    public Dealer() : base("Dealer")
    {
    }

    public bool ShouldHit()
    {
        // Dealer hits if hand value is less than 17
        return GetHandValue() < 17;
    }
}