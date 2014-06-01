namespace TankWars.Common
{
    public interface IMovable
    {
        ItemPosition Position { get; }

        void Move( int x, int y);
    }
}
