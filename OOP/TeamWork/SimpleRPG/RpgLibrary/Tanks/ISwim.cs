namespace TankWars.Tanks
{
    using System;
    public interface ISwim
    {
        bool IsSwimming { get; set; }

        int SwimSpeed { get; }

        int OxigenLevel { get; set; }
    }
}
