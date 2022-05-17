using ElObrador.Dao;
using ElObrador.Entidades;
using Microsoft.Office.Interop.Excel;
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
    public partial class ReportesWF : Form
    {
        public ReportesWF()
        {
            InitializeComponent();
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
        private void ReportesWF_Load(object sender, EventArgs e)
        {
            List<Proveedores> listaProveedores = new List<Proveedores>();
            List<Alquiler> listaAlquileres = new List<Alquiler>();
            ////// Grafico Proveedores
            listaProveedores = ReportesDao.BuscarTotalComprasRealizadasProveedores();
            if (listaProveedores.Count > 0)
            {
                DiseñoGraficoProveedores(listaProveedores);
            }
            else
            { btnExportarComprasProveedores.Visible = false; }
            ////// Grafico Ventas
            listaAlquileres = ReportesDao.BuscarAlquileresPorMes();
            if (listaAlquileres.Count > 0)
            {
                DiseñoGraficoAlquiler(listaAlquileres);
            }
            else
            { btnExportar.Visible = false; }
            ////// Grafico Producto Más Alquilado
            listaAlquileres = ReportesDao.BuscarProductosMasAlquilado();
            if (listaAlquileres.Count > 0)
            {
                DiseñoGraficoProductosMasAlquilado(listaAlquileres);
            }
            else
            { btnproductoMasVendido.Visible = false; }
            ////// Reportes Botones
            /// Total de Ventas
            List<Alquiler> listaVentas2 = new List<Alquiler>();
            listaVentas2 = ReportesDao.TotalDeAlquileres();
            lblTotalVentas.Text = Convert.ToString(listaVentas2[0].TotalDeAlquleresGenerales);
            /// Caja de Ventas
            List<Alquiler> listaVentas3 = new List<Alquiler>();
            List<Alquiler> listaRecargo = new List<Alquiler>();
            listaVentas3 = ReportesDao.CajaDeAlquileres();
            listaRecargo = ReportesDao.CajaDeRecargos();
            decimal totalCaja = listaVentas3[0].CajaDeAlquileres + listaRecargo[0].CajaDeAlquileres;
            lblCajaVentas.Text = Convert.ToString(totalCaja);
            ToolTip tool = new ToolTip();
            toolTip2.SetToolTip(btnAlquileresCaja, "Caja de Alquiler = '" + listaVentas3[0].CajaDeAlquileres + "' Recargos = '" + listaRecargo[0].CajaDeAlquileres + "'");
            /// Total de Compras
            List<Proveedores> listaCompras = new List<Proveedores>();
            listaCompras = ReportesDao.TotalDeCompras();
            lblTotalCompras.Text = Convert.ToString(listaCompras[0].TotalDeComprasGenerales);         
          

            /// Pagos de Compras
            List<Proveedores> listaCompras2 = new List<Proveedores>();
            listaCompras2 = ReportesDao.PagosCompras();
            lblPagosProveedores.Text = Convert.ToString(listaCompras2[0].CajaDePagos);
        }

        private void DiseñoGraficoProductosMasAlquilado(List<Alquiler> listaAlquileres)
        {
            List<string> Nombre = new List<string>();
            List<string> Total = new List<string>();
            foreach (var item in listaAlquileres)
            {
                Nombre.Add(item.DescripcionProducto);
                string total = Convert.ToString(item.ProductoMasAlquilado);
                Total.Add(total);
            }
            chartProductos.Series[0].Points.DataBindXY(Nombre, Total);           
            //this.chartProductos.Titles.Add("Essential Chart");

        }
        private void DiseñoGraficoProveedores(List<Proveedores> listaProveedores)
        {
            List<string> Nombre = new List<string>();
            List<string> Total = new List<string>();
            foreach (var item in listaProveedores)
            {
                Nombre.Add(item.NombreEmpresa);
                string total = Convert.ToString(item.TotalCompras);
                Total.Add(total);
            }
            chartProveedores.Series[0].Points.DataBindXY(Nombre, Total);
        }
        private void btnExportarComprasProveedores_Click(object sender, EventArgs e)
        {
            List<Proveedores> listaComprasAProveedores = new List<Proveedores>();
            listaComprasAProveedores = ReportesDao.BuscarMovimientoStock();
            if (listaComprasAProveedores.Count > 0)
            {
                foreach (var item in listaComprasAProveedores)
                {
                    string Fecha = item.Fecha.ToShortDateString();
                    dataGridView2.Rows.Add(Fecha, item.Proveedor, item.Remito);
                }
            }
            dataGridView2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView2.MultiSelect = true;
            dataGridView2.SelectAll();
            DataObject dataObj = dataGridView2.GetClipboardContent();
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
        private void DiseñoGraficoAlquiler(List<Alquiler> listaAlquileres)
        {
            List<string> Mes = new List<string>();
            List<string> Total = new List<string>();
            String Año = DateTime.Now.Year.ToString();
            foreach (var item in listaAlquileres)
            {
                Mes.Add(item.mes);
                string total = Convert.ToString(item.TotalVentasPorMes);
                Total.Add(total);
            }
            chartVentas.Series[0].Points.DataBindXY(Mes, Total);
        }
        private void btnproductoMasVendido_Click(object sender, EventArgs e)
        {
            List<Alquiler> listaVentas = new List<Alquiler>();
            listaVentas = ReportesDao.ListadoProductosMasAlquilados();
            if (listaVentas.Count > 0)
            {
                foreach (var item in listaVentas)
                {
                    dataGridView3.Rows.Add(item.DescripcionProducto, item.ProductoMasAlquilado);
                }
            }
            dataGridView3.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView3.MultiSelect = true;
            dataGridView3.SelectAll();
            DataObject dataObj = dataGridView3.GetClipboardContent();
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            List<Alquiler> listaVentas = new List<Alquiler>();
            listaVentas = ReportesDao.BuscarTodasLosAlquileres();
            if (listaVentas.Count > 0)
            {
                foreach (var item in listaVentas)
                {
                    dataGridView1.Rows.Add(item.FechaDesde, item.Monto);
                }
            }
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Reportes_AlquileresWF frm2 = new Reportes_AlquileresWF();
            frm2.Show();
        }
    }
}
