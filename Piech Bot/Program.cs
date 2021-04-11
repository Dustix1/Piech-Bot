using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Piech_Bot
{
    class Program
    {
        public static void Main(string[] args)  => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        public async Task MainAsync()
        {
            Console.Title = "Piech Bot";
            _client = new DiscordSocketClient();
            _client.MessageReceived += CommandHandler;
            _client.Log += Log;

            var token = File.ReadAllText("token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandHandler(SocketMessage message)
        {
            //variables
            string command = "";
            int lengthOfCommand = -1;
            string caseinsensitive = "";
            int lengthOfMessage = -1;

            /*
             
                          FILTERING MESSAGES
             
                                                    */
            if (!message.Content.StartsWith("ß"))
            {
                lengthOfMessage = message.Content.Length;
                caseinsensitive = message.Content.Substring(0, lengthOfMessage).ToLower();

                if (message.Author.IsBot)
                {
                    return Task.CompletedTask;
                }
                else if (caseinsensitive.Contains("pích"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(message.Author);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" >> " + message.Content);
                    Console.ForegroundColor = ConsoleColor.White;
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Myslel jsi Piech?");
                }
                else if (caseinsensitive.Contains("helo piech") || caseinsensitive.Contains("hello piech"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(message.Author);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" >> " + message.Content);
                    Console.ForegroundColor = ConsoleColor.White;
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " no");
                }

                //  CLASSIFIED COMMAND

                else if (caseinsensitive.Contains("69"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(message.Author);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" >> " + message.Content);
                    Console.ForegroundColor = ConsoleColor.White;
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " nice");
                }
                else
                {
                    return Task.CompletedTask;
                }
            }

            if (message.Author.IsBot) //This ignores all commands from bots
                return Task.CompletedTask;

            if (message.Content.Contains(" "))
                lengthOfCommand = message.Content.IndexOf(' ');
            else
                lengthOfCommand = message.Content.Length;

            command = message.Content.Substring(1, lengthOfCommand - 1).ToLower();

            /*
             
                          COMMANDS
                                                
                                                    */
            if (command.Equals("randompiech"))
            {
                Random rndImage = new Random();
                int random_Piech = rndImage.Next(1, 10);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message.Author);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("ßrandompiech command ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("random: " + random_Piech);
                Console.ForegroundColor = ConsoleColor.White;

                if (random_Piech == 1)
                {
                    message.Channel.SendFileAsync("PiechImage/PiechPOG.jpeg");
                }
                else if (random_Piech == 2)
                {
                    message.Channel.SendFileAsync("PiechImage/Piechf13.png");
                }
                else if (random_Piech == 3)
                {
                    message.Channel.SendFileAsync("PiechImage/PiechLinkedin.png");
                }
                else if (random_Piech == 4)
                {
                    message.Channel.SendFileAsync("PiechImage/Cyberpiech.jpg");
                }
                else if (random_Piech == 5)
                {
                    message.Channel.SendFileAsync("PiechImage/PiechHand.jpg");
                }
                else if (random_Piech == 6)
                {
                    message.Channel.SendFileAsync("PiechImage/PiechConvertibleLESSGOO.jpg", "**LESS GOOOOOOOOOOO**");
                }
                else if (random_Piech == 7)
                {
                    message.Channel.SendFileAsync("PiechImage/piechpogsign.jpg");
                }
                else if (random_Piech == 8)
                {
                    message.Channel.SendFileAsync("PiechImage/piechfacesign.jpg");
                }
                else if (random_Piech == 9)
                {
                    message.Channel.SendFileAsync("PiechImage/piechwtfsign.jpg");
                }

            } //                  ßrandompiech COMMAND
            else if (command.Equals("randompiechvideo"))
            {
                Random rndVideo = new Random();
                int randomPiechVideo = rndVideo.Next(1, 23);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message.Author);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("ßrandompiechvideo ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("random: " + randomPiechVideo);
                Console.ForegroundColor = ConsoleColor.White;

                if (randomPiechVideo == 1)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo1.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 2)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo2.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 3)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo3.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 4)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo4.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 5)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo5.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 6)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo6.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 7)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo7.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 8)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo8.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 9)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo9.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 10)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo10.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 11)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo11.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 12)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo12.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 13)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo13.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 14)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo14.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 15)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo15.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 16)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo16.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 17)
                {
                    message.Channel.SendFileAsync("PiechVideo/defaultpiech.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 18)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo17.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 19)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo18.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 20)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo19.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 21)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo20.mp4", "Enjoy your Piech video!");
                }
                else if (randomPiechVideo == 22)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo21.mp4", "Enjoy your Piech video!");
                }

            } //        ßrandompiechvideo COMMAND
            else if (command.Equals("vizitka"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message.Author);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ßvizitka");
                Console.ForegroundColor = ConsoleColor.White;

                Embed embed = new EmbedBuilder()
                    .WithColor(Color.Red)
                    .WithAuthor("Info", "https://i.imgur.com/M6GOXYo.png")
                    .WithTitle("**Cyberpiech**")
                    .WithUrl("https://www.f13cybertech.cz")
                    .WithThumbnailUrl("https://i.imgur.com/r0CVj08.jpg")
                    .WithFields(new EmbedFieldBuilder[]
                {
                    // Non-inline fields each get own rows
                    new EmbedFieldBuilder() { IsInline = false, Name = "**Martin Piech**", Value = "**Výkonný ředitel**" },

                    // Inline fields may share rows
                    new EmbedFieldBuilder() { IsInline = true, Name = "E-mail", Value = "martin@f13cybertech.cz" },
                    new EmbedFieldBuilder() { IsInline = true, Name = "Tel. číslo", Value = "+420 721 232 021" },
                })
                .WithFooter("Cyberpiech s.r.o", "https://i.imgur.com/M6GOXYo.png")
                .Build();
                message.Channel.SendMessageAsync("", false, embed);
            } //                 ßvizitka COMMAND
            else if (command.Equals("stop"))
            {
                if (message.Author.Id == 385845659674345484)
                {
                    System.Environment.Exit(1);
                }
            } //                    ßstop COMMAND
            else if (command.Equals("help"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message.Author);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ßhelp");
                Console.ForegroundColor = ConsoleColor.White;

                Color lime_green = new Color(0, 255, 0);

                Embed embed = new EmbedBuilder()
                    .WithColor(lime_green)
                    .WithAuthor("Piech Help", "https://i.imgur.com/M6GOXYo.png")
                    .WithThumbnailUrl("https://i.ibb.co/vZ2VrMv/Piech-commands.jpg")
                    .WithFields(new EmbedFieldBuilder[]
                {
                    // Non-inline fields each get own rows
                    new EmbedFieldBuilder() { IsInline = true, Name = "**ßrandompiech**", Value = "Pošle random Piech obrázek"},
                    new EmbedFieldBuilder() { IsInline = true, Name = "**ßrandompiechvideo**", Value = "Pošle random Piech video"},
                    new EmbedFieldBuilder() { IsInline = true, Name = "**ßvizitka**", Value = "Vizitka od Piecha"},
                    new EmbedFieldBuilder() { IsInline = true, Name = "**ßstop**", Value = "*Nemáš na tohle právo takže to ani nezkoušej*"},
                })
                .WithFooter("Cyberpiech s.r.o", "https://i.imgur.com/M6GOXYo.png")
                .Build();
                message.Channel.SendMessageAsync("", false, embed);

            } //                    ßhelp COMMAND
            //  CLASSIFIED COMMAND

            return Task.CompletedTask;

        }
    }
}