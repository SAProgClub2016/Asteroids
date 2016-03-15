using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Asteroids.Time
{
    class Timer
    {
        [DllImport("kernel32.dll")]
        private static extern int GetTickCount();
        private long StartTick = 0;
        public long Time
        {
            get
            {
                long currentTick = GetTickCount();
                return currentTick - StartTick;
            }
            set
            {
                StartTick = GetTickCount() - value;
            }
        }
        public Timer()
        {
            Reset();
        }
        public void Reset()
        {
            StartTick = GetTickCount();
        }
    }
}
