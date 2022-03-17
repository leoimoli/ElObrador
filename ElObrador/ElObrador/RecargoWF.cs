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
    public partial class RecargoWF : Form
    {
        private int diasAtraso;
        private int idAlquiler;
        private int idMaterial;
        private string material;

        public RecargoWF(int diasAtraso, int idAlquiler, string material, int idMaterial)
        {
            this.diasAtraso = diasAtraso;
            this.idAlquiler = idAlquiler;
            this.idMaterial = idMaterial;
            this.material = material;
            InitializeComponent();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void RecargoWF_Load(object sender, EventArgs e)
        {
            txtMaterial.Text = material;
            txtDias.Text = Convert.ToString(diasAtraso);
            txtMonto.Focus();
        }
        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                AsignarRecargo();               
            }
            catch (Exception ex)
            { }
        }

        private void AsignarRecargo()
        {
            decimal MontoRecargo = Convert.ToDecimal(txtMonto.Text);
            bool Exito = AlquilerNeg.IngresarRecargo(MontoRecargo, idAlquiler, diasAtraso);
            if (Exito == true)
            {
                Exito = AlquilerNeg.ActualizarEstados(idAlquiler, idMaterial);
            }
            if (Exito == true)
            {
                ProgressBar();
                const string message2 = "Se registro el Recargo y la devolución exitosamente.";
                const string caption2 = "Éxito";
                var result2 = MessageBox.Show(message2, caption2,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Asterisk);
                Close();
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

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                AsignarRecargo();
            }
            catch (Exception ex)
            { }
        }
    }
}
