using ElObrador.Clases_Maestras;
using ElObrador.Entidades;
using ElObrador.Negocio;
using ElObrador.utilidades;
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

namespace ElObrador
{
    public partial class ReparacionesWF : Form
    {
        public ReparacionesWF()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Reparaciones _taller = CargarEntidad();

                int Exito = ReparacionesNeg.RegistrarIngresoEnTaller(_taller);
                if (Exito > 0)
                {
                    ProgressBar();
                    const string message2 = "Se registro el ingreso a taller exitosamente.";
                    const string caption2 = "Éxito";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                    GenerarReporte(Exito, _taller);
                    LimpiarCampos();
                    FuncionListarReparaciones();
                }
            }
            catch (Exception ex)
            { }
        }

        #region "variables"

        /// <summary>
        /// Obtener la ruta y nombre logotipo 
        /// </summary>
        public string ArchivoLogotipoCupon = Comun.AppRuta() + Comun.AppLogotipoDos;

        /// <summary>
        /// Obtener la ruta donde se crea y guarda el reporte (archivo) PDF

        //SqlConnection conTmp = new SqlConnection();
        SqlCommand cmdTmpCupon = new SqlCommand();
        //SqlDataAdapter daTmp;
        DataSet dstTmpCupon = new DataSet();
        string ArchivoNombreCupon;
        string EncabezadoCupon;
        string SubencabezadoCupon = "";
        string DiasHorariosLaboralesCupon = "";
        string TextoCupon = "";
        string TextoLineaDosCupon = "";
        string TextoLeyCupon = "";
        string PiePaginaCupon = "";
        ArrayList arlColumnasCupon = new ArrayList();
        Rectangle PapelTamanioCupon = iTextSharp.text.PageSize.LETTER;        /// </summary>
        //public string RutaReporte = Comun.AppRuta() + Comun.AppRutaReporte;

        /// <summary>
        /// Obtener la cadena de conexión desde App.config, para conexíón con SQL Server 
        /// </summary>
        // public string CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["csMSQLServer"].ConnectionString;

        #endregion
        private void GenerarCuponDeCodigo(int exito)
        {

            string TablaImnprimir = "Nro.Reparacion '" + exito + "'";
            try
            {

                // cambiar puntero del ratón
                Cursor.Current = Cursors.WaitCursor;

                //// mensaje inicializar
                //MensajeLimpiar();

                //// mensaje
                //MensajeMostrar(" - [ Reporte en proceso... ]");


                string folderPath = "C:\\Obrador-Archivos\\PDFs\\Nro.Reparacion\\";
                //string folderPath = "C:\\Users\\Leo - Romi\\Desktop\\Obrador";
                
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string RutaReporte = folderPath;
                // ruta y nombre del archivo con extensión
                ArchivoNombreCupon = RutaReporte + "rpt" + TablaImnprimir + DateTime.Now.ToFileTime().ToString() + ".pdf";

                // Encabezado
                EncabezadoCupon = Comun.AppNombreReparaciones();


                // tamaño de la hoja
                PapelTamanioCupon = iTextSharp.text.PageSize.LETTER;

                // encabezado
                //Subencabezado = "Comprobante de Alquiler" + Environment.NewLine + "(No valido como factura)";
                SubencabezadoCupon = "Código de Reparación:" + exito + "";

                //Jornada Laboral
                DiasHorariosLaboralesCupon = "Días y Horario de Atención: Lunes a Viernes de 8hs a 17hs / Sábados de 8hs a 13hs";


                // Texto
                var espacios = "";
                string Blancos = espacios.PadRight(80);
                string BlancosDos = espacios.PadRight(20);


                string txtApellido = lblApellido.Text;
                string txtTelefono = lblTelefono.Text;
                string txtNroReferencia = Convert.ToString(exito);
                string txSeña = txtSeña.Text;
                if (txtSeña.Text == "")
                {
                    txSeña = "0";
                }
                else
                { txSeña = txtSeña.Text; }
                string txFechaEstimada = dtFechaEstimadaEntrega.Value.ToShortDateString();

                TextoCupon = "Cliente: '" + txtApellido + "'; Teléfono: '" + txtTelefono + "'; Referencia: '" + txtNroReferencia + "';" + "Seña: '" + txSeña + "';" + "Fecha Estimada de Entrega: '" + txFechaEstimada + "'";



                // Texto Ley
                TextoLeyCupon = "IMPORTANTE " + Environment.NewLine + " 1) Sera requisito indispensable presentar este comprobante para retirar el equipo. " + Environment.NewLine + " 2) Si pasados los 90 días de terminado el arreglo, el material no es retirado, quedara en propiedad de este service, entendiendose que el titular renuncia al mismo de acuerdo a los Art.872/3 del Código Civil. " + Environment.NewLine + " 3) Los tiempos de reparación estarán sujetos a disponibilidad y/o stock de los repuestos. " + Environment.NewLine + " 4) Las reparaciones gozarán de 90 días de garantía sobre el arreglo específico. " + Environment.NewLine + " 5) Los equipos dejado a presupuestar que no tengan una confirmación dentro de los 60 días una vez cotizado el trabajo, quedarán a disposición del El obrador, perdiendo el propietario todo derecho a reclamo alguno.";

                //columnas
                arlColumnasCupon.Add(new ReporteColumna("Código", 20, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
                arlColumnasCupon.Add(new ReporteColumna("Material", 30, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
                arlColumnasCupon.Add(new ReporteColumna("Modelo", 30, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));


                // pie de página
                PiePaginaCupon = "";

                // instanciar reporte
                CodigoReparacion udtReporte = new CodigoReparacion(ArchivoLogotipoCupon);

                //
                // Se define la estructura del DataTable
                //
                DataTable dtCupon = new DataTable();

                dtCupon.Columns.Add("Código");
                dtCupon.Columns.Add("Material");
                dtCupon.Columns.Add("Modelo");


                //dt.Rows.Add("Código", "Material", "Modelo");
                //dt.Rows.Add(_taller.Codigo, _taller.Material, _taller.Modelo);

                //foreach (var item in _taller)
                //{
                //    dt.Rows.Add(item.Material, item.Modelo, item.Codigo);
                //}

                //string Prueba = "Hola Mundo";
                // crear reporte
                try
                {
                    udtReporte.Generar(ArchivoNombreCupon, PapelTamanioCupon, EncabezadoCupon, SubencabezadoCupon, DiasHorariosLaboralesCupon, TextoCupon, TextoLeyCupon, PiePaginaCupon, arlColumnasCupon, dtCupon);
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
                System.Diagnostics.Process.Start(ArchivoNombreCupon);

                // mensaje
                //MensajeMostrar(" - [ Reporte terminado... ]");

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
                ////cerrar y destruir
                //cmdTmpCupon.Dispose();
                //conTmpCupon.Close();
                //conTmpCupon.Dispose();
            }
        }


        //////////////// TICKET DE LA FACTURA
        #region "variables"

        /// <summary>
        /// Obtener la ruta y nombre logotipo 
        /// </summary>
        public string ArchivoLogotipo = Comun.AppRuta() + Comun.AppLogotipo;

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
        string TextoLineaDos = "";
        string TextoLey = "";
        string PiePagina = "";
        ArrayList arlColumnas = new ArrayList();
        Rectangle PapelTamanio = iTextSharp.text.PageSize.LETTER;        /// </summary>
        //public string RutaReporte = Comun.AppRuta() + Comun.AppRutaReporte;

        /// <summary>
        /// Obtener la cadena de conexión desde App.config, para conexíón con SQL Server 
        /// </summary>
        // public string CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["csMSQLServer"].ConnectionString;

        #endregion
        private void GenerarReporte(int Exito, Reparaciones _taller)
        {


            string TablaImnprimir = "Nro.Reparacion '" + Exito + "'";
            try
            {

                // cambiar puntero del ratón
                Cursor.Current = Cursors.WaitCursor;

                //// mensaje inicializar
                //MensajeLimpiar();

                //// mensaje
                //MensajeMostrar(" - [ Reporte en proceso... ]");


                string folderPath = "C:\\Obrador-Archivos\\PDFs\\Comprobante-Reparaciones\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string RutaReporte = folderPath;
                // ruta y nombre del archivo con extensión
                ArchivoNombre = RutaReporte + "rpt" + TablaImnprimir + DateTime.Now.ToFileTime().ToString() + ".pdf";

                // Encabezado
                Encabezado = Comun.AppNombre();


                // tamaño de la hoja
                PapelTamanio = iTextSharp.text.PageSize.LETTER;

                // encabezado
                //Subencabezado = "Comprobante de Alquiler" + Environment.NewLine + "(No valido como factura)";
                Subencabezado = "Fecha de Ingreso:" + _taller.Fecha.ToShortDateString() + "";

                // Jornada Laboral                
                DiasHorariosLaborales = "Días y Horario de Atención: Lunes a Viernes de 8hs a 17hs / Sábados de 8hs a 13hs";


                // Texto
                var espacios = "";
                string Blancos = espacios.PadRight(80);
                string BlancosDos = espacios.PadRight(20);


                string txtApellido = lblApellido.Text;
                string txtTelefono = lblTelefono.Text;
                string txtNroReferencia = Convert.ToString(Exito);
                string txSeña = txtSeña.Text;
                if (txtSeña.Text == "")
                {
                    txSeña = "0";
                }
                else
                { txSeña = txtSeña.Text; }
                string txFechaEstimada = dtFechaEstimadaEntrega.Value.ToShortDateString();

                Texto = "Cliente: '" + txtApellido + "'; Teléfono: '" + txtTelefono + "'; Referencia: '" + txtNroReferencia + "';" + "Seña: '" + txSeña + "';" + "Fecha Estimada de Entrega: '" + txFechaEstimada + "'";



                // Texto Ley
                TextoLey = "IMPORTANTE " + Environment.NewLine + " 1) Sera requisito indispensable presentar este comprobante para retirar el equipo. " + Environment.NewLine + " 2) Si pasados los 90 días de terminado el arreglo, el material no es retirado, quedara en propiedad de este service, entendiendose que el titular renuncia al mismo de acuerdo a los Art.872/3 del Código Civil. " + Environment.NewLine + " 3) Los tiempos de reparación estarán sujetos a disponibilidad y/o stock de los repuestos. " + Environment.NewLine + " 4) Las reparaciones gozarán de 90 días de garantía sobre el arreglo específico. " + Environment.NewLine + " 5) Los equipos dejado a presupuestar que no tengan una confirmación dentro de los 60 días una vez cotizado el trabajo, quedarán a disposición del El obrador, perdiendo el propietario todo derecho a reclamo alguno.";

                // columnas
                arlColumnas.Add(new ReporteColumna("Código", 20, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
                arlColumnas.Add(new ReporteColumna("Material", 30, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
                arlColumnas.Add(new ReporteColumna("Modelo", 30, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));


                // pie de página
                PiePagina = "";

                // instanciar reporte
                OrdenDeTrabajoReparaciones udtReporte = new OrdenDeTrabajoReparaciones(ArchivoLogotipo);

                //
                // Se define la estructura del DataTable
                //
                DataTable dt = new DataTable();

                dt.Columns.Add("Código");
                dt.Columns.Add("Material");
                dt.Columns.Add("Modelo");


                dt.Rows.Add("Código", "Material", "Modelo");
                dt.Rows.Add(_taller.Codigo, _taller.Material, _taller.Modelo);

                //foreach (var item in _taller)
                //{
                //    dt.Rows.Add(item.Material, item.Modelo, item.Codigo);
                //}

                //string Prueba = "Hola Mundo";
                // crear reporte
                try
                {
                    udtReporte.Generar(ArchivoNombre, PapelTamanio, Encabezado, Subencabezado, DiasHorariosLaborales, Texto, TextoLey, PiePagina, arlColumnas, dt);
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
                //MensajeMostrar(" - [ Reporte terminado... ]");

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
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtModelo.Clear();
            txtDescripcionProducto.Clear();
            txtDiagnostico.Enabled = false;
            dtFecha.Value = DateTime.Now;
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
            CargarComboServicio();
            textBox1.Clear();
            txtPorDni.Clear();
            lblidCliente.Text = "0";
            panel1.Enabled = false;
            txtDiagnostico.Clear();
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
        private Reparaciones CargarEntidad()
        {
            Reparaciones _taller = new Reparaciones();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            int idCliente = Convert.ToInt32(lblidCliente.Text);
            if (idCliente == 0)
            {
                const string message = "Atención: Debe seleccionar un cliente";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            else
            {
                _taller.idCliente = idCliente;
            }
            _taller.Material = txtDescripcionProducto.Text;
            _taller.Codigo = txtCodigo.Text;
            _taller.Modelo = txtModelo.Text;
            _taller.TipoServicio = cmbTipoServicio.Text;
            _taller.Fecha = dtFecha.Value;
            _taller.Diagnostico = txtDiagnostico.Text;
            if (txtSeña.Text != "")
            {
                _taller.Seña = Convert.ToDecimal(txtSeña.Text);
            }
            _taller.FechaEstimadaEntrega = dtFechaEstimadaEntrega.Value;
            _taller.idUsuario = idusuarioLogueado;
            return _taller;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarClientePorDescripcion();
            }
        }
        private void BuscarClientePorDescripcion()
        {
            dgvReparaciones.Rows.Clear();
            string Descripcion = textBox1.Text;
            string Ape = Descripcion.Split(',')[0];
            string Nom = Descripcion.Split(',')[1];
            List<Entidades.Clientes> ListaClientes = ClientesNeg.BuscarClientePorApellidoNombre(Ape, Nom);
            if (ListaClientes.Count > 0)
            {
                foreach (var item in ListaClientes)
                {
                    lblidCliente.Text = Convert.ToString(item.IdCliente);
                    string Apellido = item.Apellido;
                    string Nombre = item.Nombre;
                    lblApellido.Text = Apellido + "," + Nombre;
                    lblTelefono.Text = item.Telefono;
                    lblApellido.Visible = true;
                    txtPorDni.Text = item.Dni;
                    txtPorDni.Enabled = false;
                    //string Apellido = item.Apellido;
                    //string Nombre = item.Nombre;
                    //string Persona = Apellido + "," + Nombre;
                    //string Domicilio = item.Calle + "N°" + item.Altura;
                    //dgvReparaciones.Rows.Add(item.IdCliente, Persona, Domicilio, item.Email, item.Telefono);
                }
            }
            else
            {
                const string message2 = "No existe ningun cliente con el Apellido y Nombre ingresado.";
                const string caption2 = "Atención";
                var result2 = MessageBox.Show(message2, caption2,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Exclamation);
                txtPorDni.Clear();
                textBox1.Clear();
                lblApellido.Text = "";
                lblApellido.Visible = false;

            }
            dgvReparaciones.ReadOnly = true;
        }
        private void txtCodigoBus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarClientePorDni();
            }
        }
        private void BuscarClientePorDni()
        {
            dgvReparaciones.Rows.Clear();
            string Dni = txtPorDni.Text;
            List<Entidades.Clientes> ListaClientes = ClientesNeg.BuscarClientePorDni(Dni);
            if (ListaClientes.Count > 0)
            {
                foreach (var item in ListaClientes)
                {
                    lblidCliente.Text = Convert.ToString(item.IdCliente);
                    string Apellido = item.Apellido;
                    string Nombre = item.Nombre;
                    lblApellido.Text = Apellido + "," + Nombre;
                    lblApellido.Visible = true;
                    lblTelefono.Text = item.Telefono;
                    //string Domicilio = item.Calle + "N°" + item.Altura;
                    //dgvReparaciones.Rows.Add(item.IdCliente, Persona, Domicilio, item.Email, item.Telefono);
                }
            }
            else
            {
                const string message2 = "No existe ningun cliente con el dni ingresado.";
                const string caption2 = "Atención";
                var result2 = MessageBox.Show(message2, caption2,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Exclamation);
                txtPorDni.Clear();
                textBox1.Clear();
                lblApellido.Text = "";
                lblApellido.Visible = false;

            }
            dgvReparaciones.ReadOnly = true;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel1.Visible = true;
            panelVer.Visible = false;
            textBox1.Focus();
            txtPorDni.Enabled = true;
            CargarComboServicio();
            FuncionBuscartextoCliente();
            txtPorDni.Clear();
            textBox1.Clear();
            lblApellido.Text = "";
            lblApellido.Visible = false;
        }
        private void FuncionBuscartextoCliente()
        {
            textBox1.AutoCompleteCustomSource = Clases_Maestras.AutoCompletePorApellido.Autocomplete();
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void CargarComboServicio()
        {
            string[] Perfiles = Clases_Maestras.ValoresConstantes.TipoServicio;
            cmbTipoServicio.Items.Add("Seleccione");
            cmbTipoServicio.Items.Clear();
            foreach (string item in Perfiles)
            {
                cmbTipoServicio.Text = "Seleccione";
                cmbTipoServicio.Items.Add(item);
            }
        }

        private void txtDiagnostico_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = Convert.ToString(txtDiagnostico.Text.Length);
        }

        private void ReparacionesWF_Load(object sender, EventArgs e)
        {
            try
            {
                txtDescipcionBus.Focus();
                FuncionListarReparaciones();
                FuncionBuscartexto();
            }
            catch (Exception ex)
            { }
        }

        private void FuncionListarReparaciones()
        {
            dgvReparaciones.Rows.Clear();
            List<Reparaciones> ListaReparaciones = ReparacionesNeg.ListaDeReparaciones();
            if (ListaReparaciones.Count > 0)
            {
                foreach (var item in ListaReparaciones)
                {
                    dgvReparaciones.Rows.Add(item.idReparaciones, item.Material, item.Codigo, item.Modelo);
                }
            }
            dgvReparaciones.ReadOnly = true;
        }

        private void FuncionBuscartexto()
        {
            txtDescipcionBus.AutoCompleteCustomSource = Clases_Maestras.AutoCompletePorMaterialesReparaciones.Autocomplete();
            txtDescipcionBus.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDescipcionBus.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public static int idReparacionSeleccionado = 0;
        public static int idHistorialReparacionSeleccionado = 0;
        private void dgvReparaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReparaciones.CurrentCell.ColumnIndex == 4)
            {
                dgvHistorialTaller.Rows.Clear();
                idReparacionSeleccionado = Convert.ToInt32(this.dgvReparaciones.CurrentRow.Cells[0].Value.ToString());
                lblidReparacion.Text = Convert.ToString(idReparacionSeleccionado);
                panel1.Visible = false;
                panelVer.Visible = true;
                List<Reparaciones> ListaHistorialTaller = ReparacionesNeg.ListarHistorialReparacion(idReparacionSeleccionado);
                if (ListaHistorialTaller.Count > 0)
                {
                    foreach (var item in ListaHistorialTaller)
                    {
                        dgvHistorialTaller.Rows.Add(item.idReparaciones, item.Fecha, item.Usuario);
                    }

                }
            }
        }
        public static string Funcion;
        private void btnSalidaTaller_Click(object sender, EventArgs e)
        {
            int idTaller = Convert.ToInt32(lblidReparacion.Text);
            Funcion = "Cierre";
            HistorialReparacionWF _historial = new HistorialReparacionWF(idTaller, Funcion);
            _historial.Show();
        }

        private void btnNuevoHistorial_Click(object sender, EventArgs e)
        {
            int idTaller = Convert.ToInt32(lblidReparacion.Text);
            Funcion = "";
            HistorialReparacionWF _historial = new HistorialReparacionWF(idTaller, Funcion);
            _historial.Show();
        }

        private void dgvHistorialTaller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHistorialTaller.CurrentCell.ColumnIndex == 3)
            {
                idHistorialReparacionSeleccionado = Convert.ToInt32(this.dgvHistorialTaller.CurrentRow.Cells[0].Value.ToString());
                lblidReparacion.Text = Convert.ToString(idHistorialReparacionSeleccionado);
                List<Reparaciones> ListaHistorialTaller = ReparacionesNeg.BuscarHistorialPorId(idHistorialReparacionSeleccionado);
                if (ListaHistorialTaller.Count > 0)
                {
                    string Material = "";
                    DateTime Fecha = DateTime.Now;
                    int idTaller = 0;
                    string Descripcion = "";
                    foreach (var item in ListaHistorialTaller)
                    {
                        Material = item.Material;
                        Fecha = item.Fecha;
                        idTaller = item.idReparaciones;
                        Descripcion = item.Diagnostico;
                    }
                    VisualizarHistorialWF _visualizar = new VisualizarHistorialWF(Material, Fecha, idTaller, Descripcion);
                    _visualizar.Show();
                }
            }
        }

        private void dgvReparaciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvReparaciones.Columns[e.ColumnIndex].Name == "Ver" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvReparaciones.Rows[e.RowIndex].Cells["Ver"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-cursor-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvReparaciones.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvReparaciones.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;
                e.Handled = true;
            }
        }

        private void dgvHistorialTaller_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvHistorialTaller.Columns[e.ColumnIndex].Name == "VerHistorial" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvHistorialTaller.Rows[e.RowIndex].Cells["VerHistorial"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-visible-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvHistorialTaller.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvHistorialTaller.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;
                e.Handled = true;
            }
        }

        private void txtDescipcionBus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FuncionListarMaterialesEnReparacionPorDescripcion();
            }
        }

        private void FuncionListarMaterialesEnReparacionPorDescripcion()
        {
            dgvReparaciones.Rows.Clear();
            List<Reparaciones> ListaTaller = ReparacionesNeg.ListaDeReparacionPorDescripcion(txtDescipcionBus.Text);
            if (ListaTaller.Count > 0)
            {
                foreach (var item in ListaTaller)
                {
                    dgvReparaciones.Rows.Add(item.idReparaciones, item.Material, item.Codigo, item.Modelo);
                }
            }
            dgvReparaciones.ReadOnly = true;
        }
        private void cmbTipoServicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(this.dgvReparaciones.CurrentRow.Cells[0].Value.ToString());
            GenerarCuponDeCodigo(codigo);
        }
    }
}
