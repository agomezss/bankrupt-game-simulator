namespace Alessandro.Bankrupt;

public static class Randomizer
{
    private static readonly Random _seed = new();

    public static bool RollBool => _seed.Next(1,3) == 1;
    public static int RollD6() => _seed.Next(1, 7);
}
