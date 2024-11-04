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

                //HttpContext.Session.SetString("Rol", "Cliente");
                if (unUsuario is Cliente)
                {
                    HttpContext.Session.SetString("Rol", "Cliente");
                }
                else
                {
                    HttpContext.Session.SetString("Rol", "Admin");
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

    }
}
