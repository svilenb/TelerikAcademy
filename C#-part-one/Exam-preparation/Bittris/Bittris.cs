using System;

class Bittris
{
    static int numberOfCommands = int.Parse(Console.ReadLine());
    static uint[] fallingpieces = new uint[numberOfCommands / 4];
    static int piecesCounter = 0;
    static uint[] rows = new uint[4];
    static char[] operations = new char[numberOfCommands - numberOfCommands / 4];
    static int opCounter = 0;
    static int piecePoints = 0;
    static int currentRow = 0;
    static bool fallen = false;
    static long score = new int();
    static bool pieceShifted = false;

    private static void CalculatePiecePointsAndEnterPiece()
    {
        for (int nextBit = 31; nextBit >= 0; nextBit--)
        {
            uint bitValue = (fallingpieces[piecesCounter] >> nextBit) & 1;

            if (bitValue == 1)
            {
                piecePoints++;

                if (nextBit < 8)
                {
                    rows[0] = rows[0] | (bitValue << nextBit);
                }
            }
        }
    }

    private static void PieceShifting()
    {
        if (operations[opCounter] == 'L' && fallingpieces[piecesCounter - 1] < 128) //&& ((rows[currentRow] & (fallingpieces[piecesCounter - 1] << 1)) == 0)
        {
            fallingpieces[piecesCounter - 1] <<= 1;
            pieceShifted = true;
        }
        else if (operations[opCounter] == 'R' && (fallingpieces[piecesCounter - 1] % 2) == 0) //&& ((rows[currentRow] & (fallingpieces[piecesCounter - 1] >> 1)) == 0)            
        {
            fallingpieces[piecesCounter - 1] >>= 1;
            pieceShifted = true;
        }
        else
        {
            pieceShifted = false;
        }
    }

    private static void MovePieceDown()
    {
        if (operations[opCounter] == 'L' && pieceShifted == true)
        {
            rows[currentRow + 1] |= fallingpieces[piecesCounter - 1];
            rows[currentRow] ^= (fallingpieces[piecesCounter - 1] >> 1);//Clearing previous row
        }
        else if (operations[opCounter] == 'R' && pieceShifted == true)
        {
            rows[currentRow + 1] |= fallingpieces[piecesCounter - 1];
            rows[currentRow] ^= (fallingpieces[piecesCounter - 1] << 1);//Clearing previous row
        }
        else
        {
            rows[currentRow + 1] |= fallingpieces[piecesCounter - 1];
            rows[currentRow] ^= fallingpieces[piecesCounter - 1];//Clearing previous row
        }
    }

    private static void ChangeCurrentRow()
    {
        if (operations[opCounter] == 'L')
        {
            rows[currentRow] ^= (fallingpieces[piecesCounter - 1] >> 1);
            rows[currentRow] |= fallingpieces[piecesCounter - 1];
        }
        else if (operations[opCounter] == 'R')
        {
            rows[currentRow] ^= fallingpieces[piecesCounter - 1] << 1;
            rows[currentRow] |= fallingpieces[piecesCounter - 1];
        }
    }

    private static void CheckForFullRow(int currentRow)
    {
        if (rows[currentRow] == 255)
        {
            if (currentRow == 0)
            {
                rows[currentRow] = 0;
            }
            else
            {
                for (int k = 0; (k <= 3) && (currentRow - (k + 1) >= 0); k++)
                {
                    rows[currentRow - k] = rows[(currentRow - 1) - k];
                }
            }
            piecePoints *= 10;
        }
    }

    private static void PrintMatrix()
    {
        Console.WriteLine();
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 7; j >= 0; j--)
            {
                Console.Write("{0,-2}", rows[i] >> j & 1);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        for (int i = 1; i <= numberOfCommands; i++)
        {
            if (i % 4 == 1)
            {
                fallingpieces[piecesCounter] = uint.Parse(Console.ReadLine());

                CalculatePiecePointsAndEnterPiece();

                piecesCounter++;
            }
            else
            {
                operations[opCounter] = Convert.ToChar(Console.ReadLine());

                if (!fallen)
                {
                    PieceShifting();

                    if (((fallingpieces[piecesCounter - 1] & rows[currentRow + 1]) == 0))
                    {
                        MovePieceDown();
                        currentRow++;
                    }
                    else if ((fallingpieces[piecesCounter - 1] & rows[currentRow + 1]) != 0)
                    {
                        if (pieceShifted == true)
                        {
                            ChangeCurrentRow();
                        }
                        fallen = true;
                    }
                }

                if ((opCounter + 1) % 3 == 0)
                {
                    fallen = false;
                    CheckForFullRow(currentRow);
                    score += piecePoints;
                    piecePoints = 0;
                    currentRow = 0;

                    if (rows[0] != 0)
                    {
                        Console.WriteLine(score);
                        return;
                    }
                }
                opCounter++;
            }
            //PrintMatrix(); //<-- Can be used for easier check of result
        }

        Console.WriteLine(score);
    }
}