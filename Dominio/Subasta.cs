using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subasta : Publicacion
    {
        List<Oferta> listaOfertas = new List<Oferta>();



        public Subasta()
        {
        }

        public Subasta(string nombre, Enums.EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulosPublicados, Cliente cliente, Usuario usuarioFinal, DateTime fechaCierre) : base(nombre, estado, fechaPublicacion, articulosPublicados, cliente, usuarioFinal, fechaCierre)
        {
        }

        //devuelve OFERTA
        public void BuscarMejorOferta()
        {
        }
    }
}
