using System;

class FighterAttack
{
    static int Px1 = int.Parse(Console.ReadLine());
    static int Py1 = int.Parse(Console.ReadLine());
    static int Px2 = int.Parse(Console.ReadLine());
    static int Py2 = int.Parse(Console.ReadLine());
    static int Fx = int.Parse(Console.ReadLine());
    static int Fy = int.Parse(Console.ReadLine());
    static int D = int.Parse(Console.ReadLine());

    static void Main()
    {
        if (Px1 > Px2)
        {
            int temp = Px1;
            Px1 = Px2;
            Px2 = temp;
        }
        if (Py1 < Py2)
        {
            int temp = Py1;
            Py1 = Py2;
            Py2 = temp;
        }

        float totalDamage = new int();

        totalDamage += CalculateDamage(Fx + D, Fy, 100);
        totalDamage += CalculateDamage(Fx + D + 1, Fy, 75);
        totalDamage += CalculateDamage(Fx + D, Fy + 1, 50);
        totalDamage += CalculateDamage(Fx + D, Fy - 1, 50);

        Console.WriteLine("{0}%", totalDamage);
    }

    static int CalculateDamage(int p1, int p2, int coef)
    {
        int damage = new int();

        if (p1 >= Px1 && p1 <= Px2 && p2 <= Py1 && p2 >= Py2)
        {
            damage = coef;
        }
        return damage;
    }
}
