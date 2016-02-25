using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Asteroids
{
    class Utils
    {
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
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Error creating operations for {0}", typeof(T));
                }
            }
        }
    }
}
