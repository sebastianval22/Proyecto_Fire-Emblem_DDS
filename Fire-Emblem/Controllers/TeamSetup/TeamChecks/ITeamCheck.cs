using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.TeamSetup.TeamChecks
{
    public interface ITeamCheck
    {
        bool Check(TeamList teams);
    }
}