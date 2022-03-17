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
        public void AddMonth(int year)
        {
            _listCalendar.ListOfMonthsWithTotalDays = new List<Tuple<int, string>>();
            int i = 0;
            while (i < _listCalendar.TotalDaysOfMonths.Count)
            {
                if (year == 1582)
                {
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i], "October"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+1], "November"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+2], "December"));
                    break;
                }
                else
                {
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i], "Janurary"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+1], "Feburary"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+2], "March"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+3], "April"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+4], "May"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+5], "June"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+6], "July"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+7], "August"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+8], "September"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+9], "October"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+10], "November"));
                    _listCalendar.ListOfMonthsWithTotalDays.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+11], "December"));
                    break;
                }
            }
        }
    }
}
