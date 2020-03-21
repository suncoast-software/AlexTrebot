using AlexTrebot.Extentions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlexTrebot.Models
{
    public class Question
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Difficulty { get; set; }
        public string _Question { get; set; }
        public string Correct_Answer { get; set; }
        public JArray Answers { get; set; }

    }
}
