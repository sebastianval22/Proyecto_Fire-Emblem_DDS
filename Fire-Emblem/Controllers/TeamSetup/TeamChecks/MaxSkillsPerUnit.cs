using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers.TeamSetup.TeamChecks;

public static class MaxSkillsPerUnit
{
    public static bool Check(NameList skillNames)
    {
        return skillNames.CountNames() > 2;
    }
}
    
