using ElObrador.Clases_Maestras;
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
    public partial class ConsultaClientesWF : Form
    {
        public ConsultaClientesWF()
        {
            InitializeComponent();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ConsultaClientesWF_Load(object sender, EventArgs e)
        {
            try
            {
                txtDni.Select();
                FuncionListarClientes();
                FuncionBuscartexto();
            }
            catch (Exception ex)
            { }
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
                    string Domicilio = item.Calle + "N°" + item.Altura;
                    //string Calle = item.Calle;
                    //string Altura = item.Altura;
                    //string Domicilio = Calle + " " + "N° " + item.Altura + ", " + item.NombreProvincia + ", " + item.NombreLocalidad;
                    dgvClientes.Rows.Add(item.IdCliente, item.Dni, Persona, Domicilio, item.Email, item.Telefono);
                }
            }
            dgvClientes.ReadOnly = true;
        }
        private void FuncionBuscartexto()
        {
            txtDni.AutoCompleteCustomSource = Clases_Maestras.AutoCompletePorApellido.Autocomplete();
            txtDni.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDni.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void dgvClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvClientes.Columns[e.ColumnIndex].Name == "Seleccionar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvClientes.Rows[e.RowIndex].Cells["Seleccionar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-cursor-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvClientes.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvClientes.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;
                e.Handled = true;
            }
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentCell.ColumnIndex == 6)
            {
                int idCliente = Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value.ToString());
                string dni = this.dgvClientes.CurrentRow.Cells[1].Value.ToString();
                string ApellidoNombre = this.dgvClientes.CurrentRow.Cells[2].Value.ToString();

                //CODIGO SOLO PERMITE 2 INSTANCIAS DEL FORMULARIO CLIENTES
                //---------------------------------------------
                int existe = Application.OpenForms.OfType<AlquileresWF>().Count();
                if (existe <= 2)
                {
                    AlquileresWF frm2 = Application.OpenForms.OfType<AlquileresWF>().SingleOrDefault();
                    if (frm2 != null)
                    {
                        frm2.lblidCliente.Text = Convert.ToString(idCliente);
                        frm2.lblDniCliente.Text = dni;
                        frm2.lblApeNom.Text = ApellidoNombre;
                        // frm2.IniciarPantalla();
                        frm2.lblDniCliente.Visible = true;
                        frm2.lblApeNom.Visible = true;
                        frm2.lblClienteFijo.Visible = true;
                        frm2.lblDniFijo.Visible = true;
                        Close();
                    }
                }
                else
                {
                    foreach (var item in Application.OpenForms.OfType<TallerWF>())
                    {
                        item.BringToFront();
                    }
                }
            }
        }
        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string dni = txtDni.Text;
                FuncionListarClientes(dni);
            }
        }
        private void FuncionListarClientes(string dni)
        {
            try
            {
                FuncionBuscartexto();
                dgvClientes.Rows.Clear();
                List<Entidades.Clientes> ListaClientes = ClientesNeg.ListaDeClientesPorDNI(dni);
                if (ListaClientes.Count > 0)
                {
                    foreach (var item in ListaClientes)
                    {
                        string Apellido = item.Apellido;
                        string Nombre = item.Nombre;
                        string Persona = Apellido + "," + Nombre;
                        string Domicilio = item.Calle + "N°" + item.Altura;
                        //string Calle = item.Calle;
                        //string Altura = item.Altura;
                        //string Domicilio = Calle + " " + "N° " + item.Altura + ", " + item.NombreProvincia + ", " + item.NombreLocalidad;
                        dgvClientes.Rows.Add(item.IdCliente, item.Dni, Persona, Domicilio, item.Email, item.Telefono);
                    }
                }
                dgvClientes.ReadOnly = true;
            }
            catch (Exception ex)
            { }
        }
        private void btnCrearPersona_Click(object sender, EventArgs e)
        {
            dgvClientes.Visible = false;
            panelAltaClientes.Visible = true;
            LimpiarCampos();
            HabilitarCamposClienteNuevo();
            CargarCombo();
            CargarProvincias();
            btnVolver.Visible = false;
        }
        private void CargarProvincias()
        {
            txtProvincia.AutoCompleteCustomSource = Clases_Maestras.AutoCompleteProvincias.Autocomplete();
            txtProvincia.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProvincia.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void HabilitarCamposClienteNuevo()
        {
            txtNroDoc.Enabled = true;
            txtNroDoc.Focus();
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
        }
        private void LimpiarCampos()
        {
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
        public static int idProvinciaSeleccionada;
        public static int idLocalidadSeleccionada;
        private Clientes CargarEntidad()
        {
            Clientes _clientes = new Clientes();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            _clientes.idUsuario = idusuarioLogueado;
            _clientes.Dni = txtNroDoc.Text;
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
            _clientes.FechaDeAlta = fechaActual;
            return _clientes;
        }
        private void txtProvincia_TextChanged(object sender, EventArgs e)
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
        private void txtLocalidad_TextChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
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
                    FuncionCancelar();
                }
            }
            catch (Exception ex)
            { }
        }
        private void CargarLocalidades(int idProvincia)
        {
            txtLocalidad.AutoCompleteCustomSource = Clases_Maestras.AutoCompleteLocalidades.Autocomplete(idProvincia);
            txtLocalidad.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtLocalidad.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FuncionCancelar();
        }
        private void FuncionCancelar()
        {
            LimpiarCampos();
            panelAltaClientes.Visible = false;
            dgvClientes.Visible = true;
            FuncionListarClientes();
            btnVolver.Visible = true;
        }
    }
}
