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
    public partial class GrupoWF : Form
    {
        public GrupoWF()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Grupo _grupo = CargarEntidad();
                bool Exito = GrupoNeg.GuardarGrupo(_grupo);
                if (Exito == true)
                {
                    ProgressBar();
                    const string message2 = "Se registro el grupo exitosamente.";
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
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
            txtGrupo.Clear();
            txtGrupo.Focus();           
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
        private Grupo CargarEntidad()
        {
            Grupo _grupo = new Grupo();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            _grupo.Nombre = txtGrupo.Text;
            _grupo.FechaAlta = DateTime.Now;
            _grupo.idUsuario = idusuarioLogueado;                    
            return _grupo;           
        }
    }
}
