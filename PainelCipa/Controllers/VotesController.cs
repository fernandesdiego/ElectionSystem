using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainelCipa.Models;

namespace PainelCipa.Controllers
{
    [Authorize]
    public class VotesController : Controller
    {
        private readonly PainelCipaContext _context;

        public VotesController(PainelCipaContext context)
        {
            _context = context;
        }

        // GET: Votes
        public async Task<IActionResult> Index()
        {
            var painelCipaContext = _context.Vote.Include(v => v.Candidate).Include(v => v.Candidate.Election);
            ViewData["Election"] = new SelectList(_context.Election, "Year", "Year");
            return View(await painelCipaContext.ToListAsync());
        }

        // GET: Votes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .Include(v => v.Candidate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // GET: Votes/Create
        public IActionResult Create()
        {
            ViewData["CandidateID"] = new SelectList(_context.Candidate, "Id", "Id");
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CPF,CandidateID,Moment")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateID"] = new SelectList(_context.Candidate, "Id", "Id", vote.CandidateID);
            return View(vote);
        }

        // GET: Votes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }
            ViewData["CandidateID"] = new SelectList(_context.Candidate, "Id", "Id", vote.CandidateID);
            return View(vote);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CPF,CandidateID,Moment")] Vote vote)
        {
            if (id != vote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoteExists(vote.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateID"] = new SelectList(_context.Candidate, "Id", "Id", vote.CandidateID);
            return View(vote);
        }

        // GET: Votes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .Include(v => v.Candidate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vote = await _context.Vote.FindAsync(id);
            _context.Vote.Remove(vote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoteExists(int id)
        {
            return _context.Vote.Any(e => e.Id == id);
        }

        [HttpPost]
        public IActionResult Export(int electionYear)
        {
            string[] headers = new string[] { "Id", "Eleitor", "Candidato", "Horario" };
            StringBuilder sb = new StringBuilder();

            //SELECT vote.Id, candidate.Name, election.Year from vote JOIN candidate ON vote.CandidateID = candidate.Id JOIN election ON candidate.ElectionID = election.Id where Election.Id = $var

            var data = from v in _context.Vote where v.Candidate.Election.Year == electionYear select new { v.Id, v.CPF, v.Candidate.Name, v.Moment };


            //var data = from v in _context.Vote
            //           where v.Moment.Year == election.Year
            //           select new
            //           {
            //               v.CPF,
            //               v.Candidate.Name,
            //               v.Moment
            //           };
            var list = data.ToList();
            foreach (var item in list)
            {
                sb.AppendFormat("{0},{1},{2},{3}\r\n", item.Id, item.CPF, item.Name, item.Moment);
            }

            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", headers)}\r\n{sb.ToString()}");
            return File(buffer, "text/csv", $"CIPA-Resultado.csv");
        }
    }
}
