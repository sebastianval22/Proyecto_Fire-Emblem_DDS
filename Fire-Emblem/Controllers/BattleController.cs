using Fire_Emblem.Exceptions;
using Fire_Emblem.Views;
using Fire_Emblem.Skills;

namespace Fire_Emblem.Controllers;

public class BattleController
{
    
    private readonly TeamList _teams;
    private int _attackingPlayerNumber = 1;
    private int _defendingPlayerNumber = 2;
    private int _round = 1;
    private Unit _attackingUnit;
    private Unit _defendingUnit;
    private readonly RoundFightController _roundFightControllerController;
    private readonly SkillsController _skillsController;
    private readonly UnitController _unitController = new UnitController();
    
    public BattleController(TeamList teams)
    {
        _teams = teams;
        _roundFightControllerController = new RoundFightController();
        _skillsController = new SkillsController(_roundFightControllerController);
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
        UnitList team1 = _teams.GetTeam(1);
        UnitList team2 = _teams.GetTeam(2);
        return team1.CountUnits() > 0 && team2.CountUnits() > 0;
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
        for (int i = 1; i < _teams.NumberOfTeams() + 1; i++)
        {
            _teams.GetTeam(i).RemoveAll(unit => !_unitController.IsUnitAlive(unit));
        }
    }
    
    private Unit ChooseUnit(int playerNumber)
    {
        UnitList team = _teams.GetTeam(playerNumber);
        BattleView.DisplayTeamOptions(playerNumber, team);
        return GetChosenUnit(team);
    }

    private Unit GetChosenUnit(UnitList team)
    { 
        string optionChosenUnit = BaseView.ReadLine();
        if (int.TryParse(optionChosenUnit, out int index))
        {
            return team.GetUnit(index);
        }
        throw new InvalidUnitChoiceException();
    }

    private void AddAlterationBaseStats()
    {
        foreach (UnitList team in _teams)
        {
            AddBaseStatsToTeam(team);
        }
    }

    private void AddBaseStatsToTeam(UnitList team)
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
        if (skill.SkillType == "Base Stats")
        {
            _skillsController.ActivateBaseStatsSkillEffects(skill, unit);
        }
    }
}