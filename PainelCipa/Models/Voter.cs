using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PainelCipa.Models
{
    public class Voter
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public Election Election { get; set; }
        public bool HasVoted { get; set; }

        public Voter()
        {

        }

        public Voter(int id, string cPF, Election cipa, bool hasVoted)
        {
            Id = id;
            CPF = cPF;
            Election = cipa;
            HasVoted = hasVoted;
        }
    }
}
