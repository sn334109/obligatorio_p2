using Microsoft.AspNetCore.Mvc;

namespace WebObligatorioP2.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
