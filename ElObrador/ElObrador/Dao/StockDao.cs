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
    public class StockDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool ValidarCodigoExistente(string codigo)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Codigo_in", codigo) };
            string proceso = "ValidarCodigoExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            if (Existe == false)
            {
                Existe = ValidarCodigoExistenteEnProductos(codigo);
            }
            connection.Close();
            return Existe;
        }
        public static bool ValidarProductoExistente(string codigo)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Codigo_in", codigo) };
            string proceso = "ValidarProductoExistentePorCodigo";
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
        public static bool InsertarProducto(Stock stock)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaProducto";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idGrupo_in", stock.idGrupo);
            cmd.Parameters.AddWithValue("idCategoria_in", stock.idCategoria);
            cmd.Parameters.AddWithValue("Descripcion_in", stock.Descripcion);
            cmd.Parameters.AddWithValue("Codigo_in", stock.Codigo);
            cmd.Parameters.AddWithValue("Modelo_in", stock.Modelo);
            cmd.Parameters.AddWithValue("FechaDeCompra_in", stock.FechaDeCompra);
            cmd.Parameters.AddWithValue("Monto_in", stock.Monto);
            cmd.Parameters.AddWithValue("Factura_in", stock.Factura);
            cmd.Parameters.AddWithValue("idProveedor_in", stock.idProveedor);
            cmd.Parameters.AddWithValue("FechaDeAlta_in", stock.FechaDeAlta);
            cmd.Parameters.AddWithValue("idUsuario_in", stock.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        private static bool ValidarCodigoExistenteEnProductos(string codigo)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Codigo_in", codigo) };
            string proceso = "ValidarCodigoExistenteEnProductos";
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
    }
}
