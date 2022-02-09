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
    public class FeriadosNeg
    {
        public static bool CargarFeriados(Feriados feriados)
        {
            bool exito = false;
            try
            {
                ValidarDatos(feriados);
                bool FeriadoExistente = ValidarFeriadoExistente(feriados);
                if (FeriadoExistente == true)
                {
                    const string message2 = "Ya existe un Feriado/Día No laboral para la fecha ingresada.";
                    const string caption2 = "Éxito";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    exito = FeriadosDao.InsertFeriado(feriados);
                }
            }
            catch (Exception ex)
            {
            }
            return exito;
        }
        private static bool ValidarFeriadoExistente(Feriados feriados)
        {
            bool existe = FeriadosDao.ValidarFeriadoExistente(feriados);
            return existe;
        }
        private static void ValidarDatos(Feriados feriados)
        {
            if (String.IsNullOrEmpty(feriados.Motivo))
            {
                const string message = "El campo Motivo es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (feriados.Fecha < DateTime.Now)
            {
                const string message = "No se puede ingresar feriados o días No laborables con fecha menor a la actual.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
    }
}
