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

        public override string ToString()
        {
            return $"\n PUBLICACION A LA VENTA {Estado}: {Nombre.ToUpper()} - Id: {Id}- FECHA DE PUBLICACION: {FechaPublicacion.ToString("dd/MM/yyyy")} \n ARTICULOS DE LA PUBLICACION: {string.Join("-- ", ArticulosPublicados.Select(a => a.Nombre))}   \n { (ofertaRelampago ? "LA PUBLICACION ESTA EN OFERTA RELAMPAGO" : "" )}";
        }
    }
}
