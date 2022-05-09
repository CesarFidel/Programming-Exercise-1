using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Exercise_1
{
    class EmployeeSchedule
    {
        public EmployeeSchedule(string employeeName, Dictionary<string, string> schedulePerDay)
        {
            EmployeeName = employeeName;
            SchedulePerDay = schedulePerDay;
        }
        public string EmployeeName { get; set; }
        public  Dictionary<string, string> SchedulePerDay { get; set; }
    }
}
