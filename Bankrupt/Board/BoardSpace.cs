namespace Alessandro.Bankrupt;

public class BoardSpace
{
    public static int TotalSpacesCount { get; set; }
    public static int TotalOwnedSpacesCount { get; set; }
    public static int TotalEmptySpacesCount => TotalSpacesCount - TotalOwnedSpacesCount;

    public int BoughtValue { get; set; }

    public int RentValue { get; set; }

    private Player? Owner { get; set; }

    public BoardSpace(int boughtValueSet, int rentValueSet)
    {
        TotalSpacesCount++;
        BoughtValue = boughtValueSet;
        RentValue = rentValueSet;
    }

    public bool HasOwner() => Owner != null;

    public Player? GetOwner() => Owner;

    public void Claim(Player owner)
    {
        Owner = owner;
        TotalOwnedSpacesCount++;
    }

    public void Unclaim()
    {
        Owner = null;
        TotalOwnedSpacesCount--;
    }

}
