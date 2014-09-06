namespace RandomDataGenerator.Contracts
{
    public interface IRandomNumberProvider
    {
        int GetIntInRange(int min, int max);

        int GetIntUpTo(int max);

        double GetDoubleInRange(double min, double max);

        double GetDouble();

        bool GetChance(int percentage);
    }
}
