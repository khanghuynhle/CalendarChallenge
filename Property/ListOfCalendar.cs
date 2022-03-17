using System;
using System.Collections.Generic;

namespace CalendarChallenge.Property
{
    public class ListOfCalendar
    {
        public List<int> Years { get; set; }
        public List<Tuple<int, string>> ListOfMonthsWithYears { get; set; }
        public List<int> FirstDayOfYears { get; set; }
        public List<int> TotalDaysOfMonths { get; set; }
        public List<int> TotalMonths { get; set; }
    }
}
