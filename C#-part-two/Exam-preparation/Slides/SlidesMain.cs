namespace Slides
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;

    class Ball
    {
        private int currentWidth;
        private int currentHeight;
        private int currentDepth;
        private bool isStuck;

        public Ball(int w, int h, int d)
        {
            this.currentWidth = w;
            this.currentHeight = h;
            this.currentDepth = d;
            this.isStuck = false;
        }

        public Ball(Ball oldBall)
        {
            this.BallWidth = oldBall.BallWidth;
            this.BallHeight = oldBall.BallHeight;
            this.BallDepth = oldBall.BallDepth;
        }

        public int BallWidth
        {
            get
            {
                return this.currentWidth;
            }
            set
            {
                this.currentWidth = value;
            }
        }

        public int BallHeight
        {
            get
            {
                return this.currentHeight;
            }
            set
            {
                this.currentHeight = value;
            }
        }

        public int BallDepth
        {
            get
            {
                return this.currentDepth;
            }
            set
            {
                this.currentDepth = value;
            }
        }

        public bool BallStuck
        {
            get
            {
                return this.isStuck;
            }
            set
            {
                this.isStuck = value;
            }
        }

        public void Slide(string command)
        {
            Ball newBall = new Ball(this);

            if (command == "L")
            {
                newBall.currentWidth--;
            }
            else if (command == "R")
            {
                newBall.currentWidth++;
            }
            else if (command == "F")
            {
                newBall.currentDepth--;
            }
            else if (command == "B")
            {
                newBall.currentDepth++;
            }
            else if (command == "FL")
            {
                newBall.currentWidth--;
                newBall.currentDepth--;
            }
            else if (command == "FR")
            {
                newBall.currentWidth++;
                newBall.currentDepth--;
            }
            else if (command == "BL")
            {
                newBall.currentWidth--;
                newBall.currentDepth++;
            }
            else if (command == "BR")
            {
                newBall.currentWidth++;
                newBall.currentDepth++;
            }
            newBall.BallHeight++;

            if (newBall.IsInCube())
            {
                this.BallWidth = newBall.BallWidth;
                this.BallHeight = newBall.BallHeight;
                this.BallDepth = newBall.BallDepth;
            }
            else
            {
                this.BallStuck = true;
            }
        }

        public bool IsInCube()
        {
            if (this.BallWidth >= 0 && this.BallWidth < SlidesMain.whd[0]
                && this.BallDepth >= 0 && this.BallDepth < SlidesMain.whd[2]
                && this.BallHeight < SlidesMain.whd[1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Teleport(int telWidth, int telDepth)
        {
            this.currentWidth = telWidth;
            this.currentDepth = telDepth;
        }

        public void MoveBall(string command)
        {
            if (command == "E")
            {
                if (this.currentHeight == SlidesMain.whd[1] - 1)
                {
                    this.BallStuck = true;                    
                }
                else
                {
                    this.currentHeight++;
                }
            }
            else if (command == "B")
            {
                this.BallStuck = true;
            }
            else if (command[0] == 'S')
            {
                this.Slide(command.Substring(2));
            }
            else if (command[0] == 'T')
            {
                string[] splittedCommand = command.Split();
                this.Teleport(int.Parse(splittedCommand[1]), int.Parse(splittedCommand[2]));
            }
        }
    }

    class SlidesMain
    {
        public static int[] whd;
        public static string[, ,] cube;
        public static int[] ballWD;

        private static void ReadInput()
        {
            //if (File.Exists("input.txt"))
            //{
            //    Console.SetIn(new StreamReader("input.txt"));
            //}

            whd = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            cube = new string[whd[0], whd[1], whd[2]];

            for (int h = 0; h < whd[1]; h++)
            {
                string[] line = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                for (int d = 0; d < whd[2]; d++)
                {
                    string[] cubeContent = line[d].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int w = 0; w < whd[0]; w++)
                    {
                        cube[w, h, d] = cubeContent[w];
                    }
                }
            }

            ballWD = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }

        private static void PrintMessage(Ball ball)
        {
            if (ball.BallHeight != whd[1] - 1 || cube[ball.BallWidth, ball.BallHeight, ball.BallDepth] == "B")
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
            Console.WriteLine("{0} {1} {2}", ball.BallWidth, ball.BallHeight, ball.BallDepth);
        }

        static void Main()
        {
            ReadInput();

            Ball ball = new Ball(ballWD[0], 0, ballWD[1]);

            while (true)
            {
                ball.MoveBall(cube[ball.BallWidth, ball.BallHeight, ball.BallDepth]);

                if (ball.BallStuck)
                {
                    PrintMessage(ball);
                    return;
                }
            }
        }
    }
}
