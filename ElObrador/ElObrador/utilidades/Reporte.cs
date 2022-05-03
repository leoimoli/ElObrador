using System;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.Windows.Forms;
using ElObrador.utilidades;

namespace waiTextSharp.utilidades
{
    class Reporte
    {

        #region "variables"

        private static string m_Logotipo;

        #endregion

        #region "constructor"

        /// <summary>
        /// Inicializa una nueva instancia de clase <see cref="Reporte"/>
        /// </summary>
        /// <param name="Logotipo">Ruta y nombre del logotipo que se muestra en el encabezado</param>
        public Reporte(string Logotipo)
        {
            try
            {
                // asignar valor
                m_Logotipo = Logotipo;
            }
            catch (Exception Ex)
            {
                // heredar
                throw Ex;
            }
        }

        #endregion

        #region "reporte"

        /// <summary>
        /// Generar el reporte PDF con las caracteristícas e información proporcionada
        /// </summary>
        /// <param name="ReporteNombre">Ruta y nombre del archivo a crear</param>
        /// <param name="PapelTamanio">Tipo de papel <see cref="iTextSharp.text.Rectangle"/></param>
        /// <param name="Encabezado">Encabezado del reporte</param>
        /// <param name="SubEncabezado">Subencabezado del reporte</param>
        /// <param name="TextoAlquiler">texto del reporte</param>
        /// <param name="PiePagina">Pie de página del reporte</param>
        /// <param name="EncabezadoColumnas">Arreglo de columnas que contiene el reporte</param>
        /// <param name="dtbDatos"><see cref="DataTable"/> con la información a imprimir</param>
        public void Generar(string ReporteNombre, Rectangle PapelTamanio, string Encabezado, string SubEncabezado, string DiasHorariosLaborales, string TextoAlquiler, string Nota, string TextoNota, string FirmaAclaracion, string DniFirmante, string TextoLey, string PiePagina, ArrayList EncabezadoColumnas, DataTable dtbDatos)
        {

            //try
            //{
            FileStream fsTmp;
            int[] iTamanio;
            PdfPTable tablaTmp;
            try
            {
                fsTmp = new FileStream(ReporteNombre, FileMode.Create);
            }
            catch (Exception Ex)
            {
                const string message = "Error FileStream.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            Document docTmp = new Document(PapelTamanio, 36, 36, 72, 27);
            PdfWriter m_writerTmp;
            IPdfPageEvent m_peTmp;
            PdfPCell celdaTmp;
            Font fuenteTmp = new Font();
            ReporteColumna udtCIDTmp;
            try
            {
                tablaTmp = new PdfPTable(EncabezadoColumnas.Count);
            }
            catch (Exception Ex)
            {
                const string message = "Error PdfPTable.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            try
            {
                iTamanio = new int[EncabezadoColumnas.Count];
            }
            catch (Exception Ex)
            {
                const string message = "Error iTamanio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            //try
            //{
            try
            {
                // No hay información a imprimir.
                if (dtbDatos.Rows.Count == 0)
                {
                    throw new System.Exception("No hay información para imprimir.");
                }
            }
            catch (Exception Ex)
            {
                const string message = "Error No hay información a imprimir.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            try
            {
                // asignar documento y evento
                m_writerTmp = PdfWriter.GetInstance(docTmp, fsTmp);
                m_peTmp = new ReportePaginaAlquiler(Encabezado, SubEncabezado, DiasHorariosLaborales, TextoAlquiler, Nota, TextoNota, FirmaAclaracion,DniFirmante, TextoLey, PiePagina, EncabezadoColumnas, m_Logotipo, true);
                m_writerTmp.PageEvent = m_peTmp;
            }
            catch (Exception Ex)
            {
                const string message = "Error asignar documento y evento.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            try
            {
                // adicionar propiedades
                docTmp.AddTitle(Comun.AppNombre());
                docTmp.AddAuthor("Vidal TI Consultor");
                docTmp.AddCreator(Comun.AppNombre());
            }
            catch (Exception Ex)
            {
                const string message = "Error adicionar propiedades.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            // abrir documento
            try
            {
                docTmp.Open();
            }
            catch (Exception Ex)
            {
                const string message = "Error docTmp.Open.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            // asignar ancho
            try
            {
                tablaTmp.WidthPercentage = 100;
            }
            catch (Exception Ex)
            {
                const string message = "Error tablaTmpWidthPercentage.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            //tablaTmp.DefaultCell.PaddingTop = 100;
            try
            {
                // obtener ancho de columnas
                for (int i = 0; i <= EncabezadoColumnas.Count - 1; i++)
                {
                    // obtener columna
                    udtCIDTmp = (ReporteColumna)EncabezadoColumnas[i];

                    // obtener tamaño de la columna
                    iTamanio[i] = udtCIDTmp.Tamanio;

                    // destruir
                    udtCIDTmp = null;
                }
            }
            catch (Exception Ex)
            {
                const string message = "Error foreach.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            // fijar ancho de columnas
           
            try
            {
                tablaTmp.SetWidths(iTamanio);             
            }
            catch (Exception Ex)
            {
                const string message = "Error tablaTmpEsEncabezado.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            bool EsEncabezado = true;
            try
            {
                // por cada registro
                foreach (DataRow drwTmp in dtbDatos.Rows)
                {
                    // por cada columna
                    for (int i = 0; i <= EncabezadoColumnas.Count - 1; i++)
                    {
                        // obtener columna
                        udtCIDTmp = (ReporteColumna)EncabezadoColumnas[i];

                        // crear fuente
                        fuenteTmp = new Font();
                        fuenteTmp = FontFactory.GetFont(udtCIDTmp.Fuente, udtCIDTmp.FuenteTamanio, Font.NORMAL);

                        // asignar información
                        if (udtCIDTmp.Formato.Length > 0)
                        {

                            // con formato
                            if (!Convert.IsDBNull(drwTmp[i]))
                            {
                                celdaTmp = new PdfPCell(new Phrase(String.Format("{0:" + udtCIDTmp.Formato + "}", drwTmp[i]), fuenteTmp));
                                //celdaTmp.PaddingTop = 40;
                            }
                            else
                            {
                                celdaTmp = new PdfPCell(new Phrase(" ", fuenteTmp));
                                //celdaTmp.PaddingTop = 40;
                            }
                        }
                        else
                        {
                            // sin formato
                            if (!Convert.IsDBNull(drwTmp[i]))
                            {
                                celdaTmp = new PdfPCell(new Phrase(drwTmp[i].ToString(), fuenteTmp));
                                //celdaTmp.PaddingTop = 40;
                            }
                            else
                            {
                                celdaTmp = new PdfPCell(new Phrase(" ", fuenteTmp));
                                //celdaTmp.PaddingTop = 40;
                            }
                        }

                        // adicionar
                        if (EsEncabezado == false)
                        {
                            celdaTmp.Border = PdfPCell.NO_BORDER;
                            celdaTmp.HorizontalAlignment = udtCIDTmp.AlineacionValor;
                            celdaTmp.VerticalAlignment = Element.ALIGN_MIDDLE;
                        }
                        else
                        {
                            celdaTmp.BackgroundColor = Color.LIGHT_GRAY;

                            celdaTmp.HorizontalAlignment = udtCIDTmp.AlineacionValor;
                            celdaTmp.VerticalAlignment = Element.ALIGN_MIDDLE;
                        }
                        tablaTmp.AddCell(celdaTmp);

                        // resetear
                        udtCIDTmp = null;
                    }
                    EsEncabezado = false;
                }
            }
            catch (Exception Ex)
            {
                const string message = "Erro foreach de datos.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            try
            {
                // adicionar línea en blanco
                celdaTmp = new PdfPCell(new Phrase(" ", fuenteTmp))
                {
                    Border = PdfPCell.NO_BORDER,
                    Colspan = EncabezadoColumnas.Count,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_TOP
                };
            }
            catch (Exception Ex)
            {
                const string message = "Erro celdaTmp.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            //tablaTmp.AddCell(celdaTmp);
            try
            {
                tablaTmp.TotalWidth = 500;
            }
            catch (Exception Ex)
            {
                const string message = "Erro tablaTmpTotalWidth.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            try
            {
                // adicionar tabla con la información
                tablaTmp.WriteSelectedRows(0, -1, docTmp.LeftMargin + 30, docTmp.Top - 60, m_writerTmp.DirectContent);
            }
            catch (Exception Ex)
            {
                const string message = "Erro tablaTmp.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                //// heredar
                //throw Ex;
            }
            //docTmp.Add(tablaTmp);
            // }
            //catch (Exception Ex)
            //{
            //    const string message = "Erro al generar el comprobante.";
            //    const string caption = "Error";
            //    var result = MessageBox.Show(message, caption,
            //                                 MessageBoxButtons.OK,
            //                               MessageBoxIcon.Exclamation);
            //    throw new Exception();
            //    //// heredar
            //    //throw Ex;
            //}
            finally
            {
                // cerrar
                if (docTmp.IsOpen()) docTmp.Close();
                fsTmp.Close();
            }
            //}
            //catch (Exception Ex)
            //{
            //    string mensaje = "Error generico variable.";
            //    string message = mensaje;
            //    const string caption = "Error";
            //    var result = MessageBox.Show(message, caption,
            //                                 MessageBoxButtons.OK,
            //                               MessageBoxIcon.Exclamation);
            //    throw new Exception();
            //    //// heredar
            //    //throw Ex;
            //}
        }

        #endregion
    }
}