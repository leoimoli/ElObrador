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
    public partial class ReparacionesWF : Form
    {
        public ReparacionesWF()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Reparaciones _taller = CargarEntidad();

                bool Exito = ReparacionesNeg.RegistrarIngresoEnTaller(_taller);
                if (Exito == true)
                {
                    ProgressBar();
                    const string message2 = "Se registro el ingreso a taller exitosamente.";
                    const string caption2 = "Éxito";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                    LimpiarCampos();
                    FuncionListarReparaciones();
                }
            }
            catch (Exception ex)
            { }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtModelo.Clear();
            txtDescripcionProducto.Clear();
            txtDiagnostico.Enabled = false;
            dtFecha.Value = DateTime.Now;
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
            CargarComboServicio();
            textBox1.Clear();
            txtPorDni.Clear();
            lblidCliente.Text = "0";
            panel1.Enabled = false;
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
        private Reparaciones CargarEntidad()
        {
            Reparaciones _taller = new Reparaciones();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            int idCliente = Convert.ToInt32(lblidCliente.Text);
            if (idCliente == 0)
            {
                const string message = "Atención: Debe seleccionar un cliente";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            else
            {
                _taller.idCliente = idCliente;
            }
            _taller.Material = txtDescripcionProducto.Text;
            _taller.Codigo = txtCodigo.Text;
            _taller.Modelo = txtModelo.Text;
            _taller.TipoServicio = cmbTipoServicio.Text;
            _taller.Fecha = dtFecha.Value;
            _taller.Diagnostico = txtDiagnostico.Text;
            _taller.idUsuario = idusuarioLogueado;
            return _taller;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarClientePorDescripcion();
            }
        }
        private void BuscarClientePorDescripcion()
        {
            dgvReparaciones.Rows.Clear();
            string Descripcion = textBox1.Text;
            string Ape = Descripcion.Split(',')[0];
            string Nom = Descripcion.Split(',')[1];
            List<Entidades.Clientes> ListaClientes = ClientesNeg.BuscarClientePorApellidoNombre(Ape, Nom);
            if (ListaClientes.Count > 0)
            {
                foreach (var item in ListaClientes)
                {
                    lblidCliente.Text = Convert.ToString(item.IdCliente);
                    //string Apellido = item.Apellido;
                    //string Nombre = item.Nombre;
                    //string Persona = Apellido + "," + Nombre;
                    //string Domicilio = item.Calle + "N°" + item.Altura;
                    //dgvReparaciones.Rows.Add(item.IdCliente, Persona, Domicilio, item.Email, item.Telefono);
                }
            }
            dgvReparaciones.ReadOnly = true;
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
            dgvReparaciones.Rows.Clear();
            string Dni = txtPorDni.Text;
            List<Entidades.Clientes> ListaClientes = ClientesNeg.BuscarClientePorDni(Dni);
            if (ListaClientes.Count > 0)
            {
                foreach (var item in ListaClientes)
                {
                    lblidCliente.Text = Convert.ToString(item.IdCliente);
                    //string Apellido = item.Apellido;
                    //string Nombre = item.Nombre;
                    //string Persona = Apellido + "," + Nombre;
                    //string Domicilio = item.Calle + "N°" + item.Altura;
                    //dgvReparaciones.Rows.Add(item.IdCliente, Persona, Domicilio, item.Email, item.Telefono);
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
            dgvReparaciones.ReadOnly = true;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel1.Visible = true;
            panelVer.Visible = false;
            textBox1.Focus();
            CargarComboServicio();
        }
        private void CargarComboServicio()
        {
            string[] Perfiles = Clases_Maestras.ValoresConstantes.TipoServicio;
            cmbTipoServicio.Items.Add("Seleccione");
            cmbTipoServicio.Items.Clear();
            foreach (string item in Perfiles)
            {
                cmbTipoServicio.Text = "Seleccione";
                cmbTipoServicio.Items.Add(item);
            }
        }

        private void txtDiagnostico_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = Convert.ToString(txtDiagnostico.Text.Length);
        }

        private void ReparacionesWF_Load(object sender, EventArgs e)
        {
            try
            {
                txtDescipcionBus.Focus();
                FuncionListarReparaciones();
                FuncionBuscartexto();
            }
            catch (Exception ex)
            { }
        }

        private void FuncionListarReparaciones()
        {
            dgvReparaciones.Rows.Clear();
            List<Reparaciones> ListaReparaciones = ReparacionesNeg.ListaDeReparaciones();
            if (ListaReparaciones.Count > 0)
            {
                foreach (var item in ListaReparaciones)
                {
                    dgvReparaciones.Rows.Add(item.idReparaciones, item.Material, item.Codigo, item.Modelo);
                }
            }
            dgvReparaciones.ReadOnly = true;
        }

        private void FuncionBuscartexto()
        {
            txtDescipcionBus.AutoCompleteCustomSource = Clases_Maestras.AutoCompletePorMaterialesReparaciones.Autocomplete();
            txtDescipcionBus.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDescipcionBus.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public static int idReparacionSeleccionado = 0;
        public static int idHistorialReparacionSeleccionado = 0;
        private void dgvReparaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReparaciones.CurrentCell.ColumnIndex == 4)
            {
                dgvHistorialTaller.Rows.Clear();
                idReparacionSeleccionado = Convert.ToInt32(this.dgvReparaciones.CurrentRow.Cells[0].Value.ToString());
                lblidReparacion.Text = Convert.ToString(idReparacionSeleccionado);
                panel1.Visible = false;
                panelVer.Visible = true;
                List<Reparaciones> ListaHistorialTaller = ReparacionesNeg.ListarHistorialReparacion(idReparacionSeleccionado);
                if (ListaHistorialTaller.Count > 0)
                {
                    foreach (var item in ListaHistorialTaller)
                    {
                        dgvHistorialTaller.Rows.Add(item.idReparaciones, item.Fecha, item.Usuario);
                    }

                }
            }
        }
        public static string Funcion;
        private void btnSalidaTaller_Click(object sender, EventArgs e)
        {
            int idTaller = Convert.ToInt32(lblidReparacion.Text);
            Funcion = "Cierre";
            HistorialReparacionWF _historial = new HistorialReparacionWF(idTaller, Funcion);
            _historial.Show();
        }

        private void btnNuevoHistorial_Click(object sender, EventArgs e)
        {
            int idTaller = Convert.ToInt32(lblidReparacion.Text);
            Funcion = "";
            HistorialReparacionWF _historial = new HistorialReparacionWF(idTaller, Funcion);
            _historial.Show();
        }

        private void dgvHistorialTaller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHistorialTaller.CurrentCell.ColumnIndex == 3)
            {
                idHistorialReparacionSeleccionado = Convert.ToInt32(this.dgvHistorialTaller.CurrentRow.Cells[0].Value.ToString());
                lblidReparacion.Text = Convert.ToString(idHistorialReparacionSeleccionado);
                List<Reparaciones> ListaHistorialTaller = ReparacionesNeg.BuscarHistorialPorId(idHistorialReparacionSeleccionado);
                if (ListaHistorialTaller.Count > 0)
                {
                    string Material = "";
                    DateTime Fecha = DateTime.Now;
                    int idTaller = 0;
                    string Descripcion = "";
                    foreach (var item in ListaHistorialTaller)
                    {
                        Material = item.Material;
                        Fecha = item.Fecha;
                        idTaller = item.idReparaciones;
                        Descripcion = item.Diagnostico;
                    }
                    VisualizarHistorialWF _visualizar = new VisualizarHistorialWF(Material, Fecha, idTaller, Descripcion);
                    _visualizar.Show();
                }
            }
        }

        private void dgvReparaciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvReparaciones.Columns[e.ColumnIndex].Name == "Ver" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvReparaciones.Rows[e.RowIndex].Cells["Ver"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-cursor-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvReparaciones.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvReparaciones.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;
                e.Handled = true;
            }
        }

        private void dgvHistorialTaller_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvHistorialTaller.Columns[e.ColumnIndex].Name == "VerHistorial" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvHistorialTaller.Rows[e.RowIndex].Cells["VerHistorial"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-visible-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvHistorialTaller.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvHistorialTaller.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;
                e.Handled = true;
            }
        }

        private void txtDescipcionBus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FuncionListarMaterialesEnReparacionPorDescripcion();
            }
        }

        private void FuncionListarMaterialesEnReparacionPorDescripcion()
        {
            dgvReparaciones.Rows.Clear();
            List<Reparaciones> ListaTaller = ReparacionesNeg.ListaDeReparacionPorDescripcion(txtDescipcionBus.Text);
            if (ListaTaller.Count > 0)
            {
                foreach (var item in ListaTaller)
                {
                    dgvReparaciones.Rows.Add(item.idReparaciones, item.Material, item.Codigo, item.Modelo);
                }
            }
            dgvReparaciones.ReadOnly = true;
        }
        private void cmbTipoServicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
