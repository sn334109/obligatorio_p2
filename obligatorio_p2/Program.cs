namespace obligatorio_p2
{
    using Dominio;
    internal class Program
    {
        static Sistema unSistema = new Sistema();

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

            Console.WriteLine("Listado de Clientes:");
            List<Usuario> clientes = unSistema.ObtenerClientes();
            foreach (Usuario unCliente in clientes)
            {
                Console.WriteLine(unCliente.ToString());
            }
            Console.ReadLine();

        }

        static void ListarArticulosPorCategoria()
        {

            Console.WriteLine("Listado de articulos en categoria: X");
            foreach (Articulo unArticulo in listaArticulos)
            Console.ReadLine();
        }

        static void AltaDeArticulo()
        {
            Console.WriteLine("Listado de articulos en categoria: X");
            Console.ReadLine();
        }

        static void ListarPublicacionesEntreFechas()
        {
            Console.WriteLine("Listado Publicaciones desde 20/09 hasta 24/09");
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
