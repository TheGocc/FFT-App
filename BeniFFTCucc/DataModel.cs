using System;
using System.Collections.Generic;
using System.Text;

namespace BeniFFTCuccConsole
{
    public class DataModel
    {
        public DateTime RecordTime { get; set; }
        public List<long> RawData { get; set; } = new List<long>();

        public void AddNewRawData(long value)
        {
            RawData.Add(value);
        }

    }
}
