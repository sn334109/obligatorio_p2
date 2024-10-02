using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Usuario
    {
        int id;
        string nombre;
        string apellido;
        string email;
        string clave;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public string Clave { get => clave; set => clave = value; }


        public Usuario() { }

        public Usuario(int id, string nombre, string apellido, string email, string clave)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.clave = clave;
        }
    }

}
