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
    public class GrupoNeg
    {
        public static bool GuardarGrupo(Grupo grupo)
        {
            bool exito = false;
            try
            {
                ValidarDatos(grupo);
                bool GrupoExistente = GrupoDao.ValidarGrupoExistente(grupo.Nombre);
                if (GrupoExistente == true)
                {
                    const string message = "Ya existe un Grupo registrado con el nombre ingresado.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    exito = GrupoDao.InsertarGrupo(grupo);
                }
            }
            catch (Exception ex)
            { }
            return exito;
        }      

        private static void ValidarDatos(Grupo grupo)
        {
            if (String.IsNullOrEmpty(grupo.Nombre))
            {
                const string message = "El campo nombre es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
    }
}
