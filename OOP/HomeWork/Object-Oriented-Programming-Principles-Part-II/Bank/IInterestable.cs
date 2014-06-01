namespace Bank
{
    public interface IInterestable
    {
        decimal CalcInterestAmount(int periodMonths);
    }
}
