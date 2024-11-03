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

        public Cliente() : base()
        {
            this.saldoDisponible = 3000;
        }

        public Cliente(string nombre, string apellido, string email, string clave, decimal saldoDisponible) : base(nombre, apellido, email, clave)
        {
            this.SaldoDisponible = saldoDisponible;
        }

        public void ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Debes ingresar tu Nombre.");
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("Debes ingresar tu Apellido");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("Debes ingresar tu Correo Electrònico.");
            }
            if (string.IsNullOrEmpty(Clave))
            {
                throw new Exception("Debes crear una Clave para tu Cuenta");
            }
        }

        public void ValidarSaldoPositivo()
        {
            if (SaldoDisponible < 0)
            {
                throw new Exception("El saldo del usuario debe ser positivo");
            }
        }

        public void ValidarClave() 
        {
            //sean nros y letras
            foreach (char caracter in Clave) 
            {
                if (!char.IsLetterOrDigit(caracter)) 
                {
                    throw new Exception("Su contraseña debe ser compuesta por digitos o letras");
                } 
            }

            if (Clave.Length < 8)
            {
                throw new Exception("Su contraseña debe tener al menos 8 caractéres");
            }
        }

        public void Validar()
        {
            ValidarCamposVacios();
            ValidarSaldoPositivo();
            ValidarClave();
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
