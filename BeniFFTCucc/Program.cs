using BeniFFTCuccConsole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BeniFFTCucc
{
    class Program
    {
        static void Main(string[] args)
        {

            List<DataModel> datas = new DataParser("asd.csv").LoadFromTextFile();

            foreach (var d in datas)
            {
                List<Complex> cmplx = new List<Complex>();
                foreach (var item in d.RawData)
                    cmplx.Add(new Complex(item));

                var result = new FourierTransformation().FastFourierTransformation(cmplx.Take(128).ToArray());


                foreach (var item in result)
                {
                    Console.WriteLine(item.Real + "; " + item.Imaginary + " -- Mag: " + item.Magnitude + " -- Phase: " + item.Phase);
                }
                Console.WriteLine("------------");
                Console.ReadLine();
                Console.Clear();
            }


            //var result = new FourierTransformation().FastFourierTransformation(data.ToArray());

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Real + "; " + item.Imaginary + " -- Mag: " + item.Magnitude + " -- Phase: " + item.Phase);
            //}


        }


    }
}
