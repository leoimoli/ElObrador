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
    public partial class TallerWF : Form
    {
        public TallerWF()
        {
            InitializeComponent();
        }

        private void txtDescripcionProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel1.Visible = true;
            panelVer.Visible = false;
            cmbTipoServicio.Focus();
            CargarComboServicio();
            MaterialWF _material = new MaterialWF();
            _material.Show();
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

        private void TallerWF_Load(object sender, EventArgs e)
        {
            try
            {
                panelVer.Enabled = true;
                txtDescipcionBus.Focus();
                FuncionListarMaterialesEnTaller();
                FuncionBuscartexto();
            }
            catch (Exception ex)
            { }
        }

        private void FuncionBuscartexto()
        {
            txtDescipcionBus.AutoCompleteCustomSource = Clases_Maestras.AutoCompleteMateriales.Autocomplete();
            txtDescipcionBus.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDescipcionBus.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void FuncionListarMaterialesEnTaller()
        {
            //FuncionBuscartexto();
            dgvTaller.Rows.Clear();
            List<Taller> ListaTaller = TallerNeg.ListaDeTaller();
            if (ListaTaller.Count > 0)
            {
                foreach (var item in ListaTaller)
                {

                    dgvTaller.Rows.Add(item.idTaller, item.Material, item.Codigo, item.Modelo);
                }
            }
            dgvTaller.ReadOnly = true;
        }

        public void IniciarPantalla()
        {
            //CargarCombos();
            ////BuscarFacturaParaClienteSeleccionado();
            //dtFecha.Enabled = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = Convert.ToString(txtDiagnostico.Text.Length);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Taller _taller = CargarEntidad();

                bool Exito = TallerNeg.RegistrarIngresoEnTaller(_taller);
                if (Exito == true)
                {
                    ProgressBar();
                    const string message2 = "Se registro el ingreso a taller exitosamente.";
                    const string caption2 = "Éxito";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                    LimpiarCampos();
                    FuncionListarMaterialesEnTaller();
                }
            }
            catch (Exception ex)
            { }
        }
        private void LimpiarCampos()
        {
            txtDescripcionProducto.Clear();
            txtModelo.Clear();
            txtCodigo.Clear();
            CargarComboServicio();
            dtFecha.Value = DateTime.Now;
            txtDiagnostico.Clear();
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
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
        private Taller CargarEntidad()
        {
            Taller _taller = new Taller();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            _taller.idMaterial = Convert.ToInt32(lblidProducto.Text);
            _taller.TipoServicio = cmbTipoServicio.Text;
            _taller.Fecha = dtFecha.Value;
            _taller.Diagnostico = txtDiagnostico.Text;
            _taller.idUsuario = idusuarioLogueado;
            return _taller;
        }
        public static int idTallerSeleccionado = 0;
        public static int idHistorialTallerSeleccionado = 0;
        private void dgvTaller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTaller.CurrentCell.ColumnIndex == 4)
            {
                dgvHistorialTaller.Rows.Clear();
                idTallerSeleccionado = Convert.ToInt32(this.dgvTaller.CurrentRow.Cells[0].Value.ToString());
                bool TallerAbierto = TallerDao.ValidarEstadoTaller(idTallerSeleccionado);
                if (TallerAbierto == true)
                {
                    panelVer.Enabled = true;
                    lblidTaller.Text = Convert.ToString(idTallerSeleccionado);
                    panel1.Visible = false;
                    panelVer.Visible = true;
                    List<Taller> ListaHistorialTaller = TallerNeg.ListarHistorialTaller(idTallerSeleccionado);
                    if (ListaHistorialTaller.Count > 0)
                    {
                        foreach (var item in ListaHistorialTaller)
                        {
                            dgvHistorialTaller.Rows.Add(item.idTaller, item.Fecha, item.Usuario);
                        }

                    }
                }
                else
                {
                    panelVer.Enabled = false;
                    const string message2 = "Atención: El taller seleccionado se encuentra cerrado.";
                    const string caption2 = "Atención";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                }
            }
        }

        private void dgvTaller_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvTaller.Columns[e.ColumnIndex].Name == "Ver" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvTaller.Rows[e.RowIndex].Cells["Ver"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-cursor-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvTaller.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvTaller.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;
                e.Handled = true;
            }
        }

        private void btnNuevoHistorial_Click(object sender, EventArgs e)
        {
            int idTaller = Convert.ToInt32(lblidTaller.Text);
            Funcion = "";
            NuevoHistorialWF _historial = new NuevoHistorialWF(idTaller, Funcion);
            _historial.Show();
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
                this.dgvHistorialTaller.Columns[e.ColumnIndex].Width = icoAtomico.Width + 40;
                e.Handled = true;
            }
        }
        private void dgvHistorialTaller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHistorialTaller.CurrentCell.ColumnIndex == 3)
            {
                idHistorialTallerSeleccionado = Convert.ToInt32(this.dgvHistorialTaller.CurrentRow.Cells[0].Value.ToString());
                lblidTaller.Text = Convert.ToString(idHistorialTallerSeleccionado);
                List<Taller> ListaHistorialTaller = TallerNeg.BuscarHistorialPorId(idHistorialTallerSeleccionado);
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
                        idTaller = item.idTaller;
                        Descripcion = item.Diagnostico;
                    }
                    VisualizarHistorialWF _visualizar = new VisualizarHistorialWF(Material, Fecha, idTaller, Descripcion);
                    _visualizar.Show();
                }
            }
        }
        public static string Funcion;
        private void btnSalidaTaller_Click(object sender, EventArgs e)
        {
            //panelVer.Enabled = false;
            int idTaller = Convert.ToInt32(lblidTaller.Text);
            bool TallerAbierto = TallerDao.ValidarEstadoTaller(idTaller);
            if (TallerAbierto == true)
            {
                Funcion = "Cierre";
                NuevoHistorialWF _historial = new NuevoHistorialWF(idTaller, Funcion);
                _historial.Show();
            }
            else
            { FuncionListarMaterialesEnTaller(); }
        }
        private void txtDescipcionBus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FuncionListarMaterialesEnTallerPorDescripcion();
            }
        }
        private void FuncionListarMaterialesEnTallerPorDescripcion()
        {
            dgvTaller.Rows.Clear();
            List<Taller> ListaTaller = TallerNeg.ListaDeTallerPorDescripcion(txtDescipcionBus.Text);
            if (ListaTaller.Count > 0)
            {
                foreach (var item in ListaTaller)
                {

                    dgvTaller.Rows.Add(item.idTaller, item.Material, item.Codigo, item.Modelo);
                }
            }
            dgvTaller.ReadOnly = true;
        }
        
        private void cmbTipoServicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void panelVer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
