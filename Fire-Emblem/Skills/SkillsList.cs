using System.Collections;
using System.Collections.Generic;

namespace Fire_Emblem.Skills;

public class SkillsList : IEnumerable<Skill>
{
    private List<Skill> skills = new List<Skill>();
    
    public void AddSkill(Skill skill)
    {
        skills.Add(skill);
    }
    public void AddRangeSkills(IEnumerable<Skill> skills)
    {
        this.skills.AddRange(skills);
    }
    public IEnumerator<Skill> GetEnumerator()
    {
        return skills.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}