using Fire_Emblem.Views;
using Fire_Emblem.Skills;

namespace Fire_Emblem.Controllers;

public class BattleController
{
    private List<List<Unit>> _teams;
    private int _attackingPlayerNumber = 1;
    private int _defendingPlayerNumber = 2;
    private int _round = 1;
    private Unit _attackingUnit;
    private Unit _defendingUnit;
    private RoundFightController _roundFightControllerController;
    
    public BattleController(List<List<Unit>> teams)
    {
        _teams = teams;
        _roundFightControllerController = new RoundFightController();
    }
    
    public void Start()
    {
        AddAlterationBaseStats();
        while (TeamsAreAlive())
        {   
            ExecuteRound();
            UpdateTeams();
            BattleView.DisplayRoundResult(_attackingUnit, _defendingUnit);
            PrepareNextRound();
        }
        BattleView.DisplayWinner(_teams);
    }

    private bool TeamsAreAlive()
    {
        return _teams[0].Count > 0 && _teams[1].Count > 0;
    }

    private void ExecuteRound()
    {
        _attackingUnit = ChooseUnit(_attackingPlayerNumber);
        _defendingUnit = ChooseUnit(_defendingPlayerNumber);
        BattleView.AnnounceRoundBeginning( _round, _attackingUnit, _attackingPlayerNumber);
        _roundFightControllerController.Fight(_attackingUnit, _defendingUnit);
    }

    private void PrepareNextRound()
    {
        _round++;
        (_attackingPlayerNumber, _defendingPlayerNumber) = (_defendingPlayerNumber, _attackingPlayerNumber);
    }

     
    private void UpdateTeams()
    {
        for (int i = 0; i < _teams.Count; i++)
        {
            _teams[i].RemoveAll(unit => !unit.IsUnitAlive());
        }
    }
    
    private Unit ChooseUnit(int playerNumber)
    {
        List<Unit> team = _teams[playerNumber - 1];
        BattleView.DisplayTeamOptions(playerNumber, team);
        return GetChosenUnit(playerNumber, team);
    }



    private Unit GetChosenUnit(int playerNumber, List<Unit> team)
    {
        string optionChosenUnit = BaseView.ReadLine();
        if (int.TryParse(optionChosenUnit, out int index))
        {
            return team[index];
        }
        else
        {
            return ChooseUnit(playerNumber); 
        }
    }

    private void AddAlterationBaseStats()
    {
        foreach (List<Unit> team in _teams)
        {
            AddBaseStatsToTeam(team);
        }
    }

    private void AddBaseStatsToTeam(List<Unit> team)
    {
        foreach (Unit unit in team)
        {
            AddBaseStatsToUnit(unit);
        }
    }

    private void AddBaseStatsToUnit(Unit unit)
    {
        foreach (Skill skill in unit.Skills)
        {
            ActivateBaseStatsSkillIfApplicable(skill, unit);
        }
    }

    private void ActivateBaseStatsSkillIfApplicable(Skill skill, Unit unit)
    {
        if (skill.SkillData.SkillType == "Base Stats")
        {
            skill.ActivateBaseStatsSkillEffects(unit);
        }
    }
}