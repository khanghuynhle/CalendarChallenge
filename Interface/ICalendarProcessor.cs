using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarChallenge.Interface
{
    public interface ICalendarProcessor
    {
        int GetFirstDayOfYear(int year);

        void CalendarUIGenerator(int year, int daysInMonth);
    }
}
