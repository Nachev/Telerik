using System;
using System.Linq;

namespace Infestation
{
    public class Weapon : Supplement
    {
        private const string ReactionSupplement = "WeaponrySkill";
        private const int PowerEffectModifier = 10;
        private const int AggressionEffectModifier = 3;

        private int powerEffect = 0;
        private int aggressionEffect = 0;

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == ReactionSupplement)
            {
                this.powerEffect = PowerEffectModifier;
                this.aggressionEffect = AggressionEffectModifier;
            }
        }

        public override int PowerEffect
        {
            get { return this.powerEffect; }
        }

        public override int AggressionEffect
        {
            get { return this.aggressionEffect; }
        }
    }
}
