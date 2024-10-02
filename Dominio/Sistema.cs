using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//TODO: poner el id autoincremental , ULTIMO ID

namespace Dominio
{
    internal class Sistema
    {
        List<Publicacion> listaPublicaciones = new List<Publicacion>();
        List<Articulo> listaArticulos = new List<Articulo>();
        List<Usuario> listaUsuarios = new List<Usuario>();

        public List<Cliente> ListarClientes() 
        {
            List<Cliente> listadoDeClientes = new List<Cliente>();
            return listadoDeClientes;
        }

        public List<Articulo> ListarArticulos(string categoria) 
        {
            return listaArticulos;
        }

        public void AltaArticulo(Articulo articulo) 
        { }

        public List<Publicacion> ListarPublicacionesFecha(DateTime fechaInicial, DateTime fechaFinal) 
        {
            return listaPublicaciones;
        }
    }
}
