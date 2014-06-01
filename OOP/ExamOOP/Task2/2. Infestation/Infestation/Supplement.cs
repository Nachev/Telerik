using System;
using System.Linq;

namespace Infestation
{
    public abstract class Supplement : ISupplement
    {
        private const int BasePowerEffect = 0;
        private const int BaseHealthEffect = 0;
        private const int BaseAggressionEffect = 0;

        public abstract void ReactTo(ISupplement otherSupplement);

        public virtual int PowerEffect
        {
            get { return BasePowerEffect; }
        }

        public virtual int HealthEffect
        {
            get { return BaseHealthEffect; }
        }

        public virtual int AggressionEffect
        {
            get { return BaseAggressionEffect; }
        }
    }
}
