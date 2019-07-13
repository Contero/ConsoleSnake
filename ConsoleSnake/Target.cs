using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class Target
    {
        Random random = new Random();
        private int value = 1;

        /*
         * Resets target value
         */ 
        public void Reset()
        {
            value = 1;
        }

        /*
         * returns random point and value of target object
         */ 
        public (Point, int) GetTarget()
        {    
            return (new Point(random.Next(1, Nibbler.xMax - 1),
                random.Next(1, Nibbler.yMax - 1)), value);
        }

        /*
         * Increments value of target object
         */
        public void ValueUp()
        {
            value++;
        } 
    }

}
