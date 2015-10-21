using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using OfficeTime;

namespace OfficeTime
{
    class Program
    {
        static void Main(string[] args)
        {
            //DisplayWorkTime
            OfficeWork officeWork = new OfficeWork();
            officeWork.DisplayWorkTime();

            //DisplayLockUnlock();
        }

        

        public static void DisplayLockUnlock()
        {
            CheckForWorkstationLocking workLock = new CheckForWorkstationLocking();

            workLock.Run();

            Console.WriteLine("Press ESC to exit...");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                    break;
            };
        }
    }
}
