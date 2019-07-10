using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    struct Point
    {
        public int xPos,
            yPos;

        public Point(int x,int y)
        {
            xPos = x;
            yPos = y;
        }

    }

    enum Glyphs
    {
        wall = 9619,
        snake = 9608
    }
}
