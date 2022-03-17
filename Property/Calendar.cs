using System;

namespace CalendarChallenge.Property
{
    public class Calendar
    {
        public int Year { get; set; }
        public DateTime Day { get; set; }
        public DateTime Month { get; set; }
        public DayOfWeek DaysOfWeek { get; set; }
    }
}
