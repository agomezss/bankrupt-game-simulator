using Alessandro.Bankrupt.AI.Actions;

namespace Alessandro.Bankrupt;

public class DemandingPlayer : Player
{
    public DemandingPlayer() : base("Demanding")
    {
        AddAction<BuyIfRentValueGreaterThanFifty>();
    }
}
