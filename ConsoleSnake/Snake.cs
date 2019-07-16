using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class Snake
    {
        private int Length;
        private Point position;
        private List<Point> body = new List<Point>();
        public Direction Direction { get; set; }
        public int Lives { get; set; }
        private int score;

        /*
         * Returns X axis coordinate of snake head
         */
        public int GetX()
        {
            return position.xPos;
        }

        /*
         * Returns Y axis coordinate of snake head
         */
        public int GetY()
        {
            return position.yPos;
        }

        /*
         * Constructor - creats instance of Snake
         */
        public Snake()
        {
            Reset();
        }

        /*
         * Accepts a number to increae length by
         * Increases the length by that amount
         */
        public void AddLength(int growth)
        {
            Length += growth;
        }

        /*
         * resets the snake for a new level or life
         */
        public void Reset()
        {
            Length = 2;
            position.xPos = (Nibbler.xMax / 2) + 2;
            position.yPos = (Nibbler.yMax / 2) - 2;
            Direction = Direction.North;
            body.Clear();
            body.Add(new Point(position.xPos, position.yPos));
        }

        /*
         * Method to move snake and return false if snake collides with itself, otherwise
         * return true
         */
        public bool Move()
        {
            switch (Direction)
            {
                case Direction.North:
                    position.yPos--;
                    break;
                case Direction.South:
                    position.yPos++;
                    break;
                case Direction.East:
                    position.xPos++;
                    break;
                case Direction.West:
                    position.xPos--;
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(position.xPos, position.yPos);
            Console.Write((char)Glyphs.snake);

            if (Collides(position))
            {
                return false;
            }
        
            body.Add(new Point(position.xPos, position.yPos));

            if (body.Count > Length)
            {
                Point erase = body[0];
                body.RemoveAt(0);
                Console.SetCursorPosition(erase.xPos, erase.yPos);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write((char)Glyphs.snake);
            }

            return true;

            }

        /*
         * Returns position as Point
         */
        public Point GetPosition()
        {
            return position;
        }

        /*
         * Accepts a Point
         * Returns True if that point is on the snake body 
         */
        public bool Collides(Point point)
        {
            return body.Contains(point);
        }

        /*
         * Accepts ints for level and target value
         * Calculates amount to increase score
         * prints score on screen
         */
        public void AddScore(int level, int value)
        {
            score += level * value;
            PrintScore();
        }

        /*
         * Resets score to 0
         */
         public void ResetScore()
        {
            score = 0;
        }

        /*
         * Prints score on screen
         */
         public void PrintScore()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(37, Nibbler.yMax);
            Console.Write(score);
        }
    }
}
