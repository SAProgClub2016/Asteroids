using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class GameObject
    {
        private int x, y, dx, dy, xAccel, yAccel;
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void setXAccel(int xAccel)
        {
           this.xAccel = xAccel;
        }
        public void setYAccel(int yAccel)
        {
            this.yAccel = yAccel;
        }
        public int getXAccel()
        {
            return xAccel;
        }
        public int getYAccel()
        {
            return yAccel;
        }
    }
}
