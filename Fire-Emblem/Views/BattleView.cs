namespace Fire_Emblem.Views
{
    public class BattleView
    {
        public static void DisplayTeamOptions(int playerNumber, List<Unit> team)
        {
            BaseView.ShowMessage($"Player {playerNumber} selecciona una opción");
            for (int i = 0; i < team.Count; i++)
            {
                BaseView.ShowMessage($"{i}: {team[i].Name}");
            }
        }

        public static void AnnounceRoundBeginning(int round, Unit attackingUnit, int attackingPlayerNumber)
        {
            BaseView.ShowMessage($"Round {round}: {attackingUnit.Name} (Player {attackingPlayerNumber}) comienza");
        }

        public static void DisplayRoundResult(Unit attackingUnit, Unit defendingUnit)
        {
            BaseView.ShowMessage($"{attackingUnit.Name} ({attackingUnit.CurrentHP}) : {defendingUnit.Name} ({defendingUnit.CurrentHP})");
        }

        public static void DisplayWinner(List<List<Unit>> teams)
        {
            if (teams[0].Count == 0)
            {
                BaseView.ShowMessage("Player 2 ganó");
            }
            else
            {
                BaseView.ShowMessage("Player 1 ganó");
            }
        }
    }
}
