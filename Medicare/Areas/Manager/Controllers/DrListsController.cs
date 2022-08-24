using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medicare.Data;
using Medicare.Models;

namespace Medicare.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class DrListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manager/DrLists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DrList.Include(d => d.DrCity).Include(d => d.Specialist);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Manager/DrLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drList = await _context.DrList
                .Include(d => d.DrCity)
                .Include(d => d.Specialist)
                .FirstOrDefaultAsync(m => m.DrId == id);
            if (drList == null)
            {
                return NotFound();
            }

            return View(drList);
        }

        // GET: Manager/DrLists/Create
        public IActionResult Create()
        {
            ViewData["ClinicCity"] = new SelectList(_context.DrCity, "CityId", "CityName");
            ViewData["SpecialistId"] = new SelectList(_context.Specialists, "SpecialityId", "SpecialityDescription");
            return View();
        }

        // POST: Manager/DrLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrId,DrName,DrQualification,DrSpecialities,DrDescription,ClinicCity,ClinicAddress,PhoneNumber,DrAvailability,DrFee,ImageUrl,SpecialistId")] DrList drList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicCity"] = new SelectList(_context.DrCity, "CityId", "CityName", drList.ClinicCity);
            ViewData["SpecialistId"] = new SelectList(_context.Specialists, "SpecialityId", "SpecialityDescription", drList.SpecialistId);
            return View(drList);
        }

        // GET: Manager/DrLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drList = await _context.DrList.FindAsync(id);
            if (drList == null)
            {
                return NotFound();
            }
            ViewData["ClinicCity"] = new SelectList(_context.DrCity, "CityId", "CityName", drList.ClinicCity);
            ViewData["SpecialistId"] = new SelectList(_context.Specialists, "SpecialityId", "SpecialityDescription", drList.SpecialistId);
            return View(drList);
        }

        // POST: Manager/DrLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrId,DrName,DrQualification,DrSpecialities,DrDescription,ClinicCity,ClinicAddress,PhoneNumber,DrAvailability,DrFee,ImageUrl,SpecialistId")] DrList drList)
        {
            if (id != drList.DrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrListExists(drList.DrId))
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
            ViewData["ClinicCity"] = new SelectList(_context.DrCity, "CityId", "CityName", drList.ClinicCity);
            ViewData["SpecialistId"] = new SelectList(_context.Specialists, "SpecialityId", "SpecialityDescription", drList.SpecialistId);
            return View(drList);
        }

        // GET: Manager/DrLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drList = await _context.DrList
                .Include(d => d.DrCity)
                .Include(d => d.Specialist)
                .FirstOrDefaultAsync(m => m.DrId == id);
            if (drList == null)
            {
                return NotFound();
            }

            return View(drList);
        }

        // POST: Manager/DrLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drList = await _context.DrList.FindAsync(id);
            _context.DrList.Remove(drList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrListExists(int id)
        {
            return _context.DrList.Any(e => e.DrId == id);
        }

        public async Task<IActionResult> UserIndex()
        {
            var applicationDbContext = _context.DrList.Include(d => d.DrCity).Include(d => d.Specialist);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Manager/DrLists/Details/5
        public async Task<IActionResult> UserViewDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drList = await _context.DrList
                .Include(d => d.DrCity)
                .Include(d => d.Specialist)
                .FirstOrDefaultAsync(m => m.DrId == id);
            if (drList == null)
            {
                return NotFound();
            }

            return View(drList);
        }
    }
}
