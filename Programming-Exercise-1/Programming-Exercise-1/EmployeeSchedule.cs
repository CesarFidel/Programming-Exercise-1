using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Exercise_1
{
    class EmployeeSchedule
    {
        public EmployeeSchedule(string employeeName, List<SchedulePerDay> schedulesPerDay)
        {
            EmployeeName = employeeName;
            SchedulesPerDay = schedulesPerDay;
        }
        public string EmployeeName { get; set; }
        public  List<SchedulePerDay> SchedulesPerDay { get; set; }
    }
}
