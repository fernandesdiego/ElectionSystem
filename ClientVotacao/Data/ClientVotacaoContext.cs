using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ClientVotacao.Models;

namespace ClientVotacao.Data
{
    public partial class ClientVotacaoContext : DbContext
    {
        public ClientVotacaoContext() : base("name=ClientVotacaoContext")
        {
        }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Election> Election { get; set; }
        public virtual DbSet<Vote> Vote { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Candidate>()
        //        .Property(e => e.Name)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Candidate>()
        //        .Property(e => e.Department)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Candidate>()
        //        .Property(e => e.Role)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Candidate>()
        //        .Property(e => e.Photo)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Vote>()
        //        .Property(e => e.Moment)
        //        .HasPrecision(6);
        //}
    }
}
