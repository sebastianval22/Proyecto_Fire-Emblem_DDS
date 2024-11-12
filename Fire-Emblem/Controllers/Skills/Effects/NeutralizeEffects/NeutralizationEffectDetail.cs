namespace Fire_Emblem.Controllers.Skills.Effects.NeutralizeEffects
{
    public class NeutralizationDetail
    {
        public bool IsNeutralized { get; set; }
        public string UnitName { get; set; }
        public string EffectName { get; set; }

        public NeutralizationDetail(bool isNeutralized, string unitName, string effectName)
        {
            IsNeutralized = isNeutralized;
            UnitName = unitName;
            EffectName = effectName;
        }
    }
}