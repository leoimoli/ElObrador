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
    public class ReparacionesDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);

        public static bool RegistrarIngresoEnReparacion(Reparaciones taller)
        {
            int idTaller = 0;
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarIngresoEnReparacion";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Material_in", taller.Material);
            cmd.Parameters.AddWithValue("Codigo_in", taller.Codigo);
            cmd.Parameters.AddWithValue("Modelo_in", taller.Modelo);
            cmd.Parameters.AddWithValue("TipoServicio_in", taller.TipoServicio);
            cmd.Parameters.AddWithValue("Fecha_in", taller.Fecha);
            cmd.Parameters.AddWithValue("Diagnostico_in", taller.Diagnostico);
            cmd.Parameters.AddWithValue("idUsuario_in", taller.idUsuario);
            cmd.Parameters.AddWithValue("idCliente_in", taller.idCliente);
        
            cmd.ExecuteReader();
            exito = true;
            return exito;
        }
    }
}
