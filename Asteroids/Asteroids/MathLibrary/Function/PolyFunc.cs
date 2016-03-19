#define USING_EXPRESSIONS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.MathLibrary.Function
{
    public class PolyFunc<TC, TP> : IntegrableFunction<TP, TC>
    {
        PolyFunc<TC, TP> integral;
        Vector<TC> coeffs;
        //Retrieves degree to take integral or derivative of something.
        public int Degree
        {
            get
            {
                return coeffs.Dimension - 1;
            }
        }
        public override Func<TP, TC> F
        {
            get
            {
                return this.Evaluate;
            }
        }
        public override Func<TP, TC> FI
        {
            get
            {
                return this.Integral.F;
            }
        }
        //Takes the integral.
        public PolyFunc<TC, TP> Integral
        {
            get
            {
                if(integral == null)
                {
                    if(Degree < 0)
                    {
                        integral = new PolyFunc<TC, TP>();
                    }
                    else
                    {
                        TC[] iCos = new TC[coeffs.Dimension + 1];
                        for(int i = 0; i < coeffs.Dimension; i++)
                        {
                            iCos[i + 1] = (dynamic)coeffs[i] / (i + 1);
                        }
                        integral = new PolyFunc<TC, TP>(iCos);
                    }
                }
                return integral;
            }
        }
        public PolyFunc(params TC[] cos)
        {
            int count = 0;
            while(cos.Length - 1 - count >= 0 && Utils.IsZero((dynamic)cos[cos.Length - 1 - count]))
            {
                count++;
            }
            TC[] ans;
            if(count == 0)
            {
                ans = cos;
            }
            else
            {
                ans = new TC[cos.Length - count];
                for(int i = 0; i < ans.Length; i++)
                {
                    ans[i] = cos[i];
                }
                coeffs = new Vector<TC>(ans);
            }
        }
        //Evaluate vector.
        public TC Evaluate(TP t)
        {
            TC sum = default(TC);
            if (coeffs.Dimension == 0)
                return sum;
            for(int i = coeffs.Dimension - 1; i > 0; i--)
            {
#if(USING_EXPRESSIONS)
                sum = VectorScalar<TC, TP>.ScalarRight(Operations<TC>.Add(sum, coeffs[i]), t);
#else
                sum = (dynamic)t * ((dynamic)sum + coeffs[i]);
#endif
            }
#if (USING_EXPRESSIONS)
            sum = Operations<TC>.Add(sum, coeffs[0]);
#else
            sum += (dynamic)coeffs[0];
#endif
            return sum;
        }
    }
}
