using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using System;
using System.Collections.Generic;

namespace CalendarChallenge
{
    internal class YearHelper : IYearHelper
	{
		private readonly ListOfCalendar _listCalendar;
		public YearHelper(ListOfCalendar listCalendar)
        {
			_listCalendar = listCalendar;
        }
		public void YearChecker(int year)
        {
			if(year < 1582)
            {
				Console.WriteLine("Please enter a year no earier than 1582");
                year = Convert.ToInt32(Console.ReadLine());
				YearChecker(year);
            }
			AddYears(year);
        }
		private void AddYears(int year)
        {
			_listCalendar.Years = new List<int>();
			if (year == 1582)
            {
				_listCalendar.Years.Add(year);
				_listCalendar.Years.Add(year + 1);
			}
            else {
				_listCalendar.Years.Add(year);
				_listCalendar.Years.Add(year + 1);
				_listCalendar.Years.Add(year - 1);
			}
		}
		
	}
}
