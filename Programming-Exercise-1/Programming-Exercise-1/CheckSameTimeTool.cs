﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Programming_Exercise_1
{
    internal static class CheckSameTimeTool
    {
        public static string CheckSameTime(string schedule)
        { 
            if (ValidateString(schedule))
            {
                var employeeSchedules = GetScheduleByEmployee(schedule);
                return "Valid string";
            }
            else
            {
                return "Not valid string";
            }

        }

        /// <summary>
        /// Obtain a schedule for every day for every employee
        /// </summary>
        /// <param name="schedule">A string that represents the schedule</param>
        /// <returns>A dictionary with the name of every employee and his/her schedule for everyday</returns>
        private static List<EmployeeSchedule> GetScheduleByEmployee(string schedule)
        {
            List<EmployeeSchedule> employeeSchedules = new();

            //Divide the schedule per employee
            List<string> scheduleByPerson = schedule.Split('\n').ToList();
            List<string> names = new();

            foreach (var hoursPerson in scheduleByPerson)
            {
                List<SchedulePerDay> dayAndHours = new();
                //Divide the schedule employee into employee and schedule
                List<string> hoursPersonDiv = hoursPerson.Split('=').ToList();

                //Divide the schedule by days
                List<string> daysHours = hoursPersonDiv[1].Split(',').ToList();

                //Divide the days and the hours
                List<string> days = daysHours.Select(d => d.Substring(0, 2)).ToList();
                List<string> hours = daysHours.Select(d => d[2..]).ToList();

                for (int i = 0; i < days.Count; i++)
                {
                    DateTime starHour = Convert.ToDateTime(hours[i].Split('-')[0]);
                    DateTime endHour = Convert.ToDateTime(hours[i].Split('-')[1]);
                    dayAndHours.Add(new SchedulePerDay(days[i], starHour, endHour));
                }

                //Adds the employee schedule
                EmployeeSchedule employeeSchedule = new EmployeeSchedule(hoursPersonDiv[0], dayAndHours);
                employeeSchedules.Add(employeeSchedule);
            }

            return employeeSchedules;
        }

        /// <summary>
        /// Validate the input string
        /// </summary>
        /// <param name="input">String to validate</param>
        /// <returns>Validate true or false</returns>
        private static bool ValidateString(string input)
        {
            if (input == null)
                return false;
            else
            {
                // Regular expression for a valid input
                Regex regex = new Regex(@"^(([A-Za-z]+)=((MO|TU|WE|TH|FR|SA|SU)([01][0-9]|2[0-3]):[0-5][0-9]-([01][0-9]|2[0-3]):[0-5][0-9])(,(MO|TU|WE|TH|FR|SA|SU)([01][0-9]|2[0-3]):[0-5][0-9]-([01][0-9]|2[0-3]):[0-5][0-9][\n]?)*)+$");

                // Check the input
                Match match = regex.Match(input);

                if (match.Success)
                    return true;
                else
                    return false;
            }
        }
    }
}