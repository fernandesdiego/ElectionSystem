using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace PainelCipa.Models
{
    public class Vote
    {
        public int Id { get; set; }
        [ForeignKey("VoterId")]
        public virtual Voter Voter { get; set; }
        public Candidate Candidate { get; set; }

        public Vote()
        {

        }

        public Vote(int id, Voter voter, Candidate candidate)
        {
            Id = id;
            Voter = voter;
            Candidate = candidate;
        }
    }
}
