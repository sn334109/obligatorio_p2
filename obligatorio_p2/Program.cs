namespace obligatorio_p2
{
    using Dominio;
    internal class Program
    {
        static Sistema unSistema;

        static void Main(string[] args)
        {
            try
            {
             unSistema = Sistema.Instancia;
            }
            catch (Exception unError) 
            {
                Utils.MensajeError(unError.Message);
            }
            Opciones();
        }

        static void Menu()
        {
            string[] titulos = { "Listado de todos los clientes", "Listar artículos por categoría", "Alta de artículo", "Listar publicaciones entre fechas" };

            Console.WriteLine("Presione 0 para finalizar el programa");

            int opcion = 1;
            foreach (string titulo in titulos)
            {
                Console.WriteLine($"{opcion} - {titulo}");
                opcion++;
            }
        }

        static void Opciones()
        {
            int valor = -1;
            while (valor != 0)
            {
                Console.Clear();
                Menu();
                Console.Write("Ingrese opcion:");
                valor = LeerEntero();

                switch (valor)
                {
                    case 1:
                        ListarTodosLosClientes();
                        break;
                    case 2:
                        ListarArticulosPorCategoria();
                        break;
                    case 3:
                        AltaDeArticulo();
                        break;
                    case 4:
                        try
                        {
                            ListarPublicacionesEntreFechas();
                        }
                        catch (Exception unError)
                        {
                            Utils.MensajeError(unError.Message);
                        }
                        break;
                    default:
                        if (valor != 0)
                        {
                            Console.WriteLine("No existe una función para ese número, intenta de nuevo");
                            Console.ReadLine();
                        }
                        break;
                }
            }

        }


        static void ListarTodosLosClientes()
        {
            try
            {
                Console.WriteLine("Listado de Clientes:");
                List<Usuario> clientes = unSistema.ObtenerClientes();
                foreach (Usuario unCliente in clientes)
                {
                    Console.WriteLine(unCliente.ToString());
                }

                Console.ReadLine();
            }
            catch (Exception unError)
            {

                Utils.MensajeError(unError.Message);
            }

        }

        static void ListarArticulosPorCategoria()
        {
            try
            {
                Console.WriteLine("Lista articulos por algunas de las siguientes categorías");
                Console.WriteLine("\n");

                List<String> categorias = unSistema.ListarCategorias();


                if (categorias.Count == 0)
                {
                    throw new Exception("No hay categorias en el sistema");
                }

                foreach (String unaCategoria in categorias)
                {
                    Console.WriteLine(unaCategoria.PadRight(20));
                }
                Console.WriteLine("\n");

                string texto = Utils.PedirTexto("Ingrese la categoría a listar");

                List<Articulo> articulosParaListar = unSistema.FiltrarArticulosCategoria(texto);

                foreach (Articulo unArticulo in articulosParaListar)
                {
                    Console.WriteLine(unArticulo.ToString());
                }
            }
            catch (Exception unError)
            {
                Utils.MensajeError(unError.Message);
            }
            Console.ReadLine();
        }

        static void AltaDeArticulo()
        {
            Console.WriteLine("Ingrese datos necesario para crear articulo: \n");
            string nombre = Utils.PedirTexto("Ingrese nombre del articulo ");
            string categoria = Utils.PedirTexto("Ingrese categoria del articulo ");
            int precio = Utils.LeerNumero($"Ingrese precio de {nombre} ");


            try
            {
                Articulo unArticulo = new Articulo(nombre, categoria, precio);
                unSistema.AltaArticulo(unArticulo);
                Utils.MensajeConfirmacion($"\nSe creo correctamente el articulo: \n\n\t Nombre: {nombre} \n\t Categoria: {categoria.ToUpper()} \n\t Precio: ${precio} \n\n ");
            }
            catch (Exception unError)
            {
                Utils.MensajeError(unError.Message);
            }
            Console.ReadLine();
        }

        static void ListarPublicacionesEntreFechas()
        {
            Console.WriteLine("Selecciona rango de fechas, formato Dia/Mes/Año");

            DateTime fechaInicio = Utils.LeerFecha("Ingresa la fecha inicio");
            DateTime fechaFinal = Utils.LeerFecha("Ingresa la fecha final");
            List<Publicacion> publicacionesEntreFechas = unSistema.ObtenerPublicacionesEntreFechas(fechaInicio.Date, fechaFinal.Date);

            foreach (Publicacion unaPublicacion in publicacionesEntreFechas)
            {
                Console.WriteLine(unaPublicacion.ToString());
            }
            Console.ReadLine();
        }




        static int LeerEntero()
        {
            string texto = Console.ReadLine();
            int resultado = 0;
            while (!int.TryParse(texto, out resultado))
            {
                Console.Write("Error:(ingreso inválido) ingrese un número del 1 al 4");
                texto = Console.ReadLine();
            }
            return resultado;
        }

    }
}
