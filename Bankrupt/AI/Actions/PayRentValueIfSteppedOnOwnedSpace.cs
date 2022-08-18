
namespace Alessandro.Bankrupt.AI.Actions
{
    public class PayRentValueIfSteppedOnOwnedSpace : GameAction
    {
        public override void Act(Game game, Player player)
        {
            var steppedSpace = game.Board.GetSpaceByNumber(player.GetSteppedBoardSpace());

            if (!steppedSpace.HasOwner()) return;
            if (steppedSpace.GetOwner() == player) return;

            player.Pay(steppedSpace.rentValue);
            steppedSpace.GetOwner().GainCoins(steppedSpace.rentValue);
        }
    }
}
