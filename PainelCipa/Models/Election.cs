using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainelCipa.Models
{
    public class Election
    {

        public int Id { get; set; }
        public int Year { get; set; }        
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
        public bool HasFinished { get; set; }
        public bool HasStarted { get; set; }

        public Election()
        {

        }
        public Election(int id, int year, bool hasFinished, bool hasStarted)
        {
            Id = id;
            Year = year;
            HasFinished = hasFinished;
            HasStarted = hasStarted;
        }

        public void AddCandidates(Candidate candidate)
        {
            Candidates.Add(candidate);
        }

        public void RemoveCandidates(Candidate candidate)
        {
            Candidates.Remove(candidate);
        }

    }
}
