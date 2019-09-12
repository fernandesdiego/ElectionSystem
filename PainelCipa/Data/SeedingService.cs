using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainelCipa.Models;

namespace PainelCipa.Data
{
    public class SeedingService
    {
        public PainelCipaContext _context { get; set; }

        public SeedingService(PainelCipaContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Cipa.Any() || _context.Candidate.Any())
            {
                return; //db already populated
            }
            else
            {
                Election c1 = new Election(1, 2019, false, true);
                Election c2 = new Election(2, 2024, false, true);

                Candidate ca1 = new Candidate(1, "DIEGO", "TI", "SUPORTE", null, c1);
                Candidate ca2 = new Candidate(2, "BELCHIOR", "TI", "ASSISTENTE", null, c1);

                Candidate ca3 = new Candidate(3, "TRATORZIM", "TI", "GAROTO DE PROGRAMA", null, c2);

                Voter vo1 = new Voter(1, "093672119", c1, true);
                Voter vo2 = new Voter(2, "123456789", c1, true);
                Voter vo3 = new Voter(3, "987654321", c2, true);

                Vote v1 = new Vote(1, vo1, ca1);
                Vote v2 = new Vote(2, vo2, ca1);
                Vote v3 = new Vote(3, vo3, ca3);

                _context.Cipa.AddRange(c1, c2);
                _context.Candidate.AddRange(ca1, ca2, ca3);
                _context.Voter.AddRange(vo1, vo2, vo3);
                _context.Vote.AddRange(v1, v2);

                _context.SaveChanges();
            }
        }

    }
}
