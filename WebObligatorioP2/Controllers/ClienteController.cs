using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebObligatorioP2.Controllers
{
    public class ClienteController : Controller
    {
        Sistema unSistema = Sistema.Instancia;
        public IActionResult ListadoClientes()
        {
            try
            {
                return View(unSistema.ObtenerClientes());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        public IActionResult RegistroCliente() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistroCliente(Cliente unCliente)
        {
            try
            {
                unSistema.AgregarCliente(unCliente);
                ViewBag.mensajeExito = "Usuario registrado exitosamente";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
           
        }

    }
}
