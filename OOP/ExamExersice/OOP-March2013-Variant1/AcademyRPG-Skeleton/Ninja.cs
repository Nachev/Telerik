namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Ninja : Character, IFighter, IGatherer
    {
        private const int InitialHitPoints = 1;
        private int attackPoints;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = InitialHitPoints;
            this.attackPoints = 0;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
        }

        public int DefensePoints
        {
            get
            {
                return int.MaxValue;
            }
        }
        
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int maxHitPoints = int.MinValue;
            int index = -1;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0 && 
                    availableTargets[i].Owner != this.Owner && 
                    availableTargets[i].HitPoints > maxHitPoints)
                {
                    maxHitPoints = availableTargets[i].HitPoints;
                    index = i;
                }
            }

            return index;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += (resource.Quantity * 2);
                return true;
            }

            return false;
        }
    }
}
