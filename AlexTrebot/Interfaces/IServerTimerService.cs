using System;
using System.Collections.Generic;
using System.Text;

namespace AlexTrebot.Interfaces
{
    public interface IServerTimerService
    {
        public void StartQuestionTimer();
        public void StopQuestionTimer();
        public void ResetQuestionTimer();
        public string GetQuestionStartTime();
        public double ConvertMillisecondsToSeconds(double milliseconds);
        public void StartServerTimer();
        public string GetServerUptime();
        public string GetServerStartTime();
    }
}
