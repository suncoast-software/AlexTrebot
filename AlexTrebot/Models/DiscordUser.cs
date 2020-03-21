using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlexTrebot.Models
{
   public class DiscordUser
    {
        [Key]
        public int DiscordUserdId { get; set; }

        public string Username { get; set; }

    }
}
