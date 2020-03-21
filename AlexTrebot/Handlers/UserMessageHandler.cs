using AlexTrebot.Interfaces;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexTrebot.Handlers
{
    public class UserMessageHandler : IUserMessageService
    {
        public async Task HandleMessage(SocketUserMessage message)
        {
            if (message.Content.ToLower().Contains("how"))
            {
                await message.Channel.SendMessageAsync("can I help you?");
            }
        }

        public static string EightBall()
        {
            string response = String.Empty;
            var rnd = new Random();
            var sb = new StringBuilder();

            for (int i = 0; i < 2; i++)
            {
                var d = rnd.Next(1, 6);
                sb.Append(d.ToString() + ",");
            }
            response = sb.ToString();
            return response;
        }
    }
}
