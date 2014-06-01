namespace MobilePhone
{
    using System;

    public class GSMCallHistoryTest
    {
        private static void Main()
        {
            GSM test = new GSM("1100", "Nokia", "BL-5C", BatteryType.LiIon, 15, 320, 1.5, 2, 154.3M, "Pesho");
            Console.WriteLine(test);
            test = new GSM("3310", "Nokia");
            Console.WriteLine();
            Console.WriteLine(test);
            test = new GSM("6310", "Nokia", "BL-6P", null, null, null, null, null, null, "Peter");
            Console.WriteLine();
            Console.WriteLine(test);
            test = new GSM("1600", "Nokia", "BL-5C", 1.5);
            Console.WriteLine();
            Console.WriteLine(test);
            test = GSM.IPhone4S;
            Console.WriteLine();
            Console.WriteLine(test);

            Console.WriteLine("ARRAY TEST");
            GSM[] shop = 
            {
                new GSM("1100", "Nokia", "BL-5C", BatteryType.LiIon, 15, 320, 1.5, 2, 154.3M, "Pesho"),
                new GSM("3310", "Nokia"),
                new GSM("6310", "Nokia", "BL-6P", null, null, null, null, null, null, "Gosho"),
                new GSM("Hero", "HTC", "Built-In", 3.7)
            };

            foreach (var gsm in shop)
            {
                Console.WriteLine(gsm);
            }

            test.CallHistoryAdd(new Call(DateTime.Now, "+359888845652", 20));
            test.CallHistoryAdd(new Call(DateTime.Now.AddMinutes(32), "0885005852", 98));
            test.CallHistoryAdd(new Call(DateTime.Now.AddHours(2), "+359898588885", 320));
            test.CallHistoryAdd(new Call(DateTime.Now.AddDays(1), "5552356", 12));
            Console.WriteLine(test.CallHistoryToString());
            Console.WriteLine("{0:C}", test.TotalPrice(0.37M));

            test.CallHistoryDelAt(test.PositionOfLongestCall());
            Console.WriteLine(test.CallHistoryToString());
            Console.WriteLine("{0:C}", test.TotalPrice(0.37M));

            // test.CallHistoryDeleteLast();
            // test.CallHistoryDelAt(1);
            test.CallHistoryClear();
            Console.WriteLine(test.CallHistoryToString());
        }
    }
}
