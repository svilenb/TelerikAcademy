using System;

class MathExpression
{
    static void Main()
    {
        decimal N = decimal.Parse(Console.ReadLine());
        decimal M = decimal.Parse(Console.ReadLine());
        decimal P = decimal.Parse(Console.ReadLine());
        decimal expression = new decimal();
        decimal nominator = N * N + 1 / (M * P) + 1337;
        decimal denominator = N - 128.523123123m * P;
        int mod = (int)M % 180;
        expression = nominator / denominator + (decimal)Math.Sin(mod);
        Console.WriteLine("{0:F6}", expression);
    }
}

