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
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using ElObrador.Clases_Maestras;

namespace ElObrador
{
    public partial class ReportViewerAlquilerWF : Form
    {
        private int idAlquiler;
        private List<Alquiler> listaAlquiler;

        public ReportViewerAlquilerWF(int idAlquiler, List<Alquiler> listaAlquiler)
        {
            InitializeComponent();
            this.Load += Form1_Load1;
            this.idAlquiler = idAlquiler;
            this.listaAlquiler = listaAlquiler;
        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            CargarReporte(idAlquiler, listaAlquiler);
        }

        private DataTable ConvertListToDataTable()
        {
            // New table.
            DataTable table = new DataTable();

            // Add columns.
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("ApellidoPat", typeof(string));
            table.Columns.Add("ApellidMat", typeof(string));
            table.Columns.Add("TipoDocument", typeof(string));
            table.Columns.Add("Correo", typeof(string));
            // Add rows.
  
            {
                DataRow row = table.NewRow();
                row["Nombre"] = "BONIFICACION";
                row["ApellidoPat"] = "BONIFICACION";
                row["ApellidMat"] = "BONIFICACION";
                row["TipoDocument"] = "BONIFICACION";
                row["Correo"] = "BONIFICACION"; 
                table.Rows.Add(row);
            }
            return table;
        }

        private void CargarReporte(int idAlquiler, List<Alquiler> listaAlquiler)
        {
            List<Persona> Agregar = new List<Persona>();
            Agregar.Add(new Persona
            {
                Nombre = "Prueba",
                ApellidoPat = "Prueba",
                ApellidMat = "Prueba",
                TipoDocument = "Prueba",
                Correo = "Prueba"
                //Vigencia 
            }
        );

            ///Mostrar datos en el reporte
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ElObrador.Reporte.rdlc";
            //this.reportViewer1.LocalReport.ReportPath = "Reporte.rdlc";
            ReportDataSource rds1 = new ReportDataSource("Personas", Agregar);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();





            //    List<Alquiler> Agregar = new List<Alquiler>();
            //    Agregar.Add(new Alquiler
            //    {
            //        Material = listaAlquiler[0].Material
            //    }
            //); ;


            //////Customers dsCustomers = GetData();
            ////ReportDataSource datasource = new ReportDataSource("Customers", Agregar);
            ////this.reportViewer1.LocalReport.DataSources.Clear();
            ////this.reportViewer1.LocalReport.DataSources.Add(datasource);
            ////this.reportViewer1.RefreshReport();
            //List<ReportParameter> Parametros = new List<ReportParameter>();
            //// Mostrar datos en el reporte
            //reportViewer1.ProcessingMode = ProcessingMode.Local;
            //reportViewer1.Reset();
            //int s = 0;
            ////reportViewer1.LocalReport.ReportEmbeddedResource = "Reporte.rdlc";

            //    //this.reportViewer1.LocalReport.ReportEmbeddedResource = "ElObrador.Reporte.rdlc";
            //    this.reportViewer1.LocalReport.ReportPath = "Reporte.rdlc";
            //if (!(System.IO.File.Exists(reportViewer1.LocalReport.ReportPath)))
            //    s = 1;
            //DataTable dt = ConvertListToDataTable();
            //Parametros.Add(new ReportParameter("test", DateTime.Now.ToShortDateString()));
            //ReportDataSource rds1 = new ReportDataSource("Personas",dt);
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(rds1);

            ////this.reportViewer1.LocalReport.SetParameters(Parametros);
            //this.reportViewer1.LocalReport.Refresh();
            //reportViewer1.LocalReport.Dispose();
            //reportViewer1.Dispose();

            //this.reportViewer1.LocalReport.Refresh();

            //ReportParameter[] repParamHeader = new ReportParameter[1];
            //repParamHeader[0] = new ReportParameter("Material", Agregar[0].Material, false);      





            ////LAS TRES LINEAS SIGUIENTES SON OBLIGATORIAS PARA QUE SE RECONOZCA COMO RECURSO EMBEBIDO
            //reportViewer1.ProcessingMode = ProcessingMode.Local;
            //reportViewer1.Reset();
            //reportViewer1.LocalReport.ReportEmbeddedResource = "ElObrador.ReciboElObrador.rdlc";

            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsInformes", Agregar));
            //reportViewer1.LocalReport.SetParameters(repParamHeader);
            //reportViewer1.LocalReport.Refresh();
        }

        private void ReportViewerAlquilerWF_Load(object sender, EventArgs e)
        {

        }
    }
}
