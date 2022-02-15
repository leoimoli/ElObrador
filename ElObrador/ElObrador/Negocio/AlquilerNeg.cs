using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElObrador.Dao;
using ElObrador.Entidades;

namespace ElObrador.Negocio
{
    public class AlquilerNeg
    {
        public static int RegistrarAlquiler(List<Alquiler> listaAlquiler)
        {
            int idAlquiler = 0;
            try
            {
                idAlquiler = AlquilerDao.RegistrarAlquiler(listaAlquiler);
            }
            catch (Exception ex)
            { }
            return idAlquiler;
        }
        public static List<Alquiler> ListarAlquileresActuales()
        {
            List<Alquiler> _listaAlquileres = new List<Alquiler>();
            try
            {
                _listaAlquileres = AlquilerDao.ListarAlquileresActuales();
            }
            catch (Exception ex)
            {
            }
            return _listaAlquileres;
        }
        public static bool IngresarRecargo(decimal montoRecargo, int idAlquiler, int diasAtraso)
        {
            bool exito = false;
            try
            {
                exito = AlquilerDao.IngresarRecargo(montoRecargo, idAlquiler, diasAtraso);
            }
            catch (Exception ex)
            {
            }
            return exito;
        }
        public static bool ActualizarEstados(int idAlquiler, int idMaterial)
        {
            bool exito = false;
            try
            {
                exito = AlquilerDao.ActualizarEstados(idAlquiler, idMaterial);
            }
            catch (Exception ex)
            {
            }
            return exito;
        }
    }
}
