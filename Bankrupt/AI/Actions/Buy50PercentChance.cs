namespace Alessandro.Bankrupt.AI.Actions;

public class Buy50PercentChance : GameAction
{
    public override void Act(Game game, Player player)
    {
        var steppedSpace = game.Board.GetSpaceByNumber(player.GetSteppedBoardSpace());

        if (steppedSpace.HasOwner()) return;
        if (!player.HasEnoughCoins(steppedSpace.BoughtValue)) return;

        var shouldBuy = new Random().Next(1, 3) == 1;

        if (!shouldBuy) return;

        player.Pay(steppedSpace.BoughtValue);
        steppedSpace.Claim(player);
    }
}
