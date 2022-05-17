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
            int idCliente = 0;
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
            cmd.Parameters.AddWithValue("chcDni_in", _cliente.chcDni);
            cmd.Parameters.AddWithValue("chcFacturas_in", _cliente.chcFacturas);
            cmd.Parameters.AddWithValue("chcTipoCliente_in", _cliente.TipoCliente);
            cmd.Parameters.AddWithValue("chcPersonaJuridica_in", _cliente.chcPersonaJuridica);
            cmd.Parameters.AddWithValue("chcAutorizacion_in", _cliente.chcAutorizacion);
            MySqlDataReader r = cmd.ExecuteReader();
            if (_cliente.chcFacturas == 1)
            {
                while (r.Read())
                {
                    idCliente = Convert.ToInt32(r["ID"].ToString());
                }
                exito = RegistrarHistorialComprobantes(idCliente, _cliente.ListaComprobantes);
            }
            else
            {
                exito = true;
            }

            connection.Close();
            return exito;
        }

        public static bool RegistrarPago(LibreDeuda libreDeuda)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarPago";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Monto_in", libreDeuda.Monto);
            cmd.Parameters.AddWithValue("Fecha_in", libreDeuda.Fecha);
            cmd.Parameters.AddWithValue("Motivo_in", libreDeuda.Motivo);
            cmd.Parameters.AddWithValue("FechaActual_in", libreDeuda.FechaActual);
            cmd.Parameters.AddWithValue("idUsuario_in", libreDeuda.idUsuario);
            cmd.Parameters.AddWithValue("idCliente_in", libreDeuda.idCliente);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }

        public static List<LibreDeuda> ListarLibreDeuda(int idClienteSeleccionado)
        {
            connection.Close();
            connection.Open();
            List<Entidades.LibreDeuda> _lista = new List<Entidades.LibreDeuda>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
            new MySqlParameter("idClienteSeleccionado_in", idClienteSeleccionado)};
            string proceso = "ListarLibreDeuda";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.LibreDeuda lista = new Entidades.LibreDeuda();
                    lista.idLibreDeuda = Convert.ToInt32(item["idLibreDeuda"].ToString());
                    lista.Monto = Convert.ToDecimal(item["Monto"].ToString());
                    lista.idTipoTarea = Convert.ToInt32(item["idTipo"].ToString());
                    lista.Fecha = Convert.ToDateTime(item["FechaPago"].ToString());
                    lista.Motivo = item["Motivo"].ToString();
                    _lista.Add(lista);
                }
            }
            connection.Close();
            return _lista;
        }

        public static bool RegistrarDeuda(LibreDeuda libreDeuda)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarDeuda";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Monto_in", libreDeuda.Monto);
            cmd.Parameters.AddWithValue("Fecha_in", libreDeuda.Fecha);
            cmd.Parameters.AddWithValue("Motivo_in", libreDeuda.Motivo);
            cmd.Parameters.AddWithValue("FechaActual_in", libreDeuda.FechaActual);
            cmd.Parameters.AddWithValue("idUsuario_in", libreDeuda.idUsuario);
            cmd.Parameters.AddWithValue("idCliente_in", libreDeuda.idCliente);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        private static bool RegistrarHistorialComprobantes(int idCliente, List<string> chcTipoFactura)
        {
            bool exito = false;
            foreach (var item in chcTipoFactura)
            {
                connection.Close();
                connection.Open();
                string Actualizar = "RegistrarHistorialComprobantes";
                MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idCliente_in", idCliente);
                cmd.Parameters.AddWithValue("chcTipoFactura_in", item);
                cmd.ExecuteNonQuery();
                exito = true;
            }
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
            if (_cliente.chcDni == 1 && _cliente.ActualizaComprobanteDNI == 1)
            {
                cmd.Parameters.AddWithValue("chcDni_in", _cliente.chcDni);
            }
            else if (_cliente.chcDni == 1)
            {
                cmd.Parameters.AddWithValue("chcDni_in", 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("chcDni_in", 0);
            }
            if (_cliente.chcFacturas == 1 && _cliente.ActualizaComprobanteFactura == 1)
            {
                cmd.Parameters.AddWithValue("chcFacturas_in", _cliente.chcFacturas);
            }
            else if (_cliente.chcFacturas == 1)
            {
                cmd.Parameters.AddWithValue("chcFacturas_in", 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("chcFacturas_in", 0);
            }
            cmd.Parameters.AddWithValue("chcPersonaJuridica_in", _cliente.chcPersonaJuridica);
            cmd.Parameters.AddWithValue("chcAutorizacion_in", _cliente.chcAutorizacion);
            cmd.ExecuteNonQuery();
            if (_cliente.ActualizaComprobanteFactura == 1)
            {
                RegistrarHistorialComprobantes(idUsuarioSeleccionado, _cliente.ListaComprobantes);
            }
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
        public static List<Clientes> ListarClientesPorDNI(string dni)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Clientes> _listaClientes = new List<Entidades.Clientes>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Dni_in", dni) };
            string proceso = "ListarClientesPorDNI";
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

        public static List<Clientes> BuscarClientePorIdAlquiler(int idAlquiler)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Clientes> lista = new List<Entidades.Clientes>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idAlquiler_in", idAlquiler)};
            string proceso = "BuscarClientePorIdAlquiler";
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
                    listaCliente.chcDni = Convert.ToInt32(item["chcDNI"].ToString());
                    listaCliente.chcFacturas = Convert.ToInt32(item["chcFacturas"].ToString());
                    listaCliente.TipoCliente = Convert.ToInt32(item["TipoCliente"].ToString());
                    listaCliente.chcPersonaJuridica = Convert.ToInt32(item["chcPersonaJuridica"].ToString());
                    listaCliente.chcAutorizacion = Convert.ToInt32(item["chcAutorizacion"].ToString());
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

        public static List<string> ListaComprobantesDeFactura(int idCliente)
        {
            connection.Close();
            connection.Open();
            List<string> _lista = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idCliente_in", idCliente) };
            string proceso = "ListaComprobantesDeFactura";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    string lista;
                    lista = item["Comprobante"].ToString();
                    _lista.Add(lista);
                }
            }
            connection.Close();
            return _lista;
        }
    }
}
