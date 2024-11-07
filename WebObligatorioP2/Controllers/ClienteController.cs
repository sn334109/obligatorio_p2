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

        public IActionResult MiCuenta()
        {
            string emailUsuarioActual = HttpContext.Session.GetString("Usuario");
            return View(unSistema.ObtenerUsuarioPorEmail(emailUsuarioActual));
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
                TempData["mensajeExito"] = "Usuario registrado exitosamente, ahora inicia sesión";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
           
        }

        public IActionResult CargarSaldo() 
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult CargarSaldo(decimal montoSaldo)
        //{
        //    try
        //    {
        //        string emailUsuarioActual = HttpContext.Session.GetString("Usuario");
        //        unSistema.CargarSaldo(emailUsuarioActual, montoSaldo);
        //        RedirectToAction("MiCuenta");
        //    }
        //    catch (Exception unError) 
        //    {
        //        ViewBag.error = unError.Message;
        //        return View();
        //    }

        //}


    }
}
