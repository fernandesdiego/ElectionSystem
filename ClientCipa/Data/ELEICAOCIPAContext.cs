using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ClientCipa.Models;


namespace ClientCipa.Data
{
    public partial class ELEICAOCIPAContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ELEICAOCIPAContext()
        {
        }

        public ELEICAOCIPAContext(DbContextOptions<ELEICAOCIPAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Election> Election { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Vote> Vote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["CipaContext"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("candidate");

                entity.HasIndex(e => e.ElectionId)
                    .HasName("IX_Candidate_ElectionID");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Department).HasColumnType("longtext");

                entity.Property(e => e.ElectionId)
                    .HasColumnName("ElectionID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name).HasColumnType("longtext");

                entity.Property(e => e.Photo).HasColumnType("longtext");

                entity.Property(e => e.Role).HasColumnType("longtext");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasColumnType("varchar(95)");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<Election>(entity =>
            {
                entity.ToTable("election");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.HasFinished).HasColumnType("bit(1)");

                entity.Property(e => e.HasStarted).HasColumnType("bit(1)");

                entity.Property(e => e.Year).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Password).HasColumnType("longtext");

                entity.Property(e => e.Username).HasColumnType("longtext");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.ToTable("vote");

                entity.HasIndex(e => e.CandidateId)
                    .HasName("IX_Vote_CandidateID");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CandidateId)
                    .HasColumnName("CandidateID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Moment).HasDefaultValueSql("'0001-01-01 00:00:00.000000'");
            });
        }
    }
}
