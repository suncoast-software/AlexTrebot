using AlexTrebot.Extentions;
using AlexTrebot.Handlers;
using AlexTrebot.Helpers;
using AlexTrebot.Interfaces;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexTrebot.Commads
{
    public class ModCommands : ModuleBase<SocketCommandContext>, IModCommandService
    {
        [Command("purge")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task Purge([Remainder] string amount)
        {
            bool intResult = int.TryParse(amount, out int count);
            int mCount = 0;

            if (intResult)
            {
                IEnumerable<IMessage> allMessages = await Context.Channel.GetMessagesAsync(count + 1).FlattenAsync();

                foreach (var mes in allMessages)
                {
                    mCount++;
                }

                await ((ITextChannel)Context.Channel).DeleteMessagesAsync(allMessages);
                const int delay = 1500;
                IUserMessage m = await ReplyAsync($"```I Have Deleted {mCount} messages for you!```");
                await Task.Delay(delay);
                await m.DeleteAsync();
            }

        }

        [Command("newtrivia")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task StartTriviaGame([Remainder] string args)
        {
            var cat = TriviaGameHelper.ConvertCategory(args);
            var questions = TriviaGameHelper.MakeQuestionRequest(cat);
            var _questions = TriviaGameHelper.HandleQuestionResponse(questions);

            TriviaGame game = new TriviaGame(_questions);
            game.NewGame(Context);

            if (_questions.Count > 0)
            {
                //while (_questions.Any())
                //{
                //    var rnd = new Random();
                //    var q = _questions[rnd.Next(1, _questions.Count)];
                //    _questions.Remove(q);
                //    var shuffled = new List<string>();

                //    for (int i = 0; i < q.Answers.Count; i++)
                //    {
                //        shuffled.Add(q.Answers[i].ToString());
                //    }
                //    shuffled.Add(q.Correct_Answer);
                //    var newShuffled = shuffled.Shuffle();

                //    var sb = new StringBuilder();
                //    sb.AppendLine(String.Format("Question: {0}", q._Question));
                //    sb.AppendLine(String.Format("Answers: {0}, {1}, {2}, {3}", newShuffled[0], newShuffled[1], newShuffled[2], newShuffled[3]));
                //    sb.AppendLine(String.Format("Correct Answer: {0}", q.Correct_Answer));
                //    sb.AppendLine("you have 30 seconds to answer the question correctly!");

                //    var embed = EmbedBuilderHelper.BuildEmbed("Trivia Quest - " + q.Category, sb.ToString(), DateTime.Now.ToLongTimeString(), "darkorange");
                //    await Context.Channel.SendMessageAsync(null, false, embed);

                //    await Task.Delay(20 * 1000);

                //    await Context.Channel.SendMessageAsync("```there are 10 seconds remaining to answer correctly!```");

                //    await Task.Delay(10 * 1000);

                //    await Context.Channel.SendMessageAsync("```Times Up!```");
                //}
            }
           
        }
    }
}
