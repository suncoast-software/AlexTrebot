using AlexTrebot.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AlexTrebot.Services
{
    class ServerTimerService
    {
        public static Stopwatch Timer;
        public string ServerStartDate { get; set; }

        public ServerTimerService()
        {
            StartServerTimer();
        }

        public double ConvertMillisecondsToSeconds(double milliseconds)
        {
            throw new NotImplementedException();
        }

        public string GetServerStartDate()
        {
            return ServerStartDate;
        }

        public static string GetServerUptime()
        {
            var seconds     = Timer.Elapsed.Seconds.ToString();
            var Minutes     = Timer.Elapsed.Minutes.ToString();
            var hours       = Timer.Elapsed.Hours.ToString();
            var days        = Timer.Elapsed.Days.ToString();
            var uptime      = String.Format("[{0}]:days [{1}]:hours [{2}]:minutes [{3}]:seconds", days, hours, Minutes, seconds);
            return uptime;
        }


        public void StartServerTimer()
        {
            Timer = new Stopwatch();
            Timer.Start();
            ServerStartDate = DateTime.Now.ToLongDateString();
        }

    }
}
