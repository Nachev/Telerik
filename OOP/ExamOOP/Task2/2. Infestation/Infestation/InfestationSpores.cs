using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const string ReactionSupplement = "InfestationSpores";
        private const int PowerEffectModifier = -1;
        private const int AggressionEffectModifier = 20;

        private int powerEffect;
        private int aggressionEffect;

        public InfestationSpores()
        {
            this.powerEffect = PowerEffectModifier;
            this.aggressionEffect = AggressionEffectModifier;
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == ReactionSupplement)
            {
                this.powerEffect = 0;
                this.aggressionEffect = 0;
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
