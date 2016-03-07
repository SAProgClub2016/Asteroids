using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.MathLibrary
{

    public struct Pair<T>
    {
        T x, y;

        public Pair(T x1, T y1)
        {
            x = x1;
            y = y1;
        }
        public T this[int i]
        {
            get
            {
                switch(i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch(i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                         
                }
            }

        }

    }
