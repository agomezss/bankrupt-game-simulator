using Alessandro.Bankrupt.AI.Actions;

namespace Alessandro.Bankrupt;

public class RandomPlayer : Player
{
    public RandomPlayer() : base("Random")
    {
        AddAction<Buy50PercentChance>();
    }
}
