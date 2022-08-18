namespace Alessandro.Bankrupt
{
    public class BoardSpace
    {
        public static int TotalSpacesCount { get; set; }
        public static int TotalOwnedSpacesCount { get; set; }
        public static int TotalEmptySpacesCount
        {
            get
            {
                return TotalSpacesCount - TotalOwnedSpacesCount;
            }
        }

        public int boughtValue { get; set; }

        public int rentValue { get; set; }

        private Player _owner { get; set; }

        public BoardSpace(int boughtValueSet, int rentValueSet)
        {

            TotalSpacesCount++;
            boughtValue = boughtValueSet;
            rentValue = rentValueSet;
        }

        public bool HasOwner()
        {
            return _owner != null;
        }

        public Player GetOwner()
        {
            return _owner;
        }
        
        public void Claim(Player owner)
        {
            _owner = owner;
            TotalOwnedSpacesCount++;
        }

        public void Unclaim()
        {
            _owner = null;
            TotalOwnedSpacesCount--;
        }

    }
}
