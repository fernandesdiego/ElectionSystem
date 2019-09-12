﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PainelCipa.Models;

namespace PainelCipa.Migrations
{
    [DbContext(typeof(PainelCipaContext))]
    [Migration("20190912163936_OtherEntities")]
    partial class OtherEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PainelCipa.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CipaId");

                    b.Property<string>("Department");

                    b.Property<string>("Name");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.HasIndex("CipaId");

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

            modelBuilder.Entity("PainelCipa.Models.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CandidateId");

                    b.Property<int?>("VoterId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("VoterId")
                        .IsUnique();

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("PainelCipa.Models.Voter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<int?>("CipaId");

                    b.Property<bool>("HasVoted");

                    b.HasKey("Id");

                    b.HasIndex("CipaId");

                    b.ToTable("Voter");
                });

            modelBuilder.Entity("PainelCipa.Models.Candidate", b =>
                {
                    b.HasOne("PainelCipa.Models.Election", "Election")
                        .WithMany("Candidates")
                        .HasForeignKey("CipaId");
                });

            modelBuilder.Entity("PainelCipa.Models.Vote", b =>
                {
                    b.HasOne("PainelCipa.Models.Candidate", "Candidate")
                        .WithMany("Votes")
                        .HasForeignKey("CandidateId");

                    b.HasOne("PainelCipa.Models.Voter", "Voter")
                        .WithOne("Vote")
                        .HasForeignKey("PainelCipa.Models.Vote", "VoterId");
                });

            modelBuilder.Entity("PainelCipa.Models.Voter", b =>
                {
                    b.HasOne("PainelCipa.Models.Election", "Election")
                        .WithMany()
                        .HasForeignKey("CipaId");
                });
#pragma warning restore 612, 618
        }
    }
}
