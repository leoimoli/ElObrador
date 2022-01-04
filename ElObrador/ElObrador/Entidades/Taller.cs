using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
    public class Taller
    {
        public int idTaller { get; set; }
        public DateTime Fecha { get; set; }
        public int idMaterial { get; set; }
        public string TipoServicio { get; set; }
        public string Diagnostico { get; set; }
        public int idUsuario { get; set; }
        public string Material { get; set; }
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        

    }
}
