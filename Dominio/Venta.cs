using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta : Publicacion
    {
        bool ofertaRelampago;

        public Venta() { }

        public bool OfertaRelampago { get => ofertaRelampago; set => ofertaRelampago = value; }

        public Venta(string nombre, Enums.EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulosPublicados, Cliente cliente, Usuario usuarioFinal, DateTime? fechaCierre, bool ofertaRelampago) : base(nombre, estado, fechaPublicacion, articulosPublicados, cliente, usuarioFinal, fechaCierre)
        {
            this.ofertaRelampago = ofertaRelampago;
        }
    }
}
