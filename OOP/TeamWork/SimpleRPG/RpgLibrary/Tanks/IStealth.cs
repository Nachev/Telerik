namespace TankWars.Tanks
{
    interface IStealth
    {
        bool IsInvisible { get; set; }

        int InvisibilityDuration { get; }

    }
}
