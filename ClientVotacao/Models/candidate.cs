using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ClientVotacao.Models
{
    [Table("Candidate")]
    public partial class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string Photo { get; set; }
        public Uri PhotoUri
        {
            get
            {                
                return new Uri("http://pesquisacipa.vikstarsp.br/Image/" + Photo, UriKind.Absolute);                
            }
        }

        public int ElectionID { get; set; }
        public virtual Election Election { get; set; }
        public Candidate()
        {

        }

        public Candidate(int id, string name, string department, string role, string photo, int electionID, Election election)
        {
            Id = id;
            Name = name;
            Department = department;
            Role = role;
            Photo = photo;
            ElectionID = electionID;
            Election = election;
        }
    }
}
