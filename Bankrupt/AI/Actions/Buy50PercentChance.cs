namespace Alessandro.Bankrupt.AI.Actions;

public class Buy50PercentChance : GameAction
{
    public override void Act(Game game, Player player)
    {
        var steppedSpace = game.Board.GetSpaceByNumber(player.SteppedBoardSpace1);

        if (steppedSpace.HasOwner()) return;
        if (!player.HasEnoughCoins(steppedSpace.BoughtValue)) return;
        if (!Randomizer.RollBool) return;

        player.Pay(steppedSpace.BoughtValue);
        steppedSpace.Claim(player);
    }
}
