using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Usuario
    {
        static int ultimoId;
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


        public Usuario() 
        {
            this.Id = ++ultimoId;
        }

        public Usuario(string nombre, string apellido, string email, string clave)
        {
            this.id = ++ultimoId;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.clave = clave;
        }

        public override string ToString()
        {
            return $"Usuario Nro ({id}) | {nombre.ToUpper()} {apellido.ToUpper()} | {email} ";
        }
    }

}
