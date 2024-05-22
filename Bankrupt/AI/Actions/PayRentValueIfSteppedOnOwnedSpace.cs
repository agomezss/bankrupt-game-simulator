
namespace Alessandro.Bankrupt.AI.Actions;

public class PayRentValueIfSteppedOnOwnedSpace : GameAction
{
    public override void Act(Game game, Player player)
    {
        var steppedSpace = game.Board.GetSpaceByNumber(player.SteppedBoardSpace1);

        if (!steppedSpace.HasOwner()
            || steppedSpace.GetOwner() == player) return;
            
        player.Pay(steppedSpace.RentValue);
        steppedSpace.GetOwner().GainCoins(steppedSpace.RentValue);
    }
}
