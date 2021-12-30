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
    public partial class InformeStockWF : Form
    {
        private int idCategoriaSeleccionado;
        public InformeStockWF(int idCategoriaSeleccionado)
        {
            InitializeComponent();
            this.idCategoriaSeleccionado = idCategoriaSeleccionado;
        }

        private void InformeStockWF_Load(object sender, EventArgs e)
        {
            try
            {
                idCategoria.Text = Convert.ToString(idCategoriaSeleccionado);
                ListaMaterialesDeLaCategoria(idCategoriaSeleccionado);
            }
            catch (Exception ex)
            { }
        }
        private void ListaMaterialesDeLaCategoria(int idCategoriaSeleccionado)
        {
            List<Stock> ListaStock = StockNeg.ListaMaterialesDeLaCategoria(idCategoriaSeleccionado);
            if (ListaStock.Count > 0)
            {
                //ListaMaterialesStatic = ListaStock;     
                foreach (var item in ListaStock)
                {
                    dgvLista.Rows.Add(item.idMaterial, item.Descripcion, item.Codigo, item.Modelo);
                }
            }
            dgvLista.ReadOnly = true;
        }
        public static int idProductoSeleccionado = 0;
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLista.CurrentCell.ColumnIndex == 4)
            {
                idProductoSeleccionado = Convert.ToInt32(this.dgvLista.CurrentRow.Cells[0].Value.ToString());
                PanelNuevoMaterial.Visible = true;
            }
        }
        private void dgvStock_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvLista.Columns[e.ColumnIndex].Name == "Ver" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvLista.Rows[e.RowIndex].Cells["Ver"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-visible-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvLista.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvLista.Columns[e.ColumnIndex].Width = icoAtomico.Width + 40;
                e.Handled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static int Funcion = 0;
        public static int idMaterialSeleccionado = 0;
        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            Funcion = 2;
            BuscarProveedores();
            lblNuevoProducto.Text = "Editar Material";
            if (this.dgvLista.RowCount > 0)
            {
                List<Stock> _stock = new List<Stock>();
                idMaterialSeleccionado = Convert.ToInt32(this.dgvLista.CurrentRow.Cells[0].Value);
                _stock = StockNeg.BuscarProductoPorId(idMaterialSeleccionado);
                HabilitarCamposProductoSeleccionado(_stock);
            }
            else
            {
                const string message2 = "Debe seleccionar un Material de la grilla.";
                const string caption2 = "Atención";
                var result2 = MessageBox.Show(message2, caption2,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Asterisk);
            }
        }
        private void BuscarProveedores()
        {
            txtProveedor.AutoCompleteCustomSource = Clases_Maestras.ListarProveedores.Autocomplete();
            txtProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void HabilitarCamposProductoSeleccionado(List<Stock> stock)
        {
            var _stock = stock.First();
            cmbGrupo.Text = _stock.NombreGrupo;
            cmbCategoria.Text = _stock.NombreCategoria;
            txtDescripcionProducto.Text = _stock.Descripcion;
            txtCodigo.Text = _stock.Codigo;
            txtModelo.Text = _stock.Modelo;
            dtFechaCompra.Text = Convert.ToString(_stock.FechaDeCompra);
            txtMonto.Text = Convert.ToString(_stock.Monto);
            txtFacturaRemito.Text = _stock.Factura;
            txtProveedor.Text = _stock.NombreProveedor;

            cmbGrupo.Enabled = false;
            cmbCategoria.Enabled = false;
            txtCodigo.Enabled = false;
            PanelNuevoMaterial.Visible = true;
            PanelNuevoMaterial.Enabled = true;
        }

        private void txtDescripcionProducto_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = Convert.ToString(txtDescripcionProducto.Text.Length);
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Stock _stock = CargarEntidad();
                ProgressBar();
                bool Exito = StockNeg.EditarProducto(_stock, idMaterialSeleccionado);
                if (Exito == true)
                {
                    const string message2 = "Se registro la edición del material exitosamente.";
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
            CargarComboGrupo();
            CargarComboCategoria(0);
            txtDescripcionProducto.Clear();
            txtCodigo.Clear();
            txtMonto.Clear();
            txtModelo.Clear();
            dtFechaCompra.Value = DateTime.Now;
            txtProveedor.Clear();
            txtFacturaRemito.Clear();
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
        }
        private void CargarComboCategoria(int idGrupo)
        {
            if (idGrupo > 0)
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
            else
            {
                List<string> Categoria = new List<string>();
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
        private Stock CargarEntidad()
        {
            Stock _stock = new Stock();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;

            _stock.Descripcion = txtDescripcionProducto.Text;
            _stock.Modelo = txtModelo.Text;
            _stock.FechaDeCompra = dtFechaCompra.Value;
            _stock.Monto = Convert.ToDecimal(txtMonto.Text);
            DateTime fechaActual = DateTime.Now;
            string proveedor = txtProveedor.Text;
            _stock.idProveedor = ProveedoresDao.BuscarIdProveedor(proveedor);
            _stock.FechaDeAlta = fechaActual;
            _stock.idUsuario = idusuarioLogueado;
            return _stock;
        }
    }
}
