namespace Alessandro.Bankrupt.AI.Actions
{
    public class BuyIfEightyCoinsLeftAfterPurchase : GameAction
    {
        public override void Act(Game game, Player player)
        {
            var steppedSpace = game.Board.GetSpaceByNumber(player.GetSteppedBoardSpace());

            if (steppedSpace.HasOwner()) return;
            if (!player.HasEnoughCoins(steppedSpace.boughtValue)) return;

            var shouldBuy = player.Coins - steppedSpace.boughtValue >= 80;

            if (!shouldBuy) return;

            player.Pay(steppedSpace.boughtValue);
            steppedSpace.Claim(player);
        }
    }
}
