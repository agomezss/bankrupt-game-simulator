
namespace Alessandro.Bankrupt.AI.Actions;

public class BuySpaceIfNotOwned : GameAction
{
    public override void Act(Game game, Player player)
    {
        var steppedSpace = game.Board.GetSpaceByNumber(player.GetSteppedBoardSpace());

        if (steppedSpace.HasOwner()) return;
        if (!player.HasEnoughCoins(steppedSpace.BoughtValue)) return;
        
        player.Pay(steppedSpace.BoughtValue);
        steppedSpace.Claim(player);
    }
}
