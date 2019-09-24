using System;
using System.Collections.Generic;

namespace ClientCipa.Models
{
    public partial class Election
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public bool HasFinished { get; set; }
        public bool HasStarted { get; set; }
    }
}
