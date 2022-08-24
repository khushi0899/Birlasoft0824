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
    public class DrCitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrCitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manager/DrCities
        public async Task<IActionResult> Index()
        {
            return View(await _context.DrCity.ToListAsync());
        }

        // GET: Manager/DrCities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drCity = await _context.DrCity
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (drCity == null)
            {
                return NotFound();
            }

            return View(drCity);
        }

        // GET: Manager/DrCities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manager/DrCities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName")] DrCity drCity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drCity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drCity);
        }

        // GET: Manager/DrCities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drCity = await _context.DrCity.FindAsync(id);
            if (drCity == null)
            {
                return NotFound();
            }
            return View(drCity);
        }

        // POST: Manager/DrCities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,CityName")] DrCity drCity)
        {
            if (id != drCity.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drCity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrCityExists(drCity.CityId))
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
            return View(drCity);
        }

        // GET: Manager/DrCities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drCity = await _context.DrCity
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (drCity == null)
            {
                return NotFound();
            }

            return View(drCity);
        }

        // POST: Manager/DrCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drCity = await _context.DrCity.FindAsync(id);
            _context.DrCity.Remove(drCity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrCityExists(int id)
        {
            return _context.DrCity.Any(e => e.CityId == id);
        }
    }
}
