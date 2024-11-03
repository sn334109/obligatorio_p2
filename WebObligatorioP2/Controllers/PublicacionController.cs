﻿using Dominio;
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
                ViewBag.MensajeExito = "Comprar realizada correctamente";
                return RedirectToAction("ListadoPublicaciones");
            }
            catch (Exception unError)
            {
                ViewBag.error = unError.Message;
                return View();
            }

        } 
    }
}
