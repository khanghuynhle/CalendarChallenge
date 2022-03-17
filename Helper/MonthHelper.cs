using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using System;

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
            foreach(int year in _listCalendar.Years)
            {
                if(year == 1582)
                {
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("October")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("November")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("December")));
                }
                else {
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("Janurary")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("Feburary")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("March")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("April")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("May")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("June")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("July")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("August")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("September")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("October")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("November")));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, DateTime>(year, DateTime.Parse("December")));
                }
            }
        }
    }
}
