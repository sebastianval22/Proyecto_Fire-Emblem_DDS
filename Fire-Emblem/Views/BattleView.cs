using Fire_Emblem.Models;

namespace Fire_Emblem.Views
{
    public class BattleView
    {
        
        public static void DisplayTeamOptions(int playerNumber, UnitList  team)
        {
            BaseView.ShowMessage($"Player {playerNumber} selecciona una opción");
            for (int i = 0; i < team.Count(); i++)
            {
                BaseView.ShowMessage($"{i}: {team.GetUnit(i).Name}");
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

        public static void DisplayWinner(TeamList teams)
        {
            UnitList team1 = teams.GetTeam(1);
            if (team1.CountUnits()==0)
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
