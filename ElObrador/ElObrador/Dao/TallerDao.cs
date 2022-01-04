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
    public class TallerDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool RegistrarIngresoEnTaller(Taller taller)
        {
            int idTaller = 0;
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarIngresoEnTaller";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idMaterial_in", taller.idMaterial);
            cmd.Parameters.AddWithValue("TipoServicio_in", taller.TipoServicio);
            cmd.Parameters.AddWithValue("Fecha_in", taller.Fecha);
            cmd.Parameters.AddWithValue("Diagnostico_in", taller.Diagnostico);
            cmd.Parameters.AddWithValue("idUsuario_in", taller.idUsuario);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                idTaller = Convert.ToInt32(r["ID"].ToString());
            }
            exito = true;
            connection.Close();
            if (idTaller > 0)
            {
                exito = RegistrarHistorial(taller, idTaller);
                if (exito == true)
                { ActualizarEstadoMaterial(taller); }
            }
            return exito;
        }

        public static bool RegistrarCierreHistorialDeTaller(Taller taller, int idTaller)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarHistorialDeTaller";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (idTaller > 0)
            { cmd.Parameters.AddWithValue("idTaller_in", idTaller); }
            else
            { cmd.Parameters.AddWithValue("idTaller_in", taller.idTaller); }
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

        private static bool SalidaDeTallerParaMaterial(Taller taller)
        {
            bool exito = false;
            int idMaterial = StockDao.BuscarIdMaterialPorIdTaller(taller.idTaller);
            connection.Close();
            connection.Open();
            ///PROCEDIMIENTO
            string proceso = "ActualizarEstadoCierreTaller";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idProducto_in", idMaterial);          
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }

        private static bool ActualizarCosto(Taller taller)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            ///PROCEDIMIENTO
            string proceso = "ActualizarCosto";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idTaller_in", taller.idTaller);
            cmd.Parameters.AddWithValue("CostoTotal_in", taller.CostoTotal);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }

        public static bool RegistrarHistorial(Taller taller, int idTaller)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarHistorialDeTaller";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (idTaller > 0)
            { cmd.Parameters.AddWithValue("idTaller_in", idTaller); }
            else
            { cmd.Parameters.AddWithValue("idTaller_in", taller.idTaller); }
            cmd.Parameters.AddWithValue("Fecha_in", taller.Fecha);
            cmd.Parameters.AddWithValue("Diagnostico_in", taller.Diagnostico);
            cmd.Parameters.AddWithValue("idUsuario_in", taller.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();         
            return exito;
        }        
        private static void ActualizarEstadoMaterial(Taller taller)
        {
            connection.Close();
            connection.Open();
            ///PROCEDIMIENTO
            string proceso = "ActualizarEstadoMaterial";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idMaterial_in", taller.idMaterial);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static bool ValidarEstadoDelMaterial(int idMaterial)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            List<Usuario> lista = new List<Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idMaterial_in", idMaterial) };
            string proceso = "ValidarEstadoDelMaterial";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        public static List<Taller> ListaDeTaller()
        {
            connection.Close();
            connection.Open();
            List<Entidades.Taller> _listaTaller = new List<Entidades.Taller>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ListaDeTaller";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Taller listaTaller = new Entidades.Taller();
                    listaTaller.idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                    listaTaller.idTaller = Convert.ToInt32(item["idTaller"].ToString());
                    listaTaller.TipoServicio = item["TipoServicio"].ToString();
                    listaTaller.Diagnostico = item["Diagnostico"].ToString();
                    listaTaller.Fecha = Convert.ToDateTime(item["FechaInicio"].ToString());
                    listaTaller.Material = item["Material"].ToString();
                    listaTaller.Codigo = item["Codigo"].ToString();
                    listaTaller.Modelo = item["Modelo"].ToString();
                    _listaTaller.Add(listaTaller);
                }
            }
            connection.Close();
            return _listaTaller;
        }
        public static List<Taller> BuscarHistorialPorId(int idHistorialTallerSeleccionado)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Taller> _listaTaller = new List<Entidades.Taller>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idHistorialTallerSeleccionado_in", idHistorialTallerSeleccionado) };
            string proceso = "BuscarHistorialPorId";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Taller listaTaller = new Entidades.Taller();
                    listaTaller.idTaller = Convert.ToInt32(item["idHistorialTaller"].ToString());
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

        public static List<Taller> ListaTaller;
        public static List<Taller> ListarHistorialTaller(int idTallerSeleccionado)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Taller> _listaTaller = new List<Entidades.Taller>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idTallerSeleccionado_in", idTallerSeleccionado) };
            string proceso = "ListarHistorialDeTaller";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Taller listaTaller = new Entidades.Taller();
                    listaTaller.idTaller = Convert.ToInt32(item["idHistorialTaller"].ToString());
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
    }
}
