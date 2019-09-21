using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PainelCipa.Models;

namespace PainelCipa.Models.ViewModels
{
    public class CandidateViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }                             
        public string Department { get; set; }                       
        public string Role { get; set; }                             
        public IFormFile Photo { get; set; }                         
        public virtual Election Election { get; set; }               
        public int ElectionID { get; set; }
        public ICollection<Vote> Votes { get; set; }

    }
}
