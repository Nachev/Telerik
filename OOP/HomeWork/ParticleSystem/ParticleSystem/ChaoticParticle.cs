namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /*Create ChaoticParticle class, which is a Particle, randomly, changing it's movement (Speed)
     * You are not allowed any existing class.*/

    public class ChaoticParticle : Particle
    {
        private const char Symbol = '@';
        protected Random randomGenerator;

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator) 
            : base(position, speed)
        {
            this.randomGenerator = randomGenerator;
        }

        public override IEnumerable<Particle> Update()
        {
            // Make speed zero.
            int row = this.Speed.Row * -1;
            int col = this.Speed.Col * -1;
            this.Accelerate(new MatrixCoords(row, col));

            // Set new speed.
            row = RandomSpeedElement();
            col = RandomSpeedElement();
            this.Accelerate(new MatrixCoords(row, col));

            return base.Update();
        }

        public override char[,] GetImage()
        {
            return new[,] { { Symbol } };
        }

        private int RandomSpeedElement()
        {
            return (this.randomGenerator.Next(-1, 2));
        }
    }
}
