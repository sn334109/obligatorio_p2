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

        public Cliente(string nombre, string apellido, string email, string clave, decimal saldoDisponible) : base(nombre, apellido, email, clave)
        {
            this.saldoDisponible = saldoDisponible;
        }

        public override string ToString()
        {
            return $"Cliente Nro ({Id}) | {Nombre.ToUpper().PadLeft(5)} {Apellido.ToUpper().PadRight(5)} | {Email.PadRight(10)} | Saldo: ${saldoDisponible} ";
        }
    }

}


