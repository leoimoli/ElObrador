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
    public class GrupoDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool InsertarGrupo(Grupo grupo)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaGrupo";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Nombre_in", grupo.Nombre);
            cmd.Parameters.AddWithValue("FechaAlta_in", grupo.FechaAlta);
            cmd.Parameters.AddWithValue("idUsuario_in", grupo.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool ValidarGrupoExistente(string nombre)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Nombre_in", nombre) };
            string proceso = "ValidarGrupoExistente";
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

        public static int BuscarIdGrupo(string grupo)
        {
            connection.Close();
            connection.Open();
            int idGrupo = 0;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                       new MySqlParameter("Nombre_in", grupo)};
            string proceso = "BuscarIdGrupo";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    idGrupo = Convert.ToInt32(item["idGrupo"].ToString());
                }
            }
            connection.Close();
            return idGrupo;
        }
        public static List<string> CargarComboGrupo()
        {
            connection.Close();
            connection.Open();
            List<string> _Grupos = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "CargarComboGrupo";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    string Perfil = item["Nombre"].ToString();
                    _Grupos.Add(Perfil);
                }
            }
            connection.Close();
            return _Grupos;
        }
    }
}
