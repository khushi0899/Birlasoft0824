using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medicare.Data;
using Medicare.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Medicare.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize]
    public class ConsultationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
 
        public ConsultationsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Manager/Consultations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consultations.Include(c => c.DrList);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Manager/Consultations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultations
                .Include(c => c.DrList)
                .FirstOrDefaultAsync(m => m.ConsultationId == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // GET: Manager/Consultations/Create
        public IActionResult Create()
        {
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "DrName");
            return View();
        }

        // POST: Manager/Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsultationId,PatientName,MobileNo,ConsultationStatus,DrId")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                //// Get the information of the currently logged in User
                //var userObj = await _userManager.GetUserAsync(this.User);
                //consultation.UserId = userObj.Id;                               // assign the Id of the current User in the Model.

                _context.Add(consultation);


                //var myConsultations = _context.Consultations.Where(c => c.UserId == userObj.Id);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "DrName", consultation.DrId);
            return View(consultation);
        }

        // GET: Manager/Consultations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultations.FindAsync(id);
            if (consultation == null)
            {
                return NotFound();
            }
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "ClinicAddress", consultation.DrId);
            return View(consultation);
        }

        // POST: Manager/Consultations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsultationId,PatientName,MobileNo,ConsultationStatus,DrId")] Consultation consultation)
        {
            if (id != consultation.ConsultationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultationExists(consultation.ConsultationId))
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
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "ClinicAddress", consultation.DrId);
            return View(consultation);
        }

        // GET: Manager/Consultations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultations
                .Include(c => c.DrList)
                .FirstOrDefaultAsync(m => m.ConsultationId == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // POST: Manager/Consultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultation = await _context.Consultations.FindAsync(id);
            _context.Consultations.Remove(consultation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultationExists(int id)
        {
            return _context.Consultations.Any(e => e.ConsultationId == id);
        }


        public IActionResult ConsultGynaecologist()
        {
            ViewData["DrId"] = new SelectList(_context.DrList.Where(e => e.Specialist.SpecialityName == "Gynaecologist"), "DrId", "DrName");
            return View();
        }

        // POST: Manager/Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultGynaecologist([Bind("ConsultationId,PatientName,MobileNo,ConsultationStatus,DrId")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "DrId", consultation.DrId);
            return View(consultation);
        }


        public IActionResult ConsultDermatologist()
        {
            ViewData["DrId"] = new SelectList(_context.DrList.Where(e => e.Specialist.SpecialityName == "Dermatologist"), "DrId", "DrName");
            return View();
        }

        // POST: Manager/Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultDermatologist([Bind("ConsultationId,PatientName,MobileNo,ConsultationStatus,DrId")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "DrId", consultation.DrId);
            return View(consultation);
        }
        public IActionResult ConsultGeneralPhysician()
        {
            ViewData["DrId"] = new SelectList(_context.DrList.Where(e => e.Specialist.SpecialityName == "General Physician"), "DrId", "DrName");
            return View();
        }

        // POST: Manager/Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultGeneralPhysician([Bind("ConsultationId,PatientName,MobileNo,ConsultationStatus,DrId")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "DrId", consultation.DrId);
            return View(consultation);
        }







        public IActionResult ConsultGastro()
        {
            ViewData["DrId"] = new SelectList(_context.DrList.Where(e => e.Specialist.SpecialityName == "Gastroenterologist"), "DrId", "DrName");
            return View();
        }

        // POST: Manager/Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultGastro([Bind("ConsultationId,PatientName,MobileNo,ConsultationStatus,DrId")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "DrId", consultation.DrId);
            return View(consultation);
        }

        public IActionResult ConsultPediatric()
        {
            ViewData["DrId"] = new SelectList(_context.DrList.Where(e => e.Specialist.SpecialityName == "Pediatric"), "DrId", "DrName");
            return View();
        }

        // POST: Manager/Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultPediatric([Bind("ConsultationId,PatientName,MobileNo,ConsultationStatus,DrId")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "DrId", consultation.DrId);
            return View(consultation);
        }




        public IActionResult ConsultUrologist()
        {
            ViewData["DrId"] = new SelectList(_context.DrList.Where(e => e.Specialist.SpecialityName == "Urologist"), "DrId", "DrName");
            return View();
        }

        // POST: Manager/Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultUrologist([Bind("ConsultationId,PatientName,MobileNo,ConsultationStatus,DrId")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "DrId", consultation.DrId);
            return View(consultation);
        }


        public IActionResult ConsultPsychiatry()
        {
            ViewData["DrId"] = new SelectList(_context.DrList.Where(e => e.Specialist.SpecialityName == "Psychiatry"), "DrId", "DrName");
            return View();
        }

        // POST: Manager/Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultPsychiatry([Bind("ConsultationId,PatientName,MobileNo,ConsultationStatus,DrId")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrId"] = new SelectList(_context.DrList, "DrId", "DrId", consultation.DrId);
            return View(consultation);
        }

    }
}
