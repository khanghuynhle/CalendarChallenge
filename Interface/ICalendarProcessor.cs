using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarChallenge.Interface
{
    public interface ICalendarProcessor
    {
        int GetFirstDayOfYear(int year);
        string HtmlHeaderScript(int year);
        string HtmlBodyScriptGenerator(int year, int daysInMonth);
        string HtmlFooterScript();
    }
}
