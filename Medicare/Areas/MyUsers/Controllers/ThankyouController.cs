using Microsoft.AspNetCore.Mvc;

namespace Medicare.Areas.User.Controllers
{
    public class ThankyouController : Controller
    {
        [Area("MyUsers")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
