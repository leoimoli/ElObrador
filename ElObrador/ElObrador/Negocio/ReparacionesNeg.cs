using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElObrador.Dao;
using ElObrador.Entidades;

namespace ElObrador.Negocio
{
    public class ReparacionesNeg
    {
        public static bool RegistrarIngresoEnTaller(Reparaciones taller)
        {
            bool exito = false;
            try
            {
                ValidarDatos(taller);
                exito = ReparacionesDao.RegistrarIngresoEnReparacion(taller);
            }
            catch (Exception ex)
            { }
            return exito;
        }
        private static void ValidarDatos(Reparaciones taller)
        {
            if (String.IsNullOrEmpty(taller.Diagnostico))
            {
                const string message = "El campo Diagnostico es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (taller.TipoServicio == "Seleccione")
            {
                const string message = "El campo TipoServicio es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
    }
}
