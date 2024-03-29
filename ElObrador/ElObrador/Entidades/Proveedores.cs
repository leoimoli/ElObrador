﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
    public class Proveedores
    {
        public int idProveedor { get; set; }
        public string NombreEmpresa { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string SitioWeb { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Telefono { get; set; }
        public byte[] Foto { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int idUsuario { get; set; }
        public decimal TotalCompras { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public string Remito { get; set; }
        public int TotalDeComprasGenerales { get; set; }
        public decimal CajaDePagos { get; set; }
        public decimal Monto { get; set; }
    }
}
