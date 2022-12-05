using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElObrador.Clases_Maestras;
using ElObrador.Entidades;
using ElObrador.Negocio;
using ElObrador.utilidades;
using iTextSharp.text;
using waiTextSharp.utilidades;
using Rectangle = iTextSharp.text.Rectangle;

namespace ElObrador
{
    public partial class ReAperturaAlquilerWF : Form
    {
        private List<Alquiler> _Alquiler;
        private string material;
        private int DiasDeAlquiler;
        private string montoAlquiler;
        private int idCliente;
        private string Dni;
        private string apellidoNombre;
        private string domicilio;
        private string provLoc;
        private string email;
        private string telefono;

        public ReAperturaAlquilerWF(List<Alquiler> alquiler, string material, int DiasDeAlquiler, string montoAlquiler, int idCliente, string DNI, string apellidoNombre, string domicilio, string provLoc, string email, string telefono)
        {
            InitializeComponent();
            _Alquiler = alquiler;
            this.material = material;
            this.DiasDeAlquiler = DiasDeAlquiler;
            this.montoAlquiler = montoAlquiler;
            this.idCliente = idCliente;
            this.Dni = DNI;
            this.apellidoNombre = apellidoNombre;
            this.domicilio = domicilio;
            this.provLoc = provLoc;
            this.email = email;
            this.telefono = telefono;
        }

        private void ReAperturaAlquilerWF_Load(object sender, EventArgs e)
        {
            try
            {
                lblApeNom.Text = apellidoNombre;
                lblDniCliente.Text = Dni;
                lblidCliente.Text = Convert.ToString(idCliente);
                lblEmail.Text = email;
                lblTelefono.Text = telefono;
                List<Alquiler> Detallealquiler = new List<Alquiler>();
                Detallealquiler = _Alquiler;
                bool MaterialesDisponibles = AlquilerNeg.ValidarDisponibilidadMateriales(Detallealquiler);
                if (MaterialesDisponibles == true)
                {
                    List<MontoAlquiler> MontoAlquiler = new List<MontoAlquiler>();
                    MontoAlquiler = AlquilerNeg.BuscarMontoAlquilerParaMaterial(Detallealquiler);
                    DateTime FechaDevolucion = DateTime.Now.AddDays(DiasDeAlquiler);
                    decimal MontoTotal = 0;
                    foreach (var item in MontoAlquiler)
                    {
                        decimal Total = item.Monto * DiasDeAlquiler;
                        dgvAlquiler.Rows.Add(item.idMaterial, item.Material, DiasDeAlquiler, "", FechaDevolucion, "", Total, item.Codigo, item.Modelo);

                        foreach (DataGridViewRow row in dgvAlquiler.Rows)
                        {
                            MontoTotal += Convert.ToDecimal(row.Cells["ValorAlquiler"].Value);
                        }
                        lblTotalPagarReal.Text = MontoTotal.ToString("N", new CultureInfo("es-CL"));
                    }
                }
                else
                {
                    const string message2 = "Atención: Los materiales no estan disponibles para la reapertura del alquiler.";
                    const string caption2 = "Atención";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Exclamation);
                    Close();
                    throw new Exception();
                }
            }
            catch (Exception ex)
            { }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
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
        public static List<Alquiler> ListaAlquilerStatic;
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
                if (_listaAlquiler[0].AlquilerPagado == 0)
                {
                    Entidades.LibreDeuda _libreDeuda = CargarEntidadRegistroDeuda(_listaAlquiler, idAlquiler);
                    bool Exito = LibreDeudaNeg.RegistrarDeuda(_libreDeuda);
                }
                if (idAlquiler > 0)
                {
                    ListaAlquilerStatic = _listaAlquiler;
                    GenerarReporte(idAlquiler, _listaAlquiler);
                    const string message2 = "Se registro el alquiler exitosamente.";
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
        public string ArchivoLogotipo = Comun.AppRuta() + ComunAlquiler.AppLogotipo;

        /// <summary>
        /// Obtener la ruta donde se crea y guarda el reporte (archivo) PDF

        //SqlConnection conTmp = new SqlConnection();
        SqlCommand cmdTmp = new SqlCommand();
        //SqlDataAdapter daTmp;
        DataSet dstTmp = new DataSet();
        string ArchivoNombre;
        string Encabezado;
        string Subencabezado = "";
        string DiasHorariosLaborales = "";
        string Texto = "";
        string Nota = "";
        string TextoNota = "";
        string FirmaAclaracion = "";
        string DniFirmante = "";
        string TextoLey = "";
        string TextoProtesto = "";
        string PiePagina = "";
        ArrayList arlColumnas = new ArrayList();
        Rectangle PapelTamanio = iTextSharp.text.PageSize.LETTER;
        /// </summary>
        //public string RutaReporte = Comun.AppRuta() + Comun.AppRutaReporte;

        /// <summary>
        /// Obtener la cadena de conexión desde App.config, para conexíón con SQL Server 
        /// </summary>
        // public string CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["csMSQLServer"].ConnectionString;

        #endregion
        private void GenerarReporte(int idAlquiler, List<Alquiler> listaAlquiler)
        {
            string TablaImnprimir = "Nro.Alquiler '" + idAlquiler + "'";
            try
            {

                // cambiar puntero del ratón
                Cursor.Current = Cursors.WaitCursor;

                //// mensaje inicializar
                //MensajeLimpiar();

                //// mensaje
                //MensajeMostrar(" - [ Reporte en proceso... ]");


                string folderPath = "C:\\Obrador-Archivos\\PDFs\\Comprobante-Alquiler\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string RutaReporte = folderPath;
                // ruta y nombre del archivo con extensión
                ArchivoNombre = RutaReporte + "rpt" + TablaImnprimir + DateTime.Now.ToFileTime().ToString() + ".pdf";

                // Encabezado
                Encabezado = ComunAlquiler.AppNombre();


                // tamaño de la hoja
                PapelTamanio = iTextSharp.text.PageSize.LETTER;

                // encabezado
                Subencabezado = "N°Alquiler: '" + idAlquiler + "'";


                // Jornada Laboral                
                DiasHorariosLaborales = "Días y Horario de Atención: Lunes a Viernes de 8hs a 17hs / Sábados de 8hs a 13hs";



                string txtApellido = listaAlquiler[0].Cliente;
                string DNI = listaAlquiler[0].DniCliente;
                string Telefono = listaAlquiler[0].TelefonoCliente;
                string Email = listaAlquiler[0].EmailCliente;
                string NroCliente = Convert.ToString(listaAlquiler[0].idCliente);
                string FechaActual = DateTime.Now.ToShortDateString();
                string Devolucion = listaAlquiler[0].FechaHasta.ToShortDateString();
                //string txtNroReferencia = Convert.ToString(Exito);
                //string txSeña = txtSeña.Text;

                // Texto
                Texto = "Cliente: '" + txtApellido + "'; Telefono: '" + Telefono + "'; Email: '" + Email + "';" + "NroCliente: '" + NroCliente + "';" + "Fecha: '" + FechaActual + "';" + "Fecha Estimada de Entrega: '" + Devolucion + "'";

                Nota = "Notas";

                TextoNota = "- La casa no se responsabiliza por lesiones o daños generados por el uso de la herramienta. " + Environment.NewLine + "- El cliente retira la herramienta en excelente estado de funcionamiento, cualquier observación o rotura que sufriera la misma por mal uso o negligencia sera reparada a cargo del cliente." + Environment.NewLine + " - Los períodos de alquiler son de días(24 horas) salvo indicaciones contraria, indicada en observaciones, contados a partir del retiro de la herramienta, pasado ese plazo se factura uno nuevo. " + Environment.NewLine + " - Junto con la firma del presente se firmará un pagaré en concepto de garantía por eventuales roturas, extavios de la herramientay falta de cumplimiento en el pago del alquiler de la misma, el cual será devuelto al momento que se devuelva la herramienta y el titular no posea deuda alguna.";

                FirmaAclaracion = "Firma y Aclaración";

                DniFirmante = "DNI";

                // Texto Ley
                TextoLey = "Vence el '__________' de '__________' de 20'_____' el dia '__________' pagare sin protesto(art 50 Decreto Ley N° 5965/63) a El Obrador SA o a su orden la cantidad de pesos '__________' por igual valor recibido en equipos/herramientas descriptos en el presente contrato a su entera satisfacción, pagaderos en '__________'" + Environment.NewLine + " " + Environment.NewLine + "  @Cliente: #" + Environment.NewLine + " " + Environment.NewLine + " @Teléfono: %" + Environment.NewLine + " " + Environment.NewLine + " @Email: $";

                TextoProtesto = "Clausula sin Protesto: Respecto del pagaré que luce precedentemente, se pacta la cláusula 'sin protesto', de modo que el tenedor queda dispensado de formalizar el protesto por falta de pago y le confiere la pertinente vía ejecutiva en los términos del art. 50 del decreto-ley 5965/63";

                // columnas
                arlColumnas.Add(new ReporteColumna("Código de Herramienta", 20, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
                arlColumnas.Add(new ReporteColumna("Material", 30, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
                arlColumnas.Add(new ReporteColumna("Fecha de Devolución", 30, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
                arlColumnas.Add(new ReporteColumna("Días de alquiler estimado", 20, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
                arlColumnas.Add(new ReporteColumna("Observaciones", 30, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));

                // pie de página
                PiePagina = "";

                // instanciar reporte
                Reporte udtReporte = new Reporte(ArchivoLogotipo);

                //
                // Se define la estructura del DataTable
                //
                DataTable dt = new DataTable();

                dt.Columns.Add("Código de Herramieta");
                dt.Columns.Add("Material");
                dt.Columns.Add("Fecha de Devolución");
                dt.Columns.Add("Días de alquiler estimado");
                dt.Columns.Add("Observaciones");

                dt.Rows.Add("Código de Herramieta", "Material", "Fecha de Devolución", "Días de alquiler estimado", "Observaciones");


                foreach (var item in listaAlquiler)
                {
                    dt.Rows.Add(item.Codigo, item.Material, item.FechaHasta, item.Dias, item.Observacion);
                }

                //string Prueba = "Hola Mundo";
                // crear reporte
                try
                {
                    udtReporte.Generar(ArchivoNombre, PapelTamanio, Encabezado, Subencabezado, DiasHorariosLaborales, Texto, Nota, TextoNota, FirmaAclaracion, DniFirmante, TextoLey, TextoProtesto, PiePagina, arlColumnas, dt);
                }
                catch (Exception ex)
                {

                    string message = ex.Message;
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                //entregar el reporte con la aplicación asociada
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
        private void LimpiarCamposPostExito()
        {
            dgvAlquiler.Rows.Clear();
            lblidCliente.Text = "0";
            lblDniCliente.Text = "0";
            lblApeNom.Text = "0";
            lblTotalPagarReal.Text = "0";
            lblDniCliente.Visible = false;
            lblApeNom.Visible = false;
            lblClienteFijo.Visible = false;
            lblDniFijo.Visible = false;
            chcPagado.Checked = false;
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
        private List<Alquiler> CargarEntidad()
        {
            List<Alquiler> _listaAlquiler = new List<Alquiler>();
            Alquiler _Alquiler = new Alquiler();
            foreach (DataGridViewRow row in dgvAlquiler.Rows)
            {
                _Alquiler = new Alquiler();
                _Alquiler.idMaterial = Convert.ToInt32(row.Cells["idProducto"].Value.ToString());
                _Alquiler.Material = row.Cells["Producto"].Value.ToString();
                _Alquiler.Codigo = row.Cells["Cod"].Value.ToString();
                _Alquiler.Modelo = row.Cells["Mod"].Value.ToString();
                _Alquiler.Dias = Convert.ToInt32(row.Cells["Dias"].Value.ToString());
                _Alquiler.FechaDesde = DateTime.Now;
                _Alquiler.Observacion = row.Cells["Observacion"].Value.ToString();
                _Alquiler.FechaHasta = Convert.ToDateTime(row.Cells["FechaFin"].Value.ToString());
                _Alquiler.Monto = Convert.ToDecimal(row.Cells["ValorAlquiler"].Value.ToString());
                _Alquiler.MontoTotal = Convert.ToDecimal(lblTotalPagarReal.Text);
                _Alquiler.idCliente = Convert.ToInt32(lblidCliente.Text);
                _Alquiler.Cliente = lblApeNom.Text;
                _Alquiler.DniCliente = lblDniCliente.Text;
                _Alquiler.TelefonoCliente = lblTelefono.Text;
                _Alquiler.EmailCliente = lblEmail.Text;
                _Alquiler.Estado = 1;
                if (chcPagado.Checked == true)
                {
                    _Alquiler.AlquilerPagado = 1;
                }
                else
                {
                    _Alquiler.AlquilerPagado = 0;
                }
                _listaAlquiler.Add(_Alquiler);
            }
            return _listaAlquiler;
        }
        private LibreDeuda CargarEntidadRegistroDeuda(List<Alquiler> _listaAlquiler, int idAlquiler)
        {
            LibreDeuda _libreDeuda = new LibreDeuda();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            _libreDeuda.idUsuario = idusuarioLogueado;
            /////// Tipo de Tarea 1 = registro Deuda //// 2 = Pago Deuda
            _libreDeuda.idTipoTarea = 1;
            _libreDeuda.Monto = Convert.ToDecimal(_listaAlquiler[0].MontoTotal);
            string fecha = _listaAlquiler[0].FechaDesde.ToShortDateString();
            _libreDeuda.Fecha = Convert.ToDateTime(fecha);
            _libreDeuda.Motivo = "Alquiler Nro: '" + idAlquiler + "' Impago";
            _libreDeuda.idCliente = Convert.ToInt32(_listaAlquiler[0].idCliente);
            _libreDeuda.FechaActual = DateTime.Now;
            return _libreDeuda;
        }
    }
}
