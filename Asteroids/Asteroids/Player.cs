using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Player : GameObject
    {
        int score, bulletCount;
        Boolean alive = true;
        public Player(int x, int y)
        {
            setX(x);
            setY(y);
        }

    }
}
