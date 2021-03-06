﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Migrations
{
    [DbContext(typeof(TreasureHuntWebAppContext))]
    [Migration("20181119150636_AddRoomID")]
    partial class AddRoomID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TreasureHuntWebApp.Models.AskResponse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AskDate");

                    b.Property<int>("AskType");

                    b.Property<string>("Question");

                    b.Property<string>("Response");

                    b.HasKey("ID");

                    b.ToTable("AskResponse");
                });

            modelBuilder.Entity("TreasureHuntWebApp.Models.Choice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Choice1");

                    b.Property<string>("Choice2");

                    b.Property<string>("Choice3");

                    b.Property<int>("CorrectAnswer");

                    b.Property<string>("Question");

                    b.Property<string>("Result1");

                    b.Property<string>("Result2");

                    b.Property<string>("Result3");

                    b.HasKey("ID");

                    b.ToTable("Choice");
                });

            modelBuilder.Entity("TreasureHuntWebApp.Models.Clue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClueText");

                    b.Property<int>("ClueType");

                    b.Property<int>("Cost");

                    b.Property<int>("HuntID");

                    b.HasKey("ID");

                    b.ToTable("Clue");
                });

            modelBuilder.Entity("TreasureHuntWebApp.Models.CrossWord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Column");

                    b.Property<string>("Letter")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<int>("Row");

                    b.HasKey("ID");

                    b.ToTable("CrossWord");
                });

            modelBuilder.Entity("TreasureHuntWebApp.Models.Dungeon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EastID");

                    b.Property<string>("Guidebook");

                    b.Property<int>("ItemID");

                    b.Property<string>("Name");

                    b.Property<int>("NorthID");

                    b.Property<int>("RoomID");

                    b.Property<int>("SouthID");

                    b.Property<string>("Storyline");

                    b.Property<int>("WestID");

                    b.Property<int>("WorldID");

                    b.HasKey("ID");

                    b.ToTable("Dungeon");
                });

            modelBuilder.Entity("TreasureHuntWebApp.Models.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer");

                    b.Property<int>("AnswerIndex");

                    b.Property<int>("ClueIndex");

                    b.Property<string>("Content");

                    b.Property<int>("QuestionNumber");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("TreasureHuntWebApp.Models.Score", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EntryTime");

                    b.Property<int>("HuntID");

                    b.Property<string>("Name");

                    b.Property<int>("Points");

                    b.Property<int>("QuestionID");

                    b.Property<int>("ScoreType");

                    b.HasKey("ID");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("TreasureHuntWebApp.Models.Scoreboard", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<long>("Score");

                    b.HasKey("ID");

                    b.ToTable("Scoreboard");
                });

            modelBuilder.Entity("TreasureHuntWebApp.Models.Winner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HuntID");

                    b.Property<string>("Name");

                    b.Property<DateTime>("WinTime");

                    b.HasKey("ID");

                    b.ToTable("Winner");
                });
#pragma warning restore 612, 618
        }
    }
}
