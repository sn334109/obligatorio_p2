using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebObligatorioP2.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema unSistema = Sistema.Instancia;
        public IActionResult ListadoPublicaciones()
        {
            try
            {
                string emailUsuarioActual = HttpContext.Session.GetString("Usuario"); 
                Cliente cliente = unSistema.ObtenerUsuarioPorEmail(emailUsuarioActual); 
                int clienteId = cliente.Id;
                ViewBag.ClienteId = clienteId;

                return View(unSistema.ObtenerPublicaciones());
            }
            catch (Exception unError)
            {
                ViewBag.error = unError.Message;
                return View();
            }
        }
        public IActionResult RealizarCompra()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RealizarCompra(int idPublicacion)
        {
            string emailUsuarioActual = HttpContext.Session.GetString("Usuario");

            try
            {
                unSistema.RealizarCompra(idPublicacion, emailUsuarioActual);
                TempData["MensajeExito"] = "Compra realizada correctamente";
                return RedirectToAction("ListadoPublicaciones");
            }
            catch (Exception unError)
            {
                TempData["Error"] = unError.Message; 
                return RedirectToAction("ListadoPublicaciones"); // Redirige a la misma vista en caso de error
            }

        }

        public IActionResult RealizarOferta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RealizarOferta(int idPublicacion, decimal valorOferta) {
            string emailUsuarioActual = HttpContext.Session.GetString("Usuario");
            
            try
            {
                unSistema.RealizarOferta(idPublicacion, emailUsuarioActual, valorOferta);
                TempData["MensajeExito"] = $"Oferta de ${valorOferta} realizada correctamente";
                return RedirectToAction("ListadoPublicaciones");
            }
            catch (Exception unError)
            {
                TempData["Error"] = unError.Message;
                return RedirectToAction("ListadoPublicaciones"); // Redirige a la misma vista en caso de error
            }
        
        }



    }
}
