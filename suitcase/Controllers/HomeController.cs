using System.ComponentModel.Design;
using System;
using System.Threading.Tasks.Dataflow;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using suitcase.Models;
using suitcase.Data;
using suitcase.Models.SetlistViewModels;


namespace suitcase.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> Setlist()
        {
            IQueryable<SetlistGroup> data = 
            from Act in _context.Acts
            group Act by Act.Performance.Name into actGroup
            select new SetlistGroup()
            {
                Act.Performance.Name = actGroup.Key,
                Act.Name = actGroup.Single,
                Act.ActProps = actGroup.ToList
            };        
            return ViewComponent(await data.AsNoTracking().ToListAsync());

        }
    }
}
