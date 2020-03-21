using AlexTrebot.Handlers;
using AlexTrebot.Helpers;
using AlexTrebot.Services;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexTrebot.Commads
{
   public class UserCommands : ModuleBase<SocketCommandContext>
    {
        [Command("uptime")]
        public async Task Uptime()
        {
            var uptime = ServerTimerService.GetServerUptime();
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("Uptime : {0}", uptime));
            var embed = EmbedBuilderHelper.BuildEmbed("Server Uptime", sb.ToString(), DateTime.Now.ToLongTimeString(), "blue");
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help")]
        public async Task Help([Remainder]string args = null)
        {

        }

        [Command("8ball")]
        public async Task EightBall([Remainder]string args = null)
        {

        }

        [Command("roll")]
        public async Task Roll()
        {
            string[] reply = UserMessageHandler.EightBall().Split(",");
            var user = Context.Message.Author.Username;
            var dieOne = reply[0];
            var dieTwo = reply[1];
            var sb = new StringBuilder();
            sb.Append(String.Format("{0} rolled [{1}:game_die: {2}:game_die:]", user, dieOne, dieTwo));

            var embed = EmbedBuilderHelper.BuildEmbed("Dice", sb.ToString(), DateTime.Now.ToLongTimeString(), "darkorange");
            await Context.Channel.SendMessageAsync(null, false, embed);
           
        }
    }
}
