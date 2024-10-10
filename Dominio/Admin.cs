using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Admin : Usuario
    {
        public Admin(string nombre, string apellido, string email, string clave) : base(nombre, apellido, email, clave)
        {

        }

        public void ValidarNombreApellido()
        {
            if (Nombre.Length == 0 || Apellido.Length == 0)
            {
                throw new Exception("El nombre y el apellido no pueden estar vacíos");
            }
        }

        public void Validar()
        {
            ValidarNombreApellido();
        }
    }
}
