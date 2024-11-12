namespace Fire_Emblem.Controllers.Skills.Effects
{
    public class EffectDetail
    {
        public int EffectValue { get; set; }
        public string UnitName { get; set; }
        public string EffectName { get; set; }
        public string Suffix { get; set; } = "";

        public EffectDetail(int effectValue, string unitName, string effectName, string suffix = "")
        {
            EffectValue = effectValue;
            UnitName = unitName;
            EffectName = effectName;
            Suffix = suffix;
        }
    }
}