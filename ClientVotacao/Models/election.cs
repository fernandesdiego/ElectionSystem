using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ClientVotacao.Models
{
    [Table("Election")]
    public partial class Election
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
        public bool HasFinished { get; set; }
        public bool HasStarted { get; set; }
        public Election()
        {
        }

        public Election(int id, int year, bool hasFinished, bool hasStarted)
        {
            Id = id;
            Year = year;
            HasFinished = hasFinished;
            HasStarted = hasStarted;
        }
    }
}
