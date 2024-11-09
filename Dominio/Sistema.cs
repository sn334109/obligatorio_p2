using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Enums;


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

        //Precarga de Datos
        private Sistema()
        {
            PrecargaClientes();
            PrecargaUsuariosAdmin();
            PrecargaArticulos();
            PrecargaPublicaciones();
        }


        //Listar Articulos segun la Categoria brindada
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

        //Para el metodo de listarArticulosPorCategoria, Necesitamos una Lista de categorias para poder mostrar en program.
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
            articulo.Validar();
            listaArticulos.Add(articulo);
        }

        //METODOS UTILITARIOS
        //Identificamos los usuarios que son Clientes
        public List<Usuario> ObtenerClientes()
        {
            List<Usuario> aux = new List<Usuario>();
            foreach (Usuario unUsuario in listaDeUsuarios)
            {
                if (unUsuario is Cliente cliente)
                {
                    aux.Add(cliente);
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

        public List<Publicacion> ObtenerPublicaciones()
        {
            if (listaPublicaciones.Count == 0)
            {
                throw new Exception("No hay publicaciones para listar");
            }

            return listaPublicaciones;
        }


        // PRECARGA DE ENTIDADES CONTROLADAS POR SISTEMA
        //Precarga de Clientes
        private void PrecargaClientes()
        {
            AgregarCliente(new Cliente("Federico", "Martinez", "fede@gmail.com", "12345678", 2000));
            AgregarCliente(new Cliente("Ana", "Gonzalez", "ana.gonzalez@gmail.com", "87654321", 3000));
            AgregarCliente(new Cliente("Javier", "Lopez", "javier.lopez@hotmail.com", "abcdef123", 1500));
            AgregarCliente(new Cliente("María", "Perez", "maria.perez@yahoo.com", "mariap123", 5000));
            AgregarCliente(new Cliente("Luis", "Ramirez", "luis.ramirez@gmail.com", "ramirez123", 3500));
            AgregarCliente(new Cliente("Carla", "Fernandez", "carla.f@hotmail.com", "carla4561111", 2500));
            AgregarCliente(new Cliente("Pedro", "Sanchez", "pedro.sanchez@yahoo.com", "pedrosan11111", 4000));
            AgregarCliente(new Cliente("Sofia", "Gutierrez", "sofia.gutierrez@gmail.com", "sg123456111", 4500));
            AgregarCliente(new Cliente("Ricardo", "Diaz", "ricardo.diaz@gmail.com", "rDiaz202111", 3200));
            AgregarCliente(new Cliente("Laura", "Mendez", "laura.mendez@hotmail.com", "lauraM1111111", 2700));
        }


        //Precarga Administradores
        private void PrecargaUsuariosAdmin()
        {
            AgregarAdmin(new Admin("Cesar", "Martinez", "cesar@gmail.com", "c123456"));
            AgregarAdmin(new Admin("Santiago", "Neira", "santi@gmail.com", "s123456"));
        }


        //Precarga Articulos
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

        //METODO PARA CREAR LISTAS DE OFERTAS
        Random random = new Random();
        public List<Oferta> CrearListaDeOfertas()
        {
            List<int> idUsados = new List<int>();
            List<Oferta> aux = new List<Oferta>();

            int contadorRandom = 0;

            while (contadorRandom < 3)
            {
                int idAleatorio = random.Next(1, 11);
                if (!idUsados.Contains(idAleatorio))
                {
                    idUsados.Add(idAleatorio);

                    contadorRandom++;
                    Oferta nuevaOferta = new Oferta(ObtenerClientePorId(idAleatorio), (500 * idAleatorio + 100), DateTime.Now);
                    aux.Add(nuevaOferta);
                }
            }
            return aux;
        }

        //PRECARGA PUBLICACIONES VENTAS Y SUBASTAS
        private void PrecargaPublicaciones()
        {
            //VENTAS (2 CON OFERTAS)
            CrearPublicacion(new Venta("Ropa tecnica", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-9), FiltrarArticulosCategoria("Ropa tecnica"), null, null, null, true));
            CrearPublicacion(new Venta("Accesorios de entrenamiento", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-8), FiltrarArticulosCategoria("Accesorios de entrenamiento"), null, null, null, false));
            CrearPublicacion(new Venta("Deportes de contacto", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-7), FiltrarArticulosCategoria("Deportes de contacto"), null, null, null, false));
            CrearPublicacion(new Venta("Deportes de Bate", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-6), FiltrarArticulosCategoria("Deportes de Bate"), null, null, null, true));
            CrearPublicacion(new Venta("Deportes de equipo", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-5), FiltrarArticulosCategoria("Deportes de equipo"), null, null, null, false));
            CrearPublicacion(new Venta("Deportes de raqueta", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-4), FiltrarArticulosCategoria("Deportes de raqueta"), null, null, null, true));
            CrearPublicacion(new Venta("Calzado deportivo", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-3), FiltrarArticulosCategoria("Calzado deportivo"), null, null, null, true));
            CrearPublicacion(new Venta("Ciclismo", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-2), FiltrarArticulosCategoria("Ciclismo"), null, null, null, false));
            CrearPublicacion(new Venta("Aventura y aire libre", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-1), FiltrarArticulosCategoria("Aventura y aire libre"), null, null, null, true));
            CrearPublicacion(new Venta("Natacion", Enums.EstadoPublicacion.ABIERTA, DateTime.Now, FiltrarArticulosCategoria("Natacion"), null, null, null, false));
            CrearPublicacion(new Venta("Fitness", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-10), FiltrarArticulosCategoria("Fitness"), null, null, null, true));
            CrearPublicacion(new Venta("Proteccion y seguridad", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-11), FiltrarArticulosCategoria("Proteccion y seguridad"), null, null, null, false));

            //PUBLICACIONES SUBASTAS
            CrearPublicacion(new Subasta("Deportes de equipo", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-9), FiltrarArticulosCategoria("Deportes de equipo"), CrearListaDeOfertas(), null, null, null));
            CrearPublicacion(new Subasta("Deportes de raqueta", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-8), FiltrarArticulosCategoria("Deportes de raqueta"), CrearListaDeOfertas(), null, null, null));
            CrearPublicacion(new Subasta("Calzado deportivo", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-7), FiltrarArticulosCategoria("Calzado deportivo"), CrearListaDeOfertas(), null, null, null));
            CrearPublicacion(new Subasta("Ciclismo", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-6), FiltrarArticulosCategoria("Ciclismo"), CrearListaDeOfertas(), null, null, null));
            CrearPublicacion(new Subasta("Aventura y aire libre", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-5), FiltrarArticulosCategoria("Aventura y aire libre"), CrearListaDeOfertas(), null, null, null));
            CrearPublicacion(new Subasta("Natación", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-4), FiltrarArticulosCategoria("Natacion"), CrearListaDeOfertas(), null, null, null));
            CrearPublicacion(new Subasta("Deportes de combate", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-3), FiltrarArticulosCategoria("Deportes de combate"), CrearListaDeOfertas(), null, null, null));
            CrearPublicacion(new Subasta("Fitness", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-2), FiltrarArticulosCategoria("Fitness"), CrearListaDeOfertas(), null, null, null));
            CrearPublicacion(new Subasta("Ropa deportiva", Enums.EstadoPublicacion.ABIERTA, DateTime.Now.AddDays(-1), FiltrarArticulosCategoria("Ropa deportiva"), CrearListaDeOfertas(), null, null, null));
            CrearPublicacion(new Subasta("Protección y seguridad", Enums.EstadoPublicacion.ABIERTA, DateTime.Now, FiltrarArticulosCategoria("Proteccion y seguridad"), CrearListaDeOfertas(), null, null, null));

        }

        public Cliente ObtenerClientePorId(int Id)
        {
            foreach (Usuario unUsuario in listaDeUsuarios)
            {
                // Verifica si el usuario es un Cliente y si el Id coincide
                if (unUsuario.Id == Id && unUsuario is Cliente cliente)
                {
                    return cliente; // Devuelve el objeto como Cliente
                }
            }
            throw new Exception($"ObtenerClientePorId() No se encontró un cliente con el ID especificado: {Id}");
        }


        //METODOS DE CREACION
        public void AgregarCliente(Cliente unCliente)
        {
            try
            {
                unCliente.Validar();
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
                unAdmin.Validar();
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
                unArticulo.Validar();
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
                unaPublicacion.Validar();
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
            listaPublicaciones.Add(unaSubasta);
        }


        //METODOS PARA OBLIGATORIO 2
        public Usuario? DevolverUsuario(string email, string clave)
        {
            foreach (Usuario unUsuario in listaDeUsuarios)
            {
                if (unUsuario.Email == email && unUsuario.Clave == clave) return unUsuario;
            }
            return null;
        }
        public Usuario? DevolverUsuario(string email)
        {
            foreach (Usuario unUsuario in listaDeUsuarios)
            {
                if (unUsuario.Email == email) return unUsuario;
            }
            return null;
        }


        public Publicacion ObtenerPublicacionPorId(int id)
        {
            foreach (Publicacion unaP in listaPublicaciones)
            {
                if (unaP.Id == id)
                {
                    return unaP;
                }
            }
            return null;
        }

        public Cliente ObtenerUsuarioPorEmail(string emailUsuarioActual)
        {
            foreach (Usuario unUsuario in listaDeUsuarios)
            {
                if (unUsuario.Email == emailUsuarioActual && unUsuario is Cliente cliente)
                {
                    return cliente;
                }
            }
            throw new Exception("ObtenerUsuarioPorEmail() - no es un cliente");
        }

        //Logica de la compra
        public void RealizarCompra(int id, string emailUsuarioActual)
        {
            Publicacion unaPublicacion = ObtenerPublicacionPorId(id);
            Cliente usuarioActual = ObtenerUsuarioPorEmail(emailUsuarioActual);

            decimal precioTotal = unaPublicacion.ObtenerPrecioTotalPublicacion();

            if (usuarioActual.SaldoDisponible >= precioTotal)
            {
                unaPublicacion.FechaCierre = DateTime.Now;
                unaPublicacion.Cliente = usuarioActual;
                unaPublicacion.UsuarioFinal = usuarioActual;

                unaPublicacion.Estado = Enums.EstadoPublicacion.CERRADA;
                usuarioActual.SaldoDisponible -= precioTotal;
            }
            else
            {
                throw new Exception("No dispone de saldo suficiente para realizar la compra");
            }
        }


        //Metodo agregado obligatorio 2
        //Logica de la oferta
        public void RealizarOferta(int id, string emailUsuarioActual, decimal valorOferta)
        {
            Publicacion unaPublicacion = ObtenerPublicacionPorId(id);
            Cliente usuarioActual = ObtenerUsuarioPorEmail(emailUsuarioActual);


            if (valorOferta <= 0)
            {
                throw new Exception("Ingresa un valor positivo");
            }

            if (usuarioActual == null)
            {
                throw new Exception("No se encontró al cliente actual.");
            }


            if (usuarioActual.SaldoDisponible < valorOferta)
            {
                throw new Exception("No dispone de saldo suficiente para realizar esta oferta");
            }

            if (unaPublicacion.ObtenerPrecioTotalPublicacion() >= valorOferta)
            {
                throw new Exception("Tu oferta debe ser mayor que la oferta más alta");
            }

            Oferta nuevaOferta = new Oferta(usuarioActual, valorOferta, DateTime.Now);


            if (unaPublicacion is Subasta subasta)
            {
                if (subasta.ComprobarExistenciaOfertaDeClientePorId(usuarioActual.Id))// si el usaurio se encuentra
                {
                    throw new Exception("Ya realizaste una oferta en esta Subasta");
                }

                subasta.CrearOferta(nuevaOferta);
            }

        }


        public void CargarSaldo(string emailUsuarioActual, decimal saldoACargar)
        {
            Cliente usuarioActual = ObtenerUsuarioPorEmail(emailUsuarioActual);

            if (saldoACargar <= 0)
            {
                throw new Exception("Ingresa un valor positivo");
            }

            usuarioActual.SaldoDisponible += saldoACargar;
        }

        public List<Publicacion> PublicacionesPorUsuario(string emailUsuarioActual)
        {
            List<Publicacion> aux = new List<Publicacion>();

            foreach (Publicacion unaP in listaPublicaciones)
            {
                if (unaP.Cliente != null && unaP.Cliente.Email == emailUsuarioActual)
                {
                    aux.Add(unaP);
                }
            }

            return aux;

        }

        public List<Subasta> ObtenerListaSubastas()
        {
            List<Subasta> subastas = new List<Subasta>();

            foreach (Publicacion unaPublicacion in listaPublicaciones)
            {
                if (unaPublicacion is Subasta subasta)
                {
                    subastas.Add(subasta);
                }
            }

            if (subastas.Count() == 0)
            {
                throw new Exception("No se encontraron subastas para listar");
            }

            return subastas;
        }

        public void CerrarSubasta(int idSubasta) 
        {
            Publicacion laPublicacion = ObtenerPublicacionPorId(idSubasta);
            if (laPublicacion is Subasta laSubasta) 
            {
                Cliente usuarioFinal = laSubasta.BuscarUsuarioFinal();
                if (usuarioFinal == null) 
                {
                    throw new Exception("No se pudo cerrar la subasta, no hay ofertas válidas");
                }

                //Logica de cerrar la subasta
                usuarioFinal.SaldoDisponible -= laSubasta.ObtenerPrecioTotalPublicacion();
                laSubasta.Estado = Enums.EstadoPublicacion.CERRADA;
                laSubasta.UsuarioFinal = usuarioFinal;
                laSubasta.Cliente = usuarioFinal;
                laSubasta.FechaCierre = DateTime.Now;
            }

        }
    }
}
