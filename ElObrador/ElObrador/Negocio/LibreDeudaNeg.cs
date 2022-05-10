using ElObrador.Dao;
using ElObrador.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElObrador.Negocio
{
    public class LibreDeudaNeg
    {
        public static bool RegistrarDeuda(LibreDeuda libreDeuda)
        {
            bool exito = false;
            try
            {
                ValidarDatos(libreDeuda);
                exito = ClientesDao.RegistrarDeuda(libreDeuda);
            }
            catch (Exception ex)
            { }
            return exito;
        }

        private static void ValidarDatos(LibreDeuda libreDeuda)
        {
            if (String.IsNullOrEmpty(Convert.ToString(libreDeuda.Monto)))
            {
                const string message = "El campo Monto es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
    }
}
