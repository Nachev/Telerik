namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /*Create a ChickenParticleclass. The ChickenParticle class moves like a ChaoticParticle, but randomly stops 
     * at different positions for several simulation ticks and, for each of those stops, creates (lays) a new 
     * ChickenParticle. You are not allowed to edit any existing class. */

    public class ChickenParticle : ChaoticParticle
    {
        private const char Symbol = '^';
        private const int MaxRandomTicks = 50;
        private const int MinRandomTicks = 20;

        private bool isMoving;
        private bool isSpawned;
        private int breakTicks;
        private int breakTicksSave;
        private int movingInterval;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position, speed, randomGenerator)
        {
            this.isSpawned = true;

            BreakThicksInitialization();

            this.isMoving = true;
        }

        public override IEnumerable<Particle> Update()
        {
            List<Particle> baseParticles = new List<Particle>(base.Update());

            if (this.movingInterval > 0)
            {
                this.movingInterval--;
            }
            else
            {
                HandleBreaks();
                if (!isSpawned)
                {
                    int rowSpeed = this.randomGenerator.Next(-1, 2);
                    int colSpeed = this.randomGenerator.Next(-1, 2);
                    var speed = new MatrixCoords(rowSpeed, colSpeed);
                    var layProduct = new ChickenParticle(this.Position, speed, this.randomGenerator);
                    baseParticles.Add(layProduct);
                    isSpawned = !isSpawned;
                }
            }

            return baseParticles;
        }

        public override char[,] GetImage()
        {
            return new[,] { { Symbol } };
        }

        protected override void Move()
        {
            if (isMoving)
            {
                base.Move();
            }
        }

        private void BreakThicksInitialization()
        {
            this.breakTicks = randomGenerator.Next(MinRandomTicks, MaxRandomTicks);
            this.breakTicksSave = this.breakTicks;
            this.movingInterval = randomGenerator.Next(MinRandomTicks, MaxRandomTicks);
            this.isMoving = !this.isMoving;
        }

        private void HandleBreaks()
        {
            if (this.breakTicksSave > 0)
            {
                if (this.breakTicksSave == this.breakTicks)
                {
                    this.isSpawned = !this.isSpawned;
                }

                this.breakTicksSave--;
            }
            else
            {
                BreakThicksInitialization();
            }
        }
    }
}
