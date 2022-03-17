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
        public void CalendarUIGenerator(int year, int daysInMonth)
        {
            File.WriteAllText(@"C:\Calendar.html", HtmlScriptGenerator(year, daysInMonth));

        }

        private string HtmlScriptGenerator(int year, int daysInMonth)
        {
            string header = "<!DOCTYPE html>< html >< head ><title>Calendar of " + year.ToString() + "</title></ head >";
            string footer = "</div> </ body > </ html >";
            string body = HtmlBodyGenerator(year, daysInMonth);
            string html = header + body + footer;
            return html;
        }

        private string HtmlBodyGenerator(int year, int daysInMonth)
        {
            string daysInAWeek = "<div class=\"jzdbox1 jzdbasf jzdcal\"> < span >Su</span>< span > Mo </ span >< span > Tu </ span >< span > We </ span >< span > Th </ span >< span > Fr </ span >< span > Sa </ span > ";

            string monthsDaysWeekDaysScript = GenerateMonthsScript(year, daysInMonth);

            string body = daysInAWeek + monthsDaysWeekDaysScript;
            return body;
        }

        private string GenerateMonthsScript(int year, int daysInMonth)
        {
            List<string> monthToDisplay = new List<string>();
            List<string> daysToDisplay = new List<string>();

            for (int i = 0; i < _listCal.ListOfMonthsWithYears.Count; i++)
            {
                string month = _listCal.ListOfMonthsWithYears[i].Item2;
                string monthMakeUp = "< div class=\"jzdcalt\">" + month.ToString() + "</div>";

                //add empty spaces before the first month
                if (_listCal.ListOfMonthsWithYears[i].Item2.Equals("Janurary"))
                    daysToDisplay.Add(GenerateEmptySpaces((int)_listCal.FirstDayOfYears[0], 0));
                else if (_listCal.ListOfMonthsWithYears[i].Item2.Equals("October") && year == 1582)
                    daysToDisplay.Add(GenerateEmptySpaces(0, 0));

                //add weeks of this month
                foreach (int firstDay in _listCal.FirstDayOfYears)
                {
                    for (int weekDay = 0; weekDay < firstDay; weekDay++)
                    {
                        //calculate how many empty days before the starting day

                        for (int day = 1; day <= daysInMonth; day++)
                        {
                            if (++weekDay > 6)
                            {
                                weekDay = 0;
                            }
                            daysToDisplay.Add("<span>" + day + "</span>");
                        }
                    }
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

            for (int i = 0; i <= emptyDays; i++)
            {
                emptyDaysScripts.Add("<span class=\"jzdb\"><!--BLANK--></span>");
            }

            return emptyDays.ToString();
        }
        private int GetEmptyDays(int startDate, int weekDay)
        {
            int emptyDays = startDate - weekDay;
            return emptyDays;
        }

        public DayOfWeek GetFirstDayOfYear(int year)
        {
            int firstDay = (((year - 1) * 365) + ((year - 1) / 4) - ((year - 1) / 100) + ((year) / 400) + 1) % 7;
            return (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), firstDay);
        }
    }
}
