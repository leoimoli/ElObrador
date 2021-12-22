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
    }
}
