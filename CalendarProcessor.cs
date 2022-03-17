using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using System;
using System.Collections.Generic;
using System.IO;

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
            string header = "<!DOCTYPE html>< html >< head ><title>Calendar of " + year.ToString() + "</title></ head >";
            return header;
        }

        public string HtmlBodyScriptGenerator(int year, int daysInMonth)
        {
            string monthsDaysWeekDaysScript = GenerateMonthsScript(year, daysInMonth);

            return monthsDaysWeekDaysScript;
        }

        public string HtmlFooterScript()
        {
            string footer = "</div> </ body > </ html >";
            return footer;
        }

        private string GenerateMonthsScript(int year, int daysInMonth)
        {
            List<string> monthToDisplay = new List<string>();
            List<string> daysToDisplay = new List<string>();
            string daysInAWeek = "<div class=\"jzdbox1 jzdbasf jzdcal\"> < span >Su</span>< span > Mo </ span >< span > Tu </ span >< span > We </ span >< span > Th </ span >< span > Fr </ span >< span > Sa </ span > ";
            foreach (int totalMonth in _listCal.TotalMonths)
            {
                for (int i = 0; i < totalMonth; i++)
                {
                    string month = _listCal.ListOfMonthsWithYears[i].Item2;
                    string monthMakeUp = "< div class=\"jzdcalt\">" + month.ToString() + "</div>";

                    //add empty spaces before the first month
                    if (_listCal.ListOfMonthsWithYears[i].Item2.Equals("Janurary"))
                        daysToDisplay.Add(GenerateEmptySpaces((int)_listCal.FirstDayOfYears[0], 0));
                    else if (_listCal.ListOfMonthsWithYears[i].Item2.Equals("October") && year == 1582)
                        daysToDisplay.Add(GenerateEmptySpaces(0, 0));

                    //add weeks of this month
                    //calculate how many empty days before the starting day

                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        daysToDisplay.Add("<span>" + day + "</span>");
                    }
                    monthToDisplay.Add(daysInAWeek);
                    monthToDisplay.Add(monthMakeUp);
                    monthToDisplay.AddRange(daysToDisplay);
                }
            }

            //each month corelate to each weekdays and daysToDisplay
            return monthToDisplay.ToString();
        }

        private string GenerateEmptySpaces(int startDate, int weekDay)
        {
            int emptyDays = GetEmptyDays(startDate, weekDay);
            List<string> emptyDaysScripts = new List<string>();

            for (int i = 1; i <= emptyDays; i++)
            {
                emptyDaysScripts.Add("<span class=\"jzdb\"><!--BLANK--></span>");
            }

            return emptyDaysScripts.ToString();
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
