using BeniFFTCucc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeniFFTCuccConsole
{
    public class FourierTransformation
    {
        public Complex[] DiscreteFourierTransformation(Complex[] input)
        {
            int N = input.Length;
            Complex[] X = new Complex[input.Length];

            for (int k = 0; k < N; k++)
            {
                X[k] = new Complex(0, 0);
                for (int n = 0; n < N; n++)
                {
                    Complex tmp = GetComplexFromPolar(1, (float)(-2 * Math.PI * n * k / N));
                    tmp *= input[n];
                    X[k] += tmp;
                }
            }
            return X;
        }

        public Complex[] FastFourierTransformation(Complex[] input)
        {
            int N = input.Length;
            Complex[] X = new Complex[N];
            Complex[] e, E, d, D;

            if (N == 1)
            {
                X[0] = input[0];
                return X;
            }

            e = new Complex[N / 2];
            d = new Complex[N / 2];

            for (int k = 0; k < N / 2; k++)
            {
                e[k] = input[k * 2];
                d[k] = input[k * 2 + 1];
            }

            E = FastFourierTransformation(e);
            D = FastFourierTransformation(d);

            for (int k = 0; k < N / 2; k++)
            {
                Complex tmp = GetComplexFromPolar(1, (float)(-2 * Math.PI * k / N));
                D[k] *= tmp;
            }

            for (int k = 0; k < N / 2; k++)
            {
                X[k] = E[k] + D[k];
                X[k + N / 2] = E[k] - D[k];
            }

            return X;
        }


        private Complex GetComplexFromPolar(float r, float theta)
        {
            return new Complex(r * (float)Math.Cos(theta), r * (float)Math.Sin(theta));
        }

    }
}
