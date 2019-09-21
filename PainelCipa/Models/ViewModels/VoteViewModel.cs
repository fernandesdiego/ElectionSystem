using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelCipa.Models.ViewModels
{
    public class VoteViewModel
    {
        public int Id { get; set; }
        [ForeignKey("VoterId")]
        public int CPF { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual Election Election { get; set; }
        public int CandidateID { get; set; }
        public DateTime Moment { get; set; }
    }
}
