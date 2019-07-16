using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class Screen
    {
        private List<Point> walls = new List<Point>();
        private readonly int xMax,
            yMax;
        public int Level { get; set;  }

        /*
         * Accepts size of the playing field as ints
         * creates instace of game screen
         */ 
         public Screen(int xMax, int yMax)
         {
            Title = "Nibbler";
            SetWindowSize(xMax, yMax + 1);
            CursorVisible = false;
            BackgroundColor = ConsoleColor.Blue;
            Clear();

            this.xMax = xMax;
            this.yMax = yMax;

            Level = 0;
            NextLevel();
        }

        /*
         * Resets the screen
         */ 
        public void Reset()
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            for (int x = 0; x < xMax; x++)
            {
                SetCursorPosition(x, 0);
                Write((char)Glyphs.wall);
                SetCursorPosition(x, yMax - 1);
                Write((char)Glyphs.wall);
            }

            for (int y = 0; y < yMax - 1; y++)
            {
                SetCursorPosition(0, y);
                Write((char)Glyphs.wall);
                SetCursorPosition(xMax - 1, y);
                Write((char)Glyphs.wall);
            }

            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(1, yMax);
            Write("Level:");

            SetCursorPosition(30, yMax);
            Write("Score:");

            SetCursorPosition(60, yMax);
            Write("Lives:");
        }

        /*
         * Accepts a Point
         * returns true if that point is on a wall
         */
        public bool Collides(Point point)
        {
            return walls.Contains(point);
        }

        /*
         * Increases the level property, draws new level, and sets wall point List
         */
        public void NextLevel()
        {
            Level++;

            Reset();

            SetCursorPosition(8, yMax);
            Write(Level);

            ForegroundColor = ConsoleColor.Red;

            switch (Level)
            {
                case 1:
                    walls.Clear();
                    break;
                case 2:
                    walls.Clear();
                    for (int x = 20; x <= 60; x++)
                    {
                        PutWall(x, 20);
                    }
                    break;
                case 3:
                    walls.Clear();
                    for (int y = 10; y <= 30; y++)
                    {
                        PutWall(15, y);
                        PutWall(65, y);
                        
                    }
                    break;
                case 4:
                    walls.Clear();
                    for (int y = 1; y <=15; y++)
                    {
                        PutWall(20, y);
                        PutWall(60, 40-y);
                        
                    }
                    
                    for (int x = 1; x <= 35; x++)
                    {
                        PutWall(x, 30);
                        PutWall(80-x, 10);
                        }

                    break;
                case 5:
                    walls.Clear();
                    for(int y = 13; y <= 27 ; y++ )
                    {
                        PutWall(9 , y);
                        PutWall(71, y);
                        }

                    for (int x = 11; x <= 69; x++)
                    {
                        PutWall(x, 11);
                        PutWall(x, 29);
                        }
                    break;
                case 6:
                    walls.Clear();
                    for (int y = 1; y < 40; y++)
                    {
                        if (y <= 15  || y >= 25)
                            {
                            PutWall(10, y);
                            PutWall(20, y);
                            PutWall(30, y);
                            PutWall(40, y);
                            PutWall(50, y);
                            PutWall(60, y);
                            PutWall(70, y);
                        }
                    }
                    break;
                case 7:
                    walls.Clear();
                    for (int y = 1;y <40 ; y+=2)
                    {
                        PutWall(40, y);
                        
                    }
                    break;
                case 8:
                    walls.Clear();
                    for (int y = 0; y <= 35; y++)
                    {
                        PutWall(10, y);
                        PutWall(20, 39-y);
                        PutWall(30, y);
                        PutWall(40, 39-y);
                        PutWall(50, y);
                        PutWall(60, 39-y);
                        PutWall(70, y);
                        
                    }
                    break;

                case 9:
                    walls.Clear();
                    for (int i = 3; i < 37; i++)
                    {
                        PutWall(i,i);
                        PutWall(i + 39, i);
                    }
                    break;
                default:
                    walls.Clear();
                    for (int y = 1; y < 39; y+=2)
                    {
                        PutWall(10, y);
                        PutWall(20, y+1);
                        PutWall(30, y);
                        PutWall(40, y+1);
                        PutWall(50, y);
                        PutWall(60, y+1);
                        PutWall(70, y);
                    }
                    break;
            }
        }

        /*
         * Accepts X and Y coordinates
         * prints a wall glyph there and adds coordinates to List of wall points
         */ 
        private void PutWall(int x, int y)
        {
            SetCursorPosition(x, y);
            Write((char)Glyphs.wall);
            walls.Add(new Point(x, y));
        }
    }
}
