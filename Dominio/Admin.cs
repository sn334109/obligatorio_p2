using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Admin: Usuario
    {
        public Admin(int id, string nombre, string apellido, string email, string clave, decimal saldoDisponible) : base(id, nombre, apellido, email, clave) 
        { 
        
        }
    }
}
