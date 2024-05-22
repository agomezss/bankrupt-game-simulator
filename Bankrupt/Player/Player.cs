using Alessandro.Bankrupt.AI.Actions;

namespace Alessandro.Bankrupt
{
    public class Player
    {
        public static int TotalPlayersCount { get; set; }

        public int PlayerId { get; set; }

        public string PlayerName { get; set; }

        private int SteppedBoardSpace { get; set; }

        public bool IsLoser => Coins < 0;

        public int Coins { get; set; }

        public bool HasLost { get; set; }

        protected List<GameAction> _actions = new();

        public Player(string name)
        {
            TotalPlayersCount++;
            PlayerId = TotalPlayersCount;
            SteppedBoardSpace = 1;

            SetName(name);
            GainCoins(300);
            AddAction<RollDiceAndWalkInBoard>();
            AddAction<PayRentValueIfSteppedOnOwnedSpace>();
        }

        public void AddAction<T>() where T : GameAction
        {
            var action = Activator.CreateInstance<T>();
            _actions.Add(action);
        }

        public void SetName(string name) => PlayerName = name;

        public void SetSteppedBoardSpace(int boardSpaceNumber) => SteppedBoardSpace = boardSpaceNumber;

        public int SteppedBoardSpace1 => SteppedBoardSpace;

        public void GainCoins(int amount) => Coins += amount;

        public void Pay(int amount) => Coins -= amount;

        public bool HasEnoughCoins(int amount) => Coins >= amount;

        public void Play(Game gameInstance)
        {
            if (IsLoser)
            {
                gameInstance.Board.ResetAllSpacesBelongingToPlayer(this);
                HasLost = true;
                return;
            }

            foreach (var action in _actions)
            {
                action.Act(gameInstance, this);
            }
        }
    }
}
