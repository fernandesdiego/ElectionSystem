using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ClientVotacao.Models
{
    [Table("Vote")]
    public partial class Vote
    {
        public int Id { get; set; }
        public int? CandidateID { get; set; }
        public Candidate Candidate { get; set; }
        public int CPF { get; set; }
        public DateTime Moment { get; set; }

        public Vote()
        {
        }

        public Vote(int id, int candidateID, Candidate candidate, int cPF, DateTime moment)
        {
            Id = id;
            CandidateID = candidateID;
            Candidate = candidate;
            CPF = cPF;
            Moment = moment;
        }
    }
}