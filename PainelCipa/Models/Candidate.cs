using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PainelCipa.Models
{
    public class Candidate { 

        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
         
        public string Photo { get; set; }
        public virtual Election Election { get; set; }
        public int ElectionID { get; set; }
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();

        public Candidate()
        {

        }
        public Candidate(int id, string name, string department, string role, string photo, Election election)
        {
            Id = id;
            Name = name;
            Department = department;
            Role = role;
            Photo = photo;
            Election = election;
        }
    }
}
