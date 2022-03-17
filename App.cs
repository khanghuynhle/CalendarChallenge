using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using System;

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
                //passing in totalDaysOfMonths based on the year
                for (int i = 0; i < _listCal.TotalDaysOfMonths.Count; i++)
                {
                    if(yearToProcess == 1582)
                    {
                        i = 9;
                    }
                    else
                    {
                        i = 0;
                    }
                    _processor.CalendarUIGenerator(yearToProcess, _listCal.TotalDaysOfMonths[i]);
                }
            }
            Console.WriteLine("Html file is created under C drive with name as: Calendar.htm");

        }
    }
}
