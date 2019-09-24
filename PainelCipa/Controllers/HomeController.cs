using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PainelCipa.Models;
using PainelCipa.Models.ViewModels;

namespace PainelCipa.Controllers
{

    public class HomeController : Controller
    {
        private readonly PainelCipaContext _context;

        public HomeController(PainelCipaContext context)
        {
            _context = context;

        }        
        public async Task<IActionResult> Index()
        {
            var painelCipaContext = _context.Election.Include(c => c.Candidates);
            return View(await painelCipaContext.ToListAsync());            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
