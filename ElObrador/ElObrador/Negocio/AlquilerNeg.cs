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

        public static List<Alquiler> ListarAlquileresActualesPorDescripcion(string valor)
        {
            List<Alquiler> _listaAlquileres = new List<Alquiler>();
            try
            {
                _listaAlquileres = AlquilerDao.ListarAlquileresActualesPorDescripcion(valor);
            }
            catch (Exception ex)
            {
            }
            return _listaAlquileres;
        }

        public static List<MontoAlquiler> BuscarMontoAlquilerParaMaterial(List<Alquiler> detallealquiler)
        {
            List<MontoAlquiler> Lista = new List<MontoAlquiler>();
            try
            {
                Lista = AlquilerDao.BuscarMontoAlquilerParaMaterial(detallealquiler);
            }
            catch (Exception ex)
            { }
            return Lista;
        }

        public static bool ValidarDisponibilidadMateriales(List<Alquiler> detallealquiler)
        {
            bool MaterialDisponible = true;
            try
            {
                MaterialDisponible = AlquilerDao.ValidarDisponibilidadMateriales(detallealquiler);
            }
            catch(Exception ex)
            { }
            return MaterialDisponible;
        }

        public static List<Alquiler> ListarAlquileresActualesPorCliente(string valor)
        {
            List<Alquiler> _listaAlquileres = new List<Alquiler>();
            try
            {
                _listaAlquileres = AlquilerDao.ListarAlquileresActualesPorCliente(valor);
            }
            catch (Exception ex)
            {
            }
            return _listaAlquileres;
        }

        public static List<Alquiler> BuscarAlquileresFinalizados()
        {
            List<Alquiler> _listaAlquileres = new List<Alquiler>();
            try
            {
                int EstadoAlquiler = 0;
                _listaAlquileres = AlquilerDao.BuscarAlquileresFinalizados(EstadoAlquiler);
            }
            catch (Exception ex)
            {
            }
            return _listaAlquileres;
        }
    }
}
