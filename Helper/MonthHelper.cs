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
            _listCalendar.ListOfTotaldaysOfAMonth = new List<Tuple<int, string>>();
            int i = 0;
            while (i < _listCalendar.TotalDaysOfMonths.Count)
            {
                if (year == 1582)
                {
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i], "October"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+1], "November"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+2], "December"));
                    break;
                }
                else
                {
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i], "Janurary"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+1], "Feburary"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+2], "March"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+3], "April"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+4], "May"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+5], "June"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+6], "July"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+7], "August"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+8], "September"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+9], "October"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+10], "November"));
                    _listCalendar.ListOfTotaldaysOfAMonth.Add(new Tuple<int, string>(_listCalendar.TotalDaysOfMonths[i+11], "December"));
                    break;
                }
            }
        }
    }
}
