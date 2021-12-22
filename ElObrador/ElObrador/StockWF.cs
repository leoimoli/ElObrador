using ElObrador.Dao;
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
    public partial class StockWF : Form
    {
        public StockWF()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Funciones 1 Nuevo 
        /// </summary>
        public static int Funcion = 0;
        public static int idProductoSeleccionado = 0;
        private void btnRegistroStock_Click(object sender, EventArgs e)
        {
            idProductoSeleccionado = 0;
            Funcion = 1;
            txtDescripcionProducto.Clear();
            txtDescripcionProducto.Focus();
            PanelNuevoMaterial.Visible = true;
            PanelNuevoMaterial.Enabled = true;
            CargarComboGrupo();
            BuscarProveedores();
        }

        private void BuscarProveedores()
        {
            txtProveedor.AutoCompleteCustomSource = Clases_Maestras.ListarProveedores.Autocomplete();
            txtProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarComboGrupo()
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
        private void btnCrerarProveedor_Click(object sender, EventArgs e)
        {
        }
        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            GrupoWF _grupo = new GrupoWF();
            _grupo.Show();
        }
        private void btnCrearCategoria_Click(object sender, EventArgs e)
        {
            CategoriaWF _categoria = new CategoriaWF();
            _categoria.Show();
        }
        private void SoloNumerosyDecimales(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            //e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back);
        }

        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Grupo = cmbGrupo.Text;
            int idGrupo = GrupoDao.BuscarIdGrupo(Grupo);
            CargarComboCategoria(idGrupo);
            //_categoria.idGrupo = idGrupo;
        }
        private void CargarComboCategoria(int idGrupo)
        {
            List<string> Categoria = new List<string>();
            Categoria = CategoriaDao.CargarComboCategoria(idGrupo);
            cmbCategoria.Items.Clear();
            cmbCategoria.Text = "Seleccione";
            cmbCategoria.Items.Add("Seleccione");
            foreach (string item in Categoria)
            {
                cmbCategoria.Text = "Seleccione";
                cmbCategoria.Items.Add(item);

            }
        }
    }
}
