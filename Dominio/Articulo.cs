using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        static int ultimoId;
        int id;
        string nombre;
        string categoria;
        int precioVenta;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int PrecioVenta { get => precioVenta; set => precioVenta = value; }

        public Articulo() { }

        public Articulo(string nombre, string categoria, int precioVenta)
        {
            this.Id = ++ultimoId;
            this.Nombre = nombre;
            this.Categoria = categoria;
            this.PrecioVenta = precioVenta;
        }

    }
}
