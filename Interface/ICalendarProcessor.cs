using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarChallenge.Interface
{
    public interface ICalendarProcessor
    {
        DayOfWeek GetFirstDayOfYear(int year);

        void CalendarUIGenerator(int year, int daysInMonth);
    }
}
