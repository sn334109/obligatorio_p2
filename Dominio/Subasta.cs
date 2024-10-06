using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Subasta : Publicacion
    {
        List<Oferta> listaOfertas = new List<Oferta>();



        public Subasta()
        {
        }

        public Subasta(string nombre, Enums.EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulosPublicados, Oferta oferta, Cliente cliente, Usuario usuarioFinal, DateTime? fechaCierre) : base(nombre, estado, fechaPublicacion, articulosPublicados, cliente, usuarioFinal, fechaCierre)
        {
        }

        public override string ToString()
        {
            return $"\n PUBLICACION EN SUBASTA {Estado}: {Nombre.ToUpper()} - Id: {Id}- FECHA DE PUBLICACION: {FechaPublicacion.ToString("dd/MM/yyyy")} \n ARTICULOS DE LA PUBLICACION: {string.Join("-- ", ArticulosPublicados.Select(a => a.Nombre))}   \n y lista de ofertas ";
        }

        //devuelve OFERTA
        public void BuscarMejorOferta()
        {
        }

        
    }
}
