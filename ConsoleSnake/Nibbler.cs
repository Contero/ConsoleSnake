using System;
using System.Threading;

namespace ConsoleSnake
{
    class Nibbler
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
            
            //new game
            do
            {
                snake.Lives = 5;
                screen.Level = 0;
                screen.NextLevel();
                Console.SetCursorPosition(67, yMax);
                Console.Write(snake.Lives);

                //new life
                while (snake.Lives > 0)
                {
                    alive = true;
                    snake.Reset();

                    target.Reset();

                    //prime targets
                    NextTarget();

                    //game loop
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
                            if (targetValue < 9)
                            {
                                snake.AddLength(targetValue * screen.Level);
                                target.ValueUp();
                                NextTarget();
                            }
                            else
                            {
                                screen.NextLevel();
                                Console.SetCursorPosition(67, yMax);
                                Console.Write(snake.Lives);
                                target.Reset();
                                snake.Reset();
                                NextTarget();
                            }
                        }
                    }

                    snake.Lives--;
                    screen.Level--;
                    screen.NextLevel();
                    Console.SetCursorPosition(67, yMax);
                    Console.Write(snake.Lives);
                    target.Reset();
                    snake.Reset();
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

            /*
             * Loop to get coordinats for the next target until one is found that is not on
             * the snake and not on a wall, prints the target and stores the location
             */
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

        /*
         * Accepts a row number and a message
         * centers the text for the message and prints it centered on the row
         */ 
        static private void CenterText(int row, string message)
        {
            int length = message.Length;
            int xPosition = (xMax - length) / 2;

            Console.SetCursorPosition(xPosition, row);
            Console.Write(message);

        }



    }
}

