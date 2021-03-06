﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PainelCipa.Models
{
    public class Election
    {

        public int Id { get; set; }
        [DisplayName("Ano")]
        public int Year { get; set; }        
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
        [DisplayName("Finalizada")]
        public bool HasFinished { get; set; }
        [DisplayName("Iniciada")]
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
