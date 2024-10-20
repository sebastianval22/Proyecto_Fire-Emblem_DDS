namespace Fire_Emblem.Controllers;

public class UnitController
{
        private readonly UnitEffectsService _effectsService;
        private readonly UnitAttributesService _attributesService;

        public UnitController()
        {
            _effectsService = new UnitEffectsService();
            _attributesService = new UnitAttributesService();
        }

        public void InitializeUnitData(Unit unit)
        {
            InitializeStats(unit);
            InitializeStatList(unit);
            InitializeDamageStats(unit);
            InitializeUnitDataObject(unit);
            foreach (var stat in unit.Stats)
            {
                stat.ResetEffects();
            }
        }

        private void InitializeStats(Unit unit)
        {
            unit.Attack = new Attack();
            unit.Defense = new Defense();
            unit.Speed = new Speed();
            unit.Resistance = new Resistance();
        }

        private void InitializeStatList(Unit unit)
        {
            unit.Stats = new List<Stat> { unit.Attack, unit.Defense, unit.Speed, unit.Resistance };
        }

        private void InitializeDamageStats(Unit unit)
        {
            unit.DamagePercentageReductionStat = new DamagePercentageReductionStat(1, 1, 1);
            unit.DamageAbsoluteReductionStat = new DamageAbsoluteReductionStat(0, 0);
            unit.ExtraDamageStat = new ExtraDamageStat(0, 0, 0);
        }

        private void InitializeUnitDataObject(Unit unit)
        {
            var unitData = new UnitData();
            unitData.InitializeUnit(unit);
        }

        public void UpdateHPStatus(Unit unit, int damage)
        {
            unit.CurrentHP = Math.Max(unit.CurrentHP - damage, 0);
        }

        public bool IsUnitAlive(Unit unit)
        {
            return unit.CurrentHP > 0;
        }

        public void SaveAttributes(Unit unit)
        {
            _attributesService.SaveAttributes(unit);
        }

        public void RestoreBackupAttributes(Unit unit)
        {
            _attributesService.RestoreBackupAttributes(unit);
        }

        public Dictionary<string, int> ObtainAttributes(Unit unit)
        {
            return _attributesService.ObtainAttributes(unit);
        }

        public void RestoreSpecificAttributes(Dictionary<string, int> attributes, Unit unit)
        {
            _attributesService.RestoreSpecificAttributes(unit, attributes);
        }

        public void ApplyEffects(Unit unit)
        {
            _effectsService.ApplyEffects(unit);
        }

        public void ApplyFollowUpAttackEffects(Unit unit)
        {
            _effectsService.ApplyFollowUpAttackEffects(unit);
        }

        public void ResetActiveSkillsEffects(Unit unit)
        {
            _effectsService.ResetActiveSkillsEffects(unit);
        }
    }
