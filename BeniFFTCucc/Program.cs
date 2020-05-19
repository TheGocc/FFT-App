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
            //asd123
            using var sw = new StreamWriter("result.csv");
            sw.WriteLine("No,Ido,Bemenet,Re,Im,Magnitude,dB,Phase");
            foreach (var d in datas)
            {

                List<Complex> cmplx = new List<Complex>();
                foreach (var item in d.RawData)
                    cmplx.Add(new Complex(item));

                var result = new FourierTransformation().FastFourierTransformation(cmplx.Take(256).ToArray());
                for (int i = 0; i < result.Length; i++)
                {
                    sw.WriteLine($"{i},{d.RecordTime},{d.RawData[i]},{result[i].Real},{result[i].Imaginary},{result[i].Magnitude},{result[i].Decibell},{result[i].Phase}");
                }
            }

        }


    }
}
