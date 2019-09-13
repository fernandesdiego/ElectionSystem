using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainelCipa.Data.FileManager;
using PainelCipa.Models;
using PainelCipa.ViewModel;

namespace PainelCipa.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly PainelCipaContext _context;
        private IFileManager _fileManager;

        public CandidatesController(PainelCipaContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            var painelCipaContext = _context.Candidate.Include(c => c.Election);
            return View(await painelCipaContext.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate
                .Include(c => c.Election)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidate == null)
            {
                return NotFound();
            }

            ViewData["ElectionID"] = new SelectList(_context.Election, "Id", "Year", candidate.ElectionID);
            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            ViewData["ElectionID"] = new SelectList(_context.Election, "Id", "Year");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Department,Role,Photo,ElectionID")] CandidateViewModel candidateViewModel)
        {
            Candidate candidate = new Candidate()
            {
                Id = candidateViewModel.Id,
                Name = candidateViewModel.Name,
                Department = candidateViewModel.Department,
                Role = candidateViewModel.Role,
                Photo = await _fileManager.SaveImage(candidateViewModel.Photo),
                ElectionID = candidateViewModel.ElectionID
            };

            if (ModelState.IsValid)
            {
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ElectionID"] = new SelectList(_context.Election, "Id", "Year", candidate.ElectionID);
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            ViewData["ElectionID"] = new SelectList(_context.Election, "Id", "Year", candidate.ElectionID);
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Department,Role,Photo,ElectionID")] CandidateViewModel candidateViewModel)
        {
            Candidate candidate = new Candidate()
            {
                Id = candidateViewModel.Id,
                Name = candidateViewModel.Name,
                Department = candidateViewModel.Department,
                Role = candidateViewModel.Role,
                Photo = await _fileManager.SaveImage(candidateViewModel.Photo),
                ElectionID = candidateViewModel.ElectionID
            };

            if (id != candidate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.Id))
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
            ViewData["ElectionID"] = new SelectList(_context.Election, "Id", "Year", candidate.ElectionID);
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate
                .Include(c => c.Election)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _context.Candidate.FindAsync(id);
            _context.Candidate.Remove(candidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidate.Any(e => e.Id == id);
        }

        [HttpGet("/image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}
