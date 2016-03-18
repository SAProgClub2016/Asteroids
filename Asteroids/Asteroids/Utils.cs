using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Asteroids
{
    public class Utils
    {
        public static readonly double TOLERANCE = 0.000001;
        public static bool IsZero(int i)
        {
            return i == 0;
        }
        public static bool IsZero(short i)
        {
            return i == 0;
        }
        public static bool IsZero(byte i)
        {
            return i == 0;
        }
        public static bool IsZero(long i)
        {
            return i == 0;
        }
        public static bool IsZero(float f)
        {
            return Math.Abs(f) < TOLERANCE;
        }
        public static bool IsZero(double d)
        {
            return Math.Abs(d) < TOLERANCE;
        }
        public static bool IsZero(object o)
        {
            return false;
        }
        public static bool IsZero(char c)
        {
            return false;
        }
    }
    public static class Operations<T>
    {
        public static readonly Func<T, T, T> Add, Mul, Sub, Div;
        public static readonly Func<T, T> Neg;
        /// <summary>
        /// Utility that allows program to do basic operations with two parameters no matter the variable type.
        /// Allows adaptability.
        /// </summary>
        static Operations()
        {
            try
            {
                var first = Expression.Parameter(typeof(T), "x");
                var second = Expression.Parameter(typeof(T), "y");
                var body = Expression.Add(first, second);
                var bodym = Expression.Multiply(first, second);
                var bodys = Expression.Subtract(first, second);
                var bodyd = Expression.Divide(first, second);
                var bodyn = Expression.Negate(first);
                Add = Expression.Lambda<Func<T, T, T>>(body, first, second).Compile();
                Mul = Expression.Lambda<Func<T, T, T>>(bodym, first, second).Compile();
                Sub = Expression.Lambda<Func<T, T, T>>(bodys, first, second).Compile();
                Div = Expression.Lambda<Func<T, T, T>>(bodyd, first, second).Compile();
                Neg = Expression.Lambda<Func<T, T>>(bodyn, first).Compile();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error creating operations for {0}", typeof(T));
            }
        }
    }
    public static class VectorScalar<V, S>
    {
        public static readonly Func<S, V, V> ScalarLeft;
        public static readonly Func<V, S, V> ScalarRight;
        public static readonly Func<V, V, S> Dot;
        static VectorScalar()
        {
            try
            {
                var vector = Expression.Parameter(typeof(V), "v");
                var vector2 = Expression.Parameter(typeof(V), "v2");
                var scalar = Expression.Parameter(typeof(S), "s");
                var bodysv = Expression.Multiply(scalar, vector);
                var bodyvs = Expression.Multiply(vector, scalar);
                var bodydot = Expression.Multiply(vector, vector2);
                ScalarLeft = Expression.Lambda<Func<S, V, V>>(bodysv, scalar, vector).Compile();
                ScalarRight = Expression.Lambda<Func<V, S, V>>(bodyvs, vector, scalar).Compile();
                Dot = Expression.Lambda<Func<V, V, S>>(bodydot, vector, vector2).Compile();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error creation vector-scalar ops for: {0}, {1}\r\nContinuing", typeof(V), typeof(S));
            }
        }
    }
}
