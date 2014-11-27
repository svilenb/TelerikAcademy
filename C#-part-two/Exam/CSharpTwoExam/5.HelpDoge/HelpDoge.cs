using System;

class HelpDoge
{
    static char[,] lab;
    static int counter = new int();
    static string[] FxAndFy;
    static int[] intFxandFy = new int[2];

    static void FindPath(int row, int col)
    {
        if ((col < 0) || (row < 0) || (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)) ||
            col > intFxandFy[1] || row > intFxandFy[0] ||
            (col == intFxandFy[1] && ThereIsEnemyOnTheCol(row, col)) ||
            (row == intFxandFy[0] && ThereIsEnemyOnTheRow(row, col)))
        {
            // We are out of the labyrinth
            return;
        }

        // Check if we have found the exit
        if (lab[row, col] == 'e')
        {
            counter++;
        }

        if (lab[row, col] != '\0')
        {
            // The current cell is not free
            return;
        }

        // Mark the current cell as visited
        lab[row, col] = 's';
        // Invoke recursion to explore all possible directions        
        FindPath(row, col + 1); // right
        FindPath(row + 1, col); // down
        // Mark back the current cell as free
        lab[row, col] = '\0';
    }

    private static bool ThereIsEnemyOnTheRow(int row, int col)
    {
        for (int i = col + 1; i <= intFxandFy[0]; i++)
        {
            if (lab[row, col] == '*') return true;
        }

        return false;
    }

    private static bool ThereIsEnemyOnTheCol(int row, int col)
    {
        for (int i = row + 1; i <= intFxandFy[1]; i++)
        {
            if (lab[row, col] == '*') return true;
        }

        return false;
    }

    static void Main()
    {
        ReadInput();

        if (intFxandFy[0] >= 1 && intFxandFy[1] >= 1)
        {
            if (lab[intFxandFy[0] - 1, intFxandFy[1]] == '*' && lab[intFxandFy[0], intFxandFy[1] - 1] == '*')
            {
                Console.WriteLine(0);
                return;
            }
        }

        FindPath(0, 0);
        Console.WriteLine(counter);
    }

    private static void ReadInput()
    {
        string[] NandM = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        lab = new char[int.Parse(NandM[0]), int.Parse(NandM[1])];

        FxAndFy = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        intFxandFy[0] = int.Parse(FxAndFy[0]);
        intFxandFy[1] = int.Parse(FxAndFy[1]);
        lab[intFxandFy[0], intFxandFy[1]] = 'e';

        int numberOfEnemies = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfEnemies; i++)
        {
            string[] KxAndKy = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            lab[int.Parse(KxAndKy[0]), int.Parse(KxAndKy[1])] = '*';
        }
    }
}
