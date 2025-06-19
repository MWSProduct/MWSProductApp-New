using Microsoft.AspNetCore.Mvc;


namespace MWSProductApp.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {

            if (username == "admin" && password == "password") 
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }
    }
}