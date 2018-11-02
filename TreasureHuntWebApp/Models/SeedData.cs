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
                            dungeon.Guidebook = "The master of the castle loved practical jokes and installed many pits into which his guests could fall. All the pits connected to the same underground network and led back to the entrance hall.";

                            if (i > 1){ dungeon.WestID = westID; }
                            if (i < 6) { dungeon.EastID = eastID; }
                            if (j > 1) { dungeon.SouthID = southID; }
                            if (j < 6) { dungeon.NorthID = northID; }

                            if (id == 1)
                            {
                                dungeon.Name = "Start";
                                dungeon.Storyline = "You wake up dazed and confused on a cold, hard floor. You look around and see a dark dingy room, lit only by torches. There are 2 old wooden doors ahead of you which look unlocked...";
                                dungeon.Guidebook = "Welcome to the Castle Emon Guidebook. Throughout your tour this book will attempt to aid you in the navigation of the castle. You can read about each room by turning to the relevant page.";
                            }
                            else if (id == 2)
                            {
                                dungeon.Name = "Sleepy Head";
                                dungeon.Storyline = "Hurrrgggghhhhh! A loud grunt startles you as you enter the room. Running away from the sound into the room, you turn as the door bangs shut and the giant troll that was sleeping behind it stands up. On it's head is a large wooden crown with the words 'King Sower' written crudely. It appears to have been nailed to it's skull. Not fazed by this, you take an aggressive stance and prepare to attack...";
                                dungeon.ItemID = 1; // monster
                                dungeon.Guidebook = "In this room, Lord Emon locked up the tyrant troll king, King Sower.";
                            }
                            else if (id == 3)
                            {
                                dungeon.Name = "The Dungeon";
                                dungeon.Storyline = "Moving into the room you step in a puddle and the sound echos off the walls. On one side are a series of cells. To the west is a large door with the words 'King Sower' written on. To the east lies a smaller door...";
                                dungeon.Guidebook = "Lord Emon had a dark sense of humour and designed his castle such that you had to walk through the dungeons to reach the main castle complex. This is also where he imprisoned the troll leader, King Sower.";
                            }
                            else if (id == 4)
                            {
                                dungeon.Name = "Dungeon Corridor";
                                dungeon.Storyline = "You emerge into a long corridor. It runs from east to west with small doors at either end. In the middle there is another small door and as you walk up to it you notice scratches and patches of blood.";
                                dungeon.Guidebook = "This corridor was a simple route past the prank pit to the north. By heading west you are able to visit the castle dungeons and to the east are the castle main living quarters.";
                            }
                            else if (id == 5)
                            {
                                dungeon.Name = "Torture Chamber";
                                dungeon.Storyline = "In the middle of the room is a strange contraption. Looking like a cross between a chair and a candelabra, you quickly realise it is some form of torture device. At this point you notice the rest of the devices around the edges. You hurry to get out of here and into another room.";
                                dungeon.Guidebook = "Always the comedian, Lord Emon created this fake torture chamber to scare his guests. FUN FACT: The central torture device was actually made out of a candelabra and a small chair. This room connected the castle living quarters to the north with the dungeons to the west.";
                            }
                            else if (id == 7)
                            {
                                dungeon.Name = "Stone Room";
                                dungeon.Storyline = "You enter a dark room. It is made entirely out of stone. You look around and notice more wooden doors...";
                                dungeon.Guidebook = "The stone room was used to entertain guests. The smell of food wafted in through the north door and guests were often seen exploring through the east door.";
                            }
                            else if (id == 9)
                            {
                                dungeon.Name = "Dungeon Corridor";
                                dungeon.Storyline = "You walk down a long corridor. To the south a sign above the door reads 'Dungeons' and to the north you see 'Armory'. In the middle on either side are 2 smaller doors.";
                                dungeon.Guidebook = "In an attempt to prevent escaping prisoners from leaving the 2 main doors of the corridor were labelled in order to deter them from escaping through these. Therefore the prisoners would be more likely to try the smaller doors in the middle which both led to pits.";
                            }
                            else if (id == 11)
                            {
                                dungeon.Name = "Guard Room";
                                dungeon.Storyline = "You peer around the door and immediately pull back, out of sight. All around the room were a large number of dark figures. One must clearly have seen you or the door move but you hear no movement or voices. You peer around again, more cautiously this time and realise they are all empty suits of armour. On further inspection of the room you see the easterly door looks well used and the north and west appear to have been hardly touched.";
                                dungeon.Guidebook = "This is the Guard Room where Lord Emon's Banen Guards lived. They spent most of their time polishing armour to give it a golden, almost yellow, glint. They never used the north or west doors as Lord Emon had put traps behind them.";
                            }
                            else if (id == 12)
                            {
                                dungeon.Name = "Entrance Hall";
                                dungeon.Storyline = "A long shaft of light pierces the eary blackness of the room. A large staircase leads up to a door at the north of the room. Suspended on all the walls are various sections of trees and plants, presented like animal heads, stuck on black plaques which appear to be moving. On closer examination the plaques are covered in a thick layer of flies and you realise they are made out of flesh.";
                                dungeon.Guidebook = "This room was the main entrance to the living quarters of the castle. It was designed to be lavish and show any guests the wealth that Lord Emon had amassed through his travels to North Eastern India. His personal chambers are to the north and he sent his less favoured subjects to sleep behind the south door.";
                            }
                            else if (id == 13)
                            {
                                dungeon.Name = "Dining Room";
                                dungeon.Storyline = "This room has more light. It allows you to see what was once a fine banquet hall. No however it lies in disarray and there is a thick layer of dust across everything. A faint wiff of food comes from a northerly direction.";
                                dungeon.Guidebook = "Dinners and banquets were frequent at Castle Emon and most took place in this very room. The food would be delivered from the north door and guests would lounge around eating their fill before emptying themselves through the east door.";
                            }
                            else if (id == 15)
                            {
                                dungeon.Name = "Armoury Storeroom";
                                dungeon.Storyline = "This room looks like it has been raided. Most of the cupboards, that once lined the walls, lay knocked over in the middle. Sword racks and various tools lie strewn around the room. No weapons here anymore.";
                                dungeon.Guidebook = "Surplus weapons and armour were stored in this room. The best pieces could be found in the armoury and trophy room to the north. It was also a room which hid the entrance to the dungeons and then onto the living quarters.";
                            }
                            else if (id == 18)
                            {
                                dungeon.Name = "The Lounge";
                                dungeon.Storyline = "As soon as you open the door there is an explosion of light. You retreat slightly as your eyes get used to the new room. Squinting, you look around a large room lined with plush sofas and various pieces of furniture. The light is streaming through 2 large windows in the western wall. The room isn't clean but someone has definitely been using this room and recently too by the lack of dust around the northern door.";
                                dungeon.Guidebook = "The lounge was were Lord Emon relaxed. He designed it to be so comfortable that he once said 'If I ever lost my mind, I like to think that I would still use this room due to the effect it has on me, regardless of my sanity'. The only room that was allowed windows, 2 large opening were carved into the west wall.";
                            }
                            else if (id == 19)
                            {
                                dungeon.Name = "Kitchen";
                                dungeon.Storyline = "As you open the door you are hit by a sea of different smells. Around the dimly lit room there are piles of rotting food and the resemblance of a kitchen. You see a glimmer of light coming from a door to the north.";
                                dungeon.Guidebook = "The kitchen was Lord Emon's pride and joy. He loved cooking everything and anything. He kept a supply closet near to the north, through which his private study lay in case he needed to check some recipes quickly. It also connected the guest areas to the rest of the castle through the east doorway.";
                            }
                            else if (id == 20)
                            {
                                dungeon.Name = "Maze Room";
                                dungeon.Storyline = "Something seems odd about this room. You notice that all the flagstones are different shades of grey. It quickly becomes apparent that it is a maze and stepping in the wrong place would mean a long drop. You can just about make out the paths and see a clear path laid out connecting the west door with the north and south doors. But only closer inspection you see a faint path leading the small eastern door.";
                                dungeon.Guidebook = "Lord Emon was very paranoid about the wrong people going to the wrong parts of the castle so he installed trick rooms like this one to prevent unwanted visitors to his armoury. Step on a wrong stone and you would fall into the pit. Even if the guests saw the paths laid out in the stonework they would be led to 2 pits through the northern and southern doors.";
                            }
                            else if (id == 21)
                            {
                                dungeon.Name = "The Armoury";
                                dungeon.Storyline = "You are taken away by the sheer number of weapons displayed in all nooks and cranies of this room. Huge spears lean on equally large racks in the centre and the walls are covered with swords of all shapes and sizes. Shields hang from the ceiling in rows and below them are work benches with scores of crossbows and knives. You approach the nearest rapier and pick it up. It feels oddly light. And flimsy. You take a spear and it breaks in 2 at the mearest touch. All these weapons seem fake. As if for show and now have rotted away. They are all useless...";
                                dungeon.Guidebook = "Weapons and Armour fascinated Lord Emon. He always brought them back from travels and stored them in his armoury. But he was also very paranoid and never kept the real weapons here instead using fakes to impress guests whilst keeping the real weapon safe from thieving hands. The actual weapons are in the storeroom to the south and his best pieces can be found locked safely in the trophy room to the north.";
                            }
                            else if (id == 23)
                            {
                                dungeon.Name = "Throne Room";
                                dungeon.Storyline = "At the centre of the room there is a great throne. Sitting proudly on the old dusty seat is a small furry creature. This must be a Klorg pup that the Professor mentioned. You notice that is wearing a collar with a small green flashing light. You approach the creature but it does not move. The light keeps flashing, getting faster and more urgent. You reach out...";
                                dungeon.ItemID = 5; // find Klorg here
                                dungeon.Guidebook = "The throne room was built to stroke the Lord Emon's ego. He was not actually a king (or a lord for that matter), as he had no kingdom, but he built a throne room to legitimise his claim to the title. Don't mention this fact to him or he will be very sour.";
                            }
                            else if (id == 24)
                            {
                                dungeon.Name = "Lord Emon";
                                dungeon.Storyline = "You enter a dark room filled only with the sound of dripping water from one corner. It appears to be coming from a stalactite hanging from the ceiling. You are very thirsty and approach to take a sip. You open your mouth directly beneath and a large drop hits your tongue. It tastes very salty and has a zesty sting to it. You peer up again at the stalactite and see 2 large oval eyes staring back. What you thought was a stalactite was in fact a large winged creature. It releases a high pitch screech: 'Eeeeeeemmmon!' and drops on you. A large mouth latches on to your arm but instead of feeling sharp fangs, your arm is simply squished a bit and covered in a sticky juice. You pull your arm away and attempty to fight back...";
                                dungeon.ItemID = 1; // monster
                                dungeon.Guidebook = "The coronation room was built to join onto the throne room so that Lord Emon could be crowned King Emon. But as he did not have a kingdom and therefore no subjects, there was never a ceremony. He has still referred to himself as king on occasions but this has never been recongised by any other official nation.";
                            }
                            else if (id == 25)
                            {
                                dungeon.Name = "Jeff the Chef";
                                dungeon.Storyline = "You open the door to what appears to be a store room and immediately hear a shuffling in the corner. Assuming it to be a rat you enter the room and try to make you way past more rotting piles of food. As you get to the center of the room you see what caused the noise. Huddled over a small pile of brown fruit is a figure in a dirty white uniform. Hearing you approach it quickly turns, brandishing a large wooden spoon. 'So! Cam tuh steal ma froot av ya?' it spurts, saliva dripping from the hole you assume is it's mouth. Suddenly out of nowhere it charges at you and you prepare to fight...";
                                dungeon.ItemID = 1; // monster
                                dungeon.Guidebook = "The kitchen, to the south, wasn't large enough to store the vast amounts of food Lord Emon consumed so he had a store room added. He even placed his personal study to north, close enought that he could quickly grab a snack or some citrus fruits.";
                            }
                            else if (id == 27)
                            {
                                dungeon.Name = "Trophy Room";
                                dungeon.Storyline = "This room looks more like a prison than the trophy room it is supposed to be. The prisoners are all the trophies and weapons displayed in cases wrapped with so many padlocked chains that they can never escape. You attempt to get to one which has a large silver mace inside but with no luck. Looking around you spot that the northern door looks well used.";
                                dungeon.Guidebook = "This room was were Lord Emon displayed his most precious objects. Weapons he collected on his travels and trophies he created himself for strange accomplishments that no one had ever seen him do. He also put in 2 fake rooms to the east and west with pit traps to make it harder to get to his most prized possession located in the northern chamber.";
                            }
                            else if (id == 30)
                            {
                                dungeon.Name = "Boring Room";
                                dungeon.Storyline = "This rooms gives you a sense of utter boredom. Clearly the interior designer had given up at this point and spent more time on the rest of the castle. If you were to describe this room to someone you would have no words to use and instead go off on a tangent explaining how utterly boring it was without actually describing any details of the room at all except that it had 3 doors.";
                                dungeon.Guidebook = "The Boring Room, often referred to as The Forgotten Room, was a space that warranted no description. It was simply a room you would pass through and therefore did not affect anything in any way. It was the way that Lord Emon went to get to his personal chambers.";
                            }
                            else if (id == 31)
                            {
                                dungeon.Name = "The Study";
                                dungeon.Storyline = "You enter and immediately break into a coughing fit. The dust in this room hangs so thick in the air it is hard to see your hand. You wave your arms around and the dust comes to life, dancing and swirling around as if an invisible conductor is leading it. You see the room for the first time and notice it is stacked with old parchments and scrolls. You pick some up and see many crude drawings of lemons and other citrus fruits. On one side you see the corner of a small document which has no dust on it, as if it has been recently moved. You pull it out and begin to examine. It is a map and a badly drawn one at that. But maybe it can guide you out of here. You put it in the top left hand corner and realise you can now click on it if you want to see it. Also you think 'I bet i'm in the top left hand corner of the map right now, you know, where that map logo is'.";
                                dungeon.ItemID = 2; // map
                                dungeon.Guidebook = "The Study was were Lord Emon conducted his most private work. Mainly self portraits and drawings of his long lost family. He also attempted to map the vast castle but legends say he never finished it, or that he did but it was so terrible he hid it somewhere.";
                            }
                            else if (id == 33)
                            {
                                dungeon.Name = "Statue of Sir Daint Emon";
                                dungeon.Storyline = "The room is empty except for a solitary figure in the centre. You approach cautiously and realise it is an old stone statue of a knight. 'Here lies Sir Teyste, Keeper of the Yellow Sword'. After reading this you notice that the stone sword is in fact slightly yellow and covered in a fine layer of grey dust. You reach out and take the sword, immediately noticing a sharp taste in your mouth. 'Time to get out of here!' you think to yourself.";
                                dungeon.ItemID = 3; // sword
                                dungeon.Guidebook = "Lord Emon grew up with a brother called Daint. Daint was always the favourite son and excelled at everything he attempted. This infuriated Lord Emon and he swore that when they were both older he would be better than his brother Daint. One day Daint stole his brothers favourite sword and hid himself in this room. Lord Emon searched the castle but never found him or so the story goes. But many years later this statue appeared here holding the very sword that Daint had taken with him on that day."; 
                            }
                            else if (id == 35)
                            {
                                dungeon.Name = "Lord Emon's Chamber";
                                dungeon.Storyline = "As soon as you open the door you are hit by a thick smell with hints of rum and paper. Peering into the room you see a four-poster bed with a large chest at the foot of it. Propped up against the chest is a rotting skeleton covered in rags. You walk closer and notice a small sheaf of parchment attached to a bottle of rum. After taking a swig *burp* you read the scribbled writing: 'If you are reading this then I have a long since escaped this castle and am off galavanting and spending the loot. That is of course unless the Professor got to it first...'.";
                                dungeon.ItemID = 3; // sword
                                dungeon.Guidebook = "Lord Emon's bed chamber was a modest room as when he grew wings he preferred hanging from the ceiling rather than sleeping in a bed. This room is also were it is claimed he hid clues to his great treasure but there is no evidence for this. Although he did like cryptic clues and often left them lying around in various texts he wrote.";
                            }
                            else if (id == 36)
                            {
                                dungeon.Name = "North-Eastern Corner Room";
                                dungeon.Storyline = "You get a weird feeling that this room is a corner of the castle. It could be the giant pile of dung in the corner, the fact that there are only 2 doors to the south and west or the fact that an old banner stretching the width of the room reads: 'North-East Corner Room'.";
                                dungeon.Guidebook = "The Corner Room was named after the late Earl Corner. Nicknamed Mueller, due to his german heritage, he took a liking to this room on frequent visits and to honour him when he died, Lord Emon named the room after him. Later Lord Emon found out that there was another castle with a Corner Room so he aptly added the location of the room and henceforth it was known as the North-Eastern Coner Room.";
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