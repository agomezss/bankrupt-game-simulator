namespace Alessandro.Bankrupt;

public class SimulationResult
{
    public int SimulationNumber { get; set; }
    public int LastedTurns { get; set; }
    public bool EndedTimeout { get; set; }
    public string? WinnerName { get; set; }
}