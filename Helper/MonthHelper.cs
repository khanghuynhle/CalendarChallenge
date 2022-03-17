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
            _listCalendar.ListOfMonthsWithYears = new System.Collections.Generic.List<Tuple<int, string>>();
            foreach (int year in _listCalendar.Years)
            {
                if(year == 1582)
                {
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "October"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "November"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "December"));
                }
                else {
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "Janurary"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "Feburary"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "March"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "April"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "May"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "June"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "July"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "August"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "September"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "October"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "November"));
                    _listCalendar.ListOfMonthsWithYears.Add(new Tuple<int, string>(year, "December"));
                }
            }
        }
    }
}
