using System;
using System.Collections.Generic;

namespace AlexTrebot.Data
{
    public partial class DiscordUsers
    {
        public int DiscordUserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public int MessageCount { get; set; }
        public int Warnings { get; set; }
        public int Coins { get; set; }
    }
}
