﻿using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexTrebot.Interfaces
{
    public interface IUserMessageService
    {
        public Task HandleMessage(SocketUserMessage message);
    }
}
