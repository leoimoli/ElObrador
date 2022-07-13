using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElObrador.Entidades;
using MySql.Data.MySqlClient;

namespace ElObrador.Dao
{
    public class ReparacionesDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);

        public static int RegistrarIngresoEnReparacion(Reparaciones taller)
        {
            int idReparacion = 0;
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarIngresoEnReparacion";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Material_in", taller.Material);
            cmd.Parameters.AddWithValue("Codigo_in", taller.Codigo);
            cmd.Parameters.AddWithValue("Modelo_in", taller.Modelo);
            cmd.Parameters.AddWithValue("TipoServicio_in", taller.TipoServicio);
            cmd.Parameters.AddWithValue("Fecha_in", taller.Fecha);
            cmd.Parameters.AddWithValue("Diagnostico_in", taller.Diagnostico);
            cmd.Parameters.AddWithValue("idUsuario_in", taller.idUsuario);
            cmd.Parameters.AddWithValue("idCliente_in", taller.idCliente);
            cmd.Parameters.AddWithValue("FechaEstimadaEntrega_in", taller.FechaEstimadaEntrega);
            cmd.Parameters.AddWithValue("Senia_in", taller.Seña);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                idReparacion = Convert.ToInt32(r["ID"].ToString());
            }
            exito = true;
            connection.Close();
            if (idReparacion > 0)
            {
                exito = RegistrarHistorial(taller, idReparacion);
            }
            return idReparacion;
        }
        public static bool RegistrarHistorial(Reparaciones taller, int idReparacion)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarHistorialDeReparacion";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (idReparacion > 0)
            { cmd.Parameters.AddWithValue("idTaller_in", idReparacion); }
            else
            { cmd.Parameters.AddWithValue("idTaller_in", taller.idReparaciones); }
            cmd.Parameters.AddWithValue("Fecha_in", taller.Fecha);
            cmd.Parameters.AddWithValue("Diagnostico_in", taller.Diagnostico);
            cmd.Parameters.AddWithValue("idUsuario_in", taller.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool RegistrarCierreHistorialDeReparacion(Reparaciones taller, int idReparacion)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarHistorialDeReparacion";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (idReparacion > 0)
            { cmd.Parameters.AddWithValue("idTaller_in", idReparacion); }
            else
            { cmd.Parameters.AddWithValue("idTaller_in", taller.idReparaciones); }
            cmd.Parameters.AddWithValue("Fecha_in", taller.Fecha);
            cmd.Parameters.AddWithValue("Diagnostico_in", taller.Diagnostico);
            cmd.Parameters.AddWithValue("idUsuario_in", taller.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            if (exito == true)
            {
                if (taller.CostoTotal > 0)
                {
                    exito = ActualizarCosto(taller);
                }
                exito = SalidaDeTallerParaMaterial(taller);
            }
            connection.Close();
            return exito;
        }
        private static bool ActualizarCosto(Reparaciones taller)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            ///PROCEDIMIENTO
            string proceso = "ActualizarCostoReparaciones";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idTaller_in", taller.idReparaciones);
            cmd.Parameters.AddWithValue("CostoTotal_in", taller.CostoTotal);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }

        public static List<Reparaciones> ListaDeReparacionPorDescripcion(string text)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Reparaciones> _listaTaller = new List<Entidades.Reparaciones>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Material_in", text) };
            string proceso = "ListaDeReparacionPorDescripcion";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Reparaciones listaTaller = new Entidades.Reparaciones();
                    listaTaller.idReparaciones = Convert.ToInt32(item["idReparaciones"].ToString());
                    listaTaller.TipoServicio = item["TipoServicio"].ToString();
                    listaTaller.Diagnostico = item["Diagnostico"].ToString();
                    listaTaller.Fecha = Convert.ToDateTime(item["FechaInicio"].ToString());
                    listaTaller.Material = item["Producto"].ToString();
                    listaTaller.Codigo = item["Codigo"].ToString();
                    listaTaller.Modelo = item["Modelo"].ToString();
                    _listaTaller.Add(listaTaller);
                }
            }
            connection.Close();
            return _listaTaller;
        }

        public static List<Reparaciones> BuscarHistorialPorId(int idHistorialReparacionSeleccionado)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Reparaciones> _listaTaller = new List<Entidades.Reparaciones>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idHistorialReparacionSeleccionado_in", idHistorialReparacionSeleccionado) };
            string proceso = "BuscarHistorialReparacionesPorId";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Reparaciones listaTaller = new Entidades.Reparaciones();
                    listaTaller.idReparaciones = Convert.ToInt32(item["idHistorialReparaciones"].ToString());
                    listaTaller.Material = item["Material"].ToString();
                    listaTaller.Diagnostico = item["Descripcion"].ToString();
                    listaTaller.Fecha = Convert.ToDateTime(item["Fecha"].ToString());
                    string Apellido = item["Apellido"].ToString();
                    string Nombre = item["Nombre"].ToString();
                    listaTaller.Usuario = Apellido + " " + Nombre;
                    _listaTaller.Add(listaTaller);
                }
            }
            connection.Close();
            return _listaTaller;
        }

        public static List<Reparaciones> ListaDeReparaciones()
        {
            connection.Close();
            connection.Open();
            List<Entidades.Reparaciones> _listaTaller = new List<Entidades.Reparaciones>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ListaDeReparaciones";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Reparaciones listaTaller = new Entidades.Reparaciones();
                    listaTaller.idReparaciones = Convert.ToInt32(item["idReparaciones"].ToString());
                    listaTaller.TipoServicio = item["TipoServicio"].ToString();
                    listaTaller.Diagnostico = item["Diagnostico"].ToString();
                    listaTaller.Fecha = Convert.ToDateTime(item["FechaInicio"].ToString());
                    listaTaller.Material = item["Producto"].ToString();
                    listaTaller.Codigo = item["Codigo"].ToString();
                    listaTaller.Modelo = item["Modelo"].ToString();
                    listaTaller.Cliente = item["Apellido"].ToString() + "," + item["Nombre"].ToString();
                    _listaTaller.Add(listaTaller);
                }
            }
            connection.Close();
            return _listaTaller;
        }
        public static List<Reparaciones> ListarHistorialReparacion(int idReparacionSeleccionado)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Reparaciones> _listaTaller = new List<Entidades.Reparaciones>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idReparacionSeleccionado_in", idReparacionSeleccionado) };
            string proceso = "ListarHistorialReparacion";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Reparaciones listaTaller = new Entidades.Reparaciones();
                    listaTaller.idReparaciones = Convert.ToInt32(item["idHistorialReparaciones"].ToString());
                    listaTaller.Diagnostico = item["Descripcion"].ToString();
                    listaTaller.Fecha = Convert.ToDateTime(item["Fecha"].ToString());
                    string Apellido = item["Apellido"].ToString();
                    string Nombre = item["Nombre"].ToString();
                    listaTaller.Usuario = Apellido + " " + Nombre;
                    _listaTaller.Add(listaTaller);
                }
            }
            connection.Close();
            return _listaTaller;
        }
        private static bool SalidaDeTallerParaMaterial(Reparaciones taller)
        {
            bool exito = false;
           // int idReparacion = StockDao.BuscarIdMaterialPorIdTaller(taller.idReparaciones);
            connection.Close();
            connection.Open();
            ///PROCEDIMIENTO
            string proceso = "ActualizarEstadoCierreReparaciones";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idReparaciones_in", taller.idReparaciones);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
    }
}
