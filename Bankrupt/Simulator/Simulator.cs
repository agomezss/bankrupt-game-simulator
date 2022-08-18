namespace Alessandro.Bankrupt
{
    public static class Simulator
    {
        public static List<SimulationResult> Simulations { get; set; }

        public static double AverageTurnDuration { get { return Simulations.Select(a=>a.LastedTurns).Average(); } }

#pragma warning disable CS8603 // Possible null reference return.
        public static string WinnestPlayer => Simulations.GroupBy(x => x.WinnerName,
                                   (t, g) => new { nome = t, val = g.Count() }).OrderByDescending(a => a.val).Select(a => a.nome).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.


        public static void Simulate(int totalSimulations)
        {
            for (int i = 0; i < totalSimulations; i++)
            {
                var game = new Game().AddPlayer(new ImpulsivePlayer())
                                     .AddPlayer(new DemandingPlayer())
                                     .AddPlayer(new CarefulPlayer())
                                     .AddPlayer(new RandomPlayer())
                                     .Play();

                var result = new SimulationResult
                {
                    SimulationNumber = i + 1,
                    EndedTimeout = game.IsTimeout,
                    LastedTurns = game.Turn,
                    WinnerName = game.GetWinnerName()
                };

                Simulations = Simulations ?? new List<SimulationResult>();
                Simulations.Add(result);
            }
        }

        public static void PrintResults()
        {
            var totalSimulations = Simulations.Count;
            Console.WriteLine($"Total Games: {totalSimulations}");

            Console.WriteLine();
            Console.WriteLine($"Total games ended by timeout: {Simulations.Where(a=>a.WinnerName.ToLower()=="timeout").Count()}");

            Console.WriteLine();
            Console.WriteLine($"Average match turn duration: {(int)AverageTurnDuration}");

            var percentages = Simulations.GroupBy(x => x.WinnerName,
                                   (t, g) => new { val = $"{t}:{Math.Round((decimal.Parse(g.Count().ToString()) / decimal.Parse(totalSimulations.ToString()) * 100m),2)}%" });


            Console.WriteLine();
            Console.WriteLine($"Victory Rate by AI Behaviour:");

            foreach (var value in percentages)
            {
                Console.WriteLine($"{value.val}");
            }

            Console.WriteLine();
            Console.WriteLine($"Winnest player: {WinnestPlayer}");
        }
    }
}
