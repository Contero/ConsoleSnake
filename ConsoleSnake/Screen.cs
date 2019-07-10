using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class Screen
    {
        private List<Point> walls = new List<Point>();

        public Screen(int xMax, int yMax)
        {
            Console.Title = "Nibbler";
            Console.SetWindowSize(xMax, yMax + 1);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;

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
        }

        public bool Collides(Point point)
        {
            return walls.Contains(point);
        }
    }
}
