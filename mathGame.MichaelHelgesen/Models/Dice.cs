namespace mathGame.MichaelHelgesen.Models;

internal static class Dice
{
    internal static int RollDice(int difficulty)
    {
        Random random = new();
        return random.Next(0,difficulty);
    }
}