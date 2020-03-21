using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexTrebot.Interfaces
{
    public interface IModCommandService
    {
        public Task Purge(string amount);
        public Task StartTriviaGame(string args);
    }
}
