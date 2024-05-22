namespace Alessandro.Bankrupt.AI.Actions;

public class Buy50PercentChance : GameAction
{
    public override void Act(Game game, Player player)
    {
        var steppedSpace = game.Board.GetSpaceByNumber(player.SteppedBoardSpace1);

        if (steppedSpace.HasOwner()
            || !player.HasEnoughCoins(steppedSpace.BoughtValue)
            || !Randomizer.RollBool) return;
            
        player.Pay(steppedSpace.BoughtValue);
        steppedSpace.Claim(player);
    }
}
