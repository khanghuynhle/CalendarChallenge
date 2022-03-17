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
			List<int> years = new List<int>();
			if (year == 1582)
            {
				years.Add(year);
				years.Add(year + 1);
			}
            else {
				years.Add(year);
				years.Add(year + 1);
				years.Add(year + 1);
			}
			_listCalendar.Years.AddRange(years);
		}
		
	}
}
