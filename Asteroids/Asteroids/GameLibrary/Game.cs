using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Asteroids.GameLibrary.EntityLibrary;
using Asteroids.MathLibrary.Function;

namespace Asteroids.GameLibrary
{
    class Game
    {
        private Time.Timer gameTimer;
        private Func<double, double> timeFunc;
        private IntegrableFunction<double, double> timeRateFunc;
        double curTimeRate;
        public void ResetTime()
        {
            gameTimer.Reset();
            timeRateFunc = new PolyFunc<double, double>(curTimeRate);
            timeFunc = timeRateFunc.FI;
        }
        public Game()
        {
            gameTimer = new Time.Timer();
        }
    }
}
