using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.MathLibrary
{
    public struct Vector<T> //Generic
    {
        T[] vec;
        public Vector(int dim)
        {
            vec = new T[dim];
        }
        public Vector(T[] v, int offset = 0, int dim = -1)
        {
            if(v == null)
            {
                throw new ArgumentNullException();
            }
            int indmax = 0;
            if(dim > 0)
            {
                vec = new T[dim];
                indmax = Math.Min(dim, Math.Max(v.Length - offset, 0));
            }
            else
            {
                vec = new T[Math.Max(v.Length - offset, 0)];
                indmax = Math.Max(v.Length - offset, 0);
            }
            for(int i = 0; i < indmax; i++)
            {
                this[i] = v[i + offset];
            }
        }
        public Vector(Vector<T> o, int offset = 0, int dim = -1)
            : this(o.vec, offset, dim)
            {
            }
        public Vector<T> MakeDim(int dim)
        {
            Vector<T> ans = new Vector<T>(dim);
            int i = 0;
            for(; i < dim && i < this.Dimension; i++)
            {
                ans[i] = this[i];
            }
            return ans;
        }
        public Vector(params T[] v)
            : this(v, (int)0)
        {
            if (v == null)
                throw new ArgumentNullException();
        }
        public int Dimension
        {
            get
            {
                return vec.Length;
            }
        }
        public T this[int i]
        {
            get
            {
                return vec[i];
            }
            set
            {
                vec[i] = value;
            }
        }
        public T[] AsArray
        {
            get
            {
                return vec;
            }
        }
    }
}
