﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PainelCipa.Models;

namespace PainelCipa.Migrations
{
    [DbContext(typeof(PainelCipaContext))]
    partial class PainelCipaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PainelCipa.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Department");

                    b.Property<int>("ElectionID");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.HasIndex("ElectionID");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("PainelCipa.Models.Election", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HasFinished");

                    b.Property<bool>("HasStarted");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Election");
                });

            modelBuilder.Entity("PainelCipa.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("PainelCipa.Models.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CPF");

                    b.Property<int>("CandidateID");

                    b.Property<DateTime>("Moment");

                    b.HasKey("Id");

                    b.HasIndex("CandidateID");

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("PainelCipa.Models.Candidate", b =>
                {
                    b.HasOne("PainelCipa.Models.Election", "Election")
                        .WithMany("Candidates")
                        .HasForeignKey("ElectionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PainelCipa.Models.Vote", b =>
                {
                    b.HasOne("PainelCipa.Models.Candidate", "Candidate")
                        .WithMany("Votes")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
