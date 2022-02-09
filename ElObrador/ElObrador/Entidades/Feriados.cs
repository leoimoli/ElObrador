using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
    public class Feriados
    {
        public int idFeriado { get; set; }
        public int idUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string FechaString { get; set; }
        public string Motivo { get; set; }
    }
}
