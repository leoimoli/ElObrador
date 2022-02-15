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
    public partial class NuevoHistorialWF : Form
    {
        private int idTaller;
        private string funcion;
        public NuevoHistorialWF(int idTaller, string funcion)
        {
            InitializeComponent();
            this.idTaller = idTaller;
            this.funcion = funcion;
            lblidTaller.Text = Convert.ToString(idTaller);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool Exito = false;
                Taller _taller = CargarEntidad();
                if (funcion == "Cierre")
                { Exito = TallerNeg.RegistrarCierreHistorialDeTaller(_taller); }
                else
                { Exito = TallerNeg.RegistrarHistorialDeTaller(_taller); }

                if (Exito == true)
                {
                    ProgressBar();
                    const string message2 = "Se registro el nuevo historial de taller exitosamente.";
                    const string caption2 = "Éxito";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            { }
        }

        private void LimpiarCampos()
        {
            txtCosto.Clear();
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
            _taller.idTaller = Convert.ToInt32(lblidTaller.Text);
            _taller.Fecha = dtFecha.Value;
            _taller.Diagnostico = txtDiagnostico.Text;
            _taller.idUsuario = idusuarioLogueado;
            if (txtCosto.Text != "")
            {
                _taller.CostoTotal = Convert.ToDecimal(txtCosto.Text);
            }
            return _taller;
        }

        private void NuevoHistorialWF_Load(object sender, EventArgs e)
        {
            if (funcion == "Cierre")
            {
                dtFecha.Focus();
                lblCosto.Visible = true;
                txtCosto.Visible = true;
                txtDiagnostico.Text = "El material sale de taller y queda en disponibilidad.";
            }
            else
            {
                dtFecha.Focus();
                lblCosto.Visible = false;
                txtCosto.Visible = false;
                txtDiagnostico.Text = "";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = Convert.ToString(txtDiagnostico.Text.Length);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
