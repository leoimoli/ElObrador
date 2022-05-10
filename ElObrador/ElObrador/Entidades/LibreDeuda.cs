using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
    public class LibreDeuda
    {
        public int idLibreDeuda { get; set; }
        public int idCliente { get; set; }
        public int idTipoTarea { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaActual { get; set; }
        public int idUsuario { get; set; }
    }
}
