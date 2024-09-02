namespace Fire_Emblem.TeamChecks;

public interface ITeamCheck
{
    bool Check(List<List<Unit>> teams);
}