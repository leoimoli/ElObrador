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
    public partial class ConfiguracionesWF : Form
    {
        public ConfiguracionesWF()
        {
            InitializeComponent();
        }

        private void ConfiguracionesWF_Load(object sender, EventArgs e)
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
                }
            }
            dgvStock.ReadOnly = true;
        }
        public static int idCategoriaSeleccionado = 0;
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStock.CurrentCell.ColumnIndex == 3)
            {
                idCategoriaSeleccionado = Convert.ToInt32(this.dgvStock.CurrentRow.Cells[0].Value.ToString());
                string Material = dgvStock.CurrentRow.Cells[1].Value.ToString();
                //idCategoria.Text = Convert.ToString(idCategoriaSeleccionado);
                ListaMaterialesDeLaCategoria(Material, idCategoriaSeleccionado);
            }
        }
        private void ListaMaterialesDeLaCategoria(string Material, int idCategoriaSeleccionado)
        {
            List<Stock> ListaStock = StockNeg.ListaMaterialesDeLaCategoria(idCategoriaSeleccionado);
            if (ListaStock.Count > 0)
            {
                dataGridView1.Rows.Clear();
                PanelPrecios.Enabled = true;
                lblCategoria.Visible = true;
                lblCategoria.Text = Material;
                foreach (var item in ListaStock)
                {
                    dataGridView1.Rows.Add(false, item.idMaterial, item.Descripcion, item.Codigo, item.Modelo, item.MontoAlquiler);
                }
            }
            else
            {
                lblCategoria.Visible = false;
            }
            dataGridView1.ReadOnly = false;
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
        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                decimal NuevoValor = Convert.ToDecimal(txtMonto.Text);
                List<Stock> ListaValoresObtenidos = ObtenerValores();
                if (ListaValoresObtenidos.Count > 0)
                {
                    bool exito = ConfiguracionesNeg.RegistrarValorAlquiler(ListaValoresObtenidos, NuevoValor);
                    if (exito == true)
                    {
                        ProgressBar();
                        const string message2 = "El valor de alquiler se registro exitosamente.";
                        const string caption2 = "Éxito";
                        var result2 = MessageBox.Show(message2, caption2,
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Asterisk);
                        LimpiarCampos();
                        ListaMaterialesDeLaCategoria(lblCategoria.Text, idCategoriaSeleccionado);
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void LimpiarCampos()
        {
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
            txtMonto.Clear();
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
        private List<Stock> ObtenerValores()
        {
            List<Stock> Lista = new List<Stock>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Stock _lista = new Stock();
                bool ck = Convert.ToBoolean(row.Cells[0].Value.ToString());
                if (ck == true)
                {
                    _lista.idMaterial = Convert.ToInt32(row.Cells[1].Value.ToString());
                    _lista.MontoAlquiler = Convert.ToDecimal(row.Cells[5].Value.ToString());
                    Lista.Add(_lista);
                }
                else
                {

                }
            }
            return Lista;
        }

        private void txtDescipcionBus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Categoria = txtDescipcionBus.Text;
                FuncionListarStock(Categoria);
            }
        }
    }
}

