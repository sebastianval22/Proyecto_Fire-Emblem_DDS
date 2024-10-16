namespace Fire_Emblem
{
    public class UnitAttributesService
    {
        public void SaveAttributes(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                stat.SaveValue();
            }
        }

        public void RestoreBackupAttributes(Unit unit)
        {
            foreach (var stat in unit.Stats)
            {
                stat.RestoreValue();
            }
        }

        public Dictionary<string, int> ObtainAttributes(Unit unit)
        {
            return unit.Stats.ToDictionary(stat => stat.GetType().Name, stat => stat.Value);
        }

        public void RestoreSpecificAttributes(Unit unit, Dictionary<string, int> attributes)
        {
            foreach (var stat in unit.Stats)
            {
                RestoreStatValue(stat, attributes);
            }
        }

        private void RestoreStatValue(Stat stat, Dictionary<string, int> attributes)
        {
            if (TryGetAttributeValue(attributes, stat.GetType().Name, out var value))
            
            {
                stat.Value = value;
            }
        }
        private bool TryGetAttributeValue(Dictionary<string, int> attributes, string key, out int value)
        {
            return attributes.TryGetValue(key, out value);
        }
    }
}