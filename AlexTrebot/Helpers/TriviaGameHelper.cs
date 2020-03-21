using AlexTrebot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace AlexTrebot.Helpers
{
    class TriviaGameHelper
    {
        public static string EndPoint { get; set; }

        #region MAKE QUESTION REQUEST
        public static string MakeQuestionRequest(string category)
        {
            EndPoint = "https://opentdb.com/api.php?amount=10&category=" + category + "&difficulty=easy&type=multiple";

            string responseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            request.Method = HttpMethod.Get.ToString();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException(String.Format("Error Code: {0}", response.StatusCode.ToString()));
                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            return responseValue;
        }
        #endregion

        #region HANDLE QUESTION RESPONSE
        public static List<Question> HandleQuestionResponse(string response)
        {
            dynamic quests = JsonConvert.DeserializeObject(response);
            List<Question> Questions = new List<Question>();

            if (quests != null)
            {
                foreach (var quest in quests["results"])
                {
                    Question question = new Question();
                    question.Category = quest.category;
                    question._Question = quest.question;
                    question.Type = quest.type;
                    question.Difficulty = quest.difficulty;
                    question.Correct_Answer = quest.correct_answer;
                    question.Answers = quest.incorrect_answers;
                    Questions.Add(question);
                    string test = "";
                }
            }
            return Questions;
        }
        #endregion

        #region CONVERT CATEGORY
        public static string ConvertCategory(string cat)
        {
            switch (cat)
            {
                case "General Knowledge":
                case "general knoweldge":
                    return "9";
                case "Music":
                case "music":
                    return "12";
                case "TV":
                case "tv":
                    return "14";
                case "Film":
                case "film":
                    return "11";
                case "Video Games":
                case "video games":
                    return "15";
                case "Science":
                case "science":
                    return "17";
                case "Mythology":
                case "mythology":
                    return "20";
                case "Sports":
                case "sports":
                    return "21";
                case "Geography":
                case "geography":
                    return "22";
                case "History":
                case "history":
                    return "23";
                case "Politics":
                case "politics":
                    return "24";
                case "Art":
                case "art":
                    return "25";
                case "Celebrities":
                case "celebrities":
                    return "26";
                case "Animals":
                case "animals":
                    return "27";
                case "Vehicles":
                case "vehicles":
                    return "28";
                default:
                    return "9";
            }
        }
        #endregion
    }
}
