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

    public class CategoriaDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);

        public static bool InsertarCategoria(Categoria categoria, string CodigoCategoria)
        {
            int idCategoria = 0;
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaCategoria";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Nombre_in", categoria.Nombre);
            cmd.Parameters.AddWithValue("FechaAlta_in", categoria.FechaAlta);
            cmd.Parameters.AddWithValue("idGrupo_in", categoria.idGrupo);
            cmd.Parameters.AddWithValue("idUsuario_in", categoria.idUsuario);
            cmd.Parameters.AddWithValue("CodigoCategoria_in", CodigoCategoria);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                idCategoria = Convert.ToInt32(r["ID"].ToString());
            }
            if (idCategoria > 0)
            {
                exito = RegistrarPrimerValorDeCodigo(CodigoCategoria, idCategoria);
            }
            exito = true;
            connection.Close();
            return exito;
        }

        private static bool RegistrarPrimerValorDeCodigo(string codigoCategoria, int idCategoria)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarPrimerValorDeCodigo";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("LetraCodigo_in", codigoCategoria);
            cmd.Parameters.AddWithValue("idCategoria_in", idCategoria);
            exito = true;
            connection.Close();
            return exito;
        }

        public static bool ValidarCodigoCategoriaExistente(string codigo)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                       new MySqlParameter("Codigo_in", codigo)};
            string proceso = "ValidarCodigoCategoriaExistente";
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
        public static bool ValidarCategoriaExistente(string nombre, int idGrupo)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Nombre_in", nombre),
            new MySqlParameter("idGrupo_in", idGrupo)};
            string proceso = "ValidarCategoriaExistente";
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
        public static List<string> CargarComboCategoria(int idGrupo)
        {
            connection.Close();
            connection.Open();
            List<string> _Grupos = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idGrupo_in", idGrupo) };
            string proceso = "CargarComboCategoria";
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
        public static int BuscarIdCategoria(string categoria)
        {
            connection.Close();
            connection.Open();
            int idGrupo = 0;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                       new MySqlParameter("Nombre_in", categoria)};
            string proceso = "BuscarIdCategoria";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    idGrupo = Convert.ToInt32(item["idCategoria"].ToString());
                }
            }
            connection.Close();
            return idGrupo;
        }
    }
}
