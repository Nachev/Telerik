namespace AcademyRPG
{
    using System;
    using System.Linq;

    public class House : StaticObject
    {
        private const int InitialHitPoints = 500;

        public House(Point position, int owner) 
            : base(position, owner)
        {
            this.HitPoints = InitialHitPoints;
        }
    }
}
