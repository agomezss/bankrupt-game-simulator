namespace Alessandro.Bankrupt.Helper;

public static class Configuration
{
    public static List<BoardSpace> CachedBoardSpace;
    public static List<BoardSpace> ReadBoardSpacesFromConfig()
    {
        var boardSpaces = new List<BoardSpace>();

        if(CachedBoardSpace!=null && CachedBoardSpace.Count > 0)
        {
            foreach (BoardSpace line in CachedBoardSpace)
                boardSpaces.Add(new BoardSpace(line.BoughtValue, line.RentValue));

            return boardSpaces;
        }

        var resourceName = "Configuration/gameConfig.txt";
        CachedBoardSpace = new List<BoardSpace>();
        var lines = File.ReadAllLines(resourceName);

        foreach (var line in lines)
        {

            var boughtValue = int.Parse(line.Substring(0, 3));
            var rentValue = int.Parse(line.Substring(3, 3));
            CachedBoardSpace.Add(new BoardSpace(boughtValue, rentValue));
            boardSpaces.Add(new BoardSpace(boughtValue, rentValue));
        }
        
        return boardSpaces;
    }
}
