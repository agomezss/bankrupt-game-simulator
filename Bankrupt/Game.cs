using System.Collections.Concurrent;
using System.Diagnostics;

namespace Alessandro.Bankrupt;

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

    public bool IsOver => IsTimeout || Players.Where(a => a.IsLoser)
                                              .ToList().Count >= Players.Count - 1;

    public Game() => Board = new Board();

    public Game AddPlayer(Player player)
    {
        Players ??= new List<Player>();
        PlayOrder ??= new ConcurrentQueue<Player>();

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

    public string WinnerName => IsTimeout ? "Timeout" : Players.FirstOrDefault(a => a.Coins >= 0).PlayerName;

    private bool CheckIfGameHasEnded()
    {
        return IsTimeout || IsOver;
    }

    private Player GetNextPlayer()
    {
        Player? nextPlayer;

        do
        {
            var ok = PlayOrder.TryDequeue(out nextPlayer);

            if (!ok || nextPlayer == null)
                Environment.Exit(-1);

            PlayOrder.Enqueue(nextPlayer);
        } while (nextPlayer.HasLost);

        return nextPlayer;
    }
}
