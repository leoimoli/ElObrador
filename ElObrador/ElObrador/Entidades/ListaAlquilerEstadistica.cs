using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
    public class ListaAlquilerEstadistica
    {
        public string anno { get; set; }
        public string mes { get; set; }
        public int TotalAlquilerPorMes { get; set; }
    }
}
