using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace OfficeTime
{
    class OfficeWork
    {
        public TimeSpan WorkHourExceptRoja
        {
            get
            {
                return GetTimeSpanFromOfficeHour(Settings1.Default.WorkHourExceptRoja);
            }
        }

        public TimeSpan WorkHourRoja
        {
            get
            {
                return GetTimeSpanFromOfficeHour(Settings1.Default.WorkHourRoja);
            }
        }

        private TimeSpan GetTimeSpanFromOfficeHour(decimal officeWorkHour)
        {
            int hour = (int)officeWorkHour;
            int minute = (int)((officeWorkHour - Math.Truncate(officeWorkHour)) * 60);
            TimeSpan workHour = new TimeSpan(hour, minute, 0);

            return workHour;
        }

        public TimeSpan UpTime
        {
            get
            {
                using (var uptime = new PerformanceCounter("System", "System Up Time"))
                {
                    uptime.NextValue();       //Call this an extra time before reading its value
                    return TimeSpan.FromSeconds(uptime.NextValue());
                }
            }
        }

        public void DisplayWorkTime()
        {
            string instructionMessage = "To know your office time is up or not do the following: " + Environment.NewLine +
                            "# Press 1 if today is roja.  " + Environment.NewLine +
                            "# Press 2 if today is a normal day.  " + Environment.NewLine + Environment.NewLine;

            string timeupMessage = "Your time is up. You total worked for: ";
            string timenotupMessage = "Your time is not up. Your remaining time: ";

            TimeSpan remainingTime;

            Console.WriteLine(instructionMessage);
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

            switch (consoleKeyInfo.KeyChar)
            {
                case '1':
                    remainingTime = WorkHourRoja - UpTime;

                    if (remainingTime <= TimeSpan.Zero)
                    {
                        Console.WriteLine(timeupMessage + UpTime + " hours.");
                    }
                    else
                    {
                        Console.WriteLine(timenotupMessage + remainingTime + " hours.");
                    }
                    break;
                case '2':
                    remainingTime = WorkHourExceptRoja - UpTime;

                    if (remainingTime <= TimeSpan.Zero)
                    {
                        Console.WriteLine(timeupMessage + UpTime + " hours.");
                    }
                    else
                    {
                        Console.WriteLine(timenotupMessage + remainingTime + " hours.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid key pressed!");
                    break;
            }
            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadLine();
        }
    }
}
