
namespace Alessandro.Bankrupt.AI.Actions;

public class RollDiceAndWalkInBoard : GameAction
{
    public override void Act(Game game, Player player)
    {
        var diceResult = Randomizer.RollD6();
        game.Board.PlacePlayerOnSpaceAccordingToDiceRoll(player, diceResult);
    }
}
