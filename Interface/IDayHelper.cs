using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarChallenge.Interface
{
    public interface IDayHelper
    {
        void GetTotalDaysInMonths (int year);
        void CalculateFirstDayOfMonth(List<int> years, List<int> firstDays, List<Tuple<int, string>> listOfTotaldaysOfAMonth);
    }
}
