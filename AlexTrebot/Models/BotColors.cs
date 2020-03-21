using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexTrebot.Models
{
    public class BotColors
    {
        public static Dictionary<string, Color> Colors { get; set; } = new Dictionary<string, Color>()
        {
            {"blue", Color.Blue}, {"default", Color.Default}, {"gold", Color.Gold}, {"green", Color.Green},
            {"magenta", Color.Magenta}, {"orange", Color.Orange}, {"purple", Color.Purple},
            {"red", Color.Red}, {"teal", Color.Teal}, {"darkblue", Color.DarkBlue}, {"dark blue", Color.DarkBlue},
            {"darkergrey", Color.DarkerGrey}, {"darker grey", Color.DarkerGrey}, {"darkgreen", Color.DarkGreen},
            {"dark green", Color.DarkGreen}, {"darkgrey", Color.DarkGrey}, {"dark grey", Color.DarkGrey},
            {"darkmagenta", Color.DarkMagenta}, {"dark magenta", Color.DarkMagenta}, {"darkorange", Color.DarkOrange},
            {"dark orange", Color.DarkOrange}, {"darkpurple", Color.DarkPurple}, {"dark purple", Color.DarkPurple},
            {"darkred", Color.DarkRed}, {"dark red", Color.DarkRed}, {"darkteal", Color.DarkTeal},
            {"dark teal", Color.DarkTeal}, {"lightergrey", Color.LighterGrey}, {"lighter grey", Color.LighterGrey},
            {"lightgrey", Color.LightGrey}, {"light grey", Color.LightGrey}, {"lightorange", Color.LightOrange},
            {"light orange", Color.LightOrange}
        };
    }
}
