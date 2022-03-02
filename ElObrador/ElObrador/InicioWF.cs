﻿using ElObrador.Dao;
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
using System.Timers;
using System.Windows.Forms;

namespace ElObrador
{
    public partial class InicioWF : Form
    {
        public InicioWF()
        {
            InitializeComponent();
        }
        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void InicioWF_Load(object sender, EventArgs e)
        {
            txtBuscarEnGrilla.Focus();
            FuncionBuscartexto();
            ///// Armo Panel de Informacion
            int totalProvedores = ReportesDao.ContadorProveedores();
            int totalClientes = ReportesDao.ContadorClientes();
            int totalMateriales = ReportesDao.ContadorProductos();
            int totalReparaciones = ReportesDao.ContadorReparaciones();
            int totalAlquileres = ReportesDao.ContadorAlquileres();
            int totalUsuarios = ReportesDao.ContadorUsuarios();

            if (totalAlquileres > 9999)
            {
                lblContadorVentas.Text = "+ 10.000";
            }
            if (totalAlquileres > 99999)
            {
                lblContadorVentas.Text = "+ 100.000";
            }
            if (totalAlquileres > 999999)
            {
                lblContadorVentas.Text = "+ 1.000.000";
            }
            else
            {
                lblContadorVentas.Text = Convert.ToString(totalAlquileres);
            }
            if (totalMateriales > 9999)
            {
                lblContadorProdcutos.Text = "+ 10.000";
            }
            if (totalMateriales > 99999)
            {
                lblContadorProdcutos.Text = "+ 100.000";
            }
            if (totalMateriales > 999999)
            {
                lblContadorProdcutos.Text = "+ 1.000.000";
            }
            else
            {
                lblContadorProdcutos.Text = Convert.ToString(totalMateriales);
            }
            if (totalClientes > 9999)
            {
                lblContadorClientes.Text = "+ 10.000";
            }
            if (totalClientes > 99999)
            {
                lblContadorClientes.Text = "+ 100.000";
            }
            if (totalClientes > 999999)
            {
                lblContadorClientes.Text = "+ 1.000.000";
            }
            else
            {
                lblContadorClientes.Text = Convert.ToString(totalClientes);
            }
            if (totalProvedores > 9999)
            {
                lblContadorProveedores.Text = "+ 10.000";
            }
            if (totalProvedores > 99999)
            {
                lblContadorProveedores.Text = "+ 100.000";
            }
            if (totalProvedores > 999999)
            {
                lblContadorProveedores.Text = "+ 1.000.000";
            }
            else
            {
                lblContadorProveedores.Text = Convert.ToString(totalProvedores);
            }
            if (totalReparaciones > 9999)
            {
                lblContadorMarcas.Text = "+ 10.000";
            }
            if (totalReparaciones > 99999)
            {
                lblContadorMarcas.Text = "+ 100.000";
            }
            if (totalReparaciones > 999999)
            {
                lblContadorMarcas.Text = "+ 1.000.000";
            }
            else
            {
                lblContadorMarcas.Text = Convert.ToString(totalReparaciones);
            }
            if (totalUsuarios > 9999)
            {
                lblContadorUsuarios.Text = "+ 10.000";
            }
            if (totalUsuarios > 99999)
            {
                lblContadorUsuarios.Text = "+ 100.000";
            }
            if (totalUsuarios > 999999)
            {
                lblContadorUsuarios.Text = "+ 1.000.000";
            }
            else
            {
                lblContadorUsuarios.Text = Convert.ToString(totalUsuarios);
            }
            ///// Dia y Hora
            CheckForIllegalCrossThreadCalls = false;
            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            t.Start();
            String DiaDeLaSemana = DateTime.Now.DayOfWeek.ToString();
            string Dia = ValidarDia(DiaDeLaSemana);
            String FechaDia = DateTime.Now.Day.ToString();
            String Month = DateTime.Now.Month.ToString();
            string Mes = ValidarMes(Month);
            String Year = DateTime.Now.Year.ToString();
            int month = Convert.ToInt32(Month);
            int year = Convert.ToInt32(Year);
            lblDia.Text = Dia + "," + " " + FechaDia + " " + "de" + " " + Mes + " " + Year;

            ///// Completo Grilla con informacion
            BuscarAlquileresVigentes();
        }

        private void FuncionBuscartexto()
        {
            txtBuscarEnGrilla.AutoCompleteCustomSource = Clases_Maestras.AutoCompleteMateriales.Autocomplete();
            txtBuscarEnGrilla.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscarEnGrilla.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void BuscarAlquileresVigentes()
        {
            List<Alquiler> ListaAlquileres = new List<Alquiler>();
            ListaAlquileres = AlquilerNeg.ListarAlquileresActuales();
            if (ListaAlquileres.Count > 0)
            {
                dgvAlquiler.Rows.Clear();
                foreach (var item in ListaAlquileres)
                {
                    dgvAlquiler.Rows.Add(item.idAlquiler, item.idMaterial, item.DescripcionProducto, item.Dias, item.FechaDesde, item.FechaHasta);
                }
            }
            dgvAlquiler.ReadOnly = true;
        }
        private string ValidarDia(string diaDeLaSemana)
        {
            string Dia = "";
            if (diaDeLaSemana == "Monday")
            {
                Dia = "Lunes";
            }
            if (diaDeLaSemana == "Tuesday")
            {
                Dia = "Martes";
            }
            if (diaDeLaSemana == "Wednesday")
            {
                Dia = "Miercoles";
            }
            if (diaDeLaSemana == "Thursday")
            {
                Dia = "Jueves";
            }
            if (diaDeLaSemana == "Friday")
            {
                Dia = "Viernes";
            }
            if (diaDeLaSemana == "Saturday")
            {
                Dia = "Sábado";
            }
            if (diaDeLaSemana == "Sunday")
            {
                Dia = "Domingo";
            }
            return Dia;
        }
        private string ValidarMes(string Month)
        {
            string Mes = "";
            if (Month == "1")
            {
                Mes = "Enero";
            }
            if (Month == "2")
            {
                Mes = "Febrero";
            }
            if (Month == "3")
            {
                Mes = "Marzo";
            }
            if (Month == "4")
            {
                Mes = "Abril";
            }
            if (Month == "5")
            {
                Mes = "Mayo";
            }
            if (Month == "6")
            {
                Mes = "Junio";
            }
            if (Month == "7")
            {
                Mes = "Julio";
            }
            if (Month == "8")
            {
                Mes = "Agosto";
            }
            if (Month == "9")
            {
                Mes = "Septiembre";
            }
            if (Month == "10")
            {
                Mes = "Octubre";
            }
            if (Month == "11")
            {
                Mes = "Noviembre";
            }
            if (Month == "12")
            {
                Mes = "Diciembre";
            }
            return Mes;
        }
        private void timer1_Tick(object sender, ElapsedEventArgs el)
        {
            CheckForIllegalCrossThreadCalls = false;
            lblMaster_FechaHoraReal.Text = Convert.ToString(DateTime.Now.ToString("HH:mm:ss"));
        }
        private void dgvAlquiler_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvAlquiler.Columns[e.ColumnIndex].Name == "Informe" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvAlquiler.Rows[e.RowIndex].Cells["Informe"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-report-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvAlquiler.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvAlquiler.Columns[e.ColumnIndex].Width = icoAtomico.Width + 40;
                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.dgvAlquiler.Columns[e.ColumnIndex].Name == "Devolucion" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvAlquiler.Rows[e.RowIndex].Cells["Devolucion"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-volver-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvAlquiler.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvAlquiler.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;
                e.Handled = true;
            }
        }
        private void dgvAlquiler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAlquiler.CurrentCell.ColumnIndex == 6)
            {
                int idAlquiler = 0;
                int idMaterial = 0;
                string ApellidoNombre = "";
                string Domicilio = "";
                string Telefono = "";
                string Email = "";
                string material = this.dgvAlquiler.CurrentRow.Cells[2].Value.ToString();
                idAlquiler = Convert.ToInt32(this.dgvAlquiler.CurrentRow.Cells[0].Value.ToString());

                string MontoAlquiler = AlquilerDao.BuscaMontoAlquiler(idAlquiler);
                List<Clientes> _cliente = ClientesDao.BuscarClientePorIdAlquiler(idAlquiler);
                if (_cliente.Count > 0)
                {
                    foreach (var item in _cliente)
                    {
                        ApellidoNombre = item.Apellido + " " + item.Nombre;
                        Domicilio = item.Calle + " " + "N°" + item.Altura + " " + item.NombreProvincia + " " + item.NombreLocalidad;
                        Telefono = item.Telefono;
                        Email = item.Email;
                    }
                    InformeAlquilerWF _informe = new InformeAlquilerWF(material, MontoAlquiler, ApellidoNombre, Domicilio, Email, Telefono);
                    _informe.Show();
                }

            }

            if (dgvAlquiler.CurrentCell.ColumnIndex == 7)
            {

                int DiasAtraso = 0;
                int idAlquiler = 0;
                int idMaterial = 0;
                string material = this.dgvAlquiler.CurrentRow.Cells[2].Value.ToString();

                DateTime FechaDevolucion = Convert.ToDateTime(this.dgvAlquiler.CurrentRow.Cells[5].Value.ToString());
                ////// Si la devolución esta fuera de fecha
                if (FechaDevolucion < DateTime.Now)
                {
                    const string message = "Atención: El alquiler seleccionado esta por fuera de la fecha de devolución pautada. ¿Desea cobrar un recargo?";
                    const string caption = "Consulta";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNoCancel,
                                                 MessageBoxIcon.Question);
                    {
                        if (result == DialogResult.Yes)
                        {
                            DiasAtraso = CalculosDiasAtrasado(FechaDevolucion);
                            idAlquiler = Convert.ToInt32(this.dgvAlquiler.CurrentRow.Cells[0].Value.ToString());
                            idMaterial = Convert.ToInt32(this.dgvAlquiler.CurrentRow.Cells[1].Value.ToString());
                            material = this.dgvAlquiler.CurrentRow.Cells[2].Value.ToString();
                            RecargoWF _recargo = new RecargoWF(DiasAtraso, idAlquiler, material, idMaterial);
                            _recargo.Show();
                        }
                        if (result == DialogResult.No)
                        {
                            bool Exito = AlquilerNeg.ActualizarEstados(idAlquiler, idMaterial);
                        }
                        if (result == DialogResult.Cancel)
                        {
                        }
                        BuscarAlquileresVigentes();
                    }
                }
                ///// Si la devolucion esta en fecha
                else
                {
                    const string message = "Atención: ¿Usted desea registrar la devolucion del material seleccionado?";
                    const string caption = "Consulta";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
                    {
                        if (result == DialogResult.Yes)
                        {
                            idAlquiler = Convert.ToInt32(this.dgvAlquiler.CurrentRow.Cells[0].Value.ToString());
                            idMaterial = Convert.ToInt32(this.dgvAlquiler.CurrentRow.Cells[1].Value.ToString());
                            bool Exito = AlquilerNeg.ActualizarEstados(idAlquiler, idMaterial);
                            const string message2 = "Se registro la devolución exitosamente.";
                            const string caption2 = "Éxito";
                            var result2 = MessageBox.Show(message2, caption2,
                                                         MessageBoxButtons.OK,
                                                         MessageBoxIcon.Asterisk);
                        }
                    }
                    BuscarAlquileresVigentes();
                }
            }
        }
        private int CalculosDiasAtrasado(DateTime fechaDevolucion)
        {
            int dias = 0;
            TimeSpan difFechas = DateTime.Now - fechaDevolucion;
            if (difFechas.Days > 0)
            { dias = Convert.ToInt32(difFechas.Days); }
            return dias;
        }

        private void txtBuscarEnGrilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FuncionListarAlquileres();
            }
        }
        private void FuncionListarAlquileres()
        {
            string Valor = txtBuscarEnGrilla.Text;
            if (Valor != "")
            {
                BuscarAlquileresVigentesPorDescripcion(Valor);
            }
            else
            { BuscarAlquileresVigentes(); }
        }
        private void BuscarAlquileresVigentesPorDescripcion(string Valor)
        {
            List<Alquiler> ListaAlquileres = new List<Alquiler>();
            ListaAlquileres = AlquilerNeg.ListarAlquileresActualesPorDescripcion(Valor);
            if (ListaAlquileres.Count > 0)
            {
                dgvAlquiler.Rows.Clear();
                foreach (var item in ListaAlquileres)
                {
                    dgvAlquiler.Rows.Add(item.idAlquiler, item.idMaterial, item.DescripcionProducto, item.Dias, item.FechaDesde, item.FechaHasta);
                }
            }
            dgvAlquiler.ReadOnly = true;
        }
    }
}
