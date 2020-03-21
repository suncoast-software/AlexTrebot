using AlexTrebot.Interfaces;
using AlexTrebot.Models;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlexTrebot.Services
{
    public class ConfigService : IConfigService
    {
        public string GetToken()
        {
            string token = String.Empty;
            using (var reader = new StreamReader("token.json"))
            {
                var Json = new JavaScriptSerializer().Deserialize<DiscordToken>(reader.ReadToEnd());
                token = Json.Token;
            }

            return token;
        }
      
    }
}
