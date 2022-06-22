using ElObrador.Clases_Maestras;
using ElObrador.Dao;
using ElObrador.Entidades;
using ElObrador.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElObrador
{
    public partial class ClientesWF : Form
    {
        public ClientesWF()
        {
            InitializeComponent();
        }

        private void FuncionBuscartexto()
        {
            txtDescipcionBus.AutoCompleteCustomSource = Clases_Maestras.AutoCompletePorApellido.Autocomplete();
            txtDescipcionBus.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDescipcionBus.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void FuncionListarClientes()
        {
            FuncionBuscartexto();
            dgvClientes.Rows.Clear();
            List<Entidades.Clientes> ListaClientes = ClientesNeg.ListaDeClientes();
            if (ListaClientes.Count > 0)
            {
                foreach (var item in ListaClientes)
                {
                    string Apellido = item.Apellido;
                    string Nombre = item.Nombre;
                    string Persona = Apellido + "," + Nombre;
                    string Domicilio = "";

                    if (item.Calle == "" && item.Altura == "")
                    {
                        Domicilio = "";
                    }
                    else
                    {
                        Domicilio = item.Calle + "N°" + item.Altura;
                    }

                    if (item.Telefono == "" || item.Telefono == "-")
                    {
                        item.Telefono = "";
                    }
                    //string Calle = item.Calle;
                    //string Altura = item.Altura;
                    //string Domicilio = Calle + " " + "N° " + item.Altura + ", " + item.NombreProvincia + ", " + item.NombreLocalidad;
                    dgvClientes.Rows.Add(item.IdCliente, Persona, Domicilio, item.Email, item.Telefono);
                }
            }
            dgvClientes.ReadOnly = true;
        }
        private void txtDescipcionBus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarClientePorDescripcion();
            }
        }
        private void BuscarClientePorDescripcion()
        {
            dgvClientes.Rows.Clear();
            string Descripcion = txtDescipcionBus.Text;
            string Ape = Descripcion.Split(',')[0];
            string Nom = Descripcion.Split(',')[1];
            List<Entidades.Clientes> ListaClientes = ClientesNeg.BuscarClientePorApellidoNombre(Ape, Nom);
            if (ListaClientes.Count > 0)
            {
                foreach (var item in ListaClientes)
                {
                    string Apellido = item.Apellido;
                    string Nombre = item.Nombre;
                    string Persona = Apellido + "," + Nombre;
                    //string Domicilio = item.Calle + "N°" + item.Altura;
                    string Domicilio = "";

                    if (item.Calle == "" && item.Altura == "")
                    {
                        Domicilio = "";
                    }
                    else
                    {
                        Domicilio = item.Calle + "N°" + item.Altura;
                    }

                    if (item.Telefono == "" || item.Telefono == "-")
                    {
                        item.Telefono = "";
                    }
                    dgvClientes.Rows.Add(item.IdCliente, Persona, Domicilio, item.Email, item.Telefono);
                }
            }
            dgvClientes.ReadOnly = true;
        }
        private void txtCodigoBus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarClientePorDni();
            }
        }
        private void BuscarClientePorDni()
        {
            dgvClientes.Rows.Clear();
            string Dni = txtCodigoBus.Text;
            List<Entidades.Clientes> ListaClientes = ClientesNeg.BuscarClientePorDni(Dni);
            if (ListaClientes.Count > 0)
            {
                foreach (var item in ListaClientes)
                {
                    string Apellido = item.Apellido;
                    string Nombre = item.Nombre;
                    string Persona = Apellido + "," + Nombre;
                    //string Domicilio = item.Calle + "N°" + item.Altura;
                    string Domicilio = "";

                    if (item.Calle == "" && item.Altura == "")
                    {
                        Domicilio = "";
                    }
                    else
                    {
                        Domicilio = item.Calle + "N°" + item.Altura;
                    }

                    if (item.Telefono == "" || item.Telefono == "-")
                    {
                        item.Telefono = "";
                    }
                    dgvClientes.Rows.Add(item.IdCliente, Persona, Domicilio, item.Email, item.Telefono);
                }
            }
            else
            {
                const string message2 = "No existe ningun cliente con el dni ingresado.";
                const string caption2 = "Atención";
                var result2 = MessageBox.Show(message2, caption2,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Exclamation);
            }
            dgvClientes.ReadOnly = true;
        }
        public static int idClienteSeleccionado = 0;
        public static int Funcion = 0;
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCamposClienteNuevo();
            idClienteSeleccionado = 0;
            Funcion = 1;
            CargarCombo();
            CargarProvincias();
        }
        private void CargarProvincias()
        {
            txtProvincia.AutoCompleteCustomSource = Clases_Maestras.AutoCompleteProvincias.Autocomplete();
            txtProvincia.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProvincia.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void HabilitarCamposClienteNuevo()
        {
            txtDni.Enabled = true;
            txtDni.Focus();
            cmbSexo.Enabled = true;
            txtApellido.Enabled = true;
            txtNombre.Enabled = true;
            txtEmail.Enabled = true;
            txtCodArea.Enabled = true;
            txtTelefono.Enabled = true;
            txtCalle.Enabled = true;
            txtAltura.Enabled = true;
            txtProvincia.Enabled = true;
            txtLocalidad.Enabled = true;
            CargarCombo();
            chcParticular.Enabled = true;
            chcEmpresa.Enabled = true;
        }
        private void LimpiarCampos()
        {
            lblFaltaDocumentacion.Visible = false;
            txtDni.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtCodArea.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtCalle.Clear();
            txtAltura.Clear();
            txtProvincia.Clear();
            txtLocalidad.Clear();
            txtDni.Enabled = false;
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            txtCodArea.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;
            txtCalle.Enabled = false;
            txtAltura.Enabled = false;
            txtProvincia.Enabled = false;
            txtLocalidad.Enabled = false;
            DateTime fecha = DateTime.Now;
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
            cmbSexo.Enabled = false;
            chcFotocopiaDNI.Checked = false;
            chcFacturas.Checked = false;
            chcAgua.Checked = false;
            chcGas.Checked = false;
            chcLuz.Checked = false;
            chcTelefono.Checked = false;
            chcOtros.Checked = false;
            grbTipoFactura.Visible = false;
            chcFotocopiaDNI.Enabled = true;
            chcFacturas.Enabled = true;
            chcAgua.Enabled = true;
            chcGas.Enabled = true;
            chcLuz.Enabled = true;
            chcTelefono.Enabled = true;
            chcOtros.Enabled = true;
            chcAutorizacion.Enabled = true;
            chcPersonaJuridica.Enabled = true;
            chcAutorizacion.Checked = false;
            chcPersonaJuridica.Checked = false;
            CargarCombo();
            CargarProvincias();
        }
        private void CargarCombo()
        {
            string[] Perfiles = Clases_Maestras.ValoresConstantes.Sexo;
            cmbSexo.Items.Add("Seleccione");
            cmbSexo.Items.Clear();
            foreach (string item in Perfiles)
            {
                cmbSexo.Text = "Seleccione";
                cmbSexo.Items.Add(item);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idClienteSeleccionado > 0)
                {
                    Clientes _cliente = CargarEntidadEdicion();
                    bool Exito = ClientesNeg.EditarCliente(_cliente, idClienteSeleccionado);
                    if (Exito == true)
                    {
                        ProgressBar();
                        const string message2 = "La edición del cliente se registro exitosamente.";
                        const string caption2 = "Éxito";
                        var result2 = MessageBox.Show(message2, caption2,
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Asterisk);
                        LimpiarCampos();
                        FuncionListarClientes();
                    }
                }
                else
                {
                    Entidades.Clientes _cliente = CargarEntidad();
                    bool Exito = ClientesNeg.CargarCliente(_cliente);
                    if (Exito == true)
                    {
                        ProgressBar();
                        const string message2 = "Se registro el cliente exitosamente.";
                        const string caption2 = "Éxito";
                        var result2 = MessageBox.Show(message2, caption2,
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Asterisk);
                        LimpiarCampos();
                        FuncionListarClientes();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private Clientes CargarEntidad()
        {
            Clientes _clientes = new Clientes();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            _clientes.idUsuario = idusuarioLogueado;
            _clientes.Dni = txtDni.Text;
            _clientes.Sexo = cmbSexo.Text;
            _clientes.Apellido = txtApellido.Text;
            _clientes.Nombre = txtNombre.Text;
            _clientes.Email = txtEmail.Text;
            _clientes.Telefono = txtCodArea.Text + "-" + txtTelefono.Text;
            DateTime fechaActual = DateTime.Now;
            _clientes.FechaDeAlta = fechaActual;
            _clientes.Calle = txtCalle.Text;
            _clientes.Altura = txtAltura.Text;
            _clientes.idProvincia = idProvinciaSeleccionada;
            _clientes.idLocalidad = idLocalidadSeleccionada;
            if (chcFotocopiaDNI.Checked == true)
            {
                _clientes.chcDni = 1;
            }
            else
            { _clientes.chcDni = 0; }

            if (chcFacturas.Checked == true)
            {
                _clientes.chcFacturas = 1;
            }
            else
            { _clientes.chcFacturas = 0; }

            if (_clientes.chcFacturas == 1)
            {
                if (chcLuz.Checked == false && chcGas.Checked == false && chcAgua.Checked == false && chcTelefono.Checked == false && chcOtros.Checked == false)
                {
                    const string message = "Atención: Debe seleccionar algún tipo de comprobante de factura.";
                    const string caption = "Atención";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    List<String> Lista = new List<string>();
                    if (chcLuz.Checked == true)
                    {
                        _clientes.chcTipoFactura = "Factura de Luz";
                        Lista.Add(_clientes.chcTipoFactura);
                    }
                    if (chcGas.Checked == true)
                    {
                        _clientes.chcTipoFactura = "Factura de Gas";
                        Lista.Add(_clientes.chcTipoFactura);
                    }
                    if (chcAgua.Checked == true)
                    {
                        _clientes.chcTipoFactura = "Factura de Agua";
                        Lista.Add(_clientes.chcTipoFactura);
                    }
                    if (chcTelefono.Checked == true)
                    {
                        _clientes.chcTipoFactura = "Factura de Teléfono";
                        Lista.Add(_clientes.chcTipoFactura);
                    }
                    if (chcOtros.Checked == true)
                    {
                        _clientes.chcTipoFactura = "Factura de Otros";
                        Lista.Add(_clientes.chcTipoFactura);
                    }
                    _clientes.ListaComprobantes = Lista;
                }
            }
            _clientes.FechaDeAlta = fechaActual;
            ////// Asigno Valor Tipo de Cliente Particular o Empresa
            if (chcParticular.Checked == true)
            {
                _clientes.TipoCliente = 1;
            }
            else
            {
                _clientes.TipoCliente = 2;
            }

            if (chcAutorizacion.Checked == true)
            {
                _clientes.chcAutorizacion = 1;
            }
            if (chcPersonaJuridica.Checked == true)
            {
                _clientes.chcPersonaJuridica = 1;
            }
            return _clientes;
        }
        private void ProgressBar()
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = 100000;
            progressBar1.Step = 1;

            for (int j = 0; j < 100000; j++)
            {
                Caluculate(j);
                progressBar1.PerformStep();
            }
        }
        private void Caluculate(int i)
        {
            double pow = Math.Pow(i, i);
        }
        private Clientes CargarEntidadEdicion()
        {
            Clientes _clientes = new Clientes();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            _clientes.idUsuario = idusuarioLogueado;
            _clientes.Dni = txtDni.Text;
            _clientes.Sexo = cmbSexo.Text;
            _clientes.Apellido = txtApellido.Text;
            _clientes.Nombre = txtNombre.Text;
            _clientes.Email = txtEmail.Text;
            _clientes.Telefono = txtCodArea.Text + "-" + txtTelefono.Text;
            _clientes.Calle = txtCalle.Text;
            _clientes.Altura = txtAltura.Text;
            ObtenerProvincia();
            ObtenerLocalidad();
            _clientes.idProvincia = idProvinciaSeleccionada;
            _clientes.idLocalidad = idLocalidadSeleccionada;
            if (chcFotocopiaDNI.Checked == true)
            {
                _clientes.chcDni = 1;
            }
            else
            { _clientes.chcDni = 0; }

            if (chcFacturas.Checked == true)
            {
                _clientes.chcFacturas = 1;
            }
            else
            { _clientes.chcFacturas = 0; }

            if (_clientes.chcFacturas == 1)
            {
                if (chcLuz.Checked == false && chcGas.Checked == false && chcAgua.Checked == false && chcTelefono.Checked == false && chcOtros.Checked == false)
                {
                    const string message = "Atención: Debe seleccionar algún tipo de comprobante de factura.";
                    const string caption = "Atención";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    List<String> Lista = new List<string>();
                    if (chcLuz.Checked == true)
                    {
                        _clientes.chcTipoFactura = "Factura de Luz";
                        if (chcLuz.Enabled == true)
                        {
                            Lista.Add(_clientes.chcTipoFactura);
                        }
                    }
                    if (chcGas.Checked == true)
                    {
                        _clientes.chcTipoFactura = "Factura de Gas";
                        if (chcGas.Enabled == true)
                        {
                            Lista.Add(_clientes.chcTipoFactura);
                        }
                    }
                    if (chcAgua.Checked == true)
                    {
                        _clientes.chcTipoFactura = "Factura de Agua";
                        if (chcAgua.Enabled == true)
                        {
                            Lista.Add(_clientes.chcTipoFactura);
                        }
                    }
                    if (chcTelefono.Checked == true)
                    {
                        _clientes.chcTipoFactura = "Factura de Teléfono";
                        if (chcTelefono.Enabled == true)
                        {
                            Lista.Add(_clientes.chcTipoFactura);
                        }
                    }
                    if (chcOtros.Checked == true)
                    {
                        _clientes.chcTipoFactura = "Factura de Otros";
                        if (chcOtros.Enabled == true)
                        {
                            Lista.Add(_clientes.chcTipoFactura);
                        }
                    }
                    _clientes.ListaComprobantes = Lista;
                }
            }
            if (_clientes.ListaComprobantes != null)
            {
                _clientes.ActualizaComprobanteFactura = 1;
            }
            else
            {
                _clientes.ActualizaComprobanteFactura = 0;
            }

            if (chcAutorizacion.Checked == true)
            {
                _clientes.chcAutorizacion = 1;
                if (chcAutorizacion.Enabled == false)
                { _clientes.ActualizaAutorizacion = 0; }
                else
                { _clientes.ActualizaAutorizacion = 1; }
            }

            if (chcPersonaJuridica.Checked == true)
            {
                _clientes.chcPersonaJuridica = 1;
                if (chcPersonaJuridica.Enabled == false)
                { _clientes.ActualizaPersonaJuridica = 0; }
                else { _clientes.ActualizaPersonaJuridica = 1; }
            }
            return _clientes;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvClientes.RowCount > 0)
            {
                LimpiarCampos();
                Funcion = 2;
                idClienteSeleccionado = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                List<Entidades.Clientes> _clientes = new List<Entidades.Clientes>();
                _clientes = ClientesNeg.BuscarClientePorID(idClienteSeleccionado);
                HabilitarCamposClienteSeleccionado(_clientes);
            }
            else
            {
                const string message2 = "Debe seleccionar un cliente de la grilla.";
                const string caption2 = "Atención";
                var result2 = MessageBox.Show(message2, caption2,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Asterisk);
            }
        }
        public static List<string> ListaTotalComprobantes = new List<string>();
        private void HabilitarCamposClienteSeleccionado(List<Clientes> _cliente)
        {
            CargarCombo();
            CargarProvincias();
            btnGuardar.Visible = true;
            var cliente = _cliente.First();
            txtDni.Text = cliente.Dni;
            txtDni.Enabled = false;
            txtApellido.Text = cliente.Apellido;
            txtNombre.Text = cliente.Nombre;
            txtEmail.Text = cliente.Email;
            txtCalle.Text = cliente.Calle;
            txtAltura.Text = cliente.Altura;
            txtProvincia.Text = cliente.NombreProvincia;
            txtLocalidad.Text = cliente.NombreLocalidad;
            cmbSexo.Text = cliente.Sexo;
            cmbSexo.Enabled = false;
            var telefono = cliente.Telefono;
            string var = telefono.ToString();
            var split1 = var.Split('-')[0];
            split1 = split1.Trim();
            txtCodArea.Text = split1;
            string var2 = telefono.ToString();
            var split2 = var2.Split('-')[1];
            split2 = split2.Trim();
            txtTelefono.Text = split2;
            txtDni.Enabled = true;
            txtDni.Focus();
            cmbSexo.Enabled = true;
            txtApellido.Enabled = true;
            txtNombre.Enabled = true;
            txtEmail.Enabled = true;
            txtCodArea.Enabled = true;
            txtTelefono.Enabled = true;
            txtCalle.Enabled = true;
            txtAltura.Enabled = true;
            txtProvincia.Enabled = true;
            txtLocalidad.Enabled = true;

            if (cliente.TipoCliente == 1)
            {
                chcParticular.Checked = true;
                chcParticular.Enabled = false;
                chcEmpresa.Checked = false;
                chcEmpresa.Enabled = false;
                HabilitarCheckParticular();
            }
            if (cliente.TipoCliente == 2)
            {
                chcParticular.Checked = false;
                chcEmpresa.Checked = true;
                chcEmpresa.Enabled = false;
                chcParticular.Enabled = false;
                HabilitarCheckEmpresa();
            }
            if (cliente.chcAutorizacion == 1)
            {
                chcAutorizacion.Checked = true;
                chcAutorizacion.Enabled = false;
            }
            else
            {
                chcAutorizacion.Checked = false;
                chcAutorizacion.Enabled = true;
            }
            if (cliente.chcPersonaJuridica == 1)
            {
                chcPersonaJuridica.Checked = true;
                chcPersonaJuridica.Enabled = false;
            }
            else
            {
                chcPersonaJuridica.Checked = false;
                chcPersonaJuridica.Enabled = true;
            }

            if (cliente.chcDni == 1)
            {
                chcFotocopiaDNI.Checked = true;
                chcFotocopiaDNI.Enabled = false;
                cliente.ActualizaComprobanteDNI = 0;
                lblFaltaDocumentacion.Visible = false;
            }
            else
            {
                chcFotocopiaDNI.Checked = false;
                chcFotocopiaDNI.Enabled = true;
                cliente.ActualizaComprobanteDNI = 1;
                lblFaltaDocumentacion.Visible = true;
            }
            if (cliente.chcFacturas == 1)
            {
                lblFaltaDocumentacion.Visible = false;
                chcFacturas.Checked = true;
                chcFacturas.Enabled = false;
                grbTipoFactura.Visible = true;
                List<string> ListaComprobantes = new List<string>();
                ListaComprobantes = ClientesDao.ListaComprobantesDeFactura(cliente.IdCliente);
                ListaTotalComprobantes = ListaComprobantes;
                foreach (var item in ListaComprobantes)
                {
                    if (item.ToString() == "Factura de Gas")
                    {
                        chcGas.Checked = true;
                        chcGas.Enabled = false;
                    }
                    //else
                    //{
                    //    chcGas.Checked = false;
                    //    chcGas.Enabled = true;
                    //}
                    if (item.ToString() == "Factura de Agua")
                    {
                        chcAgua.Checked = true;
                        chcAgua.Enabled = false;
                    }
                    //else
                    //{
                    //    chcAgua.Checked = false;
                    //    chcAgua.Enabled = true;
                    //}
                    if (item.ToString() == "Factura de Luz")
                    {
                        chcLuz.Checked = true;
                        chcLuz.Enabled = false;
                    }
                    //else
                    //{
                    //    chcLuz.Checked = false;
                    //    chcLuz.Enabled = true;
                    //}
                    if (item.ToString() == "Factura de Teléfono")
                    {
                        chcTelefono.Checked = true;
                        chcTelefono.Enabled = false;
                    }
                    //else
                    //{
                    //    chcTelefono.Checked = false;
                    //    chcTelefono.Enabled = true;
                    //}
                    if (item.ToString() == "Factura de Otros")
                    {
                        chcOtros.Checked = true;
                        chcOtros.Enabled = false;
                    }
                    //else
                    //{
                    //    chcOtros.Checked = false;
                    //    chcOtros.Enabled = true;
                    //}
                }
                if (cliente.TipoCliente == 2)
                {
                    if (cliente.chcAutorizacion == 1)
                    {
                        lblFaltaDocumentacion.Visible = false;
                    }
                    else
                    {
                        lblFaltaDocumentacion.Visible = true;
                    }
                    if (cliente.chcPersonaJuridica == 1)
                    {
                        if (lblFaltaDocumentacion.Visible == false)
                        {
                            lblFaltaDocumentacion.Visible = false;
                        }
                    }
                    else
                    {
                        lblFaltaDocumentacion.Visible = true;
                    }
                }
                //else
                //{
                //    lblFaltaDocumentacion.Visible = true;
                //}
            }
            else
            {
                //chcFotocopiaDNI.Checked = false;
                chcFacturas.Checked = false;
                chcFacturas.Enabled = true;
                //chcFotocopiaDNI.Enabled = true;
                grbTipoFactura.Visible = false;
                cliente.ActualizaComprobanteFactura = 1;
                lblFaltaDocumentacion.Visible = true;

            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigoBus.Text != "")
            {
                BuscarClientePorDni();
            }
            if (txtDescipcionBus.Text != "")
            {
                BuscarClientePorDescripcion();
            }
        }
        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back);
        }
        public static int idProvinciaSeleccionada;
        //private void txtProvincia_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string provincia = txtProvincia.Text;
        //        if (provincia != "")
        //        {
        //            int idProvincia = ClientesNeg.BuscarIdProvincia(provincia);
        //            CargarLocalidades(idProvincia);
        //            idProvinciaSeleccionada = idProvincia;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private void CargarLocalidades(int idProvincia)
        {
            txtLocalidad.AutoCompleteCustomSource = Clases_Maestras.AutoCompleteLocalidades.Autocomplete(idProvincia);
            txtLocalidad.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtLocalidad.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public static int idLocalidadSeleccionada;
        private void txtLocalidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ObtenerLocalidad();
            }
            catch (Exception ex)
            {
            }
        }

        private void ObtenerLocalidad()
        {
            string localidad = txtLocalidad.Text;
            if (localidad != "")
            {
                List<Clientes> Localidad = new List<Clientes>();
                Localidad = ClientesNeg.BuscarInformacionLocalidad(localidad, idProvinciaSeleccionada);
                var loc = Localidad.First();
                idLocalidadSeleccionada = loc.idLocalidad;
            }
        }

        private void ClientesWF_Load(object sender, EventArgs e)
        {
            try
            {
                FuncionListarClientes();
                FuncionBuscartexto();
            }
            catch (Exception ex)
            { }
        }

        private void txtProvincia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string provincia = txtProvincia.Text;
                    if (provincia != "")
                    {
                        int idProvincia = ClientesNeg.BuscarIdProvincia(provincia);
                        CargarLocalidades(idProvincia);
                        idProvinciaSeleccionada = idProvincia;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void txtProvincia_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerProvincia();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerProvincia()
        {
            string provincia = txtProvincia.Text;
            if (provincia != "")
            {
                int idProvincia = ClientesNeg.BuscarIdProvincia(provincia);
                CargarLocalidades(idProvincia);
                idProvinciaSeleccionada = idProvincia;
            }
        }

        private void cmbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void chcFacturas_CheckedChanged(object sender, EventArgs e)
        {
            if (chcFacturas.Checked == true)
            {
                grbTipoFactura.Visible = true;
            }
            else
            {
                grbTipoFactura.Visible = false;
            }
        }

        private void btnLibreDeuda_Click(object sender, EventArgs e)
        {
            if (this.dgvClientes.RowCount > 0)
            {
                LimpiarCampos();
                idClienteSeleccionado = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
                LibreDeudaWF _libreDeuda = new LibreDeudaWF(idClienteSeleccionado);
                _libreDeuda.Show();
            }
            else
            {
                const string message2 = "Debe seleccionar un cliente de la grilla.";
                const string caption2 = "Atención";
                var result2 = MessageBox.Show(message2, caption2,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Asterisk);
            }
        }

        private void dgvClientes_Click(object sender, EventArgs e)
        {
            FuncionListarLibreDeuda();
        }
        private void FuncionListarLibreDeuda()
        {
            int idCliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value);
            List<Entidades.LibreDeuda> Lista = LibreDeudaNeg.ListarLibreDeuda(idCliente);
            if (Lista.Count > 0)
            {
                decimal MontoSuma = 0;
                decimal MontoResta = 0;
                decimal MontoTotal = 0;
                foreach (var item in Lista)
                {
                    string Monto = Convert.ToString(item.Monto);
                    int Tipo = item.idTipoTarea;
                    string TipoFuncion = "";
                    if (Tipo == 1)
                    {
                        TipoFuncion = "Registro Deuda";
                        MontoResta = MontoResta + item.Monto;
                    }
                    if (Tipo == 2)
                    {
                        TipoFuncion = "Pago Deuda";
                        MontoSuma = MontoSuma + item.Monto;
                    }
                    string Fecha = Convert.ToString(item.Fecha.ToShortDateString());
                    string Motivo = item.Motivo;

                    //dgvLibreDeuda.Rows.Add(item.idLibreDeuda, Monto, TipoFuncion, Fecha, Motivo);
                }
                MontoTotal = MontoResta - MontoSuma;
                if (MontoTotal > 0)
                {
                    btnLibreDeuda.BackColor = Color.Red;
                }
                else
                {
                    btnLibreDeuda.BackColor = Color.Green;
                }
            }
            else { btnLibreDeuda.BackColor = Color.Green; }

        }

        private void chcParticular_CheckedChanged(object sender, EventArgs e)
        {
            if (chcParticular.Checked == true)
            {
                HabilitarCheckParticular();

            }
            else
            {
                HabilitarCheckEmpresa();
            }
        }
        private void HabilitarCheckEmpresa()
        {
            chcParticular.Checked = false;

            lblDniCuit.Text = "Cuit/Cuil de la empresa(*)";
            lblApellido.Text = "Nombre/Razón Social(*)";
            lblSexo.Visible = false;
            cmbSexo.Visible = false;
            txtNombre.Visible = false;
            lblNombre.Visible = false;
            chcPersonaJuridica.Visible = true;
            chcAutorizacion.Visible = true;
        }
        private void HabilitarCheckParticular()
        {
            chcEmpresa.Checked = false;
            //LimpiarCampos();
            //HabilitarCamposClienteNuevo();
            lblDniCuit.Text = "Número Documento(*)";
            lblApellido.Text = "Apellido(*)";
            lblSexo.Visible = true;
            cmbSexo.Visible = true;
            txtNombre.Visible = true;
            lblNombre.Visible = true;
            chcPersonaJuridica.Visible = false;
            chcAutorizacion.Visible = false;
        }
        private void chcEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (chcEmpresa.Checked == true)
            {
                HabilitarCheckEmpresa();
                //LimpiarCampos();
                //HabilitarCamposClienteNuevo();
            }
            else
            {
                HabilitarCheckParticular();
            }
        }
    }
}
