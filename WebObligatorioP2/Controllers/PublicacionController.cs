﻿using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebObligatorioP2.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema unSistema = Sistema.Instancia;
        public IActionResult ListadoPublicaciones()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return Redirect("/Usuario/Login");
            }
            else
            {
                if (HttpContext.Session.GetString("Rol") =="Admin")
                {
                    return RedirectToAction("AccessDenied", "Error");
                }
            }
            try
            {
                string emailUsuarioActual = HttpContext.Session.GetString("Usuario"); 
                Cliente cliente = unSistema.ObtenerUsuarioPorEmail(emailUsuarioActual); 
                int clienteId = cliente.Id;
                ViewBag.ClienteId = clienteId;
                ViewBag.clienteObjetoParaSaldo = cliente;
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
            //Cliente clienteActualizado = unSistema.ObtenerUsuarioPorEmail(emailUsuarioActual); // Logica para mostrar el SaldoDisponible
            //HttpContext.Session.SetString("SaldoDisponible", clienteActualizado.SaldoDisponible.ToString());
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
