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
        public static int RegistrarIngresoEnTaller(Reparaciones taller)
        {
            int exito = 0;
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

        public static bool RegistrarHistorialDeReparacion(Reparaciones taller)
        {
            bool exito = false;
            try
            {
                ValidarDatosHistorial(taller);
                exito = ReparacionesDao.RegistrarHistorial(taller, 0);

            }
            catch (Exception ex)
            { }
            return exito;
        }

        private static bool ValidarEstadoDelMaterial(int idMaterial)
        {
            throw new NotImplementedException();
        }

        private static void ValidarDatosHistorial(Reparaciones taller)
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
        }

        public static bool RegistrarCierreHistorialDeReparacion(Reparaciones taller)
        {
            bool exito = false;
            try
            {
                exito = ReparacionesDao.RegistrarCierreHistorialDeReparacion(taller, 0);
            }
            catch (Exception ex)
            { }
            return exito;
        }

        public static List<Reparaciones> ListaDeReparaciones()
        {
            List<Entidades.Reparaciones> _listaReparaciones = new List<Entidades.Reparaciones>();
            try
            {
                _listaReparaciones = ReparacionesDao.ListaDeReparaciones();
            }
            catch (Exception ex)
            {
            }
            return _listaReparaciones;
        }

        public static List<Reparaciones> ListarHistorialReparacion(int idReparacionSeleccionado)
        {
            List<Entidades.Reparaciones> _listaTaller = new List<Entidades.Reparaciones>();
            try
            {
                _listaTaller = ReparacionesDao.ListarHistorialReparacion(idReparacionSeleccionado);
            }
            catch (Exception ex)
            {
            }
            return _listaTaller;
        }

        public static List<Reparaciones> BuscarHistorialPorId(int idHistorialReparacionSeleccionado)
        {
            List<Entidades.Reparaciones> _listaTaller = new List<Entidades.Reparaciones>();
            try
            {
                _listaTaller = ReparacionesDao.BuscarHistorialPorId(idHistorialReparacionSeleccionado);
            }
            catch (Exception ex)
            {
            }
            return _listaTaller;
        }
        public static List<Reparaciones> ListaDeReparacionPorDescripcion(string text)
        {
            List<Entidades.Reparaciones> _listaTaller = new List<Entidades.Reparaciones>();
            try
            {
                _listaTaller = ReparacionesDao.ListaDeReparacionPorDescripcion(text);
            }
            catch (Exception ex)
            {
            }
            return _listaTaller;
        }

        public static List<Reparaciones> ListaDeReparacionesFinalizadas()
        {
            List<Entidades.Reparaciones> _listaReparaciones = new List<Entidades.Reparaciones>();
            try
            {
                _listaReparaciones = ReparacionesDao.ListaDeReparacionesFinalizadas();
            }
            catch (Exception ex)
            {
            }
            return _listaReparaciones;
        }
    }
}
