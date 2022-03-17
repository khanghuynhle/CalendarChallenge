using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using System;
using System.Collections.Generic;

namespace CalendarChallenge.Helper
{
    internal class DayHelper : IDayHelper
    {
        private readonly ListOfCalendar _listCalendar;
        public DayHelper(ListOfCalendar listCalendar)
        {
            _listCalendar = listCalendar;
        }

        public void GetTotalDaysInMonths(int year)
        {
            int[] totalDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 30, 31, 31, 30, 31 };
            _listCalendar.TotalDaysOfMonths = new System.Collections.Generic.List<int>();
            _listCalendar.TotalDaysOfMonths.AddRange(totalDays);

            if((year%4 == 0 && year%100 != 0) || year % 400 == 0)
            {
                _listCalendar.TotalDaysOfMonths[1] = 29;
            }
            if(year == 1582)
            {
                _listCalendar.TotalDaysOfMonths.RemoveRange(0, 9);
            }
        }
        public void CalculateFirstDayOfMonth(int year, int firstDay, int daysInMonth)
        {
            int dayLeft = CalculateDaysLeftInMonth(firstDay, daysInMonth);
            int dayForward = CauclateDayForwardInMonth(dayLeft, daysInMonth);
            _listCalendar.YearDayForward = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(year, dayForward)
            };
            _listCalendar.YearDayLeft = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(year, dayLeft)
            };
        }

        private int CauclateDayForwardInMonth(int daysLeft, int daysInMonth)
        {
            int dayForwards = 7 - daysLeft;

            return dayForwards;
        }

        private int CalculateDaysLeftInMonth(int firstDay, int daysInMonth)
        {
            int daysLeft = 35 - firstDay + 1 - daysInMonth;
            return daysLeft;
        }
    }
}
