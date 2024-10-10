using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            this.Categoria = categoria.ToUpper();
            this.PrecioVenta = precioVenta;
        }

        public void ValidarCamposVacios()
        {
            if (Nombre.Length == 0 || Categoria.Length == 0)
            {
                throw new Exception("El nombre y Categoria no pueden estar vacios");
            }
        }

        public void ValidarPrecioVentaPositivo()
        {
            if (PrecioVenta < 0)
            {
                throw new Exception("El precio del articulo debe ser un numero positivo");
            }
        }

        public void Validar()
        {
            ValidarCamposVacios();
            ValidarPrecioVentaPositivo();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Categoria: {Categoria}, Precio: ${PrecioVenta}";
        }
    }
}
