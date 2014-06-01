namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtendedParticleOperator : AdvancedParticleOperator
    {
        private List<ParticleRepeller> repellers = new List<ParticleRepeller>();
        private List<Particle> particles = new List<Particle>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var repellerCandidate = p as ParticleRepeller;
            if (repellerCandidate != null)
            {
                this.repellers.Add(repellerCandidate);
            }
            else
            {
                this.particles.Add(p);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in this.repellers)
            {
                foreach (var particle in this.particles)
                {
                    var currParticleToRepellerVector = repeller.Position - particle.Position;
                    if (IsInRange(currParticleToRepellerVector, repeller))
                    {
                        var currAcceleration = GetAccelerationFromParticleToRepeller(repeller, particle);

                        particle.Accelerate(currAcceleration);
                    }
                }
            }

            this.particles.Clear();
            this.repellers.Clear();
            base.TickEnded();
        }

        private MatrixCoords GetAccelerationFromParticleToRepeller(ParticleRepeller repeller, Particle particle)
        {
            var currParticleToRepellerVector = repeller.Position - particle.Position;
            var currAcceleration = new MatrixCoords();


            int pToRepRow = currParticleToRepellerVector.Row;
            pToRepRow = -DecreaseVectorCoordToPower(repeller, pToRepRow);

            int pToRepCol = currParticleToRepellerVector.Col;
            pToRepCol = -DecreaseVectorCoordToPower(repeller, pToRepCol);

            currAcceleration = new MatrixCoords(pToRepRow, pToRepCol);


            return currAcceleration;
        }

        private static int DecreaseVectorCoordToPower(ParticleRepeller repeller, int pToRepCoord)
        {
            if (pToRepCoord!= 0 && Math.Abs(pToRepCoord) > repeller.Power)
            {
                pToRepCoord = (pToRepCoord / (int)Math.Abs(pToRepCoord)) * repeller.Power;
            }

            return pToRepCoord;
        }

        private bool IsInRange(MatrixCoords subtractedCoords, ParticleRepeller repeller)
        {
            int range = subtractedCoords.Col * subtractedCoords.Col + subtractedCoords.Row * subtractedCoords.Row;

            return range <= repeller.RepellRadius * repeller.RepellRadius;
        }
    }
}
