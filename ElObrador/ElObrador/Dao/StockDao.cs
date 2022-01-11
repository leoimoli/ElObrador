using ElObrador.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static List<Stock> BuscarHistorialPrecioPorProducto(int idMaterial)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Stock> _listaStock = new List<Entidades.Stock>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idMaterial_in", idMaterial) };
            string proceso = "BuscarHistorialPrecioPorProducto";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Stock listaStock = new Entidades.Stock();
                    listaStock.idHistorial = Convert.ToInt32(item["idHistorial"].ToString());
                    listaStock.Descripcion = item["NombreProducto"].ToString();
                    listaStock.MontoAlquiler = Convert.ToDecimal(item["Monto"].ToString());
                    listaStock.FechaDeAlta = Convert.ToDateTime(item["Fecha"].ToString());
                    string Apellido = item["Apellido"].ToString();
                    string Nombre = item["Nombre"].ToString();
                    listaStock.NombreUsuario = Apellido + " " + Nombre;
                    _listaStock.Add(listaStock);
                }
            }
            connection.Close();
            return _listaStock;
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

        public static List<Stock> ListarStockPorCategoriaSeleccionada(string categoria)
        {
            int idCategoria = CategoriaDao.BuscarIdCategoria(categoria);
            connection.Close();
            connection.Open();
            List<Entidades.Stock> _listaStock = new List<Entidades.Stock>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idCategoria_in", idCategoria) };
            string proceso = "ListarStockPorCategoriaSeleccionada";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {

                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Stock listaStock = new Entidades.Stock();
                    listaStock.idCategoria = Convert.ToInt32(item["idCategoria"].ToString());
                    listaStock.TotalStock = Convert.ToInt32(item["TotalStock"].ToString());
                    listaStock.Descripcion = item["Descripcion"].ToString();
                    _listaStock.Add(listaStock);
                }
            }
            connection.Close();
            return _listaStock;
        }
        public static List<Stock> ListaMaterialesParaAlquiler(string material)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Stock> _listaStock = new List<Entidades.Stock>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Material_in", material) };
            string proceso = "ListaMaterialesParaAlquiler";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {

                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Stock listaStock = new Entidades.Stock();
                    listaStock.idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                    listaStock.Descripcion = item["Descripcion"].ToString();
                    listaStock.Codigo = item["Codigo"].ToString();
                    listaStock.Modelo = item["Modelo"].ToString();
                    listaStock.MontoAlquiler = Convert.ToDecimal(item["MontoAlquiler"].ToString());
                    _listaStock.Add(listaStock);
                }
            }
            connection.Close();
            return _listaStock;
        }

        public static List<Stock> ListaMaterialesDeLaCategoria(int idCategoriaSeleccionado)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Stock> _listaStock = new List<Entidades.Stock>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idCategoria_in", idCategoriaSeleccionado) };
            string proceso = "ListaMaterialesDeLaCategoria";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {

                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Stock listaStock = new Entidades.Stock();
                    listaStock.idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                    listaStock.Descripcion = item["Descripcion"].ToString();
                    listaStock.Codigo = item["Codigo"].ToString();
                    listaStock.Modelo = item["Modelo"].ToString();
                    listaStock.MontoAlquiler = Convert.ToDecimal(item["MontoAlquiler"].ToString());
                    _listaStock.Add(listaStock);
                }
            }
            connection.Close();
            return _listaStock;
        }
        public static List<Stock> ListaMaterialesDeLaCategoriaParaAlquiler(int idCategoriaSeleccionado)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Stock> _listaStock = new List<Entidades.Stock>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idCategoria_in", idCategoriaSeleccionado) };
            string proceso = "ListaMaterialesDeLaCategoriaParaAlquiler";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {

                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Stock listaStock = new Entidades.Stock();
                    listaStock.idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                    listaStock.Descripcion = item["Descripcion"].ToString();
                    listaStock.Codigo = item["Codigo"].ToString();
                    listaStock.Modelo = item["Modelo"].ToString();
                    listaStock.MontoAlquiler = Convert.ToDecimal(item["MontoAlquiler"].ToString());
                    _listaStock.Add(listaStock);
                }
            }
            connection.Close();
            return _listaStock;
        }
        public static int BuscarIdMaterialPorIdTaller(int idTaller)
        {
            connection.Close();
            connection.Open();
            int idMaterial = 0;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idTaller_in", idTaller) };
            string proceso = "BuscarIdMaterialPorIdTaller";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                }
            }
            connection.Close();
            return idMaterial;
        }

        public static bool EditarProducto(Stock stock, int idMaterialSeleccionado)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "EditarProducto";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idProducto_in", idMaterialSeleccionado);
            cmd.Parameters.AddWithValue("Descripcion_in", stock.Descripcion);
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

        public static List<Stock> BuscarProductoPorId(int idMaterialSeleccionado)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Stock> _listaStock = new List<Entidades.Stock>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idProducto_in", idMaterialSeleccionado) };
            string proceso = "BuscarProductoPorId";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {

                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Stock listaStock = new Entidades.Stock();
                    listaStock.idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                    listaStock.NombreCategoria = item["Categoria"].ToString();
                    listaStock.NombreGrupo = item["Grupo"].ToString();
                    listaStock.Descripcion = item["Descripcion"].ToString();
                    listaStock.Codigo = item["Codigo"].ToString();
                    listaStock.Modelo = item["Modelo"].ToString();
                    listaStock.FechaDeCompra = Convert.ToDateTime(item["FechaCompra"].ToString());
                    listaStock.Factura = item["FacturaRemito"].ToString();
                    listaStock.Monto = Convert.ToDecimal(item["Monto"].ToString());
                    listaStock.NombreProveedor = item["Proveedor"].ToString();
                    _listaStock.Add(listaStock);
                }
            }
            connection.Close();
            return _listaStock;
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
            cmd.Parameters.AddWithValue("Estado_in", 1);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }

        public static List<Stock> ListarStock()
        {
            connection.Close();
            connection.Open();
            List<Entidades.Stock> _listaStock = new List<Entidades.Stock>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ListarStock";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            if (Tabla.Rows.Count > 0)
            {

                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Stock listaStock = new Entidades.Stock();
                    listaStock.idCategoria = Convert.ToInt32(item["idCategoria"].ToString());
                    listaStock.TotalStock = Convert.ToInt32(item["TotalStock"].ToString());
                    listaStock.Descripcion = item["Descripcion"].ToString();
                    _listaStock.Add(listaStock);
                }
            }
            connection.Close();
            return _listaStock;
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
