using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class excav
    {
        public int totalSec = 86400;
        public string name { get; set; }
        public sbyte area { get; set; }
        public uint cycletime { get; set; }
        public short workday { get; set; }
        public float efficiency { get; set; }
        public float performanceExcav;
        public excav(string Name, sbyte Area, uint Cycletime, short Workday, float Efficiency)
        {
            name = Name;
            area = Area;
            cycletime = Cycletime;
            workday = Workday;
            efficiency = Efficiency;
            performanceExcav = getPerformance();
        }
        protected float getPerformance()
        {
            return area * totalSec / cycletime * workday * efficiency/1000;
        }
    }
}

