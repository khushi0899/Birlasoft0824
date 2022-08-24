using Medicare.Areas.DisplayData.ViewModels;
using Medicare.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicare.Areas.DisplayData.Controllers
{
    [Area("DisplayData")]
    public class SearchDrController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchDrController(ApplicationDbContext context)
        {
            _context = context;
        }
        public  IActionResult Index()
        {

            List<SelectListItem> drCity = new List<SelectListItem>();

            drCity.Add(new SelectListItem { Selected = true, Value = "", Text = "--Search Dr In Your City--" });
            drCity.AddRange(new SelectList(_context.DrCity, "CityId", "CityName"));

            ViewData["CityId"] = drCity.ToArray();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("CityId")] SearchDrViewModel model)
        {
            var items = _context.DrList.Where(m => m.ClinicCity == model.CityId);
            model.DrList = items.ToList();
            ViewData["CityId"] = new SelectList(_context.DrCity, "CityId", "CityName");


            return View("Index", model);
        }
    }
}
