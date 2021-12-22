﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Entidades
{
   public class Categoria
    {
        public int idCategoria { get; set; }
        public int idGrupo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public int idUsuario { get; set; }
    }
}
