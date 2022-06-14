using ElObrador.Clases_Maestras;
using ElObrador.Dao;
using ElObrador.Entidades;
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
    public partial class Reportes_AlquileresWF : Form
    {
        public Reportes_AlquileresWF()
        {
            InitializeComponent();
        }
        private void Reportes_AlquileresWF_Load(object sender, EventArgs e)
        {
            //int perfil = Sesion.UsuarioLogueado.idPerfil;
            //if (perfil != 1)
            //{
            //    btnEliminar.Visible = false;
            //}
            //else { btnEliminar.Visible = true; }
        }
        private void btnVentasDelDia_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            List<ListaAlquiler> resultado = new List<ListaAlquiler>();
            List<Entidades.ListaAlquilerEstadistica> listaAlquilerEstadistica = new List<ListaAlquilerEstadistica>();
            try
            {
                resultado = ReportesDao.ConsultarAlquileresDelDia();
                if (resultado.Count > 0)
                {
                    ArmoGrilla(resultado);
                }
                else
                {
                    SinResultados();
                }
            }
            catch (Exception ex)
            { }
        }
        private void ArmoGrilla(List<ListaAlquiler> resultado)
        {
            PanelResultado.Visible = true;
            decimal TotalVentas = 0;
            foreach (var item in resultado)
            {
                string fecha = item.Fecha.ToShortDateString();
                TotalVentas = Convert.ToDecimal(TotalVentas + item.Precio);
                dgvVentas.Rows.Add(item.idAlquiler, fecha, item.Precio, item.Recargo);
            }
            /// Total de Alquileres                 
            lblTotalVentas.Text = Convert.ToString(resultado.Count);
            /// Caja de Alquileres
            List<Alquiler> listaVentas3 = new List<Alquiler>();
            listaVentas3 = ReportesDao.CajaDeAlquileres();
            lblCajaVentas.Text = Convert.ToString(TotalVentas);
        }
        private void SinResultados()
        {
            LimpiarCampos();
            const string message2 = "No se encontraron resultados disponibles.";
            const string caption2 = "Atención";
            var result2 = MessageBox.Show(message2, caption2,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Exclamation);
        }
        private void LimpiarCampos()
        {
            lblCajaVentas.Text = "0";
            lblTotalVentas.Text = "0";
            dgvVentas.Rows.Clear();
        }
        private void btnVentasAyer_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            DateTime FechaHasta = DateTime.Now;
            DateTime FechaDesde = FechaHasta.AddDays(-1);
            FechaHasta = FechaDesde;
            List<ListaAlquiler> resultado = new List<ListaAlquiler>();
            List<Entidades.ListaAlquilerEstadistica> listaVentasEstadistica = new List<ListaAlquilerEstadistica>();
            try
            {
                resultado = ReportesDao.ConsultarAlquilerDeAyer();
                if (resultado.Count > 0)
                {
                    ArmoGrilla(resultado);
                }
                else
                { SinResultados(); }
            }
            catch (Exception ex)
            { }
        }
        private void btnVentasUltimosSiete_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            DateTime FechaHasta = DateTime.Now;
            DateTime FechaDesde = FechaHasta.AddDays(-7);
            List<ListaAlquiler> resultado = new List<ListaAlquiler>();
            List<Entidades.ListaAlquilerEstadistica> listaVentasEstadistica = new List<ListaAlquilerEstadistica>();
            try
            {
                resultado = ReportesDao.ConsultarVentasUltimosSieteDias(FechaDesde, FechaHasta);
                if (resultado.Count > 0)
                {
                    ArmoGrilla(resultado);
                }
                else
                { SinResultados(); }
            }
            catch (Exception ex)
            { }
        }

        private void btnUltimosTreinta_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            DateTime FechaHasta = DateTime.Now;
            DateTime FechaDesde = FechaHasta.AddDays(-30);
            List<ListaAlquiler> resultado = new List<ListaAlquiler>();
            List<Entidades.ListaAlquilerEstadistica> listaVentasEstadistica = new List<ListaAlquilerEstadistica>();
            try
            {
                resultado = ReportesDao.ConsultarVentasUltimos30Dias(FechaDesde, FechaHasta);
                if (resultado.Count > 0)
                {
                    ArmoGrilla(resultado);
                }
                else
                { SinResultados(); }
            }
            catch (Exception ex)
            { }
        }

        private void btnEsteMes_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            String MesAnterior = DateTime.Now.Month.ToString();
            String AñoVigente = DateTime.Now.Year.ToString();
            int Mes = Convert.ToInt32(MesAnterior);
            int Año = Convert.ToInt32(AñoVigente);
            List<ListaAlquiler> resultado = new List<ListaAlquiler>();
            List<Entidades.ListaAlquilerEstadistica> listaVentasEstadistica = new List<ListaAlquilerEstadistica>();
            try
            {
                resultado = ReportesDao.ConsultarVentasMesActual(Mes, Año);
                if (resultado.Count > 0)
                {
                    ArmoGrilla(resultado);
                }
                else
                { SinResultados(); }
            }
            catch (Exception ex)
            { }
        }

        private void btnVentasMesAnterior_Click(object sender, EventArgs e)
        {
            int Mes = 0;
            int Año = 0;
            LimpiarCampos();
            String MesAnterior = DateTime.Now.Month.ToString();
            String AñoVigente = DateTime.Now.Year.ToString();
            Mes = Convert.ToInt32(MesAnterior);
            Año = Convert.ToInt32(AñoVigente);
            if (Mes == 1)
            {
                Mes = 12;
                Año = Año - 1;
            }
            else
            { Mes = Mes - 1; }

            List<ListaAlquiler> resultado = new List<ListaAlquiler>();
            List<Entidades.ListaAlquilerEstadistica> listaVentasEstadistica = new List<ListaAlquilerEstadistica>();
            try
            {
                resultado = ReportesDao.ConsultarVentasMesAnterior(Mes, Año);
                if (resultado.Count > 0)
                {
                    ArmoGrilla(resultado);
                }
                else
                { SinResultados(); }
            }
            catch (Exception ex)
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            List<ListaAlquiler> resultado = new List<ListaAlquiler>();
            List<Entidades.ListaAlquilerEstadistica> listaVentasEstadistica = new List<ListaAlquilerEstadistica>();
            try
            {
                DateTime FechaDesde = dtFechaDesde.Value.Date;
                DateTime FechaHasta = dtFechaHasta.Value.Date;
                ValidarFechas(FechaDesde, FechaHasta);
                resultado = ReportesDao.ConsultarAlquilerPorFecha(FechaDesde, FechaHasta);
                if (resultado.Count > 0)
                {
                    ArmoGrilla(resultado);
                }
                else { }
            }
            catch (Exception ex)
            { }
        }

        private void ValidarFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaDesde > fechaHasta)
            {
                const string message = "La fecha desde no puede ser mayor a la fecha hasta.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            dgvVentas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvVentas.MultiSelect = true;
            dgvVentas.SelectAll();
            DataObject dataObj = dgvVentas.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
