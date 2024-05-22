using Alessandro.Bankrupt.AI.Actions;

namespace Alessandro.Bankrupt;

public class CarefulPlayer : Player
{
    public CarefulPlayer() : base("Careful")
    {
        AddAction<BuyIfEightyCoinsLeftAfterPurchase>();
    }
}
