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
    public class ConfiguracionesDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool RegistrarValorAlquiler(List<Stock> listaValoresObtenidos, decimal NuevoValor)
        {
            bool exito = false;
            foreach (var item in listaValoresObtenidos)
            {
                connection.Close();
                connection.Open();
                ///PROCEDIMIENTO
                string proceso = "ActualizarValorAlquiler";
                MySqlCommand cmd = new MySqlCommand(proceso, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idMaterial_in", item.idMaterial);
                cmd.Parameters.AddWithValue("NuevoValor_in", NuevoValor);             
                cmd.ExecuteNonQuery();
                exito = true;
                connection.Close();
                if (exito == true)
                {
                    exito = RegistrarHistorialValorAlquiler(item.idMaterial, NuevoValor);
                }
            }          
            return exito;
        }

        private static bool RegistrarHistorialValorAlquiler(int idMaterial, decimal nuevoValor)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarHistorialValorAlquiler";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idMaterial_in", idMaterial);
            cmd.Parameters.AddWithValue("NuevoValor_in", nuevoValor);
            cmd.Parameters.AddWithValue("idUsuario_in", Sesion.UsuarioLogueado.idUsuario);
            cmd.Parameters.AddWithValue("Fecha_in", DateTime.Now);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
    }
}
