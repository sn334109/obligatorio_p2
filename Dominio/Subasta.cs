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

        public Subasta(string nombre, Enums.EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulosPublicados, List<Oferta> ofertas, Cliente cliente, Usuario usuarioFinal, DateTime? fechaCierre) : base(nombre, estado, fechaPublicacion, articulosPublicados, cliente, usuarioFinal, fechaCierre)
        {
            this.listaOfertas = ofertas;
        }

        static Sistema unSistema = Sistema.Instancia;

        //public void PrecargaOfertas()
        //{
        //    CrearOferta(new Oferta(unSistema.ObtenerClientePorId(1), 400, DateTime.Now));
        //    CrearOferta(new Oferta(unSistema.ObtenerClientePorId(2), 450, DateTime.Now));
        //    CrearOferta(new Oferta(unSistema.ObtenerClientePorId(3), 500, DateTime.Now));
        //    CrearOferta(new Oferta(unSistema.ObtenerClientePorId(4), 550, DateTime.Now));
        //    CrearOferta(new Oferta(unSistema.ObtenerClientePorId(5), 600, DateTime.Now));
        //    CrearOferta(new Oferta(unSistema.ObtenerClientePorId(6), 650, DateTime.Now));
        //    CrearOferta(new Oferta(unSistema.ObtenerClientePorId(7), 700, DateTime.Now));
        //    CrearOferta(new Oferta(unSistema.ObtenerClientePorId(8), 750, DateTime.Now));
        //    CrearOferta(new Oferta(unSistema.ObtenerClientePorId(9), 800, DateTime.Now));
        //    CrearOferta(new Oferta(unSistema.ObtenerClientePorId(10), 850, DateTime.Now));

        //}

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

        Random random = new Random();
        public List<Oferta> CrearListaDeOfertas()
        {
            List<Oferta> aux = new List<Oferta>();

            int contadorRandom = 0;

            while (contadorRandom < 3)
            {
                int idAleatorio = random.Next(1, 11);
                contadorRandom++;
                Oferta nuevaOferta =  new Oferta(unSistema.ObtenerClientePorId(idAleatorio), (500*idAleatorio+100), DateTime.Now);
                aux.Add(nuevaOferta);
                   

            }
            return aux;
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

        public override string ToString()
        {
            return $"\n PUBLICACION EN SUBASTA {Estado}: {Nombre.ToUpper()} - Id: {Id}- FECHA DE PUBLICACION: {FechaPublicacion.ToString("dd/MM/yyyy")} \n ARTICULOS DE LA PUBLICACION: {string.Join("-- ", ArticulosPublicados.Select(a => a.Nombre))}   \n {listarNombresOfertas()}";


        }

        //devuelve OFERTA
        public void BuscarMejorOferta()
        {
        }

        
    }
}
