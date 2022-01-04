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
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            if (exito == true)
            {
                ActualizarEstadoMaterial(taller);
            }
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
    }
}
