using System;
using System.Collections;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using waiTextSharp.utilidades;

namespace ElObrador.utilidades
{
    class ReportePaginaCodigoNroReparacion : PdfPageEventHelper
    {
        #region "enumerador"
        protected enum CeldaBorde
        {
            ninguno,
            arriba,
            abajo,
            arribayabajo,
            izquierda,
            izquierdayarriba,
            izquierdayabajo,
            izquierdaarribayabajo,
            derecha,
            derechayarriba,
            derechayabajo,
            derechaarribayabajo,
            izquierdayderecha,
            izquierdaderechayarriba,
            izquierdaderechayabajo,
            todos
        }
        /// <summary>
        /// Enumerador que indica el borde que se debe de applicar a una celda de la tabla <see cref="PdfPCell"/>
        /// </summary>
        #endregion

        #region "varibles"

        private string m_Encabezado;
        private string m_Subencabezado;
        private string m_DiasHorariosLaborales;
        private string m_TextoAlquiler;
        private string m_TextoLey;
        private string m_PiePagina;
        private ArrayList m_EncabezadoColumnas;
        private readonly string m_Logo;
        private bool m_Detalle;
        private bool m_Activo;
        //
        private PdfContentByte m_cbTmp;
        private PdfTemplate m_template;
        private BaseFont m_bfTmp;

        #endregion

        #region "constructor"

        /// <summary>
        /// Inicializa una nueva instancia de clase <see cref="ReportePaginaOrdenTrabajo"/>, esta clase se encarga del encabezado y pie de página
        /// </summary>
        /// <param name="encabezado">Encabezado a mostrar</param>
        /// <param name="subencabezado">Subencabezado a mostrar</param>
        /// <param name="TextoAlquiler">Texto a mostrar</param>
        /// <param name="Prueba">Texto a mostrar</param>
        /// <param name="piePagina">Pie de página a mostrar</param>
        /// <param name="encabezadocolumnas">Arreglo de columnas que contiene el reporte</param>
        /// <param name="logoNombre">Ruta y nombre del Logotipo</param>
        /// <param name="blnDetalle">true = Para mostrar lo títulos de las columnas, false = Para no mostrar los títulos de la columnas</param>
        public ReportePaginaCodigoNroReparacion(string encabezado, string subencabezado, string DiasHorariosLaborales, string TextoAlquiler, string TextoLey, string piePagina, ArrayList encabezadocolumnas, string logotipo, bool blnDetalle)
        {
            try
            {
                // asignar valores
                m_Encabezado = encabezado;
                m_Subencabezado = subencabezado;
                m_DiasHorariosLaborales = DiasHorariosLaborales;
                m_TextoAlquiler = TextoAlquiler;
                m_TextoLey = TextoLey;
                //m_Prueba = Prueba;
                m_PiePagina = piePagina;
                //m_EncabezadoColumnas = encabezadocolumnas;
                m_Logo = logotipo;
                //m_Detalle = blnDetalle;
                m_Activo = true;
            }
            catch (Exception Ex)
            {
                // heredar
                throw Ex;
            }
        }

        #endregion

        #region "funciones"

        /// <summary>
        /// Insertar saltos de línea
        /// </summary>
        /// <param name="numeroSaltos">Saltos de línea a insertar</param>
        /// <returns></returns>
        private string LineaSalto(int numeroSaltos)
        {
            StringBuilder sbTmp = new StringBuilder();
            try
            {
                // incrementar saltos
                for (int i = 1; i <= numeroSaltos; i++)
                {
                    // adicionar saltos
                    sbTmp.Append("\r\n");
                }

                // final
                return sbTmp.ToString();
            }
            catch (Exception Ex)
            {
                // heredar
                throw Ex;
            }
        }

        #endregion

        #region "propiedades"

        public string Encabezado
        {
            get { return m_Encabezado; }
            set { m_Encabezado = value; }
        }

        public string Subencabezado
        {
            get { return m_Subencabezado; }
            set { m_Subencabezado = value; }
        }

        public string DiasHorariosLaborales
        {
            get { return m_DiasHorariosLaborales; }
            set { m_DiasHorariosLaborales = value; }
        }

        public string TextoAlquiler
        {
            get { return m_TextoAlquiler; }
            set { m_TextoAlquiler = value; }
        }

        public string TextoLey
        {
            get { return m_TextoLey; }
            set { m_TextoLey = value; }
        }
        //public string Prueba
        //{
        //    get { return m_Prueba; }
        //    set { m_Prueba = value; }
        //}

        public string PiePagina
        {
            get { return m_PiePagina; }
            set { m_PiePagina = value; }
        }

        public ArrayList EncabezadoColumnas
        {
            get { return m_EncabezadoColumnas; }
            set { m_EncabezadoColumnas = value; }
        }

        public bool Detalle
        {
            get { return m_Detalle; }
            set { m_Detalle = value; }
        }

        public bool Activo
        {
            get { return m_Activo; }
            set { m_Activo = value; }
        }

        #endregion

        #region "sobreescritura"

        /// <summary>
        /// Sobreescritura del método OnOpenDocument, para inicializar las variables necesarias
        /// </summary>
        /// <param name="writer">Objeto PdfWriter del pdf</param>
        /// <param name="document">Objeto Document del pdf</param>
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                // variables
                m_bfTmp = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                // crear plantilla
                m_cbTmp = writer.DirectContent;
                m_template = m_cbTmp.CreateTemplate(50, 50);
            }
            catch (Exception ex)
            {
                // bitacora heredar
                throw ex;
            }
        }

        /// <summary>
        /// Sobreescritura del método OnEndPage, para escribir el pie de página
        /// </summary>
        /// <param name="writer">Objeto PdfWriter del pdf</param>
        /// <param name="document">Objeto Document del pdf</param>
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfPTable tblEncabezado = new PdfPTable(2);
            PdfPTable tblSubencabezado = new PdfPTable(1);
            PdfPTable tblDiasHorariosLaborales = new PdfPTable(1);
            PdfPTable tblTextoAlquiler = new PdfPTable(1);
            PdfPTable tblTextoAlquiler2 = new PdfPTable(1);
            PdfPTable tblTextoAlquiler3 = new PdfPTable(1);
            PdfPTable tblTextoAlquiler4 = new PdfPTable(1);
            PdfPTable tblTextoAlquiler5 = new PdfPTable(1);
            PdfPTable tblTextoLey = new PdfPTable(1);
            //PdfPTable tblPrueba = new PdfPTable(2);
            // PdfPTable tblEncabezadoColumnas = new PdfPTable((m_EncabezadoColumnas.Count == 0) ? 1 : m_EncabezadoColumnas.Count);
            PdfPTable tblEncabezadoColumnas = new PdfPTable(1);
            PdfPTable tblLogotipo = new PdfPTable(1);
            PdfPTable tblPiePagina = new PdfPTable(3);
            //int[] iTamanio = new int[m_EncabezadoColumnas.Count];
            int[] iTamanio = new int[1];
            ReporteColumna udtCIDCuerpo;
            //
            PdfPCell cellTmp;
            Image imgLogo;
            Phrase fraseTmp;
            //
            Font fEncabezado;
            Font fSubEncabezado;
            Font fDiasHorariosLaborales;
            Font fTextoAlquiler;
            Font fTextoLey;
            //Font fPrueba;
            Font fPiePagina;
            Font fEncabezadoColumnas;
            Font fTamanio2;
            Rectangle recTmp;
            //Rectangle recTmp2;
            //
            string tPagina = "Impreso el " + DateTime.Now.ToShortDateString() + " Página " + writer.PageNumber.ToString() + " de ";
            float sLongitud = m_bfTmp.GetWidthPoint(tPagina, 8);
            try
            {
                // verificar
                if (m_Activo)
                {
                    // definir encabezado, subencabezado, logotipo y pie de página
                    tblEncabezado.WidthPercentage = 100;

                    tblSubencabezado.WidthPercentage = 100;
                    //tblSubencabezado.DefaultCell.BorderWidthTop = 50;
                    //tblSubencabezado.DefaultCell.BorderColorTop = Color.BLACK;
                    //tblDiasHorariosLaborales.WidthPercentage = 100;
                    //tblTextoAlquiler.WidthPercentage = 50;
                    //tblTextoAlquiler2.WidthPercentage = 50;
                    //tblTextoAlquiler3.WidthPercentage = 33;
                    //tblTextoAlquiler4.WidthPercentage = 33;
                    //tblTextoAlquiler5.WidthPercentage = 33;
                    //tblTextoLey.WidthPercentage = 100;
                    //tblPrueba.WidthPercentage = 100;
                    tblEncabezadoColumnas.WidthPercentage = 100;
                    tblLogotipo.WidthPercentage = 100;
                    tblPiePagina.WidthPercentage = 100;


                    // columnas encabezado, subencabezado, logotipo y pie de página
                    tblEncabezado.SetWidths(new int[] { 20, 80 });

                    tblSubencabezado.SetWidths(new int[] { 100 });
                    //tblDiasHorariosLaborales.SetWidths(new int[] { 100 });
                    //tblTextoAlquiler.SetWidths(new int[] { 50 });
                    //tblTextoAlquiler2.SetWidths(new int[] { 50 });
                    //tblTextoAlquiler3.SetWidths(new int[] { 33 });
                    //tblTextoAlquiler4.SetWidths(new int[] { 33 });
                    //tblTextoAlquiler5.SetWidths(new int[] { 33 });
                    //tblTextoLey.SetWidths(new int[] { 100 });
                    tblLogotipo.SetWidths(new int[] { 100 });
                    tblPiePagina.SetWidths(new int[] { 7, 15, 10 });

                    // definir fuentes
                    fEncabezado = new Font();
                    fEncabezado = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, Font.BOLD);
                    fSubEncabezado = new Font();
                    fSubEncabezado = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, Font.NORMAL);
                    fDiasHorariosLaborales = new Font();
                    fDiasHorariosLaborales = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 7, Font.NORMAL);
                    fTextoAlquiler = new Font();
                    fTextoAlquiler = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL);
                    fTextoLey = new Font();
                    fTextoLey = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, Font.NORMAL);
                    fTamanio2 = new Font();
                    fTamanio2 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 2, Font.NORMAL);



                    // cargar logotipo
                    imgLogo = Image.GetInstance(m_Logo);

                    // aplicar escala a logotipo
                    imgLogo.ScalePercent(Comun.AppLogoEscala);

                    // adicionar logotipo
                    cellTmp = new PdfPCell(imgLogo)
                    {
                        Border = (int)CeldaBorde.ninguno,
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    tblLogotipo.AddCell(cellTmp);         

                    // verificar
                    if (m_Subencabezado.Length > 0)
                    {
                        // adicionar subencabezado
                        cellTmp = new PdfPCell(new Phrase(m_Subencabezado, fSubEncabezado))
                        {
                            Border = (int)CeldaBorde.ninguno,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            PaddingTop = 20,
                            PaddingLeft = -40,
                            VerticalAlignment = Element.ALIGN_CENTER
                        };
                        tblSubencabezado.AddCell(cellTmp);
                    }

                    // linea en blanco
                    cellTmp = new PdfPCell(new Phrase(" ", fSubEncabezado))
                    {
                        Border = (int)CeldaBorde.ninguno,
                        Colspan = 2,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    tblSubencabezado.AddCell(cellTmp);

                    // verificar Dias Laborales
                    if (m_DiasHorariosLaborales.Length > 0)
                    {
                        // adicionar Dias Laborales
                        cellTmp = new PdfPCell(new Phrase(m_DiasHorariosLaborales, fDiasHorariosLaborales))
                        {
                            Border = (int)CeldaBorde.ninguno,
                            HorizontalAlignment = Element.ALIGN_RIGHT,
                            VerticalAlignment = Element.ALIGN_LEFT
                        };
                        tblDiasHorariosLaborales.AddCell(cellTmp);
                    }

                    // linea en blanco
                    cellTmp = new PdfPCell(new Phrase(" ", fDiasHorariosLaborales))
                    {
                        Border = (int)CeldaBorde.ninguno,
                        Colspan = 2,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    tblDiasHorariosLaborales.AddCell(cellTmp);

                    ////// Parseo del valor texto
                    string DatoInicial = TextoAlquiler;
                    string Persona = DatoInicial.Split(';')[0];
                    string Telefono = DatoInicial.Split(';')[1];
                    string Referencia = DatoInicial.Split(';')[2];
                    string Seña = DatoInicial.Split(';')[3];
                    string FechaEstimada = DatoInicial.Split(';')[4];

                    //string Telefono = SegundaCadena.Split(';')[0];
                    //string TerceraCadena = SegundaCadena.Split(';')[1];

                    //string Referencia = TerceraCadena.Split(';')[0];
                    //string CuartaCadena = TerceraCadena.Split(';')[1];

                    //string Seña = CuartaCadena.Split(';')[0];
                    //string QuintaCadena = Seña.Split(';')[1];

                    //string FechaEstimada = QuintaCadena.Split(';')[0];
                    //string SextaCadena = FechaEstimada.Split(';')[1];                 


                    // verificar
                    if (m_TextoAlquiler.Length > 0)
                    {
                        // adicionar textoAlquiler
                        var ApellidoNombre = new PdfPCell(new Phrase(Persona, fTextoAlquiler))
                        {
                            Border = (int)CeldaBorde.ninguno,
                            BorderWidthTop = 2,
                            PaddingRight = 2,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_BOTTOM
                        };
                        tblTextoAlquiler.AddCell(ApellidoNombre);

                        var Tel = new PdfPCell(new Phrase(Telefono, fTextoAlquiler))
                        {
                            Border = (int)CeldaBorde.ninguno,
                            BorderWidthTop = 2,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_BOTTOM
                        };
                        tblTextoAlquiler2.AddCell(Tel);


                        var Ref = new PdfPCell(new Phrase(Referencia, fTextoAlquiler))
                        {
                            Border = 0,// (int)CeldaBorde.ninguno,
                            BorderWidthTop = 0,// 2,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_BOTTOM
                        };
                        tblTextoAlquiler3.AddCell(Ref);

                        var Señ = new PdfPCell(new Phrase(Seña, fTextoAlquiler))
                        {
                            Border = 0,// (int)CeldaBorde.ninguno,
                            BorderWidthTop = 0,// 2,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_BOTTOM
                        };
                        tblTextoAlquiler4.AddCell(Señ);

                        var Fecha = new PdfPCell(new Phrase(FechaEstimada, fTextoAlquiler))
                        {
                            Border = 0,// (int)CeldaBorde.ninguno,
                            BorderWidthTop = 0,// 2,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_BOTTOM
                        };
                        tblTextoAlquiler5.AddCell(Fecha);
                    }

                    // linea en blanco
                    cellTmp = new PdfPCell(new Phrase(" ", fTextoAlquiler))
                    {
                        Border = (int)CeldaBorde.ninguno,
                        Colspan = 2,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    tblTextoAlquiler.AddCell(cellTmp);
                    // verificar
                    if (m_TextoLey.Length > 0)
                    {
                        // adicionar textoLey
                        cellTmp = new PdfPCell(new Phrase(m_TextoLey, fTextoLey))
                        {
                            Border = (int)CeldaBorde.ninguno,
                            BorderWidthTop = 2,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_BOTTOM
                        };
                        tblTextoLey.AddCell(cellTmp);
                    }

                    // linea en blanco
                    cellTmp = new PdfPCell(new Phrase(" ", fTextoLey))
                    {
                        Border = (int)CeldaBorde.ninguno,
                        Colspan = 2,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    tblTextoLey.AddCell(cellTmp);


                    cellTmp = new PdfPCell(tblLogotipo)
                    {
                        Border = (int)CeldaBorde.ninguno,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_TOP
                    };
                    tblEncabezado.AddCell(cellTmp);

                    // adicionar encabezado
                    cellTmp = new PdfPCell(tblSubencabezado)
                    {
                        Border = (int)CeldaBorde.ninguno,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_TOP
                    };
                    tblEncabezado.AddCell(cellTmp);

                    // verificar
                    if (m_Detalle)
                    {
                        // por cada columna
                        for (int i = 0; i <= m_EncabezadoColumnas.Count - 1; i++)
                        {
                            // recuperar columna
                            udtCIDCuerpo = (ReporteColumna)m_EncabezadoColumnas[i];


                            // obtener ancho de la columna
                            iTamanio[i] = udtCIDCuerpo.Tamanio;

                            // resetear
                            udtCIDCuerpo = null;
                        }

                        // fijar ancho de columnas
                        tblEncabezadoColumnas.SetWidths(iTamanio);
                        // por cada columna
                        for (int i = 0; i <= m_EncabezadoColumnas.Count - 1; i++)
                        {
                            // recuperar columna
                            udtCIDCuerpo = (ReporteColumna)m_EncabezadoColumnas[i];
                            // crear fuente
                            fEncabezadoColumnas = new Font();
                            fEncabezadoColumnas = FontFactory.GetFont(udtCIDCuerpo.Fuente, udtCIDCuerpo.FuenteTamanio, (udtCIDCuerpo.Negrita == true) ? Font.BOLD : Font.NORMAL);

                            // adicionar etiqueta
                            fraseTmp = new Phrase(udtCIDCuerpo.Etiqueta, fEncabezadoColumnas);
                            cellTmp = new PdfPCell(fraseTmp)
                            {
                                BackgroundColor = new Color(System.Drawing.Color.WhiteSmoke),
                                Border = PdfPCell.NO_BORDER,
                                HorizontalAlignment = udtCIDCuerpo.AlineacionEtiqueta,
                                VerticalAlignment = Element.ALIGN_MIDDLE,

                            };
                            cellTmp.Top = 200;


                            // resetear
                            udtCIDCuerpo = null;
                        }

                        // adicionar titulos a encabezado
                        cellTmp = new PdfPCell(tblEncabezadoColumnas)
                        {
                            Border = (int)CeldaBorde.arribayabajo,
                            BorderColor = new Color(System.Drawing.Color.LightGray),
                            Colspan = 2,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                        };

                        //tblPrueba.AddCell(cellTmp);

                    }
                    else
                    {
                        // linea en blanco
                        fraseTmp = new Phrase(LineaSalto(3), fTamanio2);
                        cellTmp = new PdfPCell(fraseTmp)
                        {
                            Border = (int)CeldaBorde.arriba,
                            BorderColor = new Color(System.Drawing.Color.LightGray),
                            Colspan = 2,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        //tblEncabezado.AddCell(cellTmp);
                        //tblPrueba.AddCell(cellTmp);

                    }
                    Rectangle rectangle2 = new Rectangle(200, 200);



                    // pie de página
                    fPiePagina = new Font();
                    fPiePagina = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 6, Font.BOLD);

                    // adicionar plantilla para número de paginas
                    recTmp = document.PageSize;
                    m_cbTmp.BeginText();
                    m_cbTmp.SetFontAndSize(m_bfTmp, 6);
                    m_cbTmp.SetTextMatrix(recTmp.Width - (document.RightMargin + sLongitud + 5), 11);
                    m_cbTmp.ShowText(tPagina);
                    m_cbTmp.EndText();
                    m_cbTmp.AddTemplate(m_template, (recTmp.Width - document.RightMargin - 5), 11);

                    // adicionar texto pie de página
                    fraseTmp = new Phrase(m_PiePagina, fPiePagina);
                    cellTmp = new PdfPCell(fraseTmp)
                    {
                        Border = (int)CeldaBorde.arriba,
                        BorderColor = new Color(System.Drawing.Color.LightGray),
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    tblPiePagina.AddCell(cellTmp);

                    // adicionar espacios
                    fraseTmp = new Phrase(" ", fPiePagina);
                    cellTmp = new PdfPCell(fraseTmp)
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        Border = (int)CeldaBorde.arriba,
                        BorderColor = new Color(System.Drawing.Color.LightGray),
                        Colspan = 2
                    };
                    tblPiePagina.AddCell(cellTmp);

                    // establecer Encabezado
                    recTmp = document.PageSize;
                    tblEncabezado.TotalWidth = recTmp.Width - document.LeftMargin - document.RightMargin;
                    tblEncabezado.WriteSelectedRows(0, -1, document.LeftMargin, recTmp.Height - document.TopMargin + tblEncabezado.TotalHeight, writer.DirectContent);

                    //recTmp = document.PageSize;
                    //tblSubencabezado.TotalWidth = recTmp.Width - document.LeftMargin - document.RightMargin;
                    //tblSubencabezado.WriteSelectedRows(0, -1, document.LeftMargin, recTmp.Height - document.TopMargin + tblEncabezado.TotalHeight - 10, writer.DirectContent);

                    //// establecer Dias Laborales
                    //recTmp = document.PageSize;
                    //tblDiasHorariosLaborales.TotalWidth = recTmp.Width - document.LeftMargin - document.RightMargin;
                    //tblDiasHorariosLaborales.WriteSelectedRows(0, -1, document.LeftMargin, recTmp.Height - document.TopMargin + tblDiasHorariosLaborales.TotalHeight, writer.DirectContent);

                    ////// establecer Texto
                    //recTmp = document.PageSize;
                    ////tblTextoAlquiler.TotalWidth = recTmp.Width - document.LeftMargin - document.RightMargin;
                    //tblTextoAlquiler.TotalWidth = 400;
                    //tblTextoAlquiler.WriteSelectedRows(0, -1, document.LeftMargin, document.Top - 10, writer.DirectContent);

                    ////// establecer Texto 2
                    //recTmp = document.PageSize;
                    //tblTextoAlquiler2.TotalWidth = recTmp.Width - document.LeftMargin - document.RightMargin;
                    //tblTextoAlquiler2.WriteSelectedRows(0, -1, document.Left + tblTextoAlquiler.TotalWidth, document.Top - 10, writer.DirectContent);

                    ////// establecer Texto 3
                    //recTmp = document.PageSize;
                    //tblTextoAlquiler3.TotalWidth = 200;
                    //tblTextoAlquiler3.WriteSelectedRows(0, -1, document.LeftMargin, document.Top - 20, writer.DirectContent);

                    ////// establecer Texto 4
                    //recTmp = document.PageSize;
                    //tblTextoAlquiler4.TotalWidth = recTmp.Width - document.LeftMargin - document.RightMargin;
                    //tblTextoAlquiler4.WriteSelectedRows(0, -1, document.Left + tblTextoAlquiler3.TotalWidth, document.Top - 20, writer.DirectContent);

                    ////// establecer Texto 5
                    //recTmp = document.PageSize;
                    //tblTextoAlquiler5.TotalWidth = recTmp.Width - document.LeftMargin - document.RightMargin;
                    //tblTextoAlquiler5.WriteSelectedRows(0, -1, document.Left + tblTextoAlquiler4.TotalWidth - 180, document.Top - 20, writer.DirectContent);

                    ////// establecer TextoLey
                    //recTmp = document.PageSize;
                    //tblTextoLey.TotalWidth = recTmp.Width - document.LeftMargin - document.RightMargin;
                    //tblTextoLey.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin + 90, writer.DirectContent);

                    // establecer pie de página
                    recTmp = document.PageSize;
                    tblPiePagina.TotalWidth = recTmp.Width - document.LeftMargin - document.RightMargin;
                    tblPiePagina.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin, writer.DirectContent);
                }
            }
            catch (Exception Ex)
            {
                // heredar
                throw Ex;
            }
        }

        /// <summary>
        /// Sobreescritura del método OnCloseDocument, para actualizar el número de página
        /// </summary>
        /// <param name="writer">Objeto PdfWriter del pdf</param>
        /// <param name="document">Objeto Document del pdf</param>
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            try
            {
                // escribir número de página final
                m_template.BeginText();
                m_template.SetFontAndSize(m_bfTmp, 6);
                m_template.ShowText((writer.PageNumber - 1).ToString());
                m_template.EndText();
            }
            catch (Exception Ex)
            {
                // heredar
                throw Ex;
            }
        }

        #endregion
    }
}
