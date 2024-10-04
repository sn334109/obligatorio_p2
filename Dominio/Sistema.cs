﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//TODO: poner el id autoincremental , ULTIMO ID

namespace Dominio
{
    public class Sistema
    {
        private static Sistema instancia;
        List<Publicacion> listaPublicaciones = new List<Publicacion>();
        List<Articulo> listaArticulos = new List<Articulo>();
        List<Usuario> listaDeUsuarios = new List<Usuario>();
        //SINGLETON
        public static Sistema Instancia 
        {
            get 
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }

        public List<Articulo> ListaArticulos { get => listaArticulos; }

        private Sistema() 
        {
            PrecargaClientes();
            PrecargaUsuariosAdmin();
            PrecargaArticulos();
        }

        public List<Cliente> ListarClientes() 
        {
            List<Cliente> listadoDeClientes = new List<Cliente>();
            return listadoDeClientes;
        }

        public List<Articulo> FiltrarArticulosCategoria(string categoria) 
        {
            List<Articulo> aux = new List<Articulo>();

            foreach(Articulo unArticulo in listaArticulos) 
            {
                if (unArticulo.Categoria.ToUpper() == categoria.ToUpper()) 
                {
                    aux.Add(unArticulo);
                }
            }
            return aux;
        }
        public List<String> ListarCategorias()
        {
            List<String> aux = new List<String>();

            foreach (Articulo unArticulo in listaArticulos)
            {
                if (!(aux.Contains(unArticulo.Categoria)))
                {
                    aux.Add(unArticulo.Categoria);
                }
            }
            return aux;
        }

        public void AltaArticulo(Articulo articulo) 
        {
            listaArticulos.Add(articulo);
        }

        public List<Publicacion> ListarPublicacionesFecha(DateTime fechaInicial, DateTime fechaFinal) 
        {
            return listaPublicaciones;
        }

        //METODOS
        //filtramos administradores quedandonos con clientes
        public List<Usuario> ObtenerClientes() 
        {
            List<Usuario> aux = new List<Usuario>();
            foreach(Usuario unUsuario in listaDeUsuarios) 
            {
               if (unUsuario is Cliente) 
               {
                    aux.Add(unUsuario);
               }
            }
            return aux;
        }


        // PRECARGA DE CLIENTES
        private void PrecargaClientes() 
        {
            //prompt1 precarga
            AgregarCliente(new Cliente("Federico", "Martinez", "fede@gmail.com", "123456", 2000));
            AgregarCliente(new Cliente("Ana", "Gonzalez", "ana.gonzalez@gmail.com", "654321", 3000));
            AgregarCliente(new Cliente("Javier", "Lopez", "javier.lopez@hotmail.com", "abcdef", 1500));
            AgregarCliente(new Cliente("María", "Perez", "maria.perez@yahoo.com", "mariap123", 5000));
            AgregarCliente(new Cliente("Luis", "Ramirez", "luis.ramirez@gmail.com", "ramirez123", 3500));
            AgregarCliente(new Cliente("Carla", "Fernandez", "carla.f@hotmail.com", "carla456", 2500));
            AgregarCliente(new Cliente("Pedro", "Sanchez", "pedro.sanchez@yahoo.com", "pedrosan", 4000));
            AgregarCliente(new Cliente("Sofia", "Gutierrez", "sofia.gutierrez@gmail.com", "sg123456", 4500));
            AgregarCliente(new Cliente("Ricardo", "Diaz", "ricardo.diaz@gmail.com", "rDiaz2021", 3200));
            AgregarCliente(new Cliente("Laura", "Mendez", "laura.mendez@hotmail.com", "lauraM", 2700));
        }


        //PRECARGA ADMINISTRADORES
        private void PrecargaUsuariosAdmin()
        {
            AgregarAdmin(new Admin("Cesar", "Martinez", "cesar@gmail.com", "c123456"));
            AgregarAdmin(new Admin("Santiago", "Neira", "santi@gmail.com", "s123456"));
        }


        //PRECARGA ARTICULOS
        private void PrecargaArticulos() 
        {
            AgregarArticulo(new Articulo("Pelota de fútbol", "Equipamiento exterior", 200));
            AgregarArticulo(new Articulo("Pelota de baloncesto", "Equipamiento interior", 180));
            AgregarArticulo(new Articulo("Camiseta de running", "Ropa deportiva", 50));
            AgregarArticulo(new Articulo("Zapatillas de tenis", "Calzado deportivo", 120));
            AgregarArticulo(new Articulo("Guantes de ciclismo", "Accesorios", 25));
            AgregarArticulo(new Articulo("Raqueta de tenis", "Equipamiento exterior", 150));
            AgregarArticulo(new Articulo("Pelota de voleibol", "Equipamiento interior", 90));
            AgregarArticulo(new Articulo("Shorts de fútbol", "Ropa deportiva", 40));
            AgregarArticulo(new Articulo("Zapatillas de baloncesto", "Calzado deportivo", 130));
            AgregarArticulo(new Articulo("Botella de agua", "Accesorios", 10));
            AgregarArticulo(new Articulo("Casco de ciclismo", "Equipamiento exterior", 80));
            AgregarArticulo(new Articulo("Pantalones de yoga", "Ropa deportiva", 60));
            AgregarArticulo(new Articulo("Pelota de rugby", "Equipamiento exterior", 210));
            AgregarArticulo(new Articulo("Malla de natación", "Ropa deportiva", 45));
            AgregarArticulo(new Articulo("Zapatillas de running", "Calzado deportivo", 100));
            AgregarArticulo(new Articulo("Gorra de béisbol", "Accesorios", 20));
            AgregarArticulo(new Articulo("Red de tenis", "Equipamiento exterior", 200));
            AgregarArticulo(new Articulo("Bicicleta de montaña", "Equipamiento exterior", 900));
            AgregarArticulo(new Articulo("Balón medicinal", "Equipamiento interior", 75));
            AgregarArticulo(new Articulo("Camiseta de baloncesto", "Ropa deportiva", 55));
            AgregarArticulo(new Articulo("Rodilleras", "Accesorios", 30));
            AgregarArticulo(new Articulo("Saco de boxeo", "Equipamiento interior", 250));
            AgregarArticulo(new Articulo("Gafas de natación", "Accesorios", 15));
            AgregarArticulo(new Articulo("Zapatillas de boxeo", "Calzado deportivo", 85));
            AgregarArticulo(new Articulo("Cuerda para saltar", "Accesorios", 12));
            AgregarArticulo(new Articulo("Camiseta de tenis", "Ropa deportiva", 50));
            AgregarArticulo(new Articulo("Zapatillas de escalada", "Calzado deportivo", 140));
            AgregarArticulo(new Articulo("Rueda de abdominales", "Equipamiento interior", 35));
            AgregarArticulo(new Articulo("Raqueta de squash", "Equipamiento interior", 110));
            AgregarArticulo(new Articulo("Guantes de boxeo", "Accesorios", 55));
            AgregarArticulo(new Articulo("Chaqueta impermeable", "Ropa deportiva", 70));
            AgregarArticulo(new Articulo("Zapatillas de fútbol", "Calzado deportivo", 115));
            AgregarArticulo(new Articulo("Tabla de surf", "Equipamiento exterior", 350));
            AgregarArticulo(new Articulo("Bañador", "Ropa deportiva", 40));
            AgregarArticulo(new Articulo("Patines en línea", "Equipamiento exterior", 160));
            AgregarArticulo(new Articulo("Muñequeras", "Accesorios", 10));
            AgregarArticulo(new Articulo("Espinilleras", "Accesorios", 25));
            AgregarArticulo(new Articulo("Camiseta de ciclismo", "Ropa deportiva", 60));
            AgregarArticulo(new Articulo("Pelota de handball", "Equipamiento interior", 100));
            AgregarArticulo(new Articulo("Balón de golf", "Equipamiento exterior", 50));
            AgregarArticulo(new Articulo("Bicicleta estática", "Equipamiento interior", 500));
            AgregarArticulo(new Articulo("Zapatillas de ciclismo", "Calzado deportivo", 180));
            AgregarArticulo(new Articulo("Toalla de gimnasio", "Accesorios", 15));
            AgregarArticulo(new Articulo("Cinturón de levantamiento de pesas", "Accesorios", 35));
            AgregarArticulo(new Articulo("Zapatillas de entrenamiento", "Calzado deportivo", 90));
            AgregarArticulo(new Articulo("Camiseta térmica", "Ropa deportiva", 65));
            AgregarArticulo(new Articulo("Pesas rusas", "Equipamiento interior", 70));
            AgregarArticulo(new Articulo("Set de mancuernas", "Equipamiento interior", 120));
            AgregarArticulo(new Articulo("Banda elástica", "Accesorios", 20));
            AgregarArticulo(new Articulo("Peto de entrenamiento", "Ropa deportiva", 15));
            AgregarArticulo(new Articulo("Balón de waterpolo", "Equipamiento interior", 85));
        }

        //Metodos de creación
        public void AgregarCliente(Cliente unCliente)
        {
            try
            {
                //TODO: agregar validaciones requeridas
                listaDeUsuarios.Add(unCliente);
            }
            catch (Exception unError)
            {
                throw unError;
            }
        }

        public void AgregarAdmin(Admin unAdmin) 
        {  
            try
            {
                //TODO: agregar validaciones requeridas
                listaDeUsuarios.Add(unAdmin);
            }
            catch (Exception unError)
            {
                throw unError;
            }
        }

        
        public void AgregarArticulo(Articulo unArticulo) 
        {
            try
            {
                //TODO: agregar validaciones requeridas
                listaArticulos.Add(unArticulo);
            }
            catch (Exception unError) 
            {
                throw unError;
            }
        }


    }
}
