using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarChallenge.Interface
{
    public interface IDayHelper
    {
        void GetTotalDaysInMonths (int year);
        void CalculateFirstDayOfMonth(int year, int firstDay, int daysInMonth);
    }
}
