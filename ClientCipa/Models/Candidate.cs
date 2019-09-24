using System;
using System.Collections.Generic;

namespace ClientCipa.Models
{
    public partial class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string Photo { get; set; }
        public int ElectionId { get; set; }
    }
}
