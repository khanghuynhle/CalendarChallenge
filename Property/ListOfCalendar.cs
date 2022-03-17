using System;
using System.Collections.Generic;

namespace CalendarChallenge.Property
{
    public class ListOfCalendar
    {
        public List<int> Years { get; set; }
        public List<Tuple<int, string>> ListOfDaysWithinMonths { get; set; }
        public List<Tuple<int, string>> ListOfMonthsWithTotalDays { get; set; }
        public List<int> FirstDayOfYears { get; set; }
        public List<int> TotalDaysOfMonths { get; set; }
    }
}
