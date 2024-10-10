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

        public decimal SaldoDisponible { get => saldoDisponible; set => saldoDisponible = value; }

        public Cliente(string nombre, string apellido, string email, string clave, decimal saldoDisponible) : base(nombre, apellido, email, clave)
        {
            this.SaldoDisponible = saldoDisponible;
        }

        public void ValidarNombreApellido()
        {
            if (Nombre.Length == 0 || Apellido.Length == 0)
            {
                throw new Exception("El nombre y el apellido no pueden estar vacíos");
            }
        }

        public void ValidarSaldoPositivo()
        {
            if (SaldoDisponible < 0)
            {
                throw new Exception("El saldo del usuario debe ser positivo");
            }
        }

        public void Validar()
        {
            ValidarNombreApellido();
            ValidarSaldoPositivo();
        }

        public override string ToString()
        {
            return $"Cliente Nro ({Id}) | {Nombre.ToUpper().PadLeft(5)} {Apellido.ToUpper().PadRight(5)} | {Email.PadRight(10)} | Saldo: ${SaldoDisponible} ";
        }

        public override bool Equals(object? objetoRecibido)
        {
            return objetoRecibido is Cliente clienteRecibido && clienteRecibido.Id == Id;
        }


    }

}
