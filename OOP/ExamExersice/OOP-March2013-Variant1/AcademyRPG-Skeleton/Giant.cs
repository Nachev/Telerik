using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private const int Owner = 0;
        private const int InitialAttackPoints = 150;
        private const int InitialDefensePoints = 80;
        private const int InitialHitPoints = 200;
        private const int AttackPointsGatherBonus = 100;

        private int attackPoints;
        private bool bonusGathered;

        public Giant(string name, Point position)
            : base(name, position, Owner)
        {
            this.HitPoints = InitialHitPoints;
            this.attackPoints = InitialAttackPoints;
            this.bonusGathered = false;
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
                return InitialDefensePoints; 
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                GatherSucceed();
                return true;
            }

            return false;
        }

        private void GatherSucceed()
        {
            if (!bonusGathered)
            {
                this.attackPoints += AttackPointsGatherBonus;
                this.bonusGathered = !this.bonusGathered;
            }
        }
    }
}
