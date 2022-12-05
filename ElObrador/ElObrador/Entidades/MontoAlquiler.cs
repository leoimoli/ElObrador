using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
    public class MontoAlquiler
    {
        public int idMaterial { get; set; }
        public string Material { get; set; }
        public decimal Monto { get; set; }
        public string Modelo { get; set; }
        public string Codigo { get; set; }
    }
}
