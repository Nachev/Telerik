namespace ParticleSystem
{
    using System;
    using System.Linq;

    public class ParticleRepeller : Particle
    {
        private const char Symbol = '&';

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int repellPower, int repellRadius) 
            : base(position, speed)
        {
            this.Power = repellPower;
            this.RepellRadius = repellRadius;
        }

        public int Power { get; private set; }
        public int RepellRadius { get; private set; }

        public override char[,] GetImage()
        {
            return new[,] { { Symbol } };
        }
    }
}
