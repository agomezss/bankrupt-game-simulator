namespace Alessandro.Bankrupt.AI.Actions;

public class BuyIfEightyCoinsLeftAfterPurchase : GameAction
{
    public override void Act(Game game, Player player)
    {
        var steppedSpace = game.Board.GetSpaceByNumber(player.SteppedBoardSpace1);

        if (steppedSpace.HasOwner()) return;
        if (!player.HasEnoughCoins(steppedSpace.BoughtValue)) return;

        var shouldBuy = player.Coins - steppedSpace.BoughtValue >= 80;

        if (!shouldBuy) return;

        player.Pay(steppedSpace.BoughtValue);
        steppedSpace.Claim(player);
    }
}
