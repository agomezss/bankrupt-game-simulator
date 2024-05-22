namespace Alessandro.Bankrupt.AI.Actions;

public class BuyIfEightyCoinsLeftAfterPurchase : GameAction
{
    public override void Act(Game game, Player player)
    {
        var steppedSpace = game.Board.GetSpaceByNumber(player.SteppedBoardSpace1);

        if (steppedSpace.HasOwner()
            || !player.HasEnoughCoins(steppedSpace.BoughtValue)
            || !(player.Coins - steppedSpace.BoughtValue >= 80)) return;
            
        player.Pay(steppedSpace.BoughtValue);
        steppedSpace.Claim(player);
    }
}
