namespace Fire_Emblem.TeamSetup.TeamChecks
{
    public interface ITeamCheck
    {
        bool Check(List<List<Unit>> teams);
    }
}