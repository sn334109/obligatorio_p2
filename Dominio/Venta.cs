using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta : Publicacion
    {
        static Sistema unSistema = Sistema.Instancia;
        bool ofertaRelampago;

        public Venta() { }

        public bool OfertaRelampago { get => ofertaRelampago; set => ofertaRelampago = value; }

        public Venta(string nombre, Enums.EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulosPublicados, Cliente cliente, Usuario usuarioFinal, DateTime? fechaCierre, bool ofertaRelampago) : base(nombre, estado, fechaPublicacion, articulosPublicados, cliente, usuarioFinal, fechaCierre)
        {
            this.ofertaRelampago = ofertaRelampago;
        }

        public string listarNombresArticulosPublicados()
        {
            string texto = "";
            foreach (Articulo unArticulo in ArticulosPublicados)
            {
                texto += $" --{unArticulo.Nombre}";
            }
            return texto;
        }

        public override string ToString()
        {
            return $"\n PUBLICACION A LA VENTA {Estado}: {Nombre.ToUpper()} - Id: {Id}- FECHA DE PUBLICACION: {FechaPublicacion.ToString("dd/MM/yyyy")} \n ARTICULOS DE LA PUBLICACION: {listarNombresArticulosPublicados()}   \n { (ofertaRelampago ? "LA PUBLICACION ESTA EN OFERTA RELAMPAGO" : "" )}";
        }

        public override decimal ObtenerPrecioTotalPublicacion()
        {
            decimal precioTotal = 0;

            foreach (Articulo articulo in ArticulosPublicados)
            {
                precioTotal += articulo.PrecioVenta; // Sumamos el precio de venta de cada artículo
            }

            // Si es una oferta relámpago, aplicamos un descuento (ejemplo: 10% de descuento)
            if (OfertaRelampago)
            {
                precioTotal *= 0.8m; // 80% del precio total
            }

            return precioTotal;
        }

        public override string ObtenerTipoPublicacion() 
        {
            return "Venta";
        }

        public override void CerrarPublicacion(string emailUsuarioActual) 
        {

            Cliente usuarioActual = unSistema.ObtenerUsuarioPorEmail(emailUsuarioActual);

            if (usuarioActual.SaldoDisponible >= ObtenerPrecioTotalPublicacion())
            {
                FechaCierre = DateTime.Now;
                Cliente = usuarioActual;
                UsuarioFinal = usuarioActual;

                Estado = Enums.EstadoPublicacion.CERRADA;
                usuarioActual.SaldoDisponible -= ObtenerPrecioTotalPublicacion();
            }
            else
            {
                throw new Exception("No dispone de saldo suficiente para realizar la compra");
            }

        }
  



    }
}
