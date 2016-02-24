using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.GameLibrary.EntityLibrary
{
    class Player : Entity
    {
        int score, bulletCount;
        Boolean alive = true;
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
