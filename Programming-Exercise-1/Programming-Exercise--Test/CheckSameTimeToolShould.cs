using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Programming_Exercise_1;

namespace Programming_Exercise__Test
{
    public class CheckSameTimeToolShould
    {
        [Theory]
        [InlineData("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00\n" +
                    "ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00\n" +
                    "ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00", 
                    "RENE-ASTRID: 2\n" + "RENE-ANDRES: 2\n" + "ASTRID-ANDRES: 3\n")]
        [InlineData("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00\n" +
                    "ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00\n" +
                    "ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00\n" +
                    "CESAR=MO11:50-12:10,TU11:00-15:00,SA22:00-23:00\n" +
                    "JUAN=TU09:15-12:00",
                    "RENE-ASTRID: 2\n" + "RENE-ANDRES: 2\n" + "RENE-CESAR: 2\n" + "RENE-JUAN: 1\n" + "ASTRID-ANDRES: 3\n" + "ASTRID-CESAR: 1\n" + "ANDRES-CESAR: 1\n" + "CESAR-JUAN: 1\n")]
        public void ReturnScheduleCoincidencesWithValidScheduleInput(string schedule, string expected)
        {
            //Arrange

            //Act
            string actual = CheckSameTimeTool.CheckSameTime(schedule);
            //Assert
            Assert.Equal(expected, actual);
        }
    

        [Theory]
        [InlineData("RENE = MO10:00 - 12:00, TU10: 00 - 12:00, TH01: 00 - 03:00, SA14: 00 - 18:00, SU20: 00 - 21:00\n" +
                    "ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00\n" +
                    "ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00", "Not valid string")]
        [InlineData("R", "Not valid string")]
        [InlineData("12:00, TH01: 00 - 03:00, SA14: 00 - 18:00, SU20: 00 - 21:00\n" +
                    "ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00\n" +
                    "ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00", "Not valid string")]
        [InlineData("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00", "There are needed 2 or more employees")]
        [InlineData("gdfgd", "Not valid string")]
        [InlineData("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00" +
                    "ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00\n" +
                    "ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00",
                    "An error has ocurred")]
        public void ReturnMessageOfInvalidInputWithInvalidScheduleInput(string schedule, string expected)
        {
            //Arrange

            //Act
            string actual = CheckSameTimeTool.CheckSameTime(schedule);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
