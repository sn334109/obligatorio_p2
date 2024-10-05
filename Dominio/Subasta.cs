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

        public Subasta(string nombre, Enums.EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulosPublicados, Cliente cliente, Usuario usuarioFinal, DateTime? fechaCierre) : base(nombre, estado, fechaPublicacion, articulosPublicados, cliente, usuarioFinal, fechaCierre)
        {
        }

        public override string ToString()
        {
            return $"LA SUBASTA: de {Nombre.ToUpper()}, Fecha publicación: {FechaPublicacion.Date}, con la lista de 3 articulo y lista de ofertas **";
        }

        //devuelve OFERTA
        public void BuscarMejorOferta()
        {
        }
    }
}
