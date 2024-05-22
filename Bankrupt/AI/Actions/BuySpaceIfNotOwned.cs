
namespace Alessandro.Bankrupt.AI.Actions;

public class BuySpaceIfNotOwned : GameAction
{
    public override void Act(Game game, Player player)
    {
        var steppedSpace = game.Board.GetSpaceByNumber(player.SteppedBoardSpace1);

        if (steppedSpace.HasOwner()
            || !player.HasEnoughCoins(steppedSpace.BoughtValue)) return;
            
        player.Pay(steppedSpace.BoughtValue);
        steppedSpace.Claim(player);
    }
}
