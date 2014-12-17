using System;

class KukataIsDancing
{
    static string[,] sideColors = 
    {
        {"RED", "BLUE", "RED"},
        {"BLUE", "GREEN", "BLUE"},
        {"RED", "BLUE", "RED"},
    };
    
                              //R  F  L  R
    static int[] directionY = { 0, 1, 0, -1 };
    static int[] directionX = { 1, 0, -1, 0 };
    static int directionIndex;
    static int currentX;
    static int currentY;

    static void Main()
    {
        int numberOfDances = int.Parse(Console.ReadLine());
        string[] danceSteps = new string[numberOfDances];

        for (int i = 0; i < numberOfDances; i++)
        {
            danceSteps[i] = Console.ReadLine();
        }

        for (int i = 0; i < numberOfDances; i++)
        {            
            directionIndex = 0;
            currentX = 1;
            currentY = 1;
            string answer = PerformDance(danceSteps[i]);
            Console.WriteLine(answer);
        }
    }

    private static string PerformDance(string steps)
    {
        for (int i = 0; i < steps.Length; i++)
        {
            if (steps[i] == 'L')
            {
                directionIndex = (directionIndex + 1) % 4;
            }
            else if (steps[i] == 'R')
            {
                directionIndex = (directionIndex + 3) % 4;
            }
            else if (steps[i] == 'W')
            {
                currentX += directionX[directionIndex];
                currentY += directionY[directionIndex];
                CheckIfMovedOnOtherSide();
            }
        }

        return sideColors[currentY, currentX];
    }

    private static void CheckIfMovedOnOtherSide()
    {
        if (currentX >= 3)
        {
            currentX = 0;
        }
        else if (currentX < 0)
        {
            currentX = 2;
        }
        else if (currentY >= 3)
        {
            currentY = 0;
        }
        else if (currentY < 0)
        {
            currentY = 2;
        }
    }
}
