using Alessandro.Bankrupt.AI.Actions;

namespace Alessandro.Bankrupt;

public class ImpulsivePlayer : Player
{
    public ImpulsivePlayer() : base("Impulsive") => AddAction<BuySpaceIfNotOwned>();
}
