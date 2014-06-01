using System;
using System.Linq;

namespace Infestation
{
    public class PowerInhibitor : Supplement
    {
        private const int BasePowerEffect = 3;

        public override void ReactTo(ISupplement otherSupplement)
        {
        }
        
        public override int PowerEffect
        {
            get { return BasePowerEffect; }
        }
    }
}
