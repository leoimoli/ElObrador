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
        public static List<ListaAlquiler> ConsultarAlquileresDelDia()
        {
            connection.Close();
            connection.Open();
            List<ListaAlquiler> lista = new List<ListaAlquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ConsultarAlquileresDelDia";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    ListaAlquiler listaVenta = new ListaAlquiler();
                    listaVenta.idAlquiler = Convert.ToInt32(item["idventas"].ToString());
                    DateTime fechaReal = Convert.ToDateTime(item["FechaDesde"].ToString());
                    listaVenta.Fecha = Convert.ToDateTime(fechaReal.ToShortDateString());
                    listaVenta.Precio = Convert.ToDecimal(item["MontoTotal"].ToString());
                    var usuario = item["Apellido"].ToString() + " " + item["Nombre"].ToString();
                    listaVenta.usuario = usuario;
                    lista.Add(listaVenta);
                }
            }
            return lista;
        }
        public static List<ListaAlquiler> ConsultarAlquilerDeAyer()
        {
            connection.Close();
            connection.Open();
            List<ListaAlquiler> lista = new List<ListaAlquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ConsultarAlquilerDeAyer";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    ListaAlquiler listaVenta = new ListaAlquiler();
                    listaVenta.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    DateTime fechaReal = Convert.ToDateTime(item["Fechadesde"].ToString());
                    listaVenta.Fecha = Convert.ToDateTime(fechaReal.ToShortDateString());
                    listaVenta.Precio = Convert.ToDecimal(item["MontoTotal"].ToString());
                    var usuario = item["Apellido"].ToString() + " " + item["Nombre"].ToString();
                    listaVenta.usuario = usuario;
                    lista.Add(listaVenta);
                }
            }
            return lista;
        }
        public static List<ListaAlquiler> ConsultarVentasUltimos30Dias(DateTime fechaDesde, DateTime fechaHasta)
        {
            connection.Close();
            connection.Open();
            List<ListaAlquiler> lista = new List<ListaAlquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {   new MySqlParameter("FechaDesde_in", fechaDesde),
                                       new MySqlParameter("FechaHasta_in", fechaHasta)};
            string proceso = "ConsultarAlquilerUltimos30Dias";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    ListaAlquiler listaVenta = new ListaAlquiler();
                    listaVenta.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    DateTime fechaReal = Convert.ToDateTime(item["Fechadesde"].ToString());
                    listaVenta.Fecha = Convert.ToDateTime(fechaReal.ToShortDateString());
                    listaVenta.Precio = Convert.ToDecimal(item["MontoTotal"].ToString());
                    var usuario = item["Apellido"].ToString() + " " + item["Nombre"].ToString();
                    listaVenta.usuario = usuario;
                    lista.Add(listaVenta);
                }
            }
            return lista;
        }
        public static List<ListaAlquiler> ConsultarVentasMesActual(int mes)
        {
            connection.Close();
            connection.Open();
            List<ListaAlquiler> lista = new List<ListaAlquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Mes_in", mes) };
            string proceso = "ConsultarAlquilersMesActual";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    ListaAlquiler listaVenta = new ListaAlquiler();
                    listaVenta.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    DateTime fechaReal = Convert.ToDateTime(item["Fechadesde"].ToString());
                    listaVenta.Fecha = Convert.ToDateTime(fechaReal.ToShortDateString());
                    listaVenta.Precio = Convert.ToDecimal(item["MontoTotal"].ToString());
                    var usuario = item["Apellido"].ToString() + " " + item["Nombre"].ToString();
                    listaVenta.usuario = usuario;
                    lista.Add(listaVenta);
                }
            }
            return lista;
        }
        public static List<ListaAlquiler> ConsultarAlquilerPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            connection.Close();
            connection.Open();
            List<ListaAlquiler> lista = new List<ListaAlquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("FechaDesde_in", fechaDesde),
                                       new MySqlParameter("FechaHasta_in", fechaHasta)};
            string proceso = "ConsultarAlquilerPorFecha";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    ListaAlquiler listaVenta = new ListaAlquiler();
                    listaVenta.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    DateTime fechaReal = Convert.ToDateTime(item["Fechadesde"].ToString());
                    listaVenta.Fecha = Convert.ToDateTime(fechaReal.ToShortDateString());
                    listaVenta.Precio = Convert.ToDecimal(item["MontoTotal"].ToString());
                    var usuario = item["Apellido"].ToString() + " " + item["Nombre"].ToString();
                    listaVenta.usuario = usuario;
                    lista.Add(listaVenta);
                }
            }
            connection.Close();
            return lista;
        }

        public static List<ListaAlquiler> ConsultarVentasMesAnterior(int mes)
        {
            connection.Close();
            connection.Open();
            List<ListaAlquiler> lista = new List<ListaAlquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Mes_in", mes) };
            string proceso = "ConsultarAlquilerMesAnterior";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    ListaAlquiler listaVenta = new ListaAlquiler();
                    listaVenta.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    DateTime fechaReal = Convert.ToDateTime(item["Fechadesde"].ToString());
                    listaVenta.Fecha = Convert.ToDateTime(fechaReal.ToShortDateString());
                    listaVenta.Precio = Convert.ToDecimal(item["MontoTotal"].ToString());
                    var usuario = item["Apellido"].ToString() + " " + item["Nombre"].ToString();
                    listaVenta.usuario = usuario;
                    lista.Add(listaVenta);
                }
            }
            return lista;
        }

        public static List<ListaAlquiler> ConsultarVentasUltimosSieteDias(DateTime fechaDesde, DateTime fechaHasta)
        {
            connection.Close();
            connection.Open();
            List<ListaAlquiler> lista = new List<ListaAlquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("FechaDesde_in", fechaDesde),
                                       new MySqlParameter("FechaHasta_in", fechaHasta)};
            string proceso = "ConsultarAlquilerUltimosSieteDias";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    ListaAlquiler listaVenta = new ListaAlquiler();
                    listaVenta.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    DateTime fechaReal = Convert.ToDateTime(item["Fechadesde"].ToString());
                    listaVenta.Fecha = Convert.ToDateTime(fechaReal.ToShortDateString());
                    listaVenta.Precio = Convert.ToDecimal(item["MontoTotal"].ToString());
                    var usuario = item["Apellido"].ToString() + " " + item["Nombre"].ToString();
                    listaVenta.usuario = usuario;
                    lista.Add(listaVenta);
                }
            }
            return lista;
        }
        public static List<Alquiler> TotalDeAlquileres()
        {
            connection.Close();
            connection.Open();
            List<Alquiler> _listaventas = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "TotalDeAlquileres";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaVentas = new Alquiler();
                    listaVentas.TotalDeAlquleresGenerales = Convert.ToInt32(item["Total"].ToString());
                    _listaventas.Add(listaVentas);
                }
            }
            connection.Close();
            return _listaventas;
        }
        public static List<Proveedores> PagosCompras()
        {
            connection.Close();
            connection.Open();
            List<Proveedores> _listaCompras = new List<Proveedores>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ConsultaIngresoStock";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            Proveedores listaCompras = new Proveedores();
            decimal CalculoGasto = 0;
            decimal ValorFinal = 0;
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    listaCompras.Monto = Convert.ToDecimal(item["Monto"].ToString());
                    _listaCompras.Add(listaCompras);
                }
            }
            if (_listaCompras.Count > 0)
            {
                foreach (var item in _listaCompras)
                {
                    CalculoGasto = item.Monto;
                    ValorFinal = ValorFinal + CalculoGasto;
                }
                listaCompras.CajaDePagos = ValorFinal;
                _listaCompras.Add(listaCompras);
            }
            else
            {
                listaCompras.CajaDePagos = 0;
                _listaCompras.Add(listaCompras);
            }
            connection.Close();
            return _listaCompras;
        }
        public static List<Proveedores> TotalDeCompras()
        {
            connection.Close();
            connection.Open();
            List<Proveedores> _listaCompras = new List<Proveedores>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "TotalDeCompras";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Proveedores listaCompras = new Proveedores();
                    if (Convert.ToInt32(item["Monto"].ToString()) > 0)
                    {
                        listaCompras.TotalDeComprasGenerales = Convert.ToInt32(item["Monto"].ToString());
                    }
                    else
                    { listaCompras.TotalDeComprasGenerales = 0; }
                    _listaCompras.Add(listaCompras);
                }
            }
            connection.Close();
            return _listaCompras;
        }
        public static List<Alquiler> CajaDeAlquileres()
        {
            connection.Close();
            connection.Open();
            List<Alquiler> _listaventas = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "CajaDeAlquileres";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaVentas = new Alquiler();
                    if (item["Total"].ToString() != null && item["Total"].ToString() != "" && Convert.ToDecimal(item["Total"].ToString()) > 0)
                    {
                        listaVentas.CajaDeAlquileres = Convert.ToDecimal(item["Total"].ToString());
                    }
                    else
                    { listaVentas.CajaDeAlquileres = 0; }
                    _listaventas.Add(listaVentas);
                }
            }
            connection.Close();
            return _listaventas;
        }
        public static List<Alquiler> BuscarProductosMasAlquilado()
        {
            connection.Close();
            connection.Open();
            List<Alquiler> _listaventas = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ProductoMasAlquilado";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaVentas = new Alquiler();
                    listaVentas.DescripcionProducto = item["Descripcion"].ToString();
                    listaVentas.ProductoMasAlquilado = Convert.ToInt32(item["TotalAlquileres"].ToString());
                    _listaventas.Add(listaVentas);
                }
            }
            connection.Close();
            return _listaventas;
        }
        public static List<Alquiler> BuscarAlquileresPorMes()
        {
            String Año = DateTime.Now.Year.ToString();
            string FechaArmadaDesde = "01/01/" + Año;
            DateTime FechaDesde = Convert.ToDateTime(FechaArmadaDesde);
            string FechaArmadaHasta = "31/12/" + Año;
            DateTime FechaHasta = Convert.ToDateTime(FechaArmadaHasta);
            connection.Close();
            connection.Open();
            List<Alquiler> _listaVentas = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("FechaDesde_in", FechaDesde),
            new MySqlParameter("FechaHasta_in", FechaHasta)};
            string proceso = "BuscarAlquilerPorMes";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaVentas = new Alquiler();
                    //listaProveedores.idProveedor = Convert.ToInt32(item["idProducto"].ToString());
                    listaVentas.mes = item["mes"].ToString();
                    if (Convert.ToInt32(item["Alquiler"].ToString()) > 0)
                    {
                        listaVentas.TotalVentasPorMes = Convert.ToInt32(item["Alquiler"].ToString());
                    }
                    else
                    { listaVentas.TotalVentasPorMes = 0; }
                    _listaVentas.Add(listaVentas);
                }
            }
            connection.Close();
            return _listaVentas;
        }
        public static List<Proveedores> BuscarTotalComprasRealizadasProveedores()
        {
            connection.Close();
            connection.Open();
            List<Proveedores> _listaProveedores = new List<Proveedores>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "BuscarTotalComprasRealizadasProveedores";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Proveedores listaProveedores = new Proveedores();
                    listaProveedores.NombreEmpresa = item["Proveedor"].ToString();
                    if (Convert.ToDecimal(item["Total"].ToString()) > 0)
                    {
                        listaProveedores.TotalCompras = Convert.ToDecimal(item["Total"].ToString());
                    }
                    else
                    {
                        listaProveedores.TotalCompras = 0;
                    }
                    _listaProveedores.Add(listaProveedores);
                }
            }
            connection.Close();
            return _listaProveedores;
        }
        public static List<Alquiler> ListadoProductosMasAlquilados()
        {
            connection.Close();
            connection.Open();
            List<Alquiler> _listaventas = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ListadoProductosMasAlquilados";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaVentas = new Alquiler();
                    listaVentas.DescripcionProducto = item["Descripcion"].ToString();
                    listaVentas.ProductoMasAlquilado = Convert.ToInt32(item["TotalAlquileres"].ToString());
                    _listaventas.Add(listaVentas);
                }
            }
            connection.Close();
            return _listaventas;
        }
        public static List<Alquiler> BuscarTodasLosAlquileres()
        {
            String Año = DateTime.Now.Year.ToString();

            string FechaArmadaDesde = "01/01/" + Año;
            DateTime FechaDesde = Convert.ToDateTime(FechaArmadaDesde);

            string FechaArmadaHasta = "31/12/" + Año;
            DateTime FechaHasta = Convert.ToDateTime(FechaArmadaHasta);
            connection.Close();
            connection.Open();
            List<Alquiler> _listaventas = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("FechaDesde_in", FechaDesde),
            new MySqlParameter("FechaHasta_in", FechaHasta)};
            string proceso = "BuscarTodasLosAlquileres";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaVentas = new Alquiler();
                    listaVentas.FechaDesde = Convert.ToDateTime(item["FechaDesde"].ToString());
                    listaVentas.Monto = Convert.ToDecimal(item["MontoTotal"].ToString());
                    _listaventas.Add(listaVentas);
                }
            }
            connection.Close();
            return _listaventas;
        }
        public static List<Proveedores> BuscarMovimientoStock()
        {
            connection.Close();
            connection.Open();
            List<Proveedores> _listaProveedores = new List<Proveedores>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "BuscarMovimientoStock";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Proveedores listaProveedores = new Proveedores();
                    listaProveedores.Fecha = Convert.ToDateTime(item["FechaCompra"].ToString());
                    listaProveedores.Proveedor = item["Proveedor"].ToString();
                    listaProveedores.Remito = item["FacturaRemito"].ToString();
                    _listaProveedores.Add(listaProveedores);
                }
            }
            connection.Close();
            return _listaProveedores;
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
                    { MontoGastadoEnServicios = Convert.ToDecimal(item["Monto"].ToString()); }
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
                    { MontoRecaudado = Convert.ToDecimal(item["Monto"].ToString()); }
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
