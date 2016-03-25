#define USING_EXPRESSIONS


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
            ///<summary>
            ///Creates given array (of generic variable) of size dim stored inside constructed Vector object.
            ///</summary>
            ///<param name="dim">
            ///Dimension
            ///</param>
            vec = new T[dim];
        }
        public Vector(T[] v, int offset = 0, int dim = -1)
        {
            ///<summary>
            ///Copies given array (of generic variable) into generic variable array stored inside Vector object.
            ///</summary>
            ///<param name="dim">
            ///Automatically set to -1. Don't worry about it.
            ///</param>
            ///<param name="offset">
            ///Automatically set to 0. Don't worry about it.
            /// </param>
            /// <param name="v">
            /// Generic variable array that needs to be copied into Vector object.
            /// </param>
            if (v == null)
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
            ///<summary>
            ///Put a vector's stored generic variable array into another vector's stored generic variable array easily.
            /// </summary>
            }
        public Vector<T> MakeDim(int dim)
        {
            ///<summary>
            ///Directly copy a vector object's contents into a new vector, of given Dimension.
            /// </summary>
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
            ///<summary>
            ///Takes a set of generic variables to be in a usable array form, and then stores them inside the new Vector object.
            /// </summary>
            if (v == null)
                throw new ArgumentNullException();
        }
        
        public T Dot(Vector<T> v2)
        {
            ///<summary>
            ///Dot product.
            /// </summary>
            ValidateDimensions(this, v2, "Dot", "this", "v2");
            T sum = default(T);
            for(int i = 0; i < this.Dimension; i++)
            {
#if USING_EXPRESSIONS
                sum = Operations<T>.Add(sum, Operations<T>.Mul(this[i], v2[i]));                
#else
                sum += (dynamic) this[i] * v2[i];
#endif
            }
            return sum;
        }
        public Vector<T> Multiply(T d, Vector<T> res = default(Vector<T>))
        {
            MakeOrValidate(ref res, this.Dimension);
            for(int i = 0; i < this.Dimension; i++)
            {
                //IMPLEMENT
            }
            return res;
        }
        private static void MakeOrValidate<S>(ref Vector<S> v1, int dimension)
        {
            if(v1.vec == null)
            {
                v1.vec = new S[dimension];
            }
            else
            {
                ValidateDimensions(v1, dimension, "MakeOrValidate(Vector<T> v1, int dimension)", "v1");
            }
        }
        private static void ValidateDimensions<Q,S>(Vector<Q> vec1, Vector<S> vec2, string usedBy, string pName1, string pName2)
        {
            ///<summary>
            ///Confirms dimension sizes of two vector objects are equal. Otherwise, throws an error.
            /// </summary>
            if(vec1.Dimension != vec2.Dimension)
            {
                throw new InvalidOperationException(string.Format("Error - {0}.\nDimension mismatch:\n{1}({2})\n{3}({4})", usedBy, pName1, vec1.Dimension, pName2, vec2.Dimension));
            }
        }
        private static void ValidateDimensions<S>(Vector<S> v1, int dim, string method, string pName1)
        {
            if(v1.Dimension != dim)
            {
                throw new InvalidOperationException(string.Format("Error - {0} - Dimension mismatch: expected({1}) given {2}({3})", method, dim, pName1, v1.Dimension));
            }
        }
        public int Dimension
        {
            ///<summary>
            ///Returns the length of the stored array inside Vector object.
            ///</summary>
            get
            {
                return vec.Length;
            }
        }
        public T this[int i]
        {
            ///<summary>
            ///Returns a specific element of the stored array inside Vector object.
            ///Can also set a variable to a specific index of stored array.
            /// </summary>
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
            ///<summary>
            ///Returns the entire array stored inside Vector object.
            /// </summary>
            get
            {
                return vec;
            }
        }
    }
}
