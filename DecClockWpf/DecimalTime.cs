using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecClockWpf
{
    internal class DecimalTime
    {
        private int dhour { get; set; }
        private int dminut{ get; set; }
        private double dsecond { get; set; }
        public int Hours { get { Calculate(); return dhour; } }
        public int Minuts { get { Calculate(); return dminut; } }
        public double Seconds { get { Calculate(); return dsecond; } }

        public override String ToString()
        {
            Calculate();
            return dhour.ToString("00") + ":" + dminut.ToString("00") + ":" + ((int)dsecond).ToString("00");
        }
        private void Calculate()
        {
            TimeSpan ts = DateTime.Now - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            double tseconds = ts.TotalSeconds;
            double seconds = (100000 * tseconds) / 86400;
            dhour =(int) seconds / 10000;
            dminut = (int)(seconds % 10000)/100;
            dsecond = seconds % 100;
        }

    }
}
