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
    public partial class MaterialWF : Form
    {
        public MaterialWF()
        {
            InitializeComponent();
        }

        private void MaterialWF_Load(object sender, EventArgs e)
        {
            try
            {
                CargarComboGrupo();
            }
            catch (Exception ex)
            { }
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
        public static int idGrupoSeleccionado = 0;
        public static int idCategoria = 0;
        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvLista.Rows.Clear();
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
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategoria.Text != "Seleccione")
                {
                    dgvLista.Rows.Clear();
                    idCategoria = CategoriaDao.BuscarIdCategoria(cmbCategoria.Text);
                    ListaMaterialesDeLaCategoria(idCategoria);
                }
                else
                { }

            }
            catch (Exception ex)
            { }
        }
        private void ListaMaterialesDeLaCategoria(object idCategoriaSeleccionado)
        {
            List<Stock> ListaStock = StockNeg.ListaMaterialesDeLaCategoria(idCategoria);
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static int idProductoSeleccionado = 0;
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLista.CurrentCell.ColumnIndex == 4)
            {
                idProductoSeleccionado = Convert.ToInt32(this.dgvLista.CurrentRow.Cells[0].Value.ToString());
                
                string idProd = dgvLista.CurrentRow.Cells[0].Value.ToString();
                string Material = dgvLista.CurrentRow.Cells[1].Value.ToString();
                string Codigo = dgvLista.CurrentRow.Cells[2].Value.ToString();
                string Modelo = dgvLista.CurrentRow.Cells[3].Value.ToString();

                //CODIGO SOLO PERMITE 2 INSTANCIAS DEL FORMULARIO CLIENTES
                //---------------------------------------------
                int existe = Application.OpenForms.OfType<TallerWF>().Count();              
                if (existe >= 2)
                {
                    Application.OpenForms["TallerWF"].Close();
                }
                if (existe <= 2)
                {
                    TallerWF frm2 = Application.OpenForms.OfType<TallerWF>().SingleOrDefault();
                    if (frm2 != null)
                    {
                        frm2.txtDescripcionProducto.Text = Material;
                        frm2.txtCodigo.Text = Codigo;
                        frm2.txtModelo.Text = Modelo;
                        frm2.lblidProducto.Text = idProd;
                        frm2.IniciarPantalla();
                        Close();
                    }
                    //FacturacionSubClientesWF frm = new FacturacionSubClientesWF(null, null);
                    //frm.Show();
                }
                else
                {
                    foreach (var item in Application.OpenForms.OfType<TallerWF>())
                    {
                        item.BringToFront();
                    }
                }
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
    }
}
