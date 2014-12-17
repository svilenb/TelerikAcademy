using System;

class Laser
{
    static int[] WHD = new int[3];
    static int[] startWHD = new int[3];
    static int[] dirWHD = new int[3];
    static int[] currentWHD = new int[3];
    static bool[, ,] cube;

    static void Main()
    {
        ReadInput();

        cube = new bool[WHD[0]+1, WHD[1]+1, WHD[2]+1];

        for (int i = 0; i < 3; i++)
        {
            currentWHD[i] = startWHD[i];
        }
        
        while (true)
        {
            cube[currentWHD[0], currentWHD[1], currentWHD[2]] = true;
            
            MoveLaser();

            if (cube[currentWHD[0], currentWHD[1], currentWHD[2]] == true || IsOnEdgeOrVertex())
            {
                Console.WriteLine("{0} {1} {2}", currentWHD[0] - dirWHD[0], currentWHD[1] - dirWHD[1], currentWHD[2] - dirWHD[2]); //Print the previous position
                return;
            }
        }
    }

    private static bool IsOnEdgeOrVertex()
    {
        int counter = 0;
        for (int i = 0; i < 3; i++)
        {
            if (currentWHD[i] <= 1 || currentWHD[i] >= WHD[i])
            {
                counter++;
            }
        }

        return counter >= 2 ? true : false;
    }

    private static void MoveLaser()
    {
        for (int i = 0; i < 3; i++)
        {
            if (currentWHD[i] + dirWHD[i] > WHD[i] || currentWHD[i] + dirWHD[i] < 1)
            {
                dirWHD[i] = -dirWHD[i];
            }
            currentWHD[i] += dirWHD[i];
        }
    }

    private static void ReadInput()
    {
        string[] strWHD = Console.ReadLine().Split();

        for (int i = 0; i < strWHD.Length; i++)
        {
            WHD[i] = int.Parse(strWHD[i]);
        }

        string[] strStartWHD = Console.ReadLine().Split();

        for (int i = 0; i < strStartWHD.Length; i++)
        {
            startWHD[i] = int.Parse(strStartWHD[i]);
        }

        string[] strDirWHD = Console.ReadLine().Split();

        for (int i = 0; i < strDirWHD.Length; i++)
        {
            dirWHD[i] = int.Parse(strDirWHD[i]);
        }
    }
}
