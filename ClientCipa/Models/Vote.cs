using System;
using System.Collections.Generic;

namespace ClientCipa.Models
{
    public partial class Vote
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int Cpf { get; set; }
        public DateTime Moment { get; set; }
    }
}
