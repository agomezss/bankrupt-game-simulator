using Alessandro.Bankrupt.Helper;

namespace Alessandro.Bankrupt;

public class Board
{
    public List<BoardSpace> Spaces { get; set; }

    public Board()
    {
        this.Spaces = Configuration.ReadBoardSpacesFromConfig();
    }

    public void ResetAllSpacesBelongingToPlayer(Player player)
    {
        Spaces.Where(a => a.GetOwner() == player).ToList().ForEach(a => a.Unclaim());
    }

    public void PlacePlayerOnSpaceAccordingToDiceRoll(Player player, int diceResult)
    {
        var nextPlayerSpace = player.GetSteppedBoardSpace() + diceResult;

        if(nextPlayerSpace > Spaces.Count)
        {
            nextPlayerSpace = nextPlayerSpace - Spaces.Count;
            player.GainCoins(100);
        }

        player.SetSteppedBoardSpace(nextPlayerSpace);
    }

    public BoardSpace GetSpaceByNumber(int stepNumber)
    {
        return Spaces[stepNumber - 1];
    }
}
