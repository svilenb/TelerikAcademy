using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        int[] numbers = new int[5];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int divisiblemajority = 0;
        /*Stores the number of numbers
        * our answer is divisble by*/

        int candidate = 1; //Our candidate for least majority multiple

        while (true)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (candidate % numbers[i] == 0)
                {
                    divisiblemajority++;
                }
            }
            if (divisiblemajority >= 3)
            {
                Console.WriteLine(candidate);
                break;
            }
            candidate++;
            divisiblemajority = 0;
        }
    }
}
