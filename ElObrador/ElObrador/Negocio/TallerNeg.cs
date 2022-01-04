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
    public class TallerNeg
    {
        public static bool RegistrarIngresoEnTaller(Taller taller)
        {
            bool exito = false;
            try
            {
                ValidarDatos(taller);
                bool EstadoMaterial = ValidarEstadoDelMaterial(taller.idMaterial);
                if (EstadoMaterial == true)
                {
                    const string message = "El material ingresado no se encuentra en el estado adecuado para ingresar a taller. ";
                    const string caption = "Atención";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    exito = TallerDao.RegistrarIngresoEnTaller(taller);
                }
            }
            catch (Exception ex)
            { }
            return exito;
        }
        private static bool ValidarEstadoDelMaterial(int idMaterial)
        {
            bool existe = TallerDao.ValidarEstadoDelMaterial(idMaterial);
            return existe;
        }

        private static void ValidarDatos(Taller taller)
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
        public static List<Taller> ListaDeTaller()
        {
            List<Entidades.Taller> _listaTaller = new List<Entidades.Taller>();
            try
            {
                _listaTaller = TallerDao.ListaDeTaller();
            }
            catch (Exception ex)
            {
            }
            return _listaTaller;
        }
    }
}
