using CalendarChallenge.Helper;
using CalendarChallenge.Interface;
using CalendarChallenge.Property;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace CalendarChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            // calls the Run method in App, which is replacing Main
            serviceProvider.GetService<App>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var config = LoadConfiguration();
            services.AddSingleton(config);

            //add services here:
            services.AddTransient<ICalendarProcessor, CalendarProcessor>();
            services.AddTransient<IDayHelper, DayHelper>();
            services.AddTransient<IMonthHelper, MonthHelper>();
            services.AddTransient<IYearHelper, YearHelper>();

            services.AddSingleton<ListOfCalendar>();
            services.AddSingleton<Calendar>();

            services.AddTransient<App>();

            return services;

        }
        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder();
            return builder.Build();
        }
    }
}
