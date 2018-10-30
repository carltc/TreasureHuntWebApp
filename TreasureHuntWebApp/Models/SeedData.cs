using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TreasureHuntWebApp.Models
{
    public static class SeedData
    {

        private static int questionNumber = 0;

        private static int QuestionNumber()
        {
            questionNumber++;
            return questionNumber;
        }

        private static decimal GetPi(int digit)
        {
            decimal pi = 3.14159265358979323846264338327950288419716939937510m;

            while (pi <= 10 * digit)
                pi *= 10;

            pi = Math.Floor(pi);
            
            return pi % 10;
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TreasureHuntWebAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<TreasureHuntWebAppContext>>()))
            {
                // Look for any movies.
                if (!context.Question.Any())
                {
                    context.Question.AddRange(
                        new Question
                        {
                            QuestionNumber = QuestionNumber(),
                            Title = "Name The Movie",
                            ReleaseDate = DateTime.Now,
                            Content = "So there's this guy and he is a bit of a war hero after fighting in Vietnam but he"
                                + " gets injured and is very sad as one of his friends gets killed. He also spends some of"
                                + " his time fishing and one day gets caught in a really bad storm, called Carmen that"
                                + " throws the boat all over the place but doesn't manage to write it off. Although it proper"
                                +" smashed up all these other boats, which was alright for our guy as it meant he could"
                                + " catch more when fishing. He then used a bunch of money he made from this venture"
                                + " and got it invested in Apple. Our friend here also spends ages sitting on a bench and"
                                + " he likes chocolates.",
                            Answer = "_ _ _ _ _ _ _ / _ _ _ _", // Forrest Gump
                            AnswerIndex = 6,
                            ClueIndex = 65
                        },

                        new Question
                        {
                            QuestionNumber = QuestionNumber(),
                            Title = "Name The Singer",
                            ReleaseDate = DateTime.Now,
                            Content = "Who is the carrot top music artist whose music video was subject to a cheeky YouTube"
                                + " practical joke, wherein on April fools day any video clicked upon on the home page,"
                                + " linked you to said music video?",
                            Answer = "_ _ _ _ / _ _ _ _ _ _", // Rick Astley
                            AnswerIndex = 10,
                            ClueIndex = 4
                        },

                        new Question
                        {
                            QuestionNumber = QuestionNumber(),
                            Title = "Find Pi Digit",
                            ReleaseDate = DateTime.Now,
                            Content = "What are the first 25 decimal places in pi?",
                            Answer = "_ . _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _", //GetPi(25).ToString() 4
                            AnswerIndex = 24,
                            ClueIndex = 8
                        },

                        new Question
                        {
                            QuestionNumber = QuestionNumber(),
                            Title = "Name The Password",
                            ReleaseDate = DateTime.Now,
                            Content = "There is this book written by the same guy that wrote this other book which was"
                                + " in turn made into a film staring Tom Hanks and Magneto. In the first book, Wikipedia"
                                + " describes it as having a Techno - Thriller genre. What is the main password that the"
                                + " characters are trying to work out (and finally do) for the main thing at the end of"
                                + " that first book ?",
                            Answer = "_", // 3
                            AnswerIndex = 1,
                            ClueIndex = 7
                        },

                        new Question
                        {
                            QuestionNumber = QuestionNumber(),
                            Title = "Name The Word",
                            ReleaseDate = DateTime.Now,
                            Content = "What is the last word of the last line of the last page of Harry Potter and the"
                                + " Deathly Hallows",
                            Answer = "_ _ _ _", // Well
                            AnswerIndex = 3,
                            ClueIndex = 9
                        },

                        new Question
                        {
                            QuestionNumber = QuestionNumber(),
                            Title = "Name The Song",
                            ReleaseDate = DateTime.Now,
                            Content = "There was this girl and she caught her train and then this guy caught his train. It is"
                                + " not clear whether both trains were in fact the same train but the trains were quite"
                                + " late in the day. There is also someone in a room which is a bit hazy and they are"
                                + " trying to sing a song to the people watching. Then there are some people who do "
                                + " not know each other and they are hanging around a wide street in a town or city,"
                                + " typically one that is lined with trees.",
                            Answer = "_ _ _ _ / _ _ _ _ / _ _ _ _ _ _ _ _ _", // "Don't Stop Believing"
                            AnswerIndex = 10,
                            ClueIndex = 90
                        },

                        new Question
                        {
                            QuestionNumber = QuestionNumber(),
                            Title = "Name The Force",
                            ReleaseDate = DateTime.Now,
                            Content = "If you droppped a 3kg bowling ball on Earth and it fell with an acceleration of 9.81"
                                + " m/s^2, what is the downward force that the bowling ball has just before it hits the floor?",
                            Answer = "_ _ . _ _", // "29.43"
                            AnswerIndex = 3,
                            ClueIndex = 2
                        },

                        new Question
                        {
                            QuestionNumber = QuestionNumber(),
                            Title = "Name The Movie",
                            ReleaseDate = DateTime.Now,
                            Content = "A story of a group of US soldiers who leave their friend Matt Damon behind in"
                                + " rural France and then heal a lot of German soldiers by sucking bullets out of them"
                                + " with their magic long range vacuum machines as they walk across France to the ships"
                                + " that send them back to England. Film described in reverse - what is the name of this film?",
                            Answer = "_ _ _ _ _ _ / _ _ _ _ _ _ _ / _ _ _ _", // "Saving Private Ryan"
                            AnswerIndex = 9,
                            ClueIndex = 49
                        }
                    );
                    context.SaveChanges();
                }

                // Look for any responses.
                if (!context.AskResponse.Any())
                {
                    context.AskResponse.AddRange(
                        new AskResponse
                        {
                            Question = "Hello",
                            Response = "Hi",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Hi",
                            Response = "Hello",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Who are you",
                            Response = "I am LemonCube. Who are you?",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Do",
                            Response = "Hehe, do. Like do do. Hihi. Stop asking Do or I won't be able to concentrate. Hihi",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "How",
                            Response = "It is not a question of how. But a question of Who.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Why",
                            Response = "Not really sure why. But I think you should be asking How.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "What",
                            Response = "Not sure really. Maybe keep asking me things and see if my responses change.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Where",
                            Response = "I don't really have a concept of where things are. Try asking other stuff.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Who",
                            Response = "That is a good question, but one for another time. Maybe ask me about treasure hunts.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Help",
                            Response = "Sure. Ask me about word games and those sorts of things.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Treasure",
                            Response = "You have said the magic word. Now maybe ask about riddles.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Hunt",
                            Response = "You have said the magic word. Now maybe ask about riddles.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Lemon",
                            Response = "Mmm lemons. Now I am distracted. Try again in a bit,",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Cube",
                            Response = "You have mentioned my favourite shape! I am a bit of a cube myself don't ya know.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Word",
                            Response = "I like words. But sometimes people put them together like a question but it is confusing to answer. Like that Batman villain.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Game",
                            Response = "Games are fun. I remember Bilbo and Gollum played a game once in the caves. What type of game was it?",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Riddle",
                            Response = "Now you are asking the right qustions. Here goes: What winds but has no coil, runs but has no legs and has a bed but never sleeps?",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "River",
                            Response = "Congratulations! You either got here by sheer luck or you have solved the youngest riddle on this site! Go to LemonCube.AzureWebsites.net/WinnyWinny to claim your prize!",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "Matt",
                            Response = "Nice to meet you, Matt.",
                            AskDate = DateTime.Now,
                            AskType = 1
                        },

                        new AskResponse
                        {
                            Question = "",
                            Response = "Not really sure what you mean.",
                            AskDate = DateTime.Now,
                            AskType = 2
                        },

                        new AskResponse
                        {
                            Question = "",
                            Response = "I don't understand. Sorry.",
                            AskDate = DateTime.Now,
                            AskType = 2
                        },

                        new AskResponse
                        {
                            Question = "",
                            Response = "Hmm. Not sure but ask something else.",
                            AskDate = DateTime.Now,
                            AskType = 2
                        },

                        new AskResponse
                        {
                            Question = "",
                            Response = "Nope. Not understanding a single bit of that. Ask again?",
                            AskDate = DateTime.Now,
                            AskType = 2
                        },

                        new AskResponse
                        {
                            Question = "",
                            Response = "Sorry, I don't understand you. Ask clear questions and I will give you more information.",
                            AskDate = DateTime.Now,
                            AskType = 2
                        }
                    );
                    context.SaveChanges();
                }

                // Look for dungeons
                if (!context.Dungeon.Any())
                {
                    Dungeon dungeon = new Dungeon();
                    // Add Medieval Dungeon
                    for (int j = 1; j <= 6; j++)
                    {
                        for (int i = 1; i <= 6; i++)
                        {
                            int id = i + ((j - 1) * 6);
                            int northID = id + 6;
                            int eastID = id + 1;
                            int southID = id - 6;
                            int westID = id - 1;

                            dungeon = new Dungeon();
                            dungeon.WorldID = 3;
                            dungeon.Name = "Pit";
                            dungeon.Storyline = "You fell in a pit.";
                            dungeon.ItemID = 0;

                            if (i > 1){ dungeon.WestID = westID; }
                            if (i < 6) { dungeon.EastID = eastID; }
                            if (j > 1) { dungeon.SouthID = southID; }
                            if (j < 6) { dungeon.NorthID = northID; }

                            if (id == 1)
                            {
                                dungeon.Name = "Start";
                                dungeon.Storyline = "You wake up dazed and confused on a cold, hard floor. You look around and see a dark dingy room, lit only by torches. There are 2 old wooden doors ahead of you which look unlocked...";
                            }
                            else if (id == 2)
                            {
                                dungeon.Name = "Sleepy Head";
                                dungeon.Storyline = "Hurrrgggghhhhh! A loud grunt startles you as you enter the room. Running away from the sound into the room, you turn as the door bangs shut and the giant troll that was sleeping behind it stands up. Not fazed by this, you take an aggressive stance and prepare to attack the troll.";
                                dungeon.ItemID = 1; // monster
                            }
                            else if (id == 3)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 4)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 5)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 7)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 9)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 11)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 12)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 13)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 15)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 18)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 19)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 20)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 21)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 23)
                            {
                                dungeon.Name = "Throne Room";
                                dungeon.Storyline = "At the centre of the room there is a great throne. Sitting proudly on the old dusty seat is a small furry creature. This must be a Klorg pup that the Professor mentioned. You notice that is wearing a collar with a small green flashing light. You approach the creature but it does not move. The light keeps flashing, getting faster and more urgent. You reach out...";
                                dungeon.ItemID = 5; // find Klorg here
                            }
                            else if (id == 24)
                            {
                                dungeon.Name = "Monster";
                                dungeon.Storyline = "Across the room you notice a large monster.";
                                dungeon.ItemID = 1; // monster
                            }
                            else if (id == 25)
                            {
                                dungeon.Name = "Monster";
                                dungeon.Storyline = "Across the room you notice a large monster.";
                                dungeon.ItemID = 1; // monster
                            }
                            else if (id == 27)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 30)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                            }
                            else if (id == 31)
                            {
                                dungeon.Name = "The Library";
                                dungeon.Storyline = "The room is stacked with old parchments and scrolls. You notice one which has no dust on it, as if it has been recently moved. Upon further examination you notice it is a map.";
                                dungeon.ItemID = 2; // map
                            }
                            else if (id == 33)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "The room is empty except for a solitary figure in the centre. You approach cautiously and realise it is an old stone statue of a knight. 'Here lies Sir Teyste, Keeper of the Yellow Sword'. After reading this you notice that the stone sword is in fact slightly yellow and covered in a fine layer of grey dust. You reach out and take the sword, immediately noticing a sharp taste in your mouth. 'Time to get out of here!' you think to yourself.";
                                dungeon.ItemID = 3; // sword
                            }
                            else if (id == 35)
                            {
                                dungeon.Name = "Map Maker Grave";
                                dungeon.Storyline = "As soon as you open the door you are hit by a thick smell with hints of rum and paper. Peering into the room you see a large chest, and propped up against it is a rotting skeleton. You walk closer and notice a small sheaf of parchment attached to a bottle of rum. After taking a swig *burp* you read the note: 'If you are reading this then I have a long since escaped this dungeon and am off galavanting and spending the loot. Unless the Professor got to it first...'.";
                                dungeon.ItemID = 3; // sword
                            }
                            else if (id == 36)
                            {
                                dungeon.Name = "Empty Room";
                                dungeon.Storyline = "You enter a dark room. You look around and notice more wooden doors...";
                                dungeon.ItemID = 3; // sword
                            }

                            context.Dungeon.Add(dungeon);
                            context.SaveChanges();
                        }
                    }

                    dungeon = new Dungeon();
                    dungeon.WorldID = 3;
                    dungeon.Name = "Defeat";
                    dungeon.Storyline = "The monster defeated you. You are knocked unconscious and carried away.";
                    dungeon.ItemID = 0;
                    dungeon.NorthID = 1;
                    context.Dungeon.Add(dungeon);
                    context.SaveChanges();
                }
            }
        }
    }
}