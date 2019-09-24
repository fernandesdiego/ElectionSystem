
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel;

namespace PainelCipa.Models
{
    public class Candidate { 

        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Departamento")]
        public string Department { get; set; }
        [DisplayName("Cargo")]
        public string Role { get; set; }
        [DisplayName("Foto")]
        public string Photo { get; set; }
        [DisplayName("Eleição")]
        public virtual Election Election { get; set; }
        [DisplayName("Eleição")]
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
