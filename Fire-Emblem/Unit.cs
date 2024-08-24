using Fire_Emblem_View;

namespace Fire_Emblem;

public class Unit
{
    public string Name { get; set; }
    public List<string> Abilities { get; set; }

    public Unit(string name, List<string> abilities)
    {
        Name = name;
        Abilities = abilities;
    }
}