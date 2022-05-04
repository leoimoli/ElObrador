using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
    public class Clientes
    {
        public int IdCliente { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Altura { get; set; }
        public string Dni { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int idUsuario { get; set; }
        public int idProvincia { get; set; }
        public int idLocalidad { get; set; }
        public int chcDni { get; set; }
        public int chcFacturas { get; set; }
        public string chcTipoFactura { get; set; }
        public string NombreProvincia { get; set; }
        public string NombreLocalidad { get; set; }
        public int ActualizaComprobanteDNI { get; set; }
        public int ActualizaComprobanteFactura { get; set; }
        public List<string> ListaComprobantes { get; set; }

        public int ListaNuevoComprobantes { get; set; }
    }
}
