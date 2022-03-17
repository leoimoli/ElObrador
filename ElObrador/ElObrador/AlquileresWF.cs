using ElObrador.Clases_Maestras;
using ElObrador.Dao;
using ElObrador.Entidades;
using ElObrador.Negocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using waiTextSharp.utilidades;
using Rectangle = iTextSharp.text.Rectangle;
///// Estado de los productos
///// 1 Habilitado
///// 2 en Taller
///// 3 Alquilado
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
            lblidCliente.Text = "0";
            lblDniCliente.Text = "0";
            lblApeNom.Text = "0";
            lblTotalPagarReal.Text = "0";
            lblDniCliente.Visible = false;
            lblApeNom.Visible = false;
            lblClienteFijo.Visible = false;
            lblDniFijo.Visible = false;
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
                    decimal PrecioTotalFinal = 0;
                    foreach (DataGridViewRow row in dgvAlquiler.Rows)
                    {
                        if (row.Cells[5].Value != null)
                            PrecioTotalFinal += Convert.ToDecimal(row.Cells[5].Value.ToString());
                    }

                    lblTotalPagarReal.Text = Convert.ToString(PrecioTotalFinal);
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                FacturarAlquiler();
            }
            catch (Exception ex)
            { }
        }
        private void FacturarAlquiler()
        {
            try
            {
                List<Alquiler> _listaAlquiler = new List<Alquiler>();
                if (lblidCliente.Text == "0" || lblidCliente.Text == "@")
                {
                    const string message2 = "Debe seleccionar un cliente.";
                    const string caption2 = "Atención";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                    throw new Exception();
                }
                _listaAlquiler = CargarEntidad();
                int idAlquiler = AlquilerNeg.RegistrarAlquiler(_listaAlquiler);
                if (idAlquiler > 0)
                {
                    ListaAlquilerStatic = _listaAlquiler;
                    GenerarReporte(idAlquiler, _listaAlquiler);
                    const string message2 = "Se registro la venta exitosamente.";
                    const string caption2 = "Éxito";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                    LimpiarCamposPostExito();
                }
            }
            catch (Exception ex)
            { }
        }

        #region "variables"

        /// <summary>
        /// Obtener la ruta y nombre logotipo 
        /// </summary>
        public string ArchivoLogotipo = Comun.AppRuta() + Comun.AppLogotipo;

        /// <summary>
        /// Obtener la ruta donde se crea y guarda el reporte (archivo) PDF
        /// </summary>
        public string RutaReporte = Comun.AppRuta() + Comun.AppRutaReporte;

        /// <summary>
        /// Obtener la cadena de conexión desde App.config, para conexíón con SQL Server 
        /// </summary>
       // public string CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["csMSQLServer"].ConnectionString;

        #endregion

        private void GenerarReporte(int idAlquiler, List<Alquiler> listaAlquiler)
        {

            //SqlConnection conTmp = new SqlConnection();
            SqlCommand cmdTmp = new SqlCommand();
            //SqlDataAdapter daTmp;
            DataSet dstTmp = new DataSet();
            string ArchivoNombre;
            string Encabezado;
            string Subencabezado = "";
            string Texto = "";
            string PiePagina = "";
            ArrayList arlColumnas = new ArrayList();
            Rectangle PapelTamanio = iTextSharp.text.PageSize.LETTER;

            string TablaImnprimir = "Nro.Alquiler '" + idAlquiler + "'";
            try
            {

                // cambiar puntero del ratón
                Cursor.Current = Cursors.WaitCursor;

                // mensaje inicializar
                MensajeLimpiar();

                // mensaje
                MensajeMostrar(" - [ Reporte en proceso... ]");

                // ruta y nombre del archivo con extensión
                ArchivoNombre = RutaReporte + "rpt" + TablaImnprimir + DateTime.Now.ToFileTime().ToString() + ".pdf";

                // Encabezado
                Encabezado = Comun.AppNombre();


                // tamaño de la hoja
                PapelTamanio = iTextSharp.text.PageSize.LETTER;

                // encabezado
                Subencabezado = "Comprobante de Alquiler";


                // Texto
                Texto = "Por la presente se deja constancia que el cliente '" + listaAlquiler[0].Cliente + "', con Número de documento '" + listaAlquiler[0].DniCliente + "' se lleva en forma de alquiler los materiales que se detallan a continucacion.";


                // columnas
                arlColumnas.Add(new ReporteColumna("Material", 30, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
                arlColumnas.Add(new ReporteColumna("Modelo", 50, true, Element.ALIGN_CENTER, Element.ALIGN_LEFT, "", FontFactory.TIMES_ROMAN, 8));
                arlColumnas.Add(new ReporteColumna("Código", 20, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));

                // pie de página
                PiePagina = "";

                // instanciar reporte
                Reporte udtReporte = new Reporte(ArchivoLogotipo);

                //
                // Se define la estructura del DataTable
                //
                DataTable dt = new DataTable();

                dt.Columns.Add("Material");           
                dt.Columns.Add("Modelo");
                dt.Columns.Add("Código");

                foreach (var item in listaAlquiler)
                {
                    dt.Rows.Add(item.Material, item.Modelo, item.Codigo);
                }

                // crear reporte
                udtReporte.Generar(ArchivoNombre, PapelTamanio, Encabezado, Subencabezado, Texto, PiePagina, arlColumnas, dt);

                // entregar el reporte con la aplicación asociada
                System.Diagnostics.Process.Start(ArchivoNombre);

                // mensaje
                MensajeMostrar(" - [ Reporte terminado... ]");

                // cambiar puntero ratón
                Cursor.Current = Cursors.Default;
            }
            catch (Exception Ex)
            {
                // heredar
                throw Ex;
            }
            finally
            {
                // cerrar y destruir
                //cmdTmp.Dispose();
                //conTmp.Close();
                //conTmp.Dispose();
            }
        }
        private void MensajeMostrar(string mensaje)
        {
            try
            {
                // mostrar
                //tssMensaje.Text = mensaje;
                //tssMensaje.ForeColor = mensaje.StartsWith(" - [ Ha ocurrido una Excepción... ]") ? System.Drawing.Color.Red : System.Drawing.Color.DodgerBlue;
            }
            catch (Exception Ex)
            {
                // heredar
                throw Ex;
            }
        }

        /// <summary>
        /// Inicializar el control del mensaje
        /// </summary>
        private void MensajeLimpiar()
        {
            try
            {
                // mostrar
                //tssMensaje.Text = "";
                //tssMensaje.ForeColor = DefaultForeColor;
            }
            catch (Exception Ex)
            {
                // heredar
                throw Ex;
            }
        }

        private void LimpiarCamposPostExito()
        {
            dgvAlquiler.Rows.Clear();
            dtFechaDesde.Enabled = true;
            dtFechaHasta.Enabled = true;
            lblidCliente.Text = "0";
            lblDniCliente.Text = "0";
            lblApeNom.Text = "0";
            lblTotalPagarReal.Text = "0";
            lblDniCliente.Visible = false;
            lblApeNom.Visible = false;
            lblClienteFijo.Visible = false;
            lblDniFijo.Visible = false;
        }

        public static List<Alquiler> ListaAlquilerStatic;

        private void CargarReporte(int idAlquiler, List<Alquiler> listaAlquiler)
        {
            ReportViewerAlquilerWF _report = new ReportViewerAlquilerWF(idAlquiler, listaAlquiler);
            _report.Show();

        }

        //private void GenerarFactura(int idAlquiler, List<Alquiler> listaAlquiler)
        //{
        //    MemoryStream m = new MemoryStream();
        //    Document doc = new Document(PageSize.LETTER);

        //    string folderPath = "C:\\ElObrador-Archivos\\PDFs\\Factura\\";
        //    if (!Directory.Exists(folderPath))
        //    {
        //        Directory.CreateDirectory(folderPath);
        //    }
        //    //string replaceWith = "";
        //    //material = material.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
        //    string ruta = folderPath;
        //    //string Periodo = "Reporte de Obra";
        //    string fecha = DateTime.Now.ToShortDateString();
        //    fecha = fecha.Replace("/", "-");
        //    PdfWriter writer = PdfWriter.GetInstance(doc,
        //                                new FileStream(ruta + "Año " + fecha + " Reporte Inventario jajaja" + ".pdf", FileMode.Create));
        //    writer.PageEvent = new PDF();

        //    doc.AddTitle("PDF");
        //    doc.AddCreator("jliCode");

        //    // Abrimos el archivo
        //    doc.Open();
        //    // Creamos el tipo de Font que vamos utilizar
        //    //iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        //    //iTextSharp.text.Font letraContenido = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 5, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        //    //iTextSharp.text.Font UltimoRegistro = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 5, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
        //    //iTextSharp.text.Font DomicilioFontMenos30 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        //    //iTextSharp.text.Font DomicilioFont30a40 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        //    //iTextSharp.text.Font DomicilioFontHasta40a50 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        //    //iTextSharp.text.Font DomicilioFontHasta50a60 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 5, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        //    // Escribimos el encabezamiento en el documento
        //    string TextoInicial = "Año " + fecha + " Reporte inventario en Kilos";


        //    doc.Add(new Paragraph(" "));

        //    Paragraph p1 = new Paragraph(new Chunk(TextoInicial));
        //    p1.Alignment = Element.ALIGN_LEFT;
        //    doc.Add(new Paragraph(p1));
        //    doc.Add(new Paragraph(" "));

        //    // Creamos una tabla que contendrá las cabeceras
        //    // de nuestros visitante.
        //    PdfPTable tblPrueba = new PdfPTable(5);
        //    tblPrueba.WidthPercentage = 110;

        //    PdfPCell clMaterial = new PdfPCell(new Phrase("Material", _standardFont));
        //    clMaterial.BorderWidth = 0;
        //    clMaterial.BorderWidthBottom = 0.50f;
        //    clMaterial.BorderWidthLeft = 0.50f;
        //    clMaterial.BorderWidthRight = 0.50f;
        //    clMaterial.BorderWidthTop = 0.50f;

        //    PdfPCell clDias = new PdfPCell(new Phrase("Dias", _standardFont));
        //    clDias.BorderWidth = 0;
        //    clDias.BorderWidthBottom = 0.50f;
        //    clDias.BorderWidthLeft = 0.50f;
        //    clDias.BorderWidthRight = 0.50f;
        //    clDias.BorderWidthTop = 0.50f;

        //    PdfPCell clFechaDesde = new PdfPCell(new Phrase("Fecha Desde", _standardFont));
        //    clFechaDesde.BorderWidth = 0;
        //    clFechaDesde.BorderWidthBottom = 0.50f;
        //    clFechaDesde.BorderWidthLeft = 0.50f;
        //    clFechaDesde.BorderWidthRight = 0.50f;
        //    clFechaDesde.BorderWidthTop = 0.50f;

        //    PdfPCell clFechaHasta = new PdfPCell(new Phrase("Fecha de Devolución", _standardFont));
        //    clFechaHasta.BorderWidth = 0;
        //    clFechaHasta.BorderWidthBottom = 0.50f;
        //    clFechaHasta.BorderWidthLeft = 0.50f;
        //    clFechaHasta.BorderWidthRight = 0.50f;
        //    clFechaHasta.BorderWidthTop = 0.50f;

        //    PdfPCell clMonto = new PdfPCell(new Phrase("Monto", _standardFont));
        //    clMonto.BorderWidth = 0;
        //    clMonto.BorderWidthBottom = 0.50f;
        //    clMonto.BorderWidthLeft = 0.50f;
        //    clMonto.BorderWidthRight = 0.50f;
        //    clMonto.BorderWidthTop = 0.50f;

        //    // Añadimos las celdas a la tabla
        //    tblPrueba.AddCell(clMaterial);
        //    tblPrueba.AddCell(clDias);
        //    tblPrueba.AddCell(clFechaDesde);
        //    tblPrueba.AddCell(clFechaHasta);
        //    tblPrueba.AddCell(clMonto);

        //    int TotalDeElementos = ListaAlquilerStatic.Count;
        //    int Contador = 0;
        //    foreach (var item in ListaAlquilerStatic)
        //    {
        //        Contador = Contador + 1;
        //        if (TotalDeElementos == Contador)
        //        {
        //            clMaterial = new PdfPCell(new Phrase(item.Material, UltimoRegistro));
        //            clMaterial.BorderWidth = 0;

        //            string dias = Convert.ToString(item.Dias);
        //            clDias = new PdfPCell(new Phrase(dias, UltimoRegistro));
        //            clDias.BorderWidth = 0;

        //            string fechaDesde = Convert.ToString(item.FechaDesde);
        //            clFechaDesde = new PdfPCell(new Phrase(fechaDesde, UltimoRegistro));
        //            clFechaDesde.BorderWidth = 0;

        //            string fechaHasta = Convert.ToString(item.FechaHasta);
        //            clFechaHasta = new PdfPCell(new Phrase(fechaHasta, UltimoRegistro));
        //            clFechaHasta.BorderWidth = 0;

        //            string Monto = Convert.ToString(item.Monto);
        //            clMonto = new PdfPCell(new Phrase(Monto, UltimoRegistro));
        //            clMonto.BorderWidth = 0;

        //            tblPrueba.AddCell(clMaterial);
        //            tblPrueba.AddCell(clDias);
        //            tblPrueba.AddCell(clFechaDesde);
        //            tblPrueba.AddCell(clFechaHasta);
        //            tblPrueba.AddCell(clMonto);
        //        }
        //    }

        //    tblPrueba.AddCell(clMonto);
        //    doc.Add(tblPrueba);
        //    doc.Close();
        //    writer.Close();
        //    string mensaje = "Se generó el PDF exitosamente en la carpeta" + " " + folderPath;
        //    string message2 = mensaje;
        //    const string caption2 = "Éxito";
        //    var result2 = MessageBox.Show(message2, caption2,
        //                                 MessageBoxButtons.OK,
        //                                 MessageBoxIcon.Asterisk);

        //}
        private List<Alquiler> CargarEntidad()
        {
            List<Alquiler> _listaAlquiler = new List<Alquiler>();
            Alquiler _Alquiler = new Alquiler();
            foreach (DataGridViewRow row in dgvAlquiler.Rows)
            {
                _Alquiler.idMaterial = Convert.ToInt32(row.Cells["idProducto"].Value.ToString());
                _Alquiler.Material = row.Cells["Material"].Value.ToString();
                _Alquiler.Dias = Convert.ToInt32(row.Cells["Dias"].Value.ToString());
                _Alquiler.FechaDesde = Convert.ToDateTime(row.Cells["FechaInicio"].Value.ToString());
                _Alquiler.FechaHasta = Convert.ToDateTime(row.Cells["FechaFin"].Value.ToString());
                _Alquiler.Monto = Convert.ToDecimal(row.Cells["ValorAlquiler"].Value.ToString());
                _Alquiler.MontoTotal = Convert.ToDecimal(lblTotalPagarReal.Text);
                _Alquiler.idCliente = Convert.ToInt32(lblidCliente.Text);
                _Alquiler.Cliente = lblApeNom.Text;
                _Alquiler.DniCliente = lblDniCliente.Text;
                _Alquiler.Estado = 1;
                _listaAlquiler.Add(_Alquiler);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                _Alquiler.Codigo = row.Cells["Codigo"].Value.ToString();
                _Alquiler.Modelo = row.Cells["Modelo"].Value.ToString();
            }
            return _listaAlquiler;
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ConsultaClientesWF _clientes = new ConsultaClientesWF();
                _clientes.Show();
            }
            catch (Exception ex)
            { }
        }
        private void dgvAlquiler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                decimal TotalDelMaterial = Convert.ToDecimal(dgvAlquiler.CurrentRow.Cells[5].Value.ToString());
                dgvAlquiler.Rows.Remove(dgvAlquiler.CurrentRow);
                EliminarProductoDeLista(TotalDelMaterial);
            }
        }
        private void EliminarProductoDeLista(decimal TotalDelMaterial)
        {
            try
            {
                decimal PrecioAcumuladoViejo = Convert.ToDecimal(lblTotalPagarReal.Text);
                decimal ValorRestar = TotalDelMaterial;
                decimal NuevoPrecioFinal = PrecioAcumuladoViejo - ValorRestar;
                lblTotalPagarReal.Text = Convert.ToString(NuevoPrecioFinal);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
