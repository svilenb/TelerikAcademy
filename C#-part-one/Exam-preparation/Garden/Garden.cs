using System;

class Garden
{
    static void Main()
    {
        int tomatoSeedsAmount = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        int cucumberSeedsAmount = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
        int potatoSeedsAmount = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        int carrotSeedsAmount = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        int cabbageSeedsAmount = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        int beansSeedsAmount = int.Parse(Console.ReadLine());

        double totalCosts = new int();
        int totalArea = 250;
        int beansArea = new int();

        totalCosts = tomatoSeedsAmount * 0.5 + cucumberSeedsAmount * 0.4
            + potatoSeedsAmount * 0.25 + carrotSeedsAmount * 0.6
            + cabbageSeedsAmount * 0.3 + beansSeedsAmount * 0.4;

        beansArea = totalArea - ( tomatoArea
            + cucumberArea +  potatoArea
            + cabbageArea + carrotArea);

        Console.WriteLine("Total costs: {0:F2}", totalCosts);

        if (beansArea == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else if (beansArea < 0)
        {
            Console.WriteLine("Insufficient area");
        }
        else
        {
            Console.WriteLine("Beans area: {0}", beansArea);
        }
    }
}

