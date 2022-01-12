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
                cmd.ExecuteNonQuery();
            }
            exito = true;
            connection.Close();
            return exito;
        }
    }
}
