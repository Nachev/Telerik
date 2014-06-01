namespace Garden
{
    using System;

    class Garden
    {
        static void Main()
        {
            const int TotalArea = 250;
            const double TomatoPrice = 0.5;
            const double CucumberPrice = 0.4;
            const double PotatoPrice = 0.25;
            const double CarrotPrice = 0.6;
            const double CabbagePrice = 0.3;
            const double BeansPrice = 0.4;

            // Input
            int tomatoSeedAmount = int.Parse(Console.ReadLine());
            int tomatoArea = int.Parse(Console.ReadLine());
            int cucumberSeedAmount = int.Parse(Console.ReadLine());
            int cucumberArea = int.Parse(Console.ReadLine());
            int potatoSeedAmount = int.Parse(Console.ReadLine());
            int potatoArea = int.Parse(Console.ReadLine());
            int carrotSeedAmount = int.Parse(Console.ReadLine());
            int carrotArea = int.Parse(Console.ReadLine());
            int cabbageSeedAmount = int.Parse(Console.ReadLine());
            int cabbageArea = int.Parse(Console.ReadLine());
            int beansSeedAmount = int.Parse(Console.ReadLine());

            // Calculate costs
            double totalCosts = new double();
            double tomatoCosts = (double)tomatoSeedAmount * TomatoPrice;
            double cucumberCosts = (double)cucumberSeedAmount * CucumberPrice;
            double potatoCosts = (double)potatoSeedAmount * PotatoPrice;
            double carrotCosts = (double)carrotSeedAmount * CarrotPrice;
            double cabbageCosts = (double)cabbageSeedAmount * CabbagePrice;
            double beansCosts = (double)beansSeedAmount * BeansPrice;
            totalCosts = tomatoCosts + cucumberCosts + potatoCosts + carrotCosts + cabbageCosts + beansCosts;
            Console.WriteLine("Total costs: {0:0.00}", totalCosts);

            // Calculate areas
            string outputStr;
            int usedArea = new int();
            usedArea = tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea;
            int remainingArea = TotalArea - usedArea;
            if (usedArea > TotalArea)
            {
                outputStr = "Insufficient area";
            }
            else if (usedArea == TotalArea)
            {
                outputStr = "No area for beans";
            }
            else
            {
                outputStr = "Beans area: " + remainingArea;
            }
            Console.Write(outputStr);
        }
    }
}
