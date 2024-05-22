
namespace Alessandro.Bankrupt.AI.Actions;

public class BuyIfRentValueGreaterThanFifty : GameAction
{
    public override void Act(Game game, Player player)
    {
        var steppedSpace = game.Board.GetSpaceByNumber(player.SteppedBoardSpace1);

        if (steppedSpace.HasOwner()
            || !player.HasEnoughCoins(steppedSpace.BoughtValue)
            || !(steppedSpace.RentValue > 50)) return;
            
        player.Pay(steppedSpace.BoughtValue);
        steppedSpace.Claim(player);
    }
}
