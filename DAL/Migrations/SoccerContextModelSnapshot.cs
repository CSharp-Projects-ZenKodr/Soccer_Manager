﻿// <auto-generated />
using DAL.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DAL.Migrations
{
    [DbContext(typeof(SoccerContext))]
    partial class SoccerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelClasses.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.Property<string>("Surname");

                    b.Property<int?>("TeamId");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ModelClasses.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ModelClasses.TeamTournament", b =>
                {
                    b.Property<int>("TournamentId");

                    b.Property<int>("TeamId");

                    b.HasKey("TournamentId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamTournament");
                });

            modelBuilder.Entity("ModelClasses.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EndDate");

                    b.Property<int>("MaxCountTeams");

                    b.Property<string>("Name");

                    b.Property<string>("StartDate");

                    b.HasKey("TournamentId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("ModelClasses.Player", b =>
                {
                    b.HasOne("ModelClasses.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("ModelClasses.TeamTournament", b =>
                {
                    b.HasOne("ModelClasses.Tournament", "Tournaments")
                        .WithMany("TeamTournaments")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ModelClasses.Team", "Teams")
                        .WithMany("TeamTournaments")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}