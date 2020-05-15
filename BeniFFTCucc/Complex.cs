using System;

namespace BeniFFTCucc
{
    public class Complex
    {
        private readonly float real;
        private readonly float imaginary;

        public double Real => Math.Round(real, 2);
        public double Imaginary => Math.Round(imaginary, 2);
        public double Magnitude => Math.Round(GetMagnitude(), 2);
        public double Decibell => 20 * Math.Log10(GetMagnitude());
        public double Phase => Math.Atan2(imaginary, real);

        public Complex()
        {
            this.real = 0.0f;
            this.imaginary = 0.0f;
        }
        public Complex(float real)
        {
            this.real = real;
            this.imaginary = 0.0f;
        }
        public Complex(float real, float imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        private double GetMagnitude()
        {
            return Math.Sqrt(real * real + imaginary * imaginary);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.real + b.real, a.imaginary + b.imaginary);
        }
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.real - b.real, a.imaginary - b.imaginary);
        }
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex((a.real * b.real) - (a.imaginary * b.imaginary), (a.real * b.imaginary) + (a.imaginary * b.real));
        }
    }
}
