using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalendarChallenge
{
    internal class CalendarProcessor : ICalendarProcessor
    {
        private readonly ListOfCalendar _listCal;
        public CalendarProcessor(ListOfCalendar listCal)
        {
            _listCal = listCal;
        }

        public string HtmlHeaderScript(int year)
        {
            string header = "<!DOCTYPE html><html><head><title>Calendar of " + year.ToString() + "</title>  <link rel=\"stylesheet\" href=\"styles.css\"></head ><body>";
            return header;
        }

        public string HtmlBodyScriptGenerator(int year, int daysInMonth, string month) 
            => string.Join(" ", GenerateMonthsScript(year, daysInMonth, month));

        public string HtmlFooterScript()
        {
            string footer = "</table> </body > </html >";
            return footer;
        }

        private List<string> GenerateMonthsScript(int year, int daysInMonth, string month)
        { 
            List<string> daysToDisplay = new List<string>();
            List<string> monthToDisplay = new List<string>();
            string daysInAWeek = "<table> <td >Su</td><td> Mo </td ><td> Tu </td><td> We </td><td> Th </td><td> Fr </td><td> Sa </td >";

            string monthMakeUp = " <tr>" + month.ToString() + "</div> </tr>";
            monthToDisplay.Add(monthMakeUp);

            //add empty spaces before the first month
            if (month =="Janurary")
                daysToDisplay.Add(GenerateEmptySpaces((int)_listCal.FirstDayOfYears[0], 0));
            else if (month == "October" && year == 1582)
                daysToDisplay.Add(GenerateEmptySpaces(0, 0));

            daysToDisplay = GenerateDaysWithinMonth(daysInMonth);

            //add weeks of this month
            //calculate how many empty days before the starting day
            monthToDisplay.Add(daysInAWeek);
            monthToDisplay.AddRange(daysToDisplay);

            //each month corelate to each weekdays and daysToDisplay
            return monthToDisplay;
        }

        private List<string> GenerateDaysWithinMonth(int daysInMonth)
        {
            List<string> daysToDisplay = new List<string>();
            for (int day = 1; day <= daysInMonth; day++)
            {
                daysToDisplay.Add("<td>" + day + "</td>");
            }

            return daysToDisplay;
        }

        private string GenerateEmptySpaces(int startDate, int weekDay)
        {
            int emptyDays = GetEmptyDays(startDate, weekDay);
            List<string> emptyDaysScripts = new List<string>();
            if (emptyDays == 0)
            {
                return "";
            }
            else
            {
                for (int i = 1; i <= emptyDays; i++)
                {
                    emptyDaysScripts.Add("<td><!--BLANK--></td>");
                }
                return emptyDaysScripts.ToString();
            }
        }

        private int GetEmptyDays(int startDate, int weekDay)
        {
            int emptyDays = startDate - weekDay - 1;
            return emptyDays;
        }

        public int GetFirstDayOfYear(int year)
        {
            int firstDay = (((year - 1) * 365) + ((year - 1) / 4) - ((year - 1) / 100) + ((year) / 400) + 1) % 7;
            return firstDay;
        }
    }
}
