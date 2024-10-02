using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Oferta
    {
        int id;
        Cliente cliente;
        decimal monto;
        DateTime fecha;

        public int Id { get => id; set => id = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }

        public Oferta() {}

        public Oferta(int id, Cliente cliente, decimal monto, DateTime fecha)
        {
            this.id = id;
            this.cliente = cliente;
            this.monto = monto;
            this.fecha = fecha;
        }
    }
}
