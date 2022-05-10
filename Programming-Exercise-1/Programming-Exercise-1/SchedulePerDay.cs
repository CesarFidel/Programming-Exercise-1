using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Exercise_1
{
    class SchedulePerDay
    {
        public SchedulePerDay(string day, DateTime startHour, DateTime endHour)
        {
            Day = day;
            StartHour = startHour;
            EndHour = endHour;
        }
        public string Day { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
    }
}
