using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarChallenge.Helper
{
    internal class DayHelper : IDayHelper
    {
        private readonly ListOfCalendar _listCalendar;
        private List<Tuple<int, int>> daysForward = new List<Tuple<int, int>>();
        public DayHelper(ListOfCalendar listCalendar)
        {
            _listCalendar = listCalendar;
        }

        public void GetTotalDaysInMonths(int year)
        {
            int[] totalDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            _listCalendar.TotalDaysOfMonths = new System.Collections.Generic.List<int>();
            _listCalendar.TotalDaysOfMonths.AddRange(totalDays);

            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                _listCalendar.TotalDaysOfMonths[1] = 29;
            }
            if (year == 1582)
            {
                _listCalendar.TotalDaysOfMonths.RemoveRange(0, 9);
            }
        }
        public void CalculateFirstDayOfMonth(List<int> years, List<int> firstDays, List<Tuple<int, string>> listOfTotaldaysOfAMonth)
        {
            _listCalendar.YearDayForward = new List<Tuple<int, int>>();
            _listCalendar.YearDayLeft = new List<Tuple<int, int>>();
            var daysInMonth = listOfTotaldaysOfAMonth.Select(x => x.Item1);

            int dayLeft, dayForward = 0;
            int k = 0;

            foreach (int firstDay in firstDays)
            {
                var year = years.ElementAt(k);

                for (int i = 0; i < listOfTotaldaysOfAMonth.Count; i++)
                {
                    if(i == 0)
                    {
                        dayLeft = CalculateDaysLeftInFirstMonth(firstDay, daysInMonth.ElementAt(i));
                    }
                    else
                    {
                        dayLeft = CalculateDaysLeftNextMonth(dayForward, daysInMonth.ElementAt(i));
                    }
                    dayForward = CauclateDayForwardInMonth(dayLeft, daysInMonth.ElementAt(i));

                    _listCalendar.YearDayForward.Add(new Tuple<int, int>(year, dayForward));
                    _listCalendar.YearDayLeft.Add(new Tuple<int, int>(year, dayLeft));
                }
                k++;
            }
        }

        private int CauclateDayForwardInMonth(int daysLeft, int daysInMonth)
        {
            int dayForwards = 7 - daysLeft;
            if(dayForwards == 7)
            {
                dayForwards = 0;
            }

            return dayForwards;
        }

        private int CalculateDaysLeftInFirstMonth(int firstDay, int daysInMonth)
        {
            int daysLeft = 35 - firstDay + 1 - daysInMonth;
            return daysLeft;
        }
        private int CalculateDaysLeftNextMonth(int dayForward, int daysInMonth)
        {
            int dayLeft;
            if (dayForward < 6)
            {
                dayLeft = 35 - dayForward - daysInMonth;
            }
            else
            {
                dayLeft = 42 - dayForward - daysInMonth;
            }

            return dayLeft;
        }
    }
}
