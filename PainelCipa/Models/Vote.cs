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
        public int CPF { get; set; }
        public virtual Candidate Candidate { get; set; }
        public int CandidateID { get; set; }
        public DateTime Moment { get; set; }

        public Vote()
        {

        }

        public Vote(int id, int cpf, Candidate candidate, DateTime moment)
        {
            Id = id;
            Candidate = candidate;
            CPF = cpf;
            Moment = moment;
        }
    }
}
