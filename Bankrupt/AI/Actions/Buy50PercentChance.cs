using System;

namespace Alessandro.Bankrupt.AI.Actions
{
    public class Buy50PercentChance : GameAction
    {
        public override void Act(Game game, Player player)
        {
            var steppedSpace = game.Board.GetSpaceByNumber(player.GetSteppedBoardSpace());

            if (steppedSpace.HasOwner()) return;
            if (!player.HasEnoughCoins(steppedSpace.boughtValue)) return;

            var shouldBuy = new Random().Next(1, 3) == 1;

            if (!shouldBuy) return;

            player.Pay(steppedSpace.boughtValue);
            steppedSpace.Claim(player);
        }
    }
}
