using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class Pedido
    {
        public DateTime fecha { get; set; }
        public int FCliente { get; set; }
        public int FCarnicero { get; set; }
        public short Envio { get; set; }
        public string Pago { get; set; }
    }
}
