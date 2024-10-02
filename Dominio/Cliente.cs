using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Cliente : Usuario
    {
        decimal saldoDisponible;

        public Cliente(int id, string nombre, string apellido, string email, string clave, decimal saldoDisponible) : base(id, nombre, apellido, email, clave)
        {
            this.saldoDisponible = saldoDisponible;
        }

    
    }

}


