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
            }
        }
    }
}
