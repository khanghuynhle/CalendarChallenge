using System;
using System.Collections.Generic;

namespace CalendarChallenge.Property
{
    public class ListOfCalendar
    {
        public List<int> Years { get; set; }
        public List<Tuple<int, DateTime>> ListOfMonthsWithYears { get; set; }
        public List<Tuple<int,DateTime, DateTime>> YearMonthDay { get; set; }
        public List<DayOfWeek> FirstDayOfYears { get; set; }
        public List<int> TotalDaysOfMonths { get; set; }
    }
}
