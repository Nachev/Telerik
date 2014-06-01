namespace TankWarsLibrary.Engine
{
    using System;
    using TankWars.Common;
    using TankWarsLibrary.Tanks;

    public class TankFactory
    {
        public SwinTank CreateSwimTank(string name, int x, int y)
        {
            return new SwinTank(name, new ItemPosition(x, y));
        }

        public HeavyDutyTank CreateHeavyDutyTank(string name, int x, int y)
        {
            return new HeavyDutyTank(name, new ItemPosition(x, y));
        }

        public StealthTank CreateStealthTank(string name, int x, int y)
        {
            return new StealthTank(name, new ItemPosition(x, y));
        }
    }
}
