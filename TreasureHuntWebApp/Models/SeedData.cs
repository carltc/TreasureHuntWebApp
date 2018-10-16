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
                if (context.Question.Any())
                {
                    return;   // DB has been seeded
                }

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
        }
    }
}