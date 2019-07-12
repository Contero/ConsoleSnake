using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class Screen
    {
        private List<Point> walls = new List<Point>();
        private int xMax,
            yMax;
        public int Level { get; set;  }


         public Screen(int xMax, int yMax)
         {
            Console.Title = "Nibbler";
            Console.SetWindowSize(xMax, yMax + 1);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;

            this.xMax = xMax;
            this.yMax = yMax;

            Level = 0;
            NextLevel();
        }

        public void Reset()
        {
            Console.Clear();

            for (int x = 0; x < xMax; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write((char)Glyphs.wall);
                Console.SetCursorPosition(x, yMax - 1);
                Console.Write((char)Glyphs.wall);
            }

            for (int y = 0; y < yMax - 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write((char)Glyphs.wall);
                Console.SetCursorPosition(xMax - 1, y);
                Console.Write((char)Glyphs.wall);
            }

            Console.SetCursorPosition(1, yMax);
            Console.Write("Level: ");
        }

        public bool Collides(Point point)
        {
            return walls.Contains(point);
        }

        public void NextLevel()
        {
            Level++;

            Reset();

            Console.SetCursorPosition(8, yMax);
            Console.Write(Level);

            switch (Level)
            {
                case 1:
                    break;
                case 2:
                    walls.Clear();
                    for (int x = 20; x <= 60; x++)
                    {
                        Console.SetCursorPosition(x, 20);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(x, 20));
                    }
                    break;
                case 3:
                    walls.Clear();
                    for (int y = 10; y <= 30; y++)
                    {
                        Console.SetCursorPosition(15, y);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(15, y));

                        Console.SetCursorPosition(65, y);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(65, y));
                    }
                    break;
                case 4:
                    walls.Clear();
                    for (int y = 1; y <=15; y++)
                    {
                        Console.SetCursorPosition(20, y);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(20, y));

                        Console.SetCursorPosition(60, 40-y);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(60, 40-y));
                    }
                    
                    for (int x = 1; x <= 35; x++)
                    {
                        Console.SetCursorPosition(x, 30);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(x, 30));

                        Console.SetCursorPosition(80-x, 10);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(80 - x, 10));
                    }

                    break;
                case 5:
                    walls.Clear();
                    for(int y = 13; y <= 27 ; y++ )
                    {
                        Console.SetCursorPosition(9 , y);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(9, y));

                        Console.SetCursorPosition(71, y);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(71, y));
                    }

                    for (int x = 11; x <= 69; x++)
                    {
                        Console.SetCursorPosition(x, 11);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(x, 11));

                        Console.SetCursorPosition(x, 29);
                        Console.Write((char)Glyphs.wall);
                        walls.Add(new Point(x,29));
                    }
                    break;
                case 6:
                    walls.Clear();
                    for (int y = 1; y <= 40; y++)
                    {
                        if (y <= 15  || y >= 25)
                            {
                            Console.SetCursorPosition(10, y);
                            Console.Write((char)Glyphs.wall);
                            walls.Add(new Point(10, y));

                            Console.SetCursorPosition(20, y);
                            Console.Write((char)Glyphs.wall);
                            walls.Add(new Point(20, y));

                            Console.SetCursorPosition(30, y);
                            Console.Write((char)Glyphs.wall);
                            walls.Add(new Point(30, y));

                            Console.SetCursorPosition(40, y);
                            Console.Write((char)Glyphs.wall);
                            walls.Add(new Point(40, y));

                            Console.SetCursorPosition(50, y);
                            Console.Write((char)Glyphs.wall);
                            walls.Add(new Point(50, y));

                            Console.SetCursorPosition(60, y);
                            Console.Write((char)Glyphs.wall);
                            walls.Add(new Point(60, y));

                            Console.SetCursorPosition(70, y);
                            Console.Write((char)Glyphs.wall);
                            walls.Add(new Point(70, y));

                        }
                    }
                    /*
                     
                     FOR i = 4 TO 49
            IF i > 30 OR i < 23 THEN
                Set i, 10, colorTable(3)
                Set i, 20, colorTable(3)
                Set i, 30, colorTable(3)
                Set i, 40, colorTable(3)
                Set i, 50, colorTable(3)
                Set i, 60, colorTable(3)
                Set i, 70, colorTable(3)
            END IF
        NEXT i*/
                    break;
            }
        }
    }
}
