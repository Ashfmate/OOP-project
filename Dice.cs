public class Dice
{
    public int Roll(int nDice = 1)
    {
        int total = 0;
        for (int n = 0; n < nDice; ++n)
        {
            total += rng.Next(1, 7);
        }
        return total;
    }
    private Random rng = new Random();
}