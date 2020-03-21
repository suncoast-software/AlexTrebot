using AlexTrebot.Models;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexTrebot.Helpers
{
   public class EmbedBuilderHelper
    {
        public static Embed BuildEmbed(string title, string sb, string footer, string color)
        {
            var embed = new EmbedBuilder()
                .WithTitle(title)
                .WithColor(GetColor(color, Color.LightGrey))
                .WithDescription(sb)
                .WithFooter(footer)
                .Build();
            return embed;
        }

        private static Color GetColor(string colorName, Color defaultColor)
        {
            if (BotColors.Colors.ContainsKey(colorName)) return BotColors.Colors[colorName];
            else
                return defaultColor;
        }
    }
}
