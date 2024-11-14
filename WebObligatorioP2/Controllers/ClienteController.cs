using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebObligatorioP2.Controllers
{
    public class ClienteController : Controller
    {
        Sistema unSistema = Sistema.Instancia;


        public IActionResult ListadoClientes()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return Redirect("/Usuario/Login");
            }
            else
            {
                if (HttpContext.Session.GetString("Rol") == "Cliente") 
                {
                    return RedirectToAction("AccessDenied", "Error");
                }
            }

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
            List<Publicacion> lista = unSistema.PublicacionesPorUsuario(emailUsuarioActual);
            ViewBag.listadoPublicacionesPorUsuario = lista;
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

        [HttpPost]
        public IActionResult CargarSaldo(decimal montoSaldo)
        {
            try
            {
                string emailUsuarioActual = HttpContext.Session.GetString("Usuario");
                unSistema.CargarSaldo(emailUsuarioActual, montoSaldo);
                TempData["mensajeExito"] = "Su saldo fue incrementado correctamente";
                return RedirectToAction("MiCuenta");
            }
            catch (Exception ex)
            {
                TempData["mensajeExito"] = "!Debe ingresar un valor positivo¡ Intentelo nuevamente.";
                return RedirectToAction("MiCuenta");
            }

        }


    }
}
