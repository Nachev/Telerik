using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Marine : Human
    {
        private readonly ISupplement DefaultSkill = new WeaponrySkill();

        public Marine(string id)
            : base(id)
        {
            base.AddSupplement(DefaultSkill);
        }

        //public override void AddSupplement(ISupplement newSupplement)
        //{
        //    if (newSupplement.GetType().Name != "WeaponrySkill")
        //    {
        //        base.AddSupplement(newSupplement);
        //    }
        //}

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            //This method finds the unit with the highest  health and attacks it
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MinValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health > optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
