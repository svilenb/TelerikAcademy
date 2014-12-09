using System;

class CoffeeMachine
{
    static void Main()
    {
        decimal[] trays = { 0.05m, 0.10m, 0.20m, 0.50m, 1.00m };

        int N1 = int.Parse(Console.ReadLine());
        int N2 = int.Parse(Console.ReadLine());
        int N3 = int.Parse(Console.ReadLine());
        int N4 = int.Parse(Console.ReadLine());
        int N5 = int.Parse(Console.ReadLine());
        decimal enteredMoney = decimal.Parse(Console.ReadLine());
        decimal priceOfDrink = decimal.Parse(Console.ReadLine());
        decimal totalMoneyInMachine = 0;

        decimal change = enteredMoney - priceOfDrink;
        totalMoneyInMachine = N1 * trays[0] + N2 * trays[1] 
            + N3 * trays[2] + N4 * trays[3] + N5 * trays[4];

        if (change >= 0)
        {
            if (change <= totalMoneyInMachine)
            {
                Console.WriteLine("Yes {0:F2}", totalMoneyInMachine-change);
            }
            else
            {
                Console.WriteLine("No {0:F2}", change-totalMoneyInMachine);
            }
        }
        else
        {
            Console.WriteLine("More {0:F2}", priceOfDrink-enteredMoney);
        }
    }
}

