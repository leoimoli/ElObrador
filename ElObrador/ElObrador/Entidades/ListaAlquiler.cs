using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
    public class ListaAlquiler
    {
        public int idAlquiler { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public string usuario { get; set; }
    }
}
