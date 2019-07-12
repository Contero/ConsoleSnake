using System;
using System.Threading;

namespace ConsoleSnake
{
    class Program
    {
        public const int xMax = 80,
                yMax = 40;

        static void Main(string[] args)
        {

            char playAgain = 'Y';
            bool alive;
            bool taken = false;
            ConsoleKey keyIn;
            Point targetLocation;
            Snake snake = new Snake();
            Target target = new Target();
            Screen screen = new Screen(xMax, yMax);

            int targetValue;

            //game loop
            do
            {
                alive = true;
                snake.Reset();
                screen.Level = 4; //change to 0
                screen.NextLevel();
                target.Reset();

                //prime targets
                NextTarget();

                while (alive)
                {
                    //non blocking read and input handling
                    if (Console.KeyAvailable)
                    {
                        keyIn = Console.ReadKey(true).Key;

                        switch (keyIn)
                        {
                            case ConsoleKey.UpArrow:
                                if (snake.Direction != 's') snake.Direction = 'n';
                                break;
                            case ConsoleKey.DownArrow:
                                if (snake.Direction != 'n') snake.Direction = 's';
                                break;
                            case ConsoleKey.LeftArrow:
                                if (snake.Direction != 'e') snake.Direction = 'w';
                                break;
                            case ConsoleKey.RightArrow:
                                if (snake.Direction != 'w') snake.Direction = 'e';
                                break;
                        }
                    }

                    //sleep
                    Thread.Sleep(100);

                    //update screen
                    alive = snake.Move();

                    //detect collisions
                    //hit wall?
                    if (snake.GetX() == 0
                        || snake.GetY() == 0
                        || snake.GetX() == xMax - 1
                        || snake.GetY() == yMax - 1
                        || screen.Collides(snake.GetPosition()))
                    {
                        alive = false;
                    }

                    //got target?
                    if (snake.GetPosition().Equals(targetLocation))
                    {
                        if (targetValue < 2)
                        {
                            snake.AddLength(targetValue * screen.Level);
                            target.ValueUp();
                            NextTarget();
                        }
                        else
                        {
                            screen.NextLevel();
                            target.Reset();
                            snake.Reset();
                            NextTarget();
                        }
                    }
                }

                CenterText(5, "Play Again (Y/N)");
                playAgain = ' ';

                while (!(char.ToUpper(playAgain) == 'Y') && !(char.ToUpper(playAgain) == 'N'))
                {
                    playAgain = Console.ReadKey(true).KeyChar;
                }

                CenterText(5, "                ");

            } while (char.ToUpper(playAgain) == 'Y');

            Environment.Exit(0);

            void NextTarget()
            {
                taken = true;
                do
                {
                    (targetLocation, targetValue) = target.GetTarget();

                    if (!snake.Collides(targetLocation) && !screen.Collides(targetLocation))
                    {
                        taken = false;
                    }
                } while (taken);

                Console.SetCursorPosition(targetLocation.xPos, targetLocation.yPos);
                Console.Write(targetValue);
            }
        }


        static private void CenterText(int row, string message)
        {
            int length = message.Length;
            int xPosition = (xMax - length) / 2;

            Console.SetCursorPosition(xPosition, row);
            Console.Write(message);

        }



    }
}

