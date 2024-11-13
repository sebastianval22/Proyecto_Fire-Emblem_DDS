using System.Diagnostics;
using Fire_Emblem.Models;

namespace Fire_Emblem.Controllers
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

        public Attributes ObtainAttributes(Unit unit)
        {
            return new Attributes(unit);
        }

        public void RestoreSpecificAttributes(Unit unit, Attributes attributes)
        {
            foreach (var stat in unit.Stats)
            {
                RestoreStatValue(stat, attributes);
            }
        }

        private void RestoreStatValue(Stat stat, Attributes attributes)
        {
            stat.Value = attributes.GetAttributeValue(stat.GetType().Name);
        }
    }
}
