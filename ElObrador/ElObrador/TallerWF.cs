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
                    //FuncionListarproveedores();
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
    }
}
