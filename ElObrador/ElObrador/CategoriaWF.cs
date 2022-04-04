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
    public partial class CategoriaWF : Form
    {
        public CategoriaWF()
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
                Categoria _categoria = CargarEntidad();
                bool Exito = CategoriaNeg.GuardarCategoria(_categoria);
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
            CargarCombo();
            txtCategoria.Clear();
            cmbGrupo.Focus();
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
        private Categoria CargarEntidad()
        {
            Categoria _categoria = new Categoria();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            string Grupo = cmbGrupo.Text;
            int idGrupo = GrupoDao.BuscarIdGrupo(Grupo);
            _categoria.Nombre = txtCategoria.Text;
            _categoria.idGrupo = idGrupo;
            _categoria.FechaAlta = DateTime.Now;
            _categoria.idUsuario = idusuarioLogueado;
            return _categoria;
        }

        private void CategoriaWF_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombo();
            }
            catch (Exception ex)
            { }
        }
        private void CargarCombo()
        {
            List<string> Grupo = new List<string>();
            Grupo = GrupoDao.CargarComboGrupo();
            cmbGrupo.Items.Clear();
            cmbGrupo.Text = "Seleccione";
            cmbGrupo.Items.Add("Seleccione");
            foreach (string item in Grupo)
            {
                cmbGrupo.Text = "Seleccione";
                cmbGrupo.Items.Add(item);

            }
        }

        private void cmbGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
