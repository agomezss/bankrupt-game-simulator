using System.Collections.Concurrent;

namespace Alessandro.Bankrupt
{
    public class Game
    {
        public Board Board { get; set; }

        public List<Player> Players { get; set; }

        private ConcurrentQueue<Player> PlayOrder { get; set; }

        public int Turn { get; set; }

        public bool IsTimeout
        {
            get
            {
                return Turn >= 1000; 
            }
        }

        public bool IsOver
        {
            get
            {
                return IsTimeout || Players.Where(a => a.IsLoser)
                                           .ToList().Count >= Players.Count - 1;
            }
        }

        public Game()
        {
            Board = new Board();
        }

        public Game AddPlayer(Player player)
        {
            if (Players == null) Players = new List<Player>();
            if(PlayOrder == null) PlayOrder = new ConcurrentQueue<Player>();

            Players.Add(player);
            PlayOrder.Enqueue(player);

            return this;
        }

        public Game Play()
        {
            while (!CheckIfGameHasEnded())
            {
                Turn++;
                var playerOfThisTurn = GetNextPlayer();
                playerOfThisTurn.Play(this);
            }

            return this;
        }

        public string GetWinnerName()
        {
            return IsTimeout ? "Timeout" : Players.FirstOrDefault(a => a.Coins >= 0).PlayerName;
        }

        private bool CheckIfGameHasEnded()
        {
            return IsTimeout || IsOver;
        }

        private Player GetNextPlayer()
        {
            Player nextPlayer = null;

            do
            {
                var ok = PlayOrder.TryDequeue(out nextPlayer);

                if (!ok)
                    throw new Exception("Concurrency Exception Caught");

                PlayOrder.Enqueue(nextPlayer);
            } while (nextPlayer.Lose);

            return nextPlayer;
        }
    }
}
