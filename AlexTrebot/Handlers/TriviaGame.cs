using AlexTrebot.Extentions;
using AlexTrebot.Models;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexTrebot.Handlers
{
    public class TriviaGame : ModuleBase<SocketCommandContext>
    {
        public Queue<Question> Questions { get; set; }

        public Question CurrentQuestion { get; set; }
        public bool AcceptingNewPlayers { get; set; } = false;
        public bool AcceptingAnswers { get; set; } = false;

        public Dictionary<string, int> Players { get; set; }

        public TriviaGame(List<Question> questions)
        {
            Questions = new Queue<Question>(questions.ToList().Shuffle());
        }

        public void NewGame(SocketCommandContext context)
        {
            AcceptingNewPlayers = true;
            context.Channel.SendMessageAsync(
                "The game is about to begin. If you are participating please type `!join`");
        }

        public async Task Startgame(SocketCommandContext context)
        {
            AcceptingNewPlayers = false;
            while (Questions.Any()) //If there are any questions remaining we keep playing
            {
                await AskQuestion(context);
                await Task.Delay(5 * 1000);
            }
        }

        public void JoinGame(SocketCommandContext context)
        {
            var caller = context.Guild.GetUser(context.User.Id).Nickname;

            try
            {
                Players.Add(caller, 0);
            }
            catch (Exception e)
            {
                context.Channel.SendMessageAsync($"'{caller}' has already joined the game!");
            }
        }

        public async Task AnswerQuestion(SocketCommandContext context)
        {
            var caller = context.Guild.GetUser(context.User.Id).Nickname;
            if (!AcceptingAnswers && CurrentQuestion != null && !Players.Keys.Contains(caller)) return;
            try
            {
                //CurrentQuestion.Answers.Add(caller, context.Message.Content);
            }
            catch (InvalidOperationException e)
            {
                await context.Channel.SendMessageAsync($"Sorry {caller}. You've already answered this question.");
            }
        }

        public async Task AskQuestion(SocketCommandContext context)
        {
            CurrentQuestion = Questions.Dequeue();
            await context.Channel.SendMessageAsync(CurrentQuestion.ToString());
            AcceptingAnswers = true;
            await Task.Delay(20 * 1000);
            await context.Channel.SendMessageAsync("10 seconds remain!");
            await Task.Delay(10 * 1000);
            AcceptingAnswers = false;

            var sb = new StringBuilder();
            //foreach (var result in CurrentQuestion)
            //{
            //    Players[result]++;
            //    sb.AppendLine(result);
            //}

            await context.Channel.SendMessageAsync($"Round over!\n These players answered correctly:\n {sb}");
        }
    }
}
