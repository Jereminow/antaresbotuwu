﻿using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Antares_bot_uwu
{
    public class SimpCommands : ModuleBase<SocketCommandContext>
    {
        [Command("starless")]
        public async Task StarlessCommand() {
            await ReplyAsync("Starless is the cutest and sweetest stag ever <3");
        }

        [Command("ping")]
        public async Task PingCommand()
        {
            await ReplyAsync($"Pong {Context.Message.Author.Username} <@{Context.Message.Author.Id}>");
        }

        [Command("weeb")]
        public async Task WeebCommand()
        {
            if (Context.Message.Author.Username.Contains("Starless")) {
                await ReplyAsync($"{Context.Message.Author.Username} is 100% weeb");
            } else {
                Random rand = new ();
                int randomPercent = rand.Next(0, 100);
                await ReplyAsync($"{Context.Message.Author.Username} is {randomPercent}% weeb");
            }
        }

        [Command("silksong")]
        public async Task SilksongCommand() {
            await ReplyAsync("https://www.youtube.com/watch?v=ib5AfwGmnZE");
        }

        [Command("cute")]
        public async Task CuteCommand() {
            Random rand = new ();
            int randomN = rand.Next(1000, 100000);
            /*if (Context.Message.Author.Username.Contains("Skye") || Context.Message.Author.Username.Contains("Zeno")) {
                await ReplyAsync($"{Context.Message.Author.Username} is ∞% cute!");
            }*/
            await ReplyAsync($"{Context.Message.Author.Username} is {randomN}% cute!");

        }

        [Command("rapax")]
        public async Task RapaxCommand() {
            await ReplyAsync("Cute translator foxy friend ^^");
        }

        [Command("say")]
        public async Task SayCommand([Remainder] string message) {
            
            await ReplyAsync(message);
            await Context.Message.DeleteAsync();
        }

        [Command("pat")]
        public async Task PatCommand()
        {
            string message = "";
            Random rand = new ();
            int temp = rand.Next(1, 30);
            for (int i = 0; i < temp; i++) {
                message = message + "pat" + " ";
            }
            await ReplyAsync(message);
        }

        [Command("shark")]
        public async Task SharkCommand()
        {
            await ReplyAsync("Definitely not a furry :wink: ");
        }

        [Command("pyru")]
        public async Task PyruCommand() {
            await ReplyAsync("Smart French gamer friend hon hon hon ^^");
        }

        [Command("mere")]
        public async Task MereCommand() {
            await ReplyAsync("One of the smartest, kindest, friendliest and cutest people in the world >w<");
        }

        [Command("antares")]
        public async Task AntaresCommand() {
            var embed = new EmbedBuilder();
            embed.WithDescription($"The sona of the dummy doe who made this bot:")
                .WithColor(Color.DarkBlue)
                .WithImageUrl("https://cdn.discordapp.com/attachments/781097596558376990/888168147503423528/Antares_refsheet_final.png")
                .Build();
            await Context.Channel.SendMessageAsync(embed:embed.Build());            
        }

        [Command("c")]
        public async Task CCommand()
        {
            await ReplyAsync("I hate C, pls help me");
        }

        [Command("searchfurry")]
        public async Task SearchFurryCommand([Remainder] string tags)
        {
            try
            {
                string html = string.Empty;
                string url = @"https://e926.net/posts.json?limit=1&tags=order:random rating:s type:png type:jpg score:>40 -comic";
                if (!tags.Length.Equals(0)) {
                    url = $"{url} {tags}";
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.UserAgent = "Antares Bot UwU";
                request.ContentType = "application/json";
                request.UseDefaultCredentials = true;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Proxy.Credentials = CredentialCache.DefaultCredentials;


                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new(stream))
                {
                    html = reader.ReadToEnd();
                }
                string[] temp_split = html.Split("url\":\"");
                string[] temp_split2 = temp_split[1].Split("\"");
                //string[] temp_split2 = temp_split[0].Split("\"");

                //await ReplyAsync(html.Substring(0, 100));
                await ReplyAsync(temp_split2[0]);
            }
            catch (Exception ex) { await ReplyAsync(ex.Message); }

        }
    }
}
