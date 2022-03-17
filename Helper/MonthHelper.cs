using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarChallenge
{
    internal class MonthHelper : IMonthHelper
    {
        private readonly ListOfCalendar _listCalendar;
        public MonthHelper(ListOfCalendar listCalendar)
        {
            _listCalendar = listCalendar;
        }
        public void AddMonth()
        {
            _listCalendar.ListOfYearMonthsWithTotalDays = new List<Tuple<int, int, string>>();
            foreach (int year in _listCalendar.Years)
            {
                foreach (int daysOfMonths in _listCalendar.TotalDaysOfMonths)
                {
                    if (year == 1582)
                    {
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "October"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "November"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "December"));
                    }
                    else
                    {
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "Janurary"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "Feburary"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "March"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "April"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "May"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "June"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "July"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "August"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "September"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "October"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "November"));
                        _listCalendar.ListOfYearMonthsWithTotalDays.Add(new Tuple<int, int, string>(year, daysOfMonths, "December"));
                    }
                }
            }
        }
    }
}
