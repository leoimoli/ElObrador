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
            dgvAlquiler.Rows.Clear();
            dtFechaDesde.Enabled = true;
            dtFechaHasta.Enabled = true;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Stock> ListaValoresObtenidos = ObtenerValores();
                CalcularMontos(ListaValoresObtenidos);
                if (ListaValoresObtenidos.Count > 0)
                {
                    foreach (var item in ListaValoresObtenidos)
                    {
                        dgvAlquiler.Rows.Add(item.idMaterial, item.Descripcion, item.CantidadDiasAlquiler, dtFechaDesde.Value, dtFechaHasta.Value, item.MontoAlquiler);
                    }
                    dtFechaDesde.Enabled = false;
                    dtFechaHasta.Enabled = false;
                }
            }
            catch (Exception ex)
            { }
        }

        private void CalcularMontos(List<Stock> ListaValoresObtenidos)
        {
            bool RestarMedioDia = false;
            int ContadorDiaNoLaboral = 0;
            var inicio = dtFechaDesde.Value;
            var fin = dtFechaHasta.Value;
            int cantidadDias = fin.Subtract(inicio).Days + 1;
            DateTime FechaInicio = dtFechaDesde.Value;
            bool esDomingo = false;
            for (int i = 0; i < cantidadDias; i++)
            {
                FechaInicio = dtFechaDesde.Value.AddDays(+i);
                string dia = FechaInicio.DayOfWeek.ToString();
                if (dia == "Sunday" || dia == "Domingo")
                {
                    esDomingo = true;
                    ContadorDiaNoLaboral = ContadorDiaNoLaboral + 1;
                }
                else
                { esDomingo = false; }
                string FechaString = FechaInicio.ToShortDateString();
                DateTime Fecha = Convert.ToDateTime(FechaString);
                if (dia != "Sunday" && dia != "Domingo")
                {
                    bool ValidarFeriado = AlquilerDao.ValidarFeriadoExistente(Fecha);
                    if (ValidarFeriado == true)
                    {
                        ContadorDiaNoLaboral = ContadorDiaNoLaboral + 1;
                    }
                }
            }
            foreach (var item in ListaValoresObtenidos)
            {
                decimal ValorTotal = item.MontoAlquiler * cantidadDias;
                if (ContadorDiaNoLaboral > 0)
                {
                    decimal ValorAbsoluto = item.MontoAlquiler / 2;
                    ValorAbsoluto = ValorAbsoluto * ContadorDiaNoLaboral;
                    decimal Monto = item.MontoAlquiler * cantidadDias;
                    ValorTotal = Monto - ValorAbsoluto;
                }
                item.MontoAlquiler = ValorTotal;
                item.CantidadDiasAlquiler = cantidadDias;
            }
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
                    _lista.Descripcion = row.Cells[2].Value.ToString();
                    _lista.MontoAlquiler = Convert.ToDecimal(row.Cells[5].Value.ToString());
                    Lista.Add(_lista);
                }
                else
                {

                }
            }
            return Lista;
        }
    }
}
