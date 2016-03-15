using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Asteroids.Time
{
    class HiResTimer
    {
        Stopwatch stopwatch;
        public HiResTimer()
        {
            stopwatch = new Stopwatch();
            stopwatch.Reset();
        }
        public bool Started
        {
            get;
            private set;
        }
        public bool Paused
        {
            get;
            private set;
        }
        public bool Running
        {
            get
            {
                return Started && !Paused;
            }
        }
        public long ElapsedMilliseconds
        {
            get
            {
                return stopwatch.ElapsedMilliseconds;
            }
        }
        public void Start()
        {
            if(!Started)
            {
                stopwatch.Reset();
                stopwatch.Start();
                Started = true;
            }
        }
        public void Unpause()
        {
            if(Paused)
            {
                stopwatch.Start();
                Paused = false;
            }
        }
        public void Stop()
        {
            stopwatch.Stop();
            Started = false;
            Paused = false;
        }
    }
}
