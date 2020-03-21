using AlexTrebot.Helpers;
using AlexTrebot.Interfaces;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexTrebot.Handlers
{
   public class UserManagerHandler : ModuleBase<SocketCommandContext>, IUserManagerService
    {
        public async Task WelcomeUser(DiscordSocketClient _client, SocketGuildUser user)
        {
            ulong chnlId = 686307918475296884;
            var channel = _client.GetChannel(chnlId) as IMessageChannel;
            
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("Welcome New User {0}", user.Username));
            sb.AppendLine(String.Format("Joined on {0}", DateTime.Now.ToLongDateString()));
            sb.AppendLine(String.Format("Joined at {0}", DateTime.Now.ToLongTimeString()));
            var embed = EmbedBuilderHelper.BuildEmbed("Welcome", sb.ToString(), DateTime.Now.ToLongTimeString(), "darkgrey");

            var role = Context.Guild.Roles.FirstOrDefault(r => r.Name.ToString().Equals("Guest"));
            await user.AddRoleAsync(role);

            await channel.SendMessageAsync(null, false, embed);
        }
    }
}
