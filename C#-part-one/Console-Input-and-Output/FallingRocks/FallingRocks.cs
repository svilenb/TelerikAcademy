using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

struct Object
{
    public int x;
    public int y;
    public char c;
    public string str;
    public ConsoleColor color;
}

class FallingRocks
{
    static void PrintOnPosition(int x, int y, char c,
        ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static void PrintStringOnPosition(int x, int y, string str,
        ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    static void SetTheConsole()
    {
        Console.BufferHeight = Console.WindowHeight = 15;
        Console.BufferWidth = Console.WindowWidth = 50;
        Console.BackgroundColor = ConsoleColor.White;
    }

    static void Main(string[] args)
    {
        SetTheConsole();

        Object dwarf = new Object();
        dwarf.x = 24;
        dwarf.y = 14;
        dwarf.str = "(O)";
        dwarf.color = ConsoleColor.Black;
        Random randomGenerator = new Random();
        List<Object> rocks = new List<Object>();

        while (true)
        {
            bool dwarfHitted = false;
            int chance = randomGenerator.Next(0, 12);

            switch (chance)
            {
                case 0:
                    Object newRock0 = new Object();
                    newRock0.color = ConsoleColor.Green;
                    newRock0.c = '$';
                    newRock0.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock0.y = 0;
                    rocks.Add(newRock0);
                    break;
                case 1:
                    Object newRock1 = new Object();
                    newRock1.color = ConsoleColor.Blue;
                    newRock1.c = '^';
                    newRock1.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock1.y = 0;
                    rocks.Add(newRock1);
                    break;
                case 2:
                    Object newRock2 = new Object();
                    newRock2.color = ConsoleColor.DarkBlue;
                    newRock2.c = '*';
                    newRock2.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock2.y = 0;
                    rocks.Add(newRock2);
                    break;
                case 3:
                    Object newRock3 = new Object();
                    newRock3.color = ConsoleColor.DarkGreen;
                    newRock3.c = '%';
                    newRock3.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock3.y = 0;
                    rocks.Add(newRock3);
                    break;
                case 4:
                    Object newRock4 = new Object();
                    newRock4.color = ConsoleColor.Red;
                    newRock4.c = '#';
                    newRock4.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock4.y = 0;
                    rocks.Add(newRock4);
                    break;
                case 5:
                    Object newRock5 = new Object();
                    newRock5.color = ConsoleColor.Blue;
                    newRock5.c = '^';
                    newRock5.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock5.y = 0;
                    rocks.Add(newRock5);
                    break;
                case 6:
                    Object newRock6 = new Object();
                    newRock6.color = ConsoleColor.Blue;
                    newRock6.c = '+';
                    newRock6.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock6.y = 0;
                    rocks.Add(newRock6);
                    break;
                case 7:
                    Object newRock7 = new Object();
                    newRock7.color = ConsoleColor.Magenta;
                    newRock7.c = '!';
                    newRock7.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock7.y = 0;
                    rocks.Add(newRock7);
                    break;
                case 8:
                    Object newRock8 = new Object();
                    newRock8.color = ConsoleColor.Magenta;
                    newRock8.c = '@';
                    newRock8.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock8.y = 0;
                    rocks.Add(newRock8);
                    break;
                case 9:
                    Object newRock9 = new Object();
                    newRock9.color = ConsoleColor.DarkYellow;
                    newRock9.c = ';';
                    newRock9.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock9.y = 0;
                    rocks.Add(newRock9);
                    break;
                case 10:
                    Object newRock10 = new Object();
                    newRock10.color = ConsoleColor.DarkYellow;
                    newRock10.c = '.';
                    newRock10.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock10.y = 0;
                    rocks.Add(newRock10);
                    break;
                case 11:
                    Object newRock11 = new Object();
                    newRock11.color = ConsoleColor.DarkGreen;
                    newRock11.c = '&';
                    newRock11.x = randomGenerator.Next(0, Console.BufferWidth - 1);
                    newRock11.y = 0;
                    rocks.Add(newRock11);
                    break;
                default:
                    break;
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x - 2 >= 0)
                    {
                        dwarf.x -= 1;
                    }
                }

                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x + 1 < Console.BufferWidth - 2)
                    {
                        dwarf.x += 1;
                    }
                }
            }

            List<Object> newRocks = new List<Object>();

            for (int i = 0; i < rocks.Count; i++)
            {
                Object oldRock = rocks[i];
                Object newRock = new Object();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.c = oldRock.c;
                newRock.color = oldRock.color;

                if (newRock.y == dwarf.y && (newRock.x == dwarf.x || newRock.x == dwarf.x - 1 || newRock.x == dwarf.x + 1))
                {
                    dwarfHitted = true;
                    PrintStringOnPosition(dwarf.x - 1, dwarf.y, "DEAD", ConsoleColor.Red);
                    PrintStringOnPosition(24, 6, "GAME OVER!!!", ConsoleColor.Red);
                    PrintStringOnPosition(24, 8, "Press [enter] to exit", ConsoleColor.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                if (newRock.y < Console.WindowHeight)
                {
                    newRocks.Add(newRock);
                }
            }

            rocks = newRocks;
            Console.Clear();

            if (dwarfHitted)
            {
                rocks.Clear();
            }
            else
            {
                PrintStringOnPosition(dwarf.x - 1, dwarf.y, dwarf.str, dwarf.color);
            }

            foreach (Object rock in rocks)
            {
                PrintOnPosition(rock.x, rock.y, rock.c, rock.color);
            }

            Thread.Sleep(150);
        }
    }
}
