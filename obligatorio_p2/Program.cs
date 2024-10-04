namespace obligatorio_p2
{
    using Dominio;
    internal class Program
    {
        static Sistema unSistema = Sistema.Instancia;

        static void Main(string[] args)
        {
            Opciones();
        }

        static void Menu()
        {
            string[] titulos = { "Listado de todos los clientes", "Listar artículos por categoría", "Alta de artículo", "Listar publicaciones entre fechas"};

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
                        ListarPublicacionesEntreFechas();
                        break;
                    default:
                        Console.WriteLine("No existe una función para ese número, intenta de nuevo");
                        Console.ReadLine();
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
            }
            catch (Exception unError)
            {
                Console.WriteLine(unError);
            }
            
            Console.ReadLine();

        }

        static void ListarArticulosPorCategoria()
        {

            Console.WriteLine("Lista articulos por algunas de las siguientes categorías");
            Console.WriteLine("\n");

            List<String> categorias = unSistema.ListarCategorias();

            foreach (String unaCategoria in categorias)
            {
                Console.WriteLine(unaCategoria.PadRight(20));
            }
            Console.WriteLine("\n");


           
            

            try 
            {
                string texto = Utils.PedirTexto("Ingrese la categoría a listar");

                List<Articulo> articulosParaListar = unSistema.FiltrarArticulosCategoria(texto);

                foreach (Articulo unArticulo in articulosParaListar)
                {
                    Console.WriteLine(unArticulo.ToString());
                }
            }
            catch (Exception unError)
            {
                Console.WriteLine(unError);
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
                Console.WriteLine(unError);
            }
            Console.ReadLine();
        }

        static void ListarPublicacionesEntreFechas()
        {
            Console.WriteLine("Listado Publicaciones desde 20/09 hasta 24/09");

            List<Publicacion> publicacionesEntreFechas = unSistema.ObtenerPublicacionesEntreFechas(fechaComienzo, fechaFin);

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
