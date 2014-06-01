using System;
using System.Linq;

namespace Infestation
{
    public class HealthInhibitor : Supplement
    {
        private const int BaseHealthEffect = 3;

        public override void ReactTo(ISupplement otherSupplement)
        {
        }

        public override int HealthEffect
        {
            get { return BaseHealthEffect; }
        }
    }
}
