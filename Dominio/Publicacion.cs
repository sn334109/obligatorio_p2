using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Publicacion
    {
        int id;
        string nombre;
        Enums.EstadoPublicacion estado;
        DateTime fechaPublicacion;
        List<Articulo> articulosPublicados;
        Cliente cliente;
        Usuario usuarioFinal;
        DateTime fechaCierre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Enums.EstadoPublicacion Estado { get => estado; set => estado = value; }
        public DateTime FechaPublicacion { get => fechaPublicacion; set => fechaPublicacion = value; }
        public List<Articulo> ArticulosPublicados { get => articulosPublicados; set => articulosPublicados = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Usuario UsuarioFinal { get => usuarioFinal; set => usuarioFinal = value; }
        public DateTime FechaCierre { get => fechaCierre; set => fechaCierre = value; }

        public Publicacion() { }

        public Publicacion(int id, string nombre, Enums.EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulosPublicados, Cliente cliente, Usuario usuarioFinal, DateTime fechaCierre)
        {
            this.id = id;
            this.nombre = nombre;
            this.estado = estado;
            this.fechaPublicacion = fechaPublicacion;
            this.articulosPublicados = articulosPublicados;
            this.cliente = cliente;
            this.usuarioFinal = usuarioFinal;
            this.fechaCierre = fechaCierre;
        }
    }
}
