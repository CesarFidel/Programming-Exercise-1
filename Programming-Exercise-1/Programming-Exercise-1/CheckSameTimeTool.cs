using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                return "Valid string";
            }
            else
            {
                return "Not valid string";
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
