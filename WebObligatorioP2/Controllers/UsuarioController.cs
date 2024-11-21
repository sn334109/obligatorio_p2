using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebObligatorioP2.Controllers
{
    public class UsuarioController : Controller
    {
        Sistema unSistema = Sistema.Instancia;
        public IActionResult VistaUsuario(string email)
        {
            Usuario? unUsuario = unSistema.DevolverUsuario(email);
            ViewBag.Rol = HttpContext.Session.GetString("Rol");
            return View(unUsuario);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string clave)
        {
            Usuario? unUsuario = unSistema.DevolverUsuario(email, clave);
            if (unUsuario != null)
            {
                //crear sesion
                HttpContext.Session.SetString("Usuario", unUsuario.Email);

                if (unUsuario is Cliente cliente)
                {
                    HttpContext.Session.SetString("Rol", "Cliente");
                    //HttpContext.Session.SetString("SaldoDisponible", cliente.SaldoDisponible.ToString()); // Logica para mostrar el SaldoDisponible
                }
                else if (unUsuario is Admin)
                {
                    HttpContext.Session.SetString("Rol", "Admin");
                }
                else
                {
                    // Manejo de error si el usuario no es ni Cliente ni Admin
                    ViewBag.Mensaje = "El usuario no tiene un rol asignado.";
                    return View("Login");
                }
                return RedirectToAction("VistaUsuario", new { email = unUsuario.Email });
            }
            else
            {
                ViewBag.Mensaje = "Datos incorrectos, intentalo de nuevo";
                return View();
            }

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        public IActionResult ListadoSubastas()
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
                List<Subasta> lista = unSistema.ObtenerListaSubastas();
                lista.Sort();
                return View(lista);
            }
            catch (Exception unError)
            {
                TempData["error"] = unError;
                return View();
            }
        }

        public IActionResult CerrarSubasta() { return View(); }


        [HttpPost]
        public IActionResult CerrarSubasta(int idSubasta) 
        {
            string emailUsuarioActual = HttpContext.Session.GetString("Usuario");
            try
            {
                unSistema.CerrarSubasta(idSubasta, emailUsuarioActual);
                TempData["mensajeExito"] = "Subasta finalizada con éxito";
                return RedirectToAction("ListadoSubastas");
            }
            catch (Exception unError)
            {
                TempData["error"] = unError.Message;
                return RedirectToAction("ListadoSubastas");
            }
            
        }
    }
}
