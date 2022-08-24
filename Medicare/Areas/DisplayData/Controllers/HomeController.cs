using Medicare.Areas.DisplayData.ViewModels;
using Medicare.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Medicare.Areas.DisplayData.Controllers
{
    [Area("DisplayData")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<SelectListItem> categories = new List<SelectListItem>();

            categories.Add(new SelectListItem { Selected = true, Value = "", Text = "--All Categories--" });
            categories.AddRange(new SelectList(_context.Categories, "ProductCategoryId", "ProductCategoryName"));


            //ViewBag.Categories = _context.Categories.ToList();
            ViewData["ProductCategoryId"] = categories.ToArray();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("ProductCategoryId")] DisplayDataViewModel model)
        {
            var items = _context.Products.Where(m => m.ProductCategoryId == model.ProductCategoryId);
            model.Products = items.ToList();
            ViewData["ProductCategoryId"] = new SelectList(_context.Categories, "ProductCategoryId", "ProductCategoryName");


            return View("Index", model);
            }

            //}

            //public IActionResult Index()
            //{
            //    // Populate the data for the drop-down select list
            //    List<SelectListItem> categories = new List<SelectListItem>();
            //    categories.Add(new SelectListItem { Selected = true, Value = "", Text = "-- select a category --" });
            //    categories.AddRange(new SelectList(_context.Categories, "ProductCategoryId", "ProductCategoryName"));
            //    ViewData["CategoryId"] = categories.ToArray();

            //    return View();
            //}

            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public IActionResult Index([Bind("CategoryId")] DisplayDataViewModel model)
            //{
            //    // Retrieve the Menu Items for the selected category
            //    var items = _context.Products.Where(m => m.ProductCategoryId == model.ProductCategoryId);

            //    // Populate the data into the viewmodel object
            //    model.Products = items.ToList();

            //    // Populate the data for the drop-down select list

            //    ViewData["ProductCategoryId"] = new SelectList(_context.Categories, "ProductCategoryId", "ProductCategoryName");


            //          return View("Index", model);
            //}
        }
}
