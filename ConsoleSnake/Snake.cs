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
        public char Direction { get;  set; }
        
        public int GetX()
        {
            return position.xPos;
        }

        public int GetY()
        {
            return position.yPos;
        }

        public Snake()
        {
            Reset();
        }

        public void AddLength(int growth)
        {
            Length += growth;
        }

        public void Reset()
        {
            Length = 2;
            position.xPos = (Program.xMax / 2) + 2;
            position.yPos = (Program.yMax / 2) - 2;
            Direction = 'n';
            body.Clear();
            body.Add(new Point(position.xPos, position.yPos));
        }

        /*
         * Method to move snake
         */
        public bool Move()
        {
            switch (Direction)
            {
                case 'n':
                    position.yPos--;
                    break;
                case 's':
                    position.yPos++;
                    break;
                case 'e':
                    position.xPos++;
                    break;
                case 'w':
                    position.xPos--;
                    break;
            }

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
                Console.Write(' ');
            }

            return true;

            }

        public Point GetPosition()
        {
            return position;
        }

        public bool Collides(Point point)
        {
            return body.Contains(point);
        }
    }
}
