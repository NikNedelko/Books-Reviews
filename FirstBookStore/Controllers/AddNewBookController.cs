using Microsoft.AspNetCore.Mvc;

namespace FirstBookStore.Controllers
{
    public class AddNewBookController : Controller
    {
        public IActionResult NewBook()
        {
            return View();
        }
    }
}