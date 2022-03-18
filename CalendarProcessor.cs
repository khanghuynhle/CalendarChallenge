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
        private readonly IDayHelper _dayHelper;
        private int NextDate { get; set; } = 0;
        public CalendarProcessor(ListOfCalendar listCal, IDayHelper dayHelper)
        {
            _listCal = listCal;
            _dayHelper = dayHelper;
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
            string footer = "</ul></body></html>";
            return footer;
        }

        private List<string> GenerateMonthsScript(int year, int daysInMonth, string month)
        {
            List<string> daysToDisplay = new List<string>();
            List<string> monthToDisplay = new List<string>();
            string daysInAWeek = "<ul class=\"weekdays\"><li>Mo</li><li>Tu</li><li>We</li><li>Th</li><li>Fr</li><li>Sa</li><li>Su</li></ul><ul class=\"days\">";

            string monthMakeUp = "<div class=\"month\"> <ul><li>" + month + "<br></li></ul></div>";
            monthToDisplay.Add(monthMakeUp);

            //add empty spaces before the first month of the years
            for (int firstDay = 0; firstDay < _listCal.FirstDayOfYears.Count; firstDay++)
            {
                if (month == "Janurary")
                {
                    daysToDisplay.Add(string.Join("", GenerateEmptySpacesFirstMonth((int)_listCal.FirstDayOfYears[firstDay], 0)));
                    break;
                }
                else if (month == "October" && year == 1582)
                {
                    break;
                }
            }
            daysToDisplay.Add(string.Join("", GenerateDaysWithinMonth(daysInMonth)));

            //add weeks of this month
            //calculate how many empty days before the starting day
            monthToDisplay.Add(daysInAWeek);
            int repeatedTimes =0;
            var index = _listCal.ListOfTotaldaysOfAMonth.IndexOf(new Tuple<int, string>(daysInMonth, month));
            if (month != "Janurary")
            {
                repeatedTimes = _listCal.YearDayForward.Select(x => x.Item2).ElementAt(index - 1);
            }
            //wrap the forward days here
            monthToDisplay.AddRange(GenerateEmptySpaceRemainingMonths(repeatedTimes));

            //displaying the whole month here
            monthToDisplay.AddRange(daysToDisplay);

            //the left days here
            repeatedTimes = _listCal.YearDayLeft.Select(x => x.Item2).ElementAt(_listCal.ListOfTotaldaysOfAMonth.IndexOf(new Tuple<int, string>(daysInMonth, month)));
            monthToDisplay.AddRange(GenerateEmptySpaceRemainingMonths(repeatedTimes));

            //each month corelate to each weekdays and daysToDisplay
            return monthToDisplay;
        }

        private List<string> GenerateDaysWithinMonth(int daysInMonth)
        {
            List<string> daysToDisplay = new List<string>();
            for (int day = 1; day <= daysInMonth; day++)
            {
                daysToDisplay.Add("<li>" + day + "</li>");
            }

            return daysToDisplay;
        }

        private List<string> GenerateEmptySpacesFirstMonth(int startDate, int weekDay)
        {
            int emptyDays = GetEmptyDays(startDate, weekDay);
            List<string> emptyDaysScripts = new List<string>();
            if (emptyDays == 0)
            {
                return emptyDaysScripts;
            }
            else
            {
                for (int i = 1; i <= emptyDays; i++)
                {
                    emptyDaysScripts.Add("<li>X</li>");
                }
                return emptyDaysScripts;
            }
        }

        private List<string> GenerateEmptySpaceRemainingMonths(int timeRepeated)
        {
            List<string> spaces = new List<string>();
            for(int i = 0; i < timeRepeated; i++)
            {
                spaces.Add("<li>X</li>");
            }
            return spaces;
        }

        private int GetEmptyDays(int startDate, int weekDay)
        {
            int emptyDays = startDate - weekDay - 1;
            return emptyDays;
        }

        public int GetFirstDayOfYear(int year)
        {
            int firstDay = (((year - 1) * 365) + ((year - 1) / 4) - ((year - 1) / 100) + ((year) / 400)) % 7;
            return firstDay;
        }
    }
}
