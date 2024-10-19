namespace Fire_Emblem.TeamSetup.TeamChecks;

public static class MaxSkillsPerUnit

{
    

    
    public static bool Check(List<string> skillNames)
    {
        return skillNames.Count > 2;
    }
    
}
    
