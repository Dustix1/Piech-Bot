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
            _client.Ready += OnReady;
            _client.MessageReceived += CommandHandler;
            _client.Log += Log;

            var token = File.ReadAllText("token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            Console.WriteLine("Setting Activity");
            await _client.SetGameAsync("PiechPOG", null, ActivityType.Watching);

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task OnReady()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Start silent? 1/0: ");
            int isSilent = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            if (isSilent == 1)
            {

            }
            else
            {
                Random rndPiechReady = new Random();
                int randomPiechReady = rndPiechReady.Next(1, 1001);
                if (randomPiechReady >= 0 && randomPiechReady <= 1000)
                {

                    var PiechChannel = _client.GetChannel(829977064890171392) as IMessageChannel;
                    await PiechChannel.SendMessageAsync("@everyone Piech is here");
                }
                else
                {
                    var PiechChannel = _client.GetChannel(829977064890171392) as IMessageChannel;
                    // CLASIFIED
                }
            }
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
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(message.Channel + " ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(message.Author);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" >> ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(message.Content);
                    Console.ForegroundColor = ConsoleColor.White;

                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Myslel jsi " + caseinsensitive.Replace("pích", "piech") + "?");
                }
                else if (caseinsensitive.Contains("helo piech") || caseinsensitive.Contains("hello piech"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(message.Channel + " ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(message.Author);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" >> ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(message.Content);
                    Console.ForegroundColor = ConsoleColor.White;
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Hello There!");
                }
                // CLASSIFIED
                else if (caseinsensitive.Contains("69"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(message.Channel + " ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(message.Author);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" >> ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(message.Content);
                    Console.ForegroundColor = ConsoleColor.White;
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " nice");
                }
                else if (caseinsensitive.Contains("cybertech"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(message.Channel + " ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(message.Author);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" >> ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(message.Content);
                    Console.ForegroundColor = ConsoleColor.White;

                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Myslel jsi " + caseinsensitive.Replace("cybertech", "cyberpiech") + "?");
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
                int random_Piech = rndImage.Next(1, 12);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(message.Channel + " ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message.Author);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("ßrandompiech ");
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
                else if (random_Piech == 10)
                {
                    message.Channel.SendFileAsync("PiechImage/piechathomedone.jpg");
                }
                else if (random_Piech == 11)
                {
                    message.Channel.SendFileAsync("PiechImage/Cyberpiechwallpaper.jpg");
                }

            } //                  ßrandompiech COMMAND
            else if (command.Equals("randompiechvideo"))
            {
                Random rndVideo = new Random();
                int randomPiechVideo = rndVideo.Next(1, 23);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(message.Channel + " ");
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
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo17.mp4", "It's raining Piech!");
                }
                else if (randomPiechVideo == 19)
                {
                    message.Channel.SendFileAsync("PiechVideo/PiechVideo18.mp4", "Piech gon give it to you!");
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(message.Channel + " ");
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
                    message.Channel.SendMessageAsync("no.. NO NOOOOOOOOOOOOOOOOOOOOOOOOOOO  *dies*");
                    System.Threading.Thread.Sleep(3000);
                    stopPiech();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(message.Channel + " ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(message.Author);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" >> ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("ßstop");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(" Nemá na tohle práva");
                    Console.ForegroundColor = ConsoleColor.White;

                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Nemáš na tohle práva");
                }
            } //                    ßstop COMMAND
            else if (command.Equals("help"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(message.Channel + " ");
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
                    new EmbedFieldBuilder() { IsInline = true, Name = "**ßrandomucitel**", Value = "koňozmrdovyhovnazdržky"},
                    new EmbedFieldBuilder() { IsInline = true, Name = "**ßstop**", Value = "*Nemáš na tohle právo takže to ani nezkoušej*"},
                })
                .WithFooter("Cyberpiech s.r.o", "https://i.imgur.com/M6GOXYo.png")
                .Build();
                message.Channel.SendMessageAsync("", false, embed);

            } //                    ßhelp COMMAND
            // CLASSIFIED
            else if (command.Equals("randomucitel"))
            {
                Random rndKonicek = new Random();
                int random_konicek = rndKonicek.Next(1, 66);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(message.Channel + " ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message.Author);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("ßrandomucitel ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("random: " + random_konicek);
                Console.ForegroundColor = ConsoleColor.White;

                if (random_konicek == 1)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " ...Dělejte to zezadu\n-Koníček 2020");
                }
                else if (random_konicek == 2)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " ...Můžet mě udělat... jo\n-Koníček 2020");
                }
                else if (random_konicek == 3)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " ...Bratr je obluda...\n-Štěpánová 2021");
                }
                else if (random_konicek == 4)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " ...Bratr je obluda...\n-Štěpánová 2021");
                }
                else if (random_konicek == 5)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " až budu mít čas, tak vám ho tam fouknu...\n-koníček 2021");
                }
                else if (random_konicek == 6)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " zakazuju vám to dělat hned..\n-koníček 2021");
                }
                else if (random_konicek == 7)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Já to nevysvětluju\n-koníček 2021");
                }
                else if (random_konicek == 8)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " když budete mít takové ty maminky...\n-Nerudová");
                }
                else if (random_konicek == 9)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Vem si motyku a di do vinohradu\n-koníček 2021");
                }
                else if (random_konicek == 10)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Občas tam fouknu plus\n-koníček 2021");
                }
                else if (random_konicek == 11)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " kluci pomožte mu, on tu kládu neunese sám...\n-koníček 2021");
                }
                else if (random_konicek == 12)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Trošku si pohrajem s tou odmocninou...\n-koníček 2021");
                }
                else if (random_konicek == 13)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Třináctku jste dělali na základce\n-koníček 2021");
                }
                else if (random_konicek == 14)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " nebojte budeme to dělat...\n-koníček 2021");
                }
                else if (random_konicek == 15)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Teď to budeme dělat...\n-koníček 2021");
                }
                else if (random_konicek == 16)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " a ted to budem dělat hodinu...\n-koníček 2021");
                }
                else if (random_konicek == 17)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Teď si slízni tu smetanu.\n-koníček 2021");
                }
                else if (random_konicek == 18)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " jak by něco polykala...\n-koníček 2021");
                }
                else if (random_konicek == 19)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " pošlete to do 1. úkolu\n-jedlička 2021");
                }
                else if (random_konicek == 20)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " tohle jsem dělal se žákama na základce...\n-koníček 2021");
                }
                else if (random_konicek == 21)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Já ti dám baby born.\n-koníček 2021");
                }
                else if (random_konicek == 22)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " zahrajem si na hantery\n-koníček 2021");
                }
                else if (random_konicek == 23)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Honza Kordula mě neslyší, nemá mikrofon...\n-Justová 2021");
                }
                else if (random_konicek == 24)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " rozlož mi dvanáctku...\n-koníček 2021");
                }
                else if (random_konicek == 25)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Oči mi vlhnou...\n-koníček 2021");
                }
                else if (random_konicek == 26)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Sežeň si kabel\n-koníček 2021");
                }
                else if (random_konicek == 27)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " devatenáctku nevykouříš...\n-koníček 2021");
                }
                else if (random_konicek == 28)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " jsem byl při chuti\n-koníček 2021");
                }
                else if (random_konicek == 29)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " já to dělám odzadu...\n-koníček 2021");
                }
                else if (random_konicek == 30)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " deseti minutové video, které trvá 15 minut, protože tam jsou sestřihy\n-koníček 2021");
                }
                else if (random_konicek == 31)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " já jsem mu vytáhl...\n-koníček 2021");
                }
                else if (random_konicek == 32)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " celou hodinu jsme mastili\n-koníček 2021");
                }
                else if (random_konicek == 33)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " srdíčko mi plesá\n-koníček 2021");
                }
                else if (random_konicek == 34)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " foukneš mu to na druhou stranu\n-koníček 2021");
                }
                else if (random_konicek == 35)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Lukáše nechci...\n-koníček 2021");
                }
                else if (random_konicek == 36)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Pořiďte si holku\n-Černoch 2021");
                }
                else if (random_konicek == 37)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " jsem z pětky\n-koníček 2021");
                }
                else if (random_konicek == 38)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Co se děje chlapci? Vy jste nějací pomotaní. Asi špatné záření...\n-Justová 2021");
                }
                else if (random_konicek == 39)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Nebudu vás dělat...\n-koníček 2021");
                }
                else if (random_konicek == 40)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " vždycky mi to vypočítejte protože já vám nevěřím že to umíte\n-koníček 2021");
                }
                else if (random_konicek == 41)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Teď vám nevěřím\n-koníček 2021");
                }
                else if (random_konicek == 42)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Dětska mi to dělali pravítkem\n-koníček 2021");
                }
                else if (random_konicek == 43)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " sestřička opálená\n-koníček 2021");
                }
                else if (random_konicek == 44)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " jak udělat hodinu atraktivní?\n-koníček 2021");
                }
                else if (random_konicek == 45)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Jo ty jsi ten kripl... Teda promiň disabled\n-Černoch 2021");
                }
                else if (random_konicek == 46)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Jsem pohodlný pán\n-koníček 2021");
                }
                else if (random_konicek == 47)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " zabít simona\n-Nerudová 2021");
                }
                else if (random_konicek == 48)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " lidé bez kružítka = chudí lidé\n-koníček 2021");
                }
                else if (random_konicek == 49)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Míša je kus chlapa\n-koníček 2021");
                }
                else if (random_konicek == 50)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Lukáši, ty si myslíš že se vrátíte do školy?\n-Halouzka 2021");
                }
                else if (random_konicek == 51)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " ty jseš víc na tvary když jseš chlap\n-koníček 2021");
                }
                else if (random_konicek == 52)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Když si zadáte třeba ten studentský antergránt\n-Štěpánová 2021");
                }
                else if (random_konicek == 53)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " ti hráči by museli být impotentní\n-koníček 2021");
                }
                else if (random_konicek == 54)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " vyměnil starou ženu za misku\n-učitelka na zsv 2021");
                }
                else if (random_konicek == 55)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Filip Urbanczik už mluví, slyšíte mě? - Ne, neslyším\n-Štěpánová 2021");
                }
                else if (random_konicek == 56)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Chlapy se raději dívají na muže než na ženy\n-koníček 2021");
                }
                else if (random_konicek == 57)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " totálně rozmazlenej čupklik\n-Nerudová 2021");
                }
                else if (random_konicek == 58)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " adame, to tě uživí nějaké zelené breberky\n-koníček 2021");
                }
                else if (random_konicek == 59)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " E-brm-brm-ware\n-Prokop 2021");
                }
                else if (random_konicek == 60)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " měl jsem trochu máslo na hlavě\n-koníček 2021");
                }
                else if (random_konicek == 61)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " TAKŽE DOBRÝ DEN DĚCKA\n-Martina Hulvová");
                }
                else if (random_konicek == 62)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Počítač nemá nožičky\n-Vengřínová 2020");
                }
                else if (random_konicek == 63)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Suckling because you suck\n-Jedlička");
                }
                else if (random_konicek == 64)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " Hulvová: To je Erik? \nErik: ano To jsem já\nHulvová: Kdo já?");
                }
                else if (random_konicek == 65)
                {
                    message.Channel.SendMessageAsync(MentionUtils.MentionUser(message.Author.Id) + " my jsme si domluvili rande za kostelem a dali jsme si tam do nosu\n-koníček 2021");
                }

            } //            ßrandomucitel Command

            return Task.CompletedTask;

        }

        void stopPiech()
        {
            System.Environment.Exit(1);
        }
    }
}