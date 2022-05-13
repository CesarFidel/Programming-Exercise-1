using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Programming_Exercise_1
{
    public static class CheckSameTimeTool
    {
        /// <summary>
        /// Return the coincided employees schedule or a message "Not valid string"
        /// </summary>
        /// <param name="schedule">The schedule in string format</param>
        /// <returns>A string of coincidences or a message of invalid input string</returns>
        public static string CheckSameTime(string schedule)
        { 
            if (ValidateString(schedule))
            {
                string employeeCoincided = "";
                var employeeSchedules = GetScheduleByEmployee(schedule);

                if (employeeSchedules != null)
                {
                    employeeCoincided = GetEmployeesCoincided(employeeSchedules);
                }
                else
                {
                    employeeCoincided = "An error has ocurred";
                }

                return employeeCoincided;
            }
            else
            {
                return "Not valid string";
            }

        }

        /// <summary>
        /// Obtain the coincided employees schedule
        /// </summary>
        /// <param name="employeeSchedules">Schedule of th employees in a special format</param>
        /// <returns>String of the tuple of employees and the number of coincidences</returns>
        private static string GetEmployeesCoincided(List<EmployeeSchedule> employeeSchedules)
        {
            string result = "";
            try
            {
                List<Tuple<string, int>> listCoincidedEmployee = new();
                if (employeeSchedules.Count == 1)
                    return "There are needed 2 or more employees";
                else
                {
                    for (int i = 0; i < employeeSchedules.Count; i++) // Employee 1
                    {
                        for (int j = i + 1; j < employeeSchedules.Count; j++) // Employee 2
                        {
                            for (int k = 0; k < employeeSchedules[i].SchedulesPerDay.Count; k++) // Schedule of the Employee 1
                            {
                                for (int l = 0; l < employeeSchedules[j].SchedulesPerDay.Count; l++) // Schedule of the Employee 2
                                {
                                    if (employeeSchedules[i].SchedulesPerDay[k].Day == employeeSchedules[j].SchedulesPerDay[l].Day) // Compare if the two employees has the same day of work
                                    {
                                        if (employeeSchedules[i].SchedulesPerDay[k].StartHour <= employeeSchedules[j].SchedulesPerDay[l].StartHour && employeeSchedules[i].SchedulesPerDay[k].EndHour >= employeeSchedules[j].SchedulesPerDay[l].StartHour) // Compare the schedule of the day
                                        {
                                            Tuple<string, int> value = listCoincidedEmployee.Where(ce => ce.Item1 == employeeSchedules[i].EmployeeName + "-" + employeeSchedules[j].EmployeeName).ToList().FirstOrDefault(); //Check if exists a previous tuple
                                            if (value == null)
                                            {
                                                listCoincidedEmployee.Add(new Tuple<string, int>(employeeSchedules[i].EmployeeName + "-" + employeeSchedules[j].EmployeeName, 1));
                                            }
                                            else
                                            {
                                                int count = value.Item2 + 1;
                                                listCoincidedEmployee.Remove(value);
                                                listCoincidedEmployee.Add(new Tuple<string, int>(employeeSchedules[i].EmployeeName + "-" + employeeSchedules[j].EmployeeName, count));
                                            }
                                        }
                                        else if (employeeSchedules[j].SchedulesPerDay[l].StartHour <= employeeSchedules[i].SchedulesPerDay[k].StartHour && employeeSchedules[j].SchedulesPerDay[l].EndHour >= employeeSchedules[j].SchedulesPerDay[l].StartHour) // Compare the schedule of the day
                                        {
                                            Tuple<string, int> value = listCoincidedEmployee.Where(ce => ce.Item1 == employeeSchedules[i].EmployeeName + "-" + employeeSchedules[j].EmployeeName).ToList().FirstOrDefault(); //Check if exists a previous tuple
                                            if (value == null)
                                            {
                                                listCoincidedEmployee.Add(new Tuple<string, int>(employeeSchedules[i].EmployeeName + "-" + employeeSchedules[j].EmployeeName, 1));
                                            }
                                            else
                                            {
                                                int count = value.Item2 + 1;
                                                listCoincidedEmployee.Remove(value);
                                                listCoincidedEmployee.Add(new Tuple<string, int>(employeeSchedules[i].EmployeeName + "-" + employeeSchedules[j].EmployeeName, count));
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                result = ConvertTupleToString(listCoincidedEmployee);
            }
            catch (Exception e)
            {
                result = "An error has ocurred";
            }
            

            return result;
        }

        /// <summary>
        /// Obtain a string of a list of tuples with the coincidences
        /// </summary>
        /// <param name="listCoincidedEmployee">List of coincidences</param>
        /// <returns>A string with the names and the number of coincidences</returns>
        private static string ConvertTupleToString(List<Tuple<string, int>> listCoincidedEmployee)
        {
            string result = "";
            foreach(var value in listCoincidedEmployee)
            {
                result += value.Item1 + ": " + value.Item2 + "\n";
            }
            return result;
        }

        /// <summary>
        /// Obtain a schedule for every day for every employee
        /// </summary>
        /// <param name="schedule">A string that represents the schedule</param>
        /// <returns>A dictionary with the name of every employee and his/her schedule for everyday</returns>
        private static List<EmployeeSchedule> GetScheduleByEmployee(string schedule)
        {
            try 
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
            catch (Exception e)
            {
                return null;
            }
            
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
