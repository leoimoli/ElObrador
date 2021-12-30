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
    public class ClientesDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool InsertCliente(Clientes _cliente)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaCliente";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Dni_in", _cliente.Dni);
            cmd.Parameters.AddWithValue("Sexo_in", _cliente.Sexo);
            cmd.Parameters.AddWithValue("Apellido_in", _cliente.Apellido);
            cmd.Parameters.AddWithValue("Nombre_in", _cliente.Nombre);
            cmd.Parameters.AddWithValue("Email_in", _cliente.Email);
            cmd.Parameters.AddWithValue("Telefono_in", _cliente.Telefono);
            cmd.Parameters.AddWithValue("FechaDeAlta_in", _cliente.FechaDeAlta);
            cmd.Parameters.AddWithValue("Calle_in", _cliente.Calle);
            cmd.Parameters.AddWithValue("Altura_in", _cliente.Altura);
            cmd.Parameters.AddWithValue("idProvincia_in", _cliente.idProvincia);
            cmd.Parameters.AddWithValue("idLocalidad_in", _cliente.idLocalidad);
            cmd.Parameters.AddWithValue("idUsuario_in", _cliente.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool EditarCliente(Clientes _cliente, int idUsuarioSeleccionado)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "EditarCliente";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idClientes_in", idUsuarioSeleccionado);
            cmd.Parameters.AddWithValue("Apellido_in", _cliente.Apellido);
            cmd.Parameters.AddWithValue("Nombre_in", _cliente.Nombre);
            cmd.Parameters.AddWithValue("Email_in", _cliente.Email);
            cmd.Parameters.AddWithValue("Telefono_in", _cliente.Telefono);
            cmd.Parameters.AddWithValue("Calle_in", _cliente.Calle);
            cmd.Parameters.AddWithValue("Altura_in", _cliente.Altura);
            cmd.Parameters.AddWithValue("idProvincia_in", _cliente.idProvincia);
            cmd.Parameters.AddWithValue("idLocalidad_in", _cliente.idLocalidad);
            cmd.Parameters.AddWithValue("idUsuario_in", _cliente.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static List<Entidades.Clientes> ListarClientes()
        {
            connection.Close();
            connection.Open();
            List<Entidades.Clientes> _listaClientes = new List<Entidades.Clientes>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ListarClientes";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Clientes listaCliente = new Entidades.Clientes();
                    listaCliente.IdCliente = Convert.ToInt32(item["idClientes"].ToString());
                    listaCliente.Apellido = item["Apellido"].ToString();
                    listaCliente.Nombre = item["Nombre"].ToString();
                    listaCliente.Dni = item["Dni"].ToString();
                    listaCliente.FechaDeAlta = Convert.ToDateTime(item["FechaDeAlta"].ToString());
                    listaCliente.Email = item["Email"].ToString();
                    listaCliente.Telefono = item["Telefono"].ToString();
                    listaCliente.Calle = item["Calle"].ToString();
                    listaCliente.Altura = item["Altura"].ToString();
                    listaCliente.NombreProvincia = item["Provincia"].ToString();
                    listaCliente.NombreLocalidad = item["Localidad"].ToString();
                    _listaClientes.Add(listaCliente);
                }
            }
            connection.Close();
            return _listaClientes;
        }
        public static List<Entidades.Clientes> BuscarClientePorApellidoNombre(string apellido, string nombre)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Clientes> _listaClientes = new List<Entidades.Clientes>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Apellido_in", apellido),
            new MySqlParameter("Nombre_in", nombre)};
            string proceso = "BuscarClientePorApellidoNombre";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Clientes listaCliente = new Entidades.Clientes();
                    listaCliente.IdCliente = Convert.ToInt32(item["idClientes"].ToString());
                    listaCliente.Apellido = item["Apellido"].ToString();
                    listaCliente.Nombre = item["Nombre"].ToString();
                    listaCliente.Dni = item["Dni"].ToString();
                    listaCliente.FechaDeAlta = Convert.ToDateTime(item["FechaDeAlta"].ToString());
                    listaCliente.Email = item["Email"].ToString();
                    listaCliente.Telefono = item["Telefono"].ToString();
                    listaCliente.Calle = item["Calle"].ToString();
                    listaCliente.Altura = item["Altura"].ToString();
                    listaCliente.NombreProvincia = item["Provincia"].ToString();
                    listaCliente.NombreLocalidad = item["Localidad"].ToString();
                    _listaClientes.Add(listaCliente);
                }
            }
            connection.Close();
            return _listaClientes;
        }
        public static List<Entidades.Clientes> BuscarClientePorDni(string dni)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Clientes> _listaClientes = new List<Entidades.Clientes>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
            new MySqlParameter("Dni_in", dni)};
            string proceso = "BuscarClientePorDni";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Clientes listaCliente = new Entidades.Clientes();
                    listaCliente.IdCliente = Convert.ToInt32(item["idClientes"].ToString());
                    listaCliente.Apellido = item["Apellido"].ToString();
                    listaCliente.Nombre = item["Nombre"].ToString();
                    listaCliente.Dni = item["Dni"].ToString();
                    listaCliente.FechaDeAlta = Convert.ToDateTime(item["FechaDeAlta"].ToString());
                    listaCliente.Email = item["Email"].ToString();
                    listaCliente.Telefono = item["Telefono"].ToString();
                    listaCliente.Calle = item["Calle"].ToString();
                    listaCliente.Altura = item["Altura"].ToString();
                    listaCliente.NombreProvincia = item["Provincia"].ToString();
                    listaCliente.NombreLocalidad = item["Localidad"].ToString();
                    _listaClientes.Add(listaCliente);
                }
            }
            connection.Close();
            return _listaClientes;
        }
        public static List<Entidades.Clientes> BuscarClientePorID(int idClienteSeleccionado)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Clientes> lista = new List<Entidades.Clientes>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idClientes_in", idClienteSeleccionado)};
            string proceso = "BuscarClientePorID";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Clientes listaCliente = new Entidades.Clientes();
                    listaCliente.IdCliente = Convert.ToInt32(item["idClientes"].ToString());
                    listaCliente.Dni = item["Dni"].ToString();
                    listaCliente.Sexo = item["Sexo"].ToString();
                    listaCliente.Apellido = item["Apellido"].ToString();
                    listaCliente.Nombre = item["Nombre"].ToString();
                    listaCliente.FechaDeAlta = Convert.ToDateTime(item["FechaDeAlta"].ToString());
                    listaCliente.Email = item["Email"].ToString();
                    listaCliente.Telefono = item["Telefono"].ToString();
                    listaCliente.Calle = item["Calle"].ToString();
                    listaCliente.Altura = item["Altura"].ToString();
                    listaCliente.NombreProvincia = item["Provincia"].ToString();
                    listaCliente.NombreLocalidad = item["Localidad"].ToString();
                    lista.Add(listaCliente);
                }
            }
            connection.Close();
            return lista;
        }
        public static bool ValidarClienteExistente(string dni)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            List<Usuario> lista = new List<Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Dni_in", dni) };
            string proceso = "ValidarClienteExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            // dt.Fill(ds, "clientes");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        public static int BuscarIdProvincia(string provincia)
        {
            connection.Close();
            connection.Open();
            int idProvincia = 0;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("provincia_in", provincia) };
            string proceso = "BuscarIdProvincia";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    idProvincia = Convert.ToInt32(item["idProvincia"].ToString());
                }
            }
            connection.Close();
            return idProvincia;
        }
        public static List<Clientes> BuscarInformacionLocalidad(string localidad, int idProvincia)
        {
            connection.Close();
            connection.Open();
            List<Clientes> _lista = new List<Clientes>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("localidad_in", localidad),
            new MySqlParameter("idProvincia_in", idProvincia)};
            string proceso = "BuscarInformacionLocalidad";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Clientes listaObra = new Clientes();
                    listaObra.idLocalidad = Convert.ToInt32(item["idLocalidad"].ToString());
                    listaObra.NombreLocalidad = item["Nombre"].ToString();
                    //listaObra.CodigoPostalLocalidad = item["CodigoPostal"].ToString();
                    _lista.Add(listaObra);
                }
            }
            connection.Close();
            return _lista;
        }
    }
}
