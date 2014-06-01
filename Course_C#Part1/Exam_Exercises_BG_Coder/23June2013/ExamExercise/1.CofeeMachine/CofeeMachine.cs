using System;

private class CofeeMachine
{
    private static void Main()
    {
        // n1 tray for 0.05; n2 tray for 0.10 ...
        short firstTrayAmmount = short.Parse(Console.ReadLine());
        short secondTrayAmmount = short.Parse(Console.ReadLine());
        short thirdTrayAmmount = short.Parse(Console.ReadLine());
        short fourthTrayAmmount = short.Parse(Console.ReadLine());
        short fifthTrayAmmount = short.Parse(Console.ReadLine());
        float moneyInserted = float.Parse(Console.ReadLine());
        float price = float.Parse(Console.ReadLine());
        float traySum = (firstTrayAmmount * 0.05f) + (secondTrayAmmount * 0.10f) + (thirdTrayAmmount * 0.20f) + (fourthTrayAmmount * 0.50f) + (fifthTrayAmmount * 1.00f);
        if ((moneyInserted >= price) && (moneyInserted - price) <= traySum)
        {
            Console.Write("Yes {0:0.00}", traySum - moneyInserted - price);
        }
        else if (price > moneyInserted)
        {
            Console.Write("More {0:0.00}", price - moneyInserted);
        }
        else if ((moneyInserted > price) && ((moneyInserted - price) > traySum))
        {
            Console.Write("No {0:0.00}", Math.Abs(traySum - (moneyInserted - price)));
        }
    }
}
