using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using suitcase.Data;
using suitcase.Models;


namespace suitcase.Controllers
{
    public class PropController : Controller
    {
        private readonly Context _context;

        public PropController(Context context)
        {
            _context = context;
        }

        // GET: Prop
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["StoreageLocactionSortParm"] = sortOrder == "StorageLocation" ? "StorageLocation_desc" : "StorageLocation";
            ViewData["CurrentFilter"] = searchString;

            if(searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var props = from s in _context.Props
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                props = props.Where(s => s.StorageLocation.Contains(searchString) || s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    props = props.OrderByDescending(s => s.Name);
                    break;
                case "StorageLocation":
                    props = props.OrderBy(s => s.StorageLocation);
                    break;
                case "StorageLocation_desc":
                    props = props.OrderByDescending(s => s.StorageLocation);
                    break;
                default:
                    props = props.OrderBy(s => s.StorageLocation);
                    break;
            }

            int pageSize = 10;

            return View(await PaginatedList<Prop>.CreateAsync(props.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Prop/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prop = await _context.Props
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prop == null)
            {
                return NotFound();
            }

            return View(prop);
        }

        // GET: Prop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropId,StorageLocation,Id,Name")] Prop prop)
        {
            if (ModelState.IsValid)
            {
                prop.Id = Guid.NewGuid();
                _context.Add(prop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ViewData["ActName"] = new SelectList(_context.Acts, "Name", "Name", prop.ActProps);
            return View(prop);
        }

        // GET: Prop/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prop = await _context.Props.FindAsync(id);
            if (prop == null)
            {
                return NotFound();
            }
            return View(prop);
        }

        // POST: Prop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PropId,StorageLocation,Id,Name")] Prop prop)
        {
            if (id != prop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropExists(prop.Id))
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
            return View(prop);
        }

        // GET: Prop/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prop = await _context.Props
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prop == null)
            {
                return NotFound();
            }

            return View(prop);
        }

        // POST: Prop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var prop = await _context.Props.FindAsync(id);
            _context.Props.Remove(prop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropExists(Guid id)
        {
            return _context.Props.Any(e => e.Id == id);
        }
    }
}
