using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
    public class Reparaciones
    {
        public int idReparaciones { get; set; }
        public int idCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int idMaterial { get; set; }
        public string TipoServicio { get; set; }
        public string Diagnostico { get; set; }
        public int idUsuario { get; set; }
        public string Material { get; set; }
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        public string Usuario { get; set; }
        public decimal CostoTotal { get; set; }
    }
}
