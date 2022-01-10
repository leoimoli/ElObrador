using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
   public class Stock
    {
        public int idStock { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaDeCompra { get; set; }
        public decimal Monto { get; set; }
        public string Factura { get; set; }
        public int idProveedor { get; set; }
        public int idGrupo { get; set; }
        public int idCategoria { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int idUsuario { get; set; }
        public int TotalStock { get; set; }
        public int idMaterial { get; set; }
        public string NombreGrupo { get; set; }
        public string NombreCategoria { get; set; }
        public string NombreProveedor { get; set; }
        public decimal MontoAlquiler { get; set; }
    }
}
