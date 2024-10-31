﻿using Dominio;
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
            //unCliente ??= new Cliente();
            try
            {
                unSistema.AgregarCliente(unCliente);
                ViewBag.mensajeExito = "Usuario registrado exitosamente";
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(unCliente);
        }

    }
}
