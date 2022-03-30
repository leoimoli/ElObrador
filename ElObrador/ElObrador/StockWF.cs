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
///// Estado de los productos
///// 1 Habilitado
///// 2 en Taller
///// 3 Alquilado

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
        public static int idGrupoSeleccionado = 0;
        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Grupo = cmbGrupo.Text;
            int idGrupo = GrupoDao.BuscarIdGrupo(Grupo);
            idGrupoSeleccionado = idGrupo;
            CargarComboCategoria(idGrupo);
            //_categoria.idGrupo = idGrupo;
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

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Stock _stock = CargarEntidad();
                ProgressBar();
                bool Exito = StockNeg.CargarProducto(_stock);
                if (Exito == true)
                {
                    const string message2 = "Se registro el material exitosamente.";
                    const string caption2 = "Éxito";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                    LimpiarCampos();
                    FuncionListarStock(null);
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
            int idCategoria = 0;
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            if (idGrupoSeleccionado > 0)
            {
                _stock.idGrupo = idGrupoSeleccionado;
            }
            else
            {
                const string message = "El campo Grupo es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            string Categoria = cmbCategoria.Text;
            if (Categoria != "Seleccione")
            {
                idCategoria = CategoriaDao.BuscarIdCategoria(Categoria);
            }
            else
            {
                const string message = "El campo Categoría es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            _stock.idCategoria = idCategoria;
            _stock.Descripcion = txtDescripcionProducto.Text;
            _stock.Modelo = txtModelo.Text;
            _stock.Codigo = txtCodigo.Text;
            _stock.FechaDeCompra = dtFechaCompra.Value;
            if (txtMonto.Text != "")
            {
                _stock.Monto = Convert.ToDecimal(txtMonto.Text);
            }
            else
            { _stock.Monto = 0; }
            DateTime fechaActual = DateTime.Now;
            string proveedor = txtProveedor.Text;
            _stock.idProveedor = ProveedoresDao.BuscarIdProveedor(proveedor);
            _stock.FechaDeAlta = fechaActual;
            _stock.idUsuario = idusuarioLogueado;
            return _stock;
        }
        private void btnCrearCodigo_Click(object sender, EventArgs e)
        {
            string Codigo = "";
            int cadena = 100;
            int numero1 = DateTime.Now.Day;
            int numero2 = DateTime.Now.Month;
            int numero3 = DateTime.Now.Year;
            int Suma1 = numero1 + numero2 + numero2 + numero3;
            Codigo = Convert.ToString(numero1 + numero2 + Suma1 + numero3) + numero1;

            for (int i = 0; i < cadena; i++)
            {
                bool existe = StockDao.ValidarCodigoExistente(Codigo);
                if (existe == true)
                {
                    Suma1 = (numero1 + numero2 + numero2 + numero3 + 10 + i) - 2;
                    Codigo = Convert.ToString(numero1 + numero2 + Suma1 + numero3) + numero1;
                }
                else
                {
                    txtCodigo.Text = Codigo;
                    break;
                }
            }


        }

        private void txtDescripcionProducto_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = Convert.ToString(txtDescripcionProducto.Text.Length);
        }

        private void cmbGrupo_Click(object sender, EventArgs e)
        {
            CargarComboGrupo();
        }

        private void cmbCategoria_Click(object sender, EventArgs e)
        {
            string Grupo = cmbGrupo.Text;
            int idGrupo = GrupoDao.BuscarIdGrupo(Grupo);
            idGrupoSeleccionado = idGrupo;
            CargarComboCategoria(idGrupo);
        }

        private void StockWF_Load(object sender, EventArgs e)
        {
            try
            {
                FuncionListarStock(null);
                FuncionBuscartexto();
            }
            catch (Exception ex)
            { }
        }
        private void FuncionBuscartexto()
        {
            txtDescipcionBus.AutoCompleteCustomSource = Clases_Maestras.AutoCompleteCategoria.Autocomplete();
            txtDescipcionBus.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDescipcionBus.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void FuncionListarStock(string Categoria)
        {
            if (Categoria != null)
            {
                FuncionBuscartexto();
                dgvStock.Rows.Clear();
                List<Stock> ListaProductos = StockNeg.ListarStockPorCategoriaSeleccionada(Categoria);
                if (ListaProductos.Count > 0)
                {
                    foreach (var item in ListaProductos)
                    {
                        string cantidad = Convert.ToString(item.TotalStock);
                        dgvStock.Rows.Add(item.idCategoria, item.Descripcion, cantidad);
                    }
                    // btnEditarProducto.Visible = true;
                }
            }
            else
            {
                FuncionBuscartexto();
                dgvStock.Rows.Clear();
                List<Stock> ListaProductos = StockNeg.ListarStock();
                if (ListaProductos.Count > 0)
                {
                    foreach (var item in ListaProductos)
                    {
                        string cantidad = Convert.ToString(item.TotalStock);
                        dgvStock.Rows.Add(item.idCategoria, item.Descripcion, cantidad);
                    }
                    // btnEditarProducto.Visible = true;
                }
            }
            dgvStock.ReadOnly = true;
        }
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStock.CurrentCell.ColumnIndex == 3)
            {
                idProductoSeleccionado = Convert.ToInt32(this.dgvStock.CurrentRow.Cells[0].Value.ToString());
                string Material = dgvStock.CurrentRow.Cells[1].Value.ToString();
                InformeStockWF frm2 = new InformeStockWF(idProductoSeleccionado);
                frm2.Show();
            }
        }
        private void dgvStock_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvStock.Columns[e.ColumnIndex].Name == "Ver" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvStock.Rows[e.RowIndex].Cells["Ver"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-visible-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvStock.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvStock.Columns[e.ColumnIndex].Width = icoAtomico.Width + 40;
                e.Handled = true;
            }
        }

        private void txtDescipcionBus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Categoria = txtDescipcionBus.Text;
                if (Categoria != "")
                {
                    FuncionListarStock(Categoria);
                }
                {
                    const string message = "Atención: Debe ingresar una categoria para realizar la busqueda..";
                    const string caption = "Atención";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                }
               
            }
        }
    }
}
