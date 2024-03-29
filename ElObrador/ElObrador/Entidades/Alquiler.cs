﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
    public class Alquiler
    {
        public int idAlquiler { get; set; }
        public int idMaterial { get; set; }
        public int idCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string EmailCliente { get; set; }
        public string Material { get; set; }
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        public string Observacion { get; set; }
        public int Dias { get; set; }
        public int Estado { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoTotal { get; set; }
        public string Cliente { get; set; }
        public string DniCliente { get; set; }
        public string mes { get; set; }
        public int TotalVentasPorMes { get; set; }
        public string DescripcionProducto { get; set; }
        public int ProductoMasAlquilado { get; set; }
        public int TotalDeAlquleresGenerales { get; set; }
        public decimal CajaDeAlquileres { get; set; }
        public int AlquilerPagado  { get; set; }
    }
}
