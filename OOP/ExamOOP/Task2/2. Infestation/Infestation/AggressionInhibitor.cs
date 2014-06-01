using System;
using System.Linq;

namespace Infestation
{
    public class AggressionInhibitor : Supplement
    {
        private const int BaseAggressionEffect = 3;

        public override void ReactTo(ISupplement otherSupplement)
        {
        }

        public override int AggressionEffect
        {
            get { return BaseAggressionEffect; }
        }
    }
}
