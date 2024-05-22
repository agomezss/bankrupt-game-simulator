
namespace Alessandro.Bankrupt.AI.Actions;

public class BuyIfRentValueGreaterThanFifty : GameAction
{
    public override void Act(Game game, Player player)
    {
        var steppedSpace = game.Board.GetSpaceByNumber(player.GetSteppedBoardSpace());

        if (steppedSpace.HasOwner()) return;
        if (!player.HasEnoughCoins(steppedSpace.BoughtValue)) return;

        var shouldBuy = steppedSpace.RentValue > 50;

        if (!shouldBuy) return;

        player.Pay(steppedSpace.BoughtValue);
        steppedSpace.Claim(player);
    }
}
