using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Clases_Maestras
{
   public class ValoresConstantes
    {
        public static string[] Sexo
        {
            get
            {
                return new string[] { "MASCULINO", "FEMENINO", "NO_BINARIO" };
            }
        }
        public static string[] TipoServicio
        {
            get
            {
                return new string[] { "MANTENIMIENTO", "REPARACIÓN" };
            }
        }
    }
}
