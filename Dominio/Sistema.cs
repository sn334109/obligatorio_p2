using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Enums;


//TODO: poner el id autoincremental , ULTIMO ID

namespace Dominio
{
    public class Sistema
    {
        private static Sistema instancia;
        List<Publicacion> listaPublicaciones = new List<Publicacion>();
        List<Articulo> listaArticulos = new List<Articulo>();
        List<Usuario> listaDeUsuarios = new List<Usuario>();
        List<Oferta> listaOfertas = new List<Oferta>();
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

            foreach (Articulo unArticulo in listaArticulos)
            {
                if (unArticulo.Categoria.ToUpper() == categoria.ToUpper())
                {
                    aux.Add(unArticulo);
                }
            }

            if (aux.Count == 0)
            {
                throw new Exception("No hay articulos en esa categoria para listar");
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
            foreach (Usuario unUsuario in listaDeUsuarios)
            {
                if (unUsuario is Cliente)
                {
                    aux.Add(unUsuario);
                }
            }

            if (aux.Count == 0)
            {
                throw new Exception("No hay clientes para listar");
            }
            return aux;
        }

        public List<Publicacion> ObtenerPublicacionesEntreFechas(DateTime fechaComienzo, DateTime fechaFin)
        {
            List<Publicacion> aux = new List<Publicacion>();

            foreach (Publicacion unaPublicacion in listaPublicaciones)
            {
                if (unaPublicacion.FechaPublicacion.Date >= fechaComienzo.Date && unaPublicacion.FechaPublicacion.Date <= fechaFin.Date)
                {
                    aux.Add(unaPublicacion);
                }
            }

            if (aux.Count == 0)
            {
                throw new Exception("No hay publicaciones para listar entre las fechas indicadas");
            }

            return aux;
        }


        // PRECARGA DE CLIENTES
        private void PrecargaClientes()
        {
            //prompt1 precarga
            //AgregarCliente(new Cliente("Federico", "Martinez", "fede@gmail.com", "123456", 2000));
            //AgregarCliente(new Cliente("Ana", "Gonzalez", "ana.gonzalez@gmail.com", "654321", 3000));
            //AgregarCliente(new Cliente("Javier", "Lopez", "javier.lopez@hotmail.com", "abcdef", 1500));
            //AgregarCliente(new Cliente("María", "Perez", "maria.perez@yahoo.com", "mariap123", 5000));
            //AgregarCliente(new Cliente("Luis", "Ramirez", "luis.ramirez@gmail.com", "ramirez123", 3500));
            //AgregarCliente(new Cliente("Carla", "Fernandez", "carla.f@hotmail.com", "carla456", 2500));
            //AgregarCliente(new Cliente("Pedro", "Sanchez", "pedro.sanchez@yahoo.com", "pedrosan", 4000));
            //AgregarCliente(new Cliente("Sofia", "Gutierrez", "sofia.gutierrez@gmail.com", "sg123456", 4500));
            //AgregarCliente(new Cliente("Ricardo", "Diaz", "ricardo.diaz@gmail.com", "rDiaz2021", 3200));
            //AgregarCliente(new Cliente("Laura", "Mendez", "laura.mendez@hotmail.com", "lauraM", 2700));
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
            AgregarArticulo(new Articulo("Pelota de fútbol", "Deportes de equipo", 200));
            AgregarArticulo(new Articulo("Pelota de baloncesto", "Deportes de equipo", 180));
            AgregarArticulo(new Articulo("Pelota de voleibol", "Deportes de equipo", 90));

            AgregarArticulo(new Articulo("Raqueta de tenis", "Deportes de raqueta", 150));
            AgregarArticulo(new Articulo("Raqueta de squash", "Deportes de raqueta", 110));
            AgregarArticulo(new Articulo("Red de tenis", "Deportes de raqueta", 200));

            AgregarArticulo(new Articulo("Zapatillas de tenis", "Calzado deportivo", 120));
            AgregarArticulo(new Articulo("Zapatillas de running", "Calzado deportivo", 100));
            AgregarArticulo(new Articulo("Zapatillas de ciclismo", "Calzado deportivo", 180));

            AgregarArticulo(new Articulo("Casco de ciclismo", "Ciclismo", 80));
            AgregarArticulo(new Articulo("Guantes de ciclismo", "Ciclismo", 25));
            AgregarArticulo(new Articulo("Camiseta de ciclismo", "Ciclismo", 60));

            AgregarArticulo(new Articulo("Bicicleta de montaña", "Aventura y aire libre", 900));
            AgregarArticulo(new Articulo("Patines en línea", "Aventura y aire libre", 160));
            AgregarArticulo(new Articulo("Tabla de surf", "Aventura y aire libre", 350));

            AgregarArticulo(new Articulo("Malla de natación", "Natacion", 45));
            AgregarArticulo(new Articulo("Gafas de natación", "Natacion", 15));
            AgregarArticulo(new Articulo("Balón de waterpolo", "Natacion", 85));

            AgregarArticulo(new Articulo("Saco de boxeo", "Deportes de combate", 250));
            AgregarArticulo(new Articulo("Guantes de boxeo", "Deportes de combate", 55));
            AgregarArticulo(new Articulo("Zapatillas de boxeo", "Deportes de combate", 85));

            AgregarArticulo(new Articulo("Cuerda para saltar", "Fitness", 12));
            AgregarArticulo(new Articulo("Pesas rusas", "Fitness", 70));
            AgregarArticulo(new Articulo("Set de mancuernas", "Fitness", 120));

            AgregarArticulo(new Articulo("Camiseta de running", "Ropa deportiva", 50));
            AgregarArticulo(new Articulo("Shorts de fútbol", "Ropa deportiva", 40));
            AgregarArticulo(new Articulo("Chaqueta impermeable", "Ropa deportiva", 70));

            AgregarArticulo(new Articulo("Rodilleras", "Proteccion y seguridad", 30));
            AgregarArticulo(new Articulo("Espinilleras", "Proteccion y seguridad", 25));
            AgregarArticulo(new Articulo("Cinturón de levantamiento de pesas", "Proteccion y seguridad", 35));

            AgregarArticulo(new Articulo("Pelota de golf", "Deportes individuales", 50));
            AgregarArticulo(new Articulo("Rueda de abdominales", "Deportes individuales", 35));
            AgregarArticulo(new Articulo("Bicicleta estática", "Deportes individuales", 500));

            AgregarArticulo(new Articulo("Toalla de gimnasio", "Accesorios deportivos", 15));
            AgregarArticulo(new Articulo("Botella de agua", "Accesorios deportivos", 10));
            AgregarArticulo(new Articulo("Banda elástica", "Accesorios deportivos", 20));

            AgregarArticulo(new Articulo("Balón medicinal", "Entrenamiento funcional", 75));
            AgregarArticulo(new Articulo("Peto de entrenamiento", "Entrenamiento funcional", 15));
            AgregarArticulo(new Articulo("Banda de resistencia", "Entrenamiento funcional", 20));

            AgregarArticulo(new Articulo("Camiseta térmica", "Ropa tecnica", 65));
            AgregarArticulo(new Articulo("Camiseta de baloncesto", "Ropa tecnica", 55));
            AgregarArticulo(new Articulo("Camiseta de tenis", "Ropa tecnica", 50));

            AgregarArticulo(new Articulo("Muñequeras", "Accesorios de entrenamiento", 10));
            AgregarArticulo(new Articulo("Gorra de béisbol", "Accesorios de entrenamiento", 20));
            AgregarArticulo(new Articulo("Cinturón de entrenamiento", "Accesorios de entrenamiento", 25));

            AgregarArticulo(new Articulo("Pelota de rugby", "Deportes de contacto", 210));
            AgregarArticulo(new Articulo("Espinilleras de rugby", "Deportes de contacto", 30));
            AgregarArticulo(new Articulo("Guantes de rugby", "Deportes de contacto", 40));

            AgregarArticulo(new Articulo("Pelota de cricket", "Deportes de bate", 120));
            AgregarArticulo(new Articulo("Bate de béisbol", "Deportes de bate", 150));
            AgregarArticulo(new Articulo("Guante de béisbol", "Deportes de bate", 100));
        }




        private void PrecargaPublicaciones() 
        {

            //10 publicaciones ventas (2 con ofertas)
            CrearPublicacion(new Venta("Ropa tecnica", Enums.EstadoPublicacion.ABIERTA, DateTime.Now, FiltrarArticulosCategoria("Ropa tecnica"), null, null, null, true));
            CrearPublicacion(new Venta("Accesorios de entrenamiento", Enums.EstadoPublicacion.ABIERTA, DateTime.Now, FiltrarArticulosCategoria("Accesorios de entrenamiento"), null, null, null, false));
            CrearPublicacion(new Venta("Deportes de contacto", Enums.EstadoPublicacion.ABIERTA, DateTime.Now, FiltrarArticulosCategoria("Deportes de contacto"), null, null, null, false));
            CrearPublicacion(new Venta("Deportes de Bate", Enums.EstadoPublicacion.ABIERTA, DateTime.Now, FiltrarArticulosCategoria("Deportes de Bate"), null, null, null, true));
            //10 publicaciones subastas (2 subastas abiertas)
            
            // CrearPublicacion()
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

        public void CrearPublicacion(Publicacion unaPublicacion)
        {
            try
            {
                listaPublicaciones.Add(unaPublicacion);
            }
            catch (Exception unError)
            {
                throw unError;
            }
        }

        public void CrearVenta(Venta unaVenta) 
        {
            listaPublicaciones.Add(unaVenta);
        }

        public void CrearSubasta(Subasta unaSubasta) 
        {
            //listaPublicaciones.Add(unaSubasta);
        }

        public void CrearOferta(Oferta unaOferta)
        {
            //listaOfertas.Add(unaOferta);
        }

    }
}
