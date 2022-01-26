using ElObrador.Clases_Maestras;
using ElObrador.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador.Dao
{
    public class ReportesDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static string BuscarEstadoProducto(int idProductoSeleccionado)
        {
            string Estado = "";
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idProductoSeleccionado_in", idProductoSeleccionado)};
            string proceso = "BuscarEstadoProducto";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {

                    int estado = Convert.ToInt32(item["Estado"].ToString());
                    ///// Estado de los productos
                    ///// 1 Habilitado
                    ///// 2 en Taller
                    ///// 3 Alquilado
                    if (estado == 1)
                    {
                        Estado = "Disponible";
                    }
                    if (estado == 2)
                    {
                        Estado = "En Taller";
                    }
                    if (estado == 3)
                    {
                        Estado = "Alquilado";
                    }
                }
            }
            connection.Close();
            return Estado;
        }
        public static string BuscarUltimoAlquiler(int idProductoSeleccionado)
        {
            string Fecha = "";
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idProductoSeleccionado_in", idProductoSeleccionado)};
            string proceso = "BuscarUltimoAlquiler";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    DateTime fecha = Convert.ToDateTime(item["FechaDesde"].ToString());
                    Fecha = fecha.ToShortDateString();
                }
            }
            connection.Close();
            return Fecha;
        }
        public static decimal MontoGastadoEnServicios(int idProductoSeleccionado)
        {
            decimal MontoGastadoEnServicios = 0;
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idProductoSeleccionado_in", idProductoSeleccionado)};
            string proceso = "MontoGastadoEnServicios";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    if (item["Monto"].ToString() == null || item["Monto"].ToString() == "")
                    { MontoGastadoEnServicios = 0; }
                    else
                    { MontoGastadoEnServicios = Convert.ToInt32(item["Monto"].ToString()); }
                }
            }
            connection.Close();
            return MontoGastadoEnServicios;
        }
        public static string UltimoIngresoTaller(int idProductoSeleccionado)
        {
            string Fecha = "";
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idProductoSeleccionado_in", idProductoSeleccionado)};
            string proceso = "UltimoIngresoTaller";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    DateTime fecha = Convert.ToDateTime(item["FechaInicio"].ToString());
                    Fecha = fecha.ToShortDateString();
                }
            }
            connection.Close();
            return Fecha;
        }
        public static int TotalIngresosTaller(int idProductoSeleccionado)
        {
            int TotalTaller = 0;
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idProductoSeleccionado_in", idProductoSeleccionado)};
            string proceso = "TotalIngresosTaller";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    TotalTaller = Convert.ToInt32(item["TotalIngresosTaller"].ToString());

                }
            }
            connection.Close();
            return TotalTaller;
        }
        public static decimal MontoRecaudado(int idProductoSeleccionado)
        {
            decimal MontoRecaudado = 0;
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idProductoSeleccionado_in", idProductoSeleccionado)};
            string proceso = "MontoRecaudado";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    if (item["Monto"].ToString() == null || item["Monto"].ToString() == "")
                    { MontoRecaudado = 0; }
                    else
                    { MontoRecaudado = Convert.ToInt32(item["Monto"].ToString()); }
                }
            }
            connection.Close();
            return MontoRecaudado;
        }
        public static int TotalClientesQueAlquilaron(int idProductoSeleccionado)
        {
            int TotalClientes = 0;
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idProductoSeleccionado_in", idProductoSeleccionado)};
            string proceso = "TotalClientesQueAlquilaron";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    TotalClientes = Convert.ToInt32(item["TotalCliente"].ToString());
                }
            }
            connection.Close();
            return TotalClientes;
        }
        public static int BuscarDiasSinAlquilar(int idProductoSeleccionado)
        {
            int TotalDias = 0;
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idProductoSeleccionado_in", idProductoSeleccionado)};
            string proceso = "BuscarDiasSinAlquilar";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    DateTime fechaUltimoAlquiler = Convert.ToDateTime(item["FechaDesde"].ToString());
                    string fecha = fechaUltimoAlquiler.ToShortDateString();
                    DateTime fechaActual = DateTime.Now;
                    if (fecha != "")
                    {
                        TimeSpan difFechas = fechaActual - fechaUltimoAlquiler;
                        int dias = difFechas.Days;
                        TotalDias = dias;
                    }
                }
            }
            connection.Close();
            return TotalDias;
        }
        public static int TotalDiasAlquilado(int idProductoSeleccionado)
        {
            int TotalDias = 0;
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idProductoSeleccionado_in", idProductoSeleccionado)};
            string proceso = "TotalDiasAlquilado";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    if (item["TotalDias"].ToString() == null || item["TotalDias"].ToString() == "")
                    { TotalDias = 0; }
                    else
                    { TotalDias = Convert.ToInt32(item["TotalDias"].ToString()); }
                }
            }
            connection.Close();
            return TotalDias;
        }
    }
}
