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
    public partial class AlquileresWF : Form
    {
        public AlquileresWF()
        {
            InitializeComponent();
        }

        private void AlquileresWF_Load(object sender, EventArgs e)
        {
            try
            {
                CargarComboGrupo();
                FuncionBuscartexto();
            }
            catch (Exception ex)
            { }
        }
        private void FuncionBuscartexto()
        {
            txtDescipcionBus.AutoCompleteCustomSource = Clases_Maestras.AutoCompleteProducto.Autocomplete();
            txtDescipcionBus.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDescipcionBus.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
        public static int idCategoriaSeleccionado = 0;
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Categoria = cmbCategoria.Text;
            idCategoriaSeleccionado = CategoriaDao.BuscarIdCategoria(Categoria);
            ListaMaterialesDeLaCategoria(null, idCategoriaSeleccionado);
        }
        private void ListaMaterialesDeLaCategoria(string Material, int idCategoriaSeleccionado)
        {
            dataGridView1.Rows.Clear();
            List<Stock> ListaStock = StockNeg.ListaMaterialesDeLaCategoriaParaAlquiler(idCategoriaSeleccionado);
            if (ListaStock.Count > 0)
            {
                dataGridView1.Rows.Clear();
                foreach (var item in ListaStock)
                {
                    dataGridView1.Rows.Add(false, item.idMaterial, item.Descripcion, item.Codigo, item.Modelo, item.MontoAlquiler);
                }
            }
            else
            {

            }
            dataGridView1.ReadOnly = false;
        }
        private void txtDescipcionBus_KeyDown(object sender, KeyEventArgs e)
        {
            string Material = txtDescipcionBus.Text;        
            ListaMateriales(Material);
        }

        private void ListaMateriales(string material)
        {
            dataGridView1.Rows.Clear();
            List<Stock> ListaStock = StockNeg.ListaMaterialesParaAlquiler(material);
            if (ListaStock.Count > 0)
            {
                dataGridView1.Rows.Clear();
                foreach (var item in ListaStock)
                {
                    dataGridView1.Rows.Add(false, item.idMaterial, item.Descripcion, item.Codigo, item.Modelo, item.MontoAlquiler);
                }
            }
            else
            {

            }
            dataGridView1.ReadOnly = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvStock.Rows.Clear();
        }
    }
}
