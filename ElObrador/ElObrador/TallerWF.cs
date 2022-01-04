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
                FuncionListarMaterialesEnTaller();               
            }
            catch (Exception ex)
            { }
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
                    //string Calle = item.Calle;
                    //string Altura = item.Altura;
                    //string Domicilio = Calle + " " + "N° " + item.Altura;
                    dgvTaller.Rows.Add(item.idMaterial, item.Material, item.Codigo, item.Modelo);
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
        public static int idMaterialSeleccionado = 0;
        private void dgvTaller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTaller.CurrentCell.ColumnIndex == 4)
            {
                panel1.Visible = false;
                panelVer.Visible = true;
            }
        }

        private void dgvTaller_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvTaller.Columns[e.ColumnIndex].Name == "Ver" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvTaller.Rows[e.RowIndex].Cells["Ver"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-visible-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvTaller.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvTaller.Columns[e.ColumnIndex].Width = icoAtomico.Width + 40;
                e.Handled = true;
            }
        }
    }
}
