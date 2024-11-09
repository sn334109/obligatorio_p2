using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Subasta : Publicacion, IComparable<Subasta>
    {
        static Sistema unSistema = Sistema.Instancia;
        List<Oferta> listaOfertas = new List<Oferta>();

        public Subasta()
        {
        }

        public Subasta(string nombre, Enums.EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulosPublicados, List<Oferta> ofertas, Cliente cliente, Usuario usuarioFinal, DateTime? fechaCierre) : base(nombre, estado, fechaPublicacion, articulosPublicados, cliente, usuarioFinal, fechaCierre)
        {
            this.listaOfertas = ofertas;
        }

        public void CrearOferta(Oferta unaOferta)
        {
            try
            {
                listaOfertas.Add(unaOferta);
            }
            catch (Exception unError)
            {
                throw unError;
            }
        }

        public Oferta ObtenerOfertaPorId(int Id)
        {
            foreach (Oferta unaOferta in listaOfertas)
            {

                if (unaOferta.Id.Equals(Id) && unaOferta is Oferta)
                {
                    return unaOferta;
                }
            }
            return null;
        }

        public string listarNombresOfertas()
        {
            string texto = "";
            foreach (Oferta unaOferta in listaOfertas)
            {
                texto += $"\n --{unaOferta.Cliente.Nombre} {unaOferta.Cliente.Apellido} -- {unaOferta.Monto}";
            }
            return texto;
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
            return $"\n PUBLICACION EN SUBASTA {Estado}: {Nombre.ToUpper()} - Id: {Id}- FECHA DE PUBLICACION: {FechaPublicacion.ToString("dd/MM/yyyy")} \n ARTICULOS DE LA PUBLICACION: {listarNombresArticulosPublicados()} \n LAS OFERTAS SON LAS SIGUIENTES: \n {listarNombresOfertas()} ";
        }

        //Obtener mejor oferta
        public override decimal ObtenerPrecioTotalPublicacion()
        {
            //sino hay ofertas sale en 0
            decimal ofertaMax = 0;
          

            foreach (Oferta unaOferta in listaOfertas)
            {
                if (ofertaMax < unaOferta.Monto) 
                {
                    ofertaMax = unaOferta.Monto;
                }
            }

            return ofertaMax;
        }


        public override string ObtenerTipoPublicacion()
        {
            return "Subasta";
        }


        public bool ComprobarExistenciaOfertaDeClientePorId(int id)
        {
            foreach (Oferta unaOferta in listaOfertas) 
            {
                if (unaOferta.Cliente.Id == id)
                {
                    return true;
                }
            }
            return false;
        }


        public int CompareTo(Subasta unaSubasta)
        {
            if (unaSubasta == null) return 1; 
            return this.FechaPublicacion.CompareTo(unaSubasta.FechaPublicacion);
        }

        public Cliente BuscarUsuarioFinal() 
        {
            Cliente usuarioFinal = null;
            decimal valorAux = 0;

            foreach (Oferta unaOferta in listaOfertas) 
            {
                if (unaOferta.Monto > valorAux && unaOferta.Cliente.SaldoDisponible >= unaOferta.Monto) 
                {
                    valorAux = unaOferta.Monto;
                    usuarioFinal = unaOferta.Cliente;
                }
            }

            return usuarioFinal;
        }

    }
}

