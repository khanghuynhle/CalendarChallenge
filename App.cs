using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalendarChallenge
{
    public class App
    {
        private readonly ICalendarProcessor _processor;
        private readonly IYearHelper _yearHelper;
        private readonly IMonthHelper _monthHelper;
        private readonly IDayHelper _dayHelper;
        private List<string> Body { get; set; }

        private readonly ListOfCalendar _listCal;
        public App(ICalendarProcessor processor, IYearHelper yearHelper, ListOfCalendar listCal, IDayHelper dayHelper, IMonthHelper monthHelper)
        {
            _processor = processor;
            _listCal = listCal;
            _yearHelper = yearHelper;
            _monthHelper = monthHelper;
            _dayHelper = dayHelper;
        }
        public void Run()
        {
            Console.WriteLine("Please enter a year later than 1581: ");
            int year = Convert.ToInt32(Console.ReadLine());

            //process weekday + day + month + year 
            _yearHelper.YearChecker(year);
            _listCal.FirstDayOfYears = new System.Collections.Generic.List<int>();

            foreach (int yearToProcess in _listCal.Years)
            {
                //get the first day of the year
                _listCal.FirstDayOfYears.Add(_processor.GetFirstDayOfYear(yearToProcess));

                //decide how many days in a month
                _dayHelper.GetTotalDaysInMonths(yearToProcess);
            }

            //add month
            _monthHelper.AddMonth();

            //generate HTML page here
            Body = new List<string>();
            //passing in totalDaysOfMonths based on the year
            foreach (var yearsDaysOfMonth in _listCal.ListOfYearMonthsWithTotalDays)
            {
                Body.Add(_processor.HtmlBodyScriptGenerator(yearsDaysOfMonth.Item1, yearsDaysOfMonth.Item2, yearsDaysOfMonth.Item3));
            }
            string html = _processor.HtmlHeaderScript(year) + Body + _processor.HtmlFooterScript();
            File.WriteAllText(@"C:\Calendar " + year + ".html", html);

            Console.WriteLine("Html file is created under C drive with name as: Calendar.htm");
        }
    }
}
