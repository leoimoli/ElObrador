﻿using ElObrador.Clases_Maestras;
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
    public class AlquilerDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);

        public static bool ValidarFeriadoExistente(DateTime fechaHasta)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("FechaHasta_in", fechaHasta) };
            string proceso = "ValidarFeriadoExistente";
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
        public static bool IngresarRecargo(decimal montoRecargo, int idAlquiler, int diasAtraso)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarRecargo";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("montoRecargo_in", montoRecargo);
            cmd.Parameters.AddWithValue("idAlquiler_in", idAlquiler);
            cmd.Parameters.AddWithValue("diasAtraso_in", diasAtraso);
            cmd.Parameters.AddWithValue("FechaIngreso_in", DateTime.Now);
            cmd.Parameters.AddWithValue("idUsuario_in", Sesion.UsuarioLogueado.idUsuario);
            cmd.ExecuteNonQuery();
            connection.Close();
            exito = true;
            return exito;
        }
        public static List<Alquiler> ListarAlquileresActualesPorDescripcion(string valor)
        {
            connection.Close();
            connection.Open();
            List<Alquiler> _listaAlquileres = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Valor_in", valor) };
            string proceso = "ListarAlquileresActualesPorDescripcion";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaAlquiler = new Alquiler();
                    listaAlquiler.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    listaAlquiler.idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                    listaAlquiler.DescripcionProducto = item["Material"].ToString();
                    listaAlquiler.Dias = Convert.ToInt32(item["Dias"].ToString());
                    listaAlquiler.FechaDesde = Convert.ToDateTime(item["FechaDesde"].ToString());
                    listaAlquiler.FechaHasta = Convert.ToDateTime(item["FechaHasta"].ToString());
                    _listaAlquileres.Add(listaAlquiler);
                }
            }
            connection.Close();
            return _listaAlquileres;
        }

        public static List<MontoAlquiler> BuscarMontoAlquilerParaMaterial(List<Alquiler> detallealquiler)
        {
            List<MontoAlquiler> _listaMonto = new List<MontoAlquiler>();
            foreach (var item in detallealquiler)
            {
                connection.Close();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = { new MySqlParameter("idMaterial_in", item.idMaterial) };
                string proceso = "BuscarMontoAlquilerParaMaterial";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow itemResultado in Tabla.Rows)
                    {
                        MontoAlquiler listMonto = new MontoAlquiler();
                        listMonto.idMaterial = Convert.ToInt32(itemResultado["idProducto"].ToString());
                        listMonto.Material = itemResultado["Descripcion"].ToString();
                        listMonto.Monto = Convert.ToDecimal(itemResultado["MontoAlquiler"].ToString());
                        listMonto.Codigo = itemResultado["Codigo"].ToString();
                        listMonto.Modelo = itemResultado["Modelo"].ToString();
                        _listaMonto.Add(listMonto);
                    }
                }
            }
            connection.Close();
            return _listaMonto;
        }

        public static bool ValidarDisponibilidadMateriales(List<Alquiler> detallealquiler)
        {
            connection.Close();
            bool MaterialDisponible = true;
            foreach (var item in detallealquiler)
            {
                connection.Close();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = {
                                      new MySqlParameter("idMaterial_in", item.idMaterial) };
                string proceso = "ValidarEstadoDelMaterial";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                DataSet ds = new DataSet();
                if (Tabla.Rows.Count > 0)
                {
                    MaterialDisponible = false;
                    break;
                }
            }
            return MaterialDisponible;
        }

        public static List<Alquiler> BuscarAlquileresFinalizados(int estadoAlquiler)
        {
            connection.Close();
            connection.Open();
            List<Alquiler> _listaAlquileres = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("EstadoAlquiler_in", estadoAlquiler) };
            string proceso = "ListarAlquileresFinalizados";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaAlquiler = new Alquiler();
                    listaAlquiler.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    listaAlquiler.idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                    listaAlquiler.DescripcionProducto = item["Material"].ToString();
                    listaAlquiler.Dias = Convert.ToInt32(item["Dias"].ToString());
                    listaAlquiler.FechaDesde = Convert.ToDateTime(item["FechaDesde"].ToString());
                    listaAlquiler.FechaHasta = Convert.ToDateTime(item["FechaHasta"].ToString());
                    listaAlquiler.AlquilerPagado = Convert.ToInt32(item["AlquilerPagado"].ToString());
                    listaAlquiler.idCliente = Convert.ToInt32(item["idCliente"].ToString());
                    listaAlquiler.Cliente = Convert.ToString(item["Apellido"].ToString() + "," + item["Nombre"].ToString());
                    _listaAlquileres.Add(listaAlquiler);
                }
            }
            connection.Close();
            return _listaAlquileres;
        }

        public static List<Alquiler> ListarAlquileresActualesPorCliente(string valor)
        {
            connection.Close();
            connection.Open();
            string Apellido = valor.Split(',')[0];
            string Nombre = valor.Split(',')[1];
            List<Alquiler> _listaAlquileres = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Apellido_in", Apellido),
             new MySqlParameter("Nombre_in", Nombre)};
            string proceso = "ListarAlquileresActualesPorCliente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaAlquiler = new Alquiler();
                    listaAlquiler.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    listaAlquiler.idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                    listaAlquiler.DescripcionProducto = item["Material"].ToString();
                    listaAlquiler.Dias = Convert.ToInt32(item["Dias"].ToString());
                    listaAlquiler.FechaDesde = Convert.ToDateTime(item["FechaDesde"].ToString());
                    listaAlquiler.FechaHasta = Convert.ToDateTime(item["FechaHasta"].ToString());
                    listaAlquiler.AlquilerPagado = Convert.ToInt32(item["AlquilerPagado"].ToString());
                    listaAlquiler.idCliente = Convert.ToInt32(item["idCliente"].ToString());
                    listaAlquiler.Cliente = Convert.ToString(item["Apellido"].ToString() + "," + item["Nombre"].ToString());
                    _listaAlquileres.Add(listaAlquiler);
                }
            }
            connection.Close();
            return _listaAlquileres;
        }

        public static bool ActualizarEstados(int idAlquiler, int idMaterial)
        {
            bool exito = false;
            //connection.Close();
            //connection.Open();

            //// Busco los IdMaterial por el idAlquiler
            List<Alquiler> listaId = new List<Alquiler>();
            listaId = BuscarMaterialesPorIdAlquiler(idAlquiler);

            ///PROCEDIMIENTO
            foreach (var item in listaId)
            {
                connection.Close();
                connection.Open();
                string proceso2 = "ActualizarEstadoDelMaterial";
                MySqlCommand cmd2 = new MySqlCommand(proceso2, connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("idMaterial_in", item.idMaterial);
                cmd2.ExecuteNonQuery();
                connection.Close();
                exito = true;
            }

            //////Valido si el alquiler tiene mas materiales asociados.
            //int ValidarCierreAlquiler = ValidarEstadoAlquiler(idAlquiler);

            //if (exito == true && ValidarCierreAlquiler == 0)
            if (exito == true)
            {
                connection.Close();
                connection.Open();
                ///PROCEDIMIENTO
                string proceso = "ActualizarCierreDeAlquiler";
                MySqlCommand cmd = new MySqlCommand(proceso, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idAlquiler_in", idAlquiler);
                cmd.Parameters.AddWithValue("FechaDevolucion_in", DateTime.Now);
                cmd.ExecuteNonQuery();
                connection.Close();
                exito = true;
            }
            return exito;
        }

        private static int ValidarEstadoAlquiler(int idAlquiler)
        {
            connection.Close();
            connection.Open();
            int idMaterial = 0;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idAlquiler_in", idAlquiler) };
            string proceso = "ValidarEstadoAlquiler";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
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

        public static List<Alquiler> ListarAlquileresActuales()
        {
            connection.Close();
            connection.Open();
            List<Alquiler> _listaAlquileres = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ListarAlquileresActuales";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaAlquiler = new Alquiler();
                    listaAlquiler.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    listaAlquiler.idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                    listaAlquiler.DescripcionProducto = item["Material"].ToString();
                    listaAlquiler.Dias = Convert.ToInt32(item["Dias"].ToString());
                    listaAlquiler.FechaDesde = Convert.ToDateTime(item["FechaDesde"].ToString());
                    listaAlquiler.FechaHasta = Convert.ToDateTime(item["FechaHasta"].ToString());
                    listaAlquiler.AlquilerPagado = Convert.ToInt32(item["AlquilerPagado"].ToString());
                    listaAlquiler.idCliente = Convert.ToInt32(item["idCliente"].ToString());
                    listaAlquiler.Cliente = Convert.ToString(item["Apellido"].ToString() + "," + item["Nombre"].ToString());
                    _listaAlquileres.Add(listaAlquiler);
                }
            }
            connection.Close();
            return _listaAlquileres;
        }
        public static int RegistrarAlquiler(List<Alquiler> listaAlquiler)
        {
            int idAlquiler = 0;
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarAlquiler";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idCliente_in", listaAlquiler[0].idCliente);
            cmd.Parameters.AddWithValue("FechaDesde_in", listaAlquiler[0].FechaDesde);
            cmd.Parameters.AddWithValue("FechaHasta_in", listaAlquiler[0].FechaHasta);
            cmd.Parameters.AddWithValue("Dias_in", listaAlquiler[0].Dias);
            cmd.Parameters.AddWithValue("MontoTotal_in", listaAlquiler[0].MontoTotal);
            cmd.Parameters.AddWithValue("FechaRegistro_in", DateTime.Now);
            cmd.Parameters.AddWithValue("idUsuario_in", Sesion.UsuarioLogueado.idUsuario);
            cmd.Parameters.AddWithValue("Estado_in", listaAlquiler[0].Estado);
            cmd.Parameters.AddWithValue("AlquilerPagado_in", listaAlquiler[0].AlquilerPagado);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                idAlquiler = Convert.ToInt32(r["ID"].ToString());
            }
            exito = true;
            connection.Close();
            if (idAlquiler > 0)
            {
                exito = RegistrarDetalleAlquiler(listaAlquiler, idAlquiler);
                if (exito == true)
                { ActualizarEstadoProducto(listaAlquiler); }
            }
            return idAlquiler;
        }

        private static void ActualizarEstadoProducto(List<Alquiler> listaAlquiler)
        {
            foreach (var item in listaAlquiler)
            {
                connection.Close();
                connection.Open();
                ///PROCEDIMIENTO
                string proceso = "ActualizarEstadoMaterialAlquilado";
                MySqlCommand cmd = new MySqlCommand(proceso, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idMaterial_in", item.idMaterial);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }

        private static bool RegistrarDetalleAlquiler(List<Alquiler> listaAlquiler, int idAlquiler)
        {
            bool exito = false;
            foreach (var item in listaAlquiler)
            {
                connection.Close();
                connection.Open();
                string proceso = "RegistrarDetalleAlquiler";
                MySqlCommand cmd = new MySqlCommand(proceso, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idMaterial_in", item.idMaterial);
                cmd.Parameters.AddWithValue("idAlquiler_in", idAlquiler);
                cmd.Parameters.AddWithValue("Observacion_in", item.Observacion);
                cmd.ExecuteNonQuery();
            }
            exito = true;
            connection.Close();
            return exito;
        }

        public static List<Alquiler> BuscarMaterialesPorIdAlquiler(int idAlquiler)
        {
            connection.Close();
            connection.Open();
            List<Alquiler> _listaAlquileres = new List<Alquiler>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idAlquiler_in", idAlquiler) };
            string proceso = "BuscarMaterialesPorIdAlquiler";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Alquiler listaAlquiler = new Alquiler();
                    listaAlquiler.idAlquiler = Convert.ToInt32(item["idAlquiler"].ToString());
                    listaAlquiler.idMaterial = Convert.ToInt32(item["idProducto"].ToString());
                    listaAlquiler.Codigo = item["Codigo"].ToString();
                    listaAlquiler.Modelo = item["Modelo"].ToString();
                    listaAlquiler.DescripcionProducto = item["Material"].ToString();
                    listaAlquiler.Dias = Convert.ToInt32(item["Dias"].ToString());
                    //listaAlquiler.FechaDesde = Convert.ToDateTime(item["FechaDesde"].ToString());
                    //listaAlquiler.FechaHasta = Convert.ToDateTime(item["FechaHasta"].ToString());
                    _listaAlquileres.Add(listaAlquiler);
                }
            }
            connection.Close();
            return _listaAlquileres;
        }

        public static string BuscaMontoAlquiler(int idAlquiler)
        {
            connection.Close();
            connection.Open();
            string MontoAlquiler = "0";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idAlquiler_in", idAlquiler) };
            string proceso = "BuscaMontoAlquiler";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    MontoAlquiler = item["MontoTotal"].ToString();
                }
            }
            connection.Close();
            return MontoAlquiler;
        }
    }
}
