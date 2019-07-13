using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    /*
     * Simple Structre to hold x and y coordinates
     */ 
    struct Point
    {
        public int xPos,
            yPos;

        /*
         * Accepts X and Y coordinates
         * Constructor - creates point at X and Y
         */ 
        public Point(int x,int y)
        {
            xPos = x;
            yPos = y;
        }

    }
    /*
     * Enum to hold ASCII Values for snake and wall 'graphics'
     */ 
    enum Glyphs
    {
        wall = 9619,
        snake = 9608
    }
}
