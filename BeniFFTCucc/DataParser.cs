using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace BeniFFTCuccConsole
{
    public class DataParser
    {
        private readonly string path;

        public DataParser(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }


        public List<DataModel> LoadFromTextFile()
        {
            using var sr = new StreamReader("asd.csv");
            string line;

            List<DataModel> model = new List<DataModel>();
            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    var tmp = line.Split(',');
                    var time = ParseTimeSpan(tmp[0]);
                    var value = long.Parse(tmp[2]);

                    if (model.Count == 0 || model.Last().RecordTime.Second != time.Second)
                    {
                        DataModel dtm = new DataModel();
                        dtm.RecordTime = time;
                        dtm.AddNewRawData(value);
                        model.Add(dtm);
                    }
                    else
                    {
                        model.Last().AddNewRawData(value);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return model;
        }

        private DateTime ParseTimeSpan(string timeSpan)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan t = new TimeSpan(long.Parse(timeSpan));
            dtDateTime = dtDateTime.AddMilliseconds(long.Parse(timeSpan)).ToLocalTime();
            return dtDateTime;
        }
    }
}
