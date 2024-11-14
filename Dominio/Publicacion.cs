using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Publicacion: IValidable
    {
        static int ultimoId;
        int id;
        string nombre;
        Enums.EstadoPublicacion estado;
        DateTime fechaPublicacion;
        List<Articulo> articulosPublicados;
        Cliente cliente;
        Usuario usuarioFinal;
        DateTime? fechaCierre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Enums.EstadoPublicacion Estado { get => estado; set => estado = value; }
        public DateTime FechaPublicacion { get => fechaPublicacion; set => fechaPublicacion = value; }
        public List<Articulo> ArticulosPublicados { get => articulosPublicados; set => articulosPublicados = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Usuario UsuarioFinal { get => usuarioFinal; set => usuarioFinal = value; }
        public DateTime? FechaCierre { get => fechaCierre; set => fechaCierre = value; }

        public Publicacion() { }

        public Publicacion(string nombre, Enums.EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulosPublicados, Cliente cliente, Usuario usuarioFinal, DateTime? fechaCierre)
        {
            this.id = ++ultimoId;
            this.nombre = nombre;
            this.estado = estado;
            this.fechaPublicacion = fechaPublicacion;
            this.articulosPublicados = articulosPublicados;
            this.cliente = cliente ?? null;
            this.usuarioFinal = usuarioFinal ?? null;
            this.fechaCierre = fechaCierre ?? null;
        }

        public void ValidarExistenciaArticulos()
        {
            if (articulosPublicados.Count == 0)
            {
                throw new Exception("La publicación debe tener al menos un Artículo");
            }
        }

        public void ValidarNombre()
        {
            if (nombre.Length == 0)
            {
                throw new Exception("El nombre de la publicación no puede ser vacío");
            }
        }

        public void Validar()
        {
            ValidarExistenciaArticulos();
            ValidarNombre();
        }

        public abstract decimal ObtenerPrecioTotalPublicacion();
        public abstract string ObtenerTipoPublicacion();
    }
}
