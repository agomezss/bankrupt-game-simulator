namespace Alessandro.Bankrupt;

public static class Simulator
{
    public static List<SimulationResult>? Simulations { get; set; }

    public static double? AverageTurnDuration => Simulations?.Select(a => a.LastedTurns)
                                                           .Average();

    public static string? WinnestPlayer
    {
        get
        {
            return Simulations?.GroupBy(x => x.WinnerName,
                               (t, g) => new { nome = t, val = g.Count() })
                              .OrderByDescending(a => a.val)
                              .Select(a => a.nome).FirstOrDefault();
        }
    }

    public static void Simulate(int totalSimulations)
    {
        for (int i = 0; i < totalSimulations; i++)
        {
            var game = new Game().AddPlayer(new ImpulsivePlayer())
                                 .AddPlayer(new DemandingPlayer())
                                 .AddPlayer(new CarefulPlayer())
                                 .AddPlayer(new RandomPlayer())
                                 .Play();

            var result = new SimulationResult(i + 1, game.Turn, game.IsTimeout, game.WinnerName);

            Simulations ??= new List<SimulationResult>();
            Simulations.Add(result);
        }
    }

    public static void PrintResults()
    {
        var totalSimulations = Simulations.Count;
        Console.Out.WriteLine($"Total Games: {totalSimulations}");

        Console.Out.WriteLine();
        Console.Out.WriteLine($"Total games ended by timeout: {Simulations.Where(a=>a.WinnerName.ToLower()=="timeout").Count()}");

        Console.Out.WriteLine();
        Console.Out.WriteLine($"Average match turn duration: {(int)(AverageTurnDuration??1)}");

        var percentages = Simulations.GroupBy(x => x.WinnerName,
                               (t, g) => new { val = $"{t}:{Math.Round(decimal.Parse(g.Count().ToString()) / decimal.Parse(totalSimulations.ToString()) * 100m,2)}%" });


        Console.Out.WriteLine();
        Console.Out.WriteLine($"Victory Rate by AI Behaviour:");

        foreach (var value in percentages)
        {
            Console.Out.WriteLine($"{value.val}");
        }

        Console.Out.WriteLine();
        Console.Out.WriteLine($"Winnest player: {WinnestPlayer}");
    }
}
