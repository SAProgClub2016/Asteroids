using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.MathLibrary.Function
{


    public abstract class IntegrableFunction<T, Q>
    {
        public abstract Func<T, Q> F { get; }
        public abstract Func<T, Q> FI { get; }
    }

}
