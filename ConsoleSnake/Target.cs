using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class Target
    {
        Random random = new Random();
        private int value = 1;

        public void Reset()
        {
            value = 1;
        }

        public (Point, int) GetTarget()
        {    
            return (new Point(random.Next(1, Program.xMax - 1),
                random.Next(1, Program.yMax - 1)), value);
        }

        public void ValueUp()
        {
            value++;
        } 
    }

}
