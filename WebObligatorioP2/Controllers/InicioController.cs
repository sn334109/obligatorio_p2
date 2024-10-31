using Microsoft.AspNetCore.Mvc;

namespace WebObligatorioP2.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
