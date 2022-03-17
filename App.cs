using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using System;
using System.IO;

namespace CalendarChallenge
{
    public class App
    {
        private readonly ICalendarProcessor _processor;
        private readonly IYearHelper _yearHelper;
        private readonly IMonthHelper _monthHelper;
        private readonly IDayHelper _dayHelper;

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
            foreach(int yearToProcess in _listCal.Years)
            {
                string body ="";

                //passing in totalDaysOfMonths based on the year
                foreach (int daysOfMonth in _listCal.TotalDaysOfMonths)
                {
                    body = _processor.HtmlBodyScriptGenerator(yearToProcess, daysOfMonth);
                }
                string html = _processor.HtmlHeaderScript(year) + body + _processor.HtmlFooterScript();
                File.WriteAllText(@"C:\Calendar " + year + ".html", html);

            }
            Console.WriteLine("Html file is created under C drive with name as: Calendar.htm");


        }
    }
}
