# Programming-Exercise-1
## Architecture of the solution
It consists of the file Program.cs in this the main method calls a static class that reads a txt file, if there is not one with that name creates one with a predefined example, and extracts the text, this text is returned and sent to another static class that will be responsible for reviewing the string, first check that it is the correct format, then transforms the string to a class that was created to see the information in a simpler way, once transformed is sent to another method that will compare this data and return the results.


## Approach and methodology
Once the file is read, the extracted string is checked to see if it is valid, for this we used a special regular expression for this exercise and check the following

ASTRID=LU 10:00-12:00, THU 12:00-14:00, SUN 20:00-21:00

First there must be a name composed of any number of upper- or lower-case letters followed by an equals sign. After this there must be two letters denoting the day (MO, TU, WE, TH, FR, SA SU), then there will be two hours in 24 hour format (separated by a hyphen) in case there are more days a comma (,) will be placed and another day will follow in the same format, when there are no more days a line break will be made and another employee will follow with the same rules, so on until there are no more employees.

After that, the string is transformed to an object of the EmployeeSchedule class, composed by the employee's name and a list of the SchedulePerDay class composed by the name of the day and a start and end time. The method to transform it is simple, first it is divided into employees, that is, by lines, then it is divided into the name of the employee and their schedules, then the schedule is divided by days and then the day between day and hour, once this is done the time is converted into DateTime and the SchedulePerDay objects are created when we have all these objects the EmployeeSchedule object is created with the list of the previous ones and the employee's name.

Now it is time to get the number of coincidences, with the list we built in the last method we will do the following:

A cycle that will go through an employee, another cycle that will go through the second employee (to avoid that it is compared with itself and there are repetitions the second cycle will always begin in the following employee of the list), another cycle that will go through the schedule of the first employee, another cycle that will go through the schedule of the second employee, from there it will compare if they have the same working day, and if so it will compare their hours to check if they are on the same schedule, if so it will create a tuple with the employee's name and the number of matches, it will be updated as matches are found.

With the tuples already created we will enter another method in charge of transforming these tuples to a string, this string will be returned and this one will be shown to the user.

## How to run the program
Once you download the solution and compile it you need to create a text file in the \Programming-Exercise-1\Programming-Exercise-1\Programming-Exercise-1\bin\Debug\net5.0 folder if you don't create the program will create one with a predefined example, if you created it you need to rename the file in the Main method of the Program.cs file on line 9.