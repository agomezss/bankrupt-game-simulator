using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Alessandro.Bankrupt.Helper
{
    public static class Configuration
    {
        public static List<BoardSpace> ReadBoardSpacesFromConfig()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Configuration/gameConfig.txt";

            var boardSpaces = new List<BoardSpace>();

            var lines = File.ReadAllLines(resourceName);

            foreach (var line in lines)
            {

                var boughtValue = int.Parse(line.Substring(0, 3));
                var rentValue = int.Parse(line.Substring(3, 3));
                var boardSpace = new BoardSpace(boughtValue, rentValue);
                boardSpaces.Add(boardSpace);
            }
            
            return boardSpaces;
        }
    }
}
