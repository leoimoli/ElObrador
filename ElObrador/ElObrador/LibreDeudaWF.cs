using ElObrador.Clases_Maestras;
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
    public partial class LibreDeudaWF : Form
    {
        private int idClienteSeleccionado;
        public LibreDeudaWF(int idClienteSeleccionado)
        {
            InitializeComponent();
            this.idClienteSeleccionado = idClienteSeleccionado;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LibreDeudaWF_Load(object sender, EventArgs e)
        {
            try
            {
                lblidCliente.Text = Convert.ToString(this.idClienteSeleccionado);
                FuncionListarLibreDeuda();

            }
            catch (Exception ex)
            { }
        }

        private void FuncionListarLibreDeuda()
        {
            dgvLibreDeuda.Rows.Clear();
            List<Entidades.LibreDeuda> Lista = LibreDeudaNeg.ListarLibreDeuda(idClienteSeleccionado);
            if (Lista.Count > 0)
            {
                decimal MontoSuma = 0;
                decimal MontoResta = 0;
                decimal MontoTotal = 0;
                foreach (var item in Lista)
                {
                    string Monto = Convert.ToString(item.Monto);
                    int Tipo = item.idTipoTarea;
                    string TipoFuncion = "";
                    if (Tipo == 1)
                    {
                        TipoFuncion = "Registro Deuda";
                        MontoResta = MontoResta + item.Monto;
                    }
                    if (Tipo == 2)
                    {
                        TipoFuncion = "Pago Deuda";
                        MontoSuma = MontoSuma + item.Monto;
                    }
                    string Fecha = Convert.ToString(item.Fecha.ToShortDateString());
                    string Motivo = item.Motivo;

                    dgvLibreDeuda.Rows.Add(item.idLibreDeuda, Monto, TipoFuncion, Fecha, Motivo);
                }
                MontoTotal = MontoResta - MontoSuma;
                if (MontoTotal >= 0)
                {
                    txtMontoTotal.Text = Convert.ToString(MontoTotal);
                    txtMontoTotal.Visible = true;
                    lblTextoDeuda.Text = "El Cliente posee deuda de:";
                    grbGrilla.Visible = true;
                }
            }
            else
            {
                lblTextoDeuda.Text = "El Cliente no posee deuda pendiente de pago.";
                txtMontoTotal.Clear();
                txtMontoTotal.Visible = false;
                grbGrilla.Visible = true;
            }

            dgvLibreDeuda.ReadOnly = true;
        }

        private void grbRegistrarDeuda_Enter(object sender, EventArgs e)
        {

        }

        private void chcRegistrarDeuda_CheckedChanged(object sender, EventArgs e)
        {
            if (chcRegistrarDeuda.Checked == true)
            {
                FuncionesCheckRegistroDeuda();
            }
        }
        public static int Funcion = 0;
        private void FuncionesCheckRegistroDeuda()
        {
            grbRegistrarDeuda.Text = "Registrar Deuda";
            grbRegistrarDeuda.Visible = true;
            chcPagarDeuda.Checked = false;
            grbGrilla.Visible = false;
            LimpiarCampos();
            Funcion = 1;
        }
        private void LimpiarCampos()
        {
            txMonto.Clear();
            txMotivo.Clear();
            dtFecha.Value = DateTime.Now;
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
            //textBox2.Clear();
            //dateTimePicker1.Value = DateTime.Now;
            //textBox1.Clear();
            //groupBox2.Visible = false;
            //grbRegistrarDeuda.Visible = false;
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
        private void chcPagarDeuda_CheckedChanged(object sender, EventArgs e)
        {
            if (chcPagarDeuda.Checked == true)
            {
                FuncionesCheckPagarDeuda();
            }
        }
        private void FuncionesCheckPagarDeuda()
        {
            grbRegistrarDeuda.Text = "Registrar Pago";
            grbRegistrarDeuda.Visible = true;
            chcRegistrarDeuda.Checked = false;
            grbGrilla.Visible = false;
            Funcion = 2;
            LimpiarCampos();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chcRegistrarDeuda.Checked == true)
                {
                    Entidades.LibreDeuda _libreDeuda = CargarEntidadRegistroDeuda();
                    bool Exito = LibreDeudaNeg.RegistrarDeuda(_libreDeuda);
                    if (Exito == true)
                    {
                        ProgressBar();
                        const string message2 = "Se registro la deuda exitosamente.";
                        const string caption2 = "Éxito";
                        var result2 = MessageBox.Show(message2, caption2,
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Asterisk);
                        LimpiarCampos();
                        FuncionListarLibreDeuda();
                    }
                }
                if (chcPagarDeuda.Checked == true)
                {
                    Entidades.LibreDeuda _libreDeuda = CargarEntidadRegistroPago();
                    bool Exito = LibreDeudaNeg.RegistrarPago(_libreDeuda);
                    if (Exito == true)
                    {
                        ProgressBar();
                        const string message2 = "Se registro el pago exitosamente.";
                        const string caption2 = "Éxito";
                        var result2 = MessageBox.Show(message2, caption2,
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Asterisk);
                        LimpiarCampos();
                        FuncionListarLibreDeuda();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private LibreDeuda CargarEntidadRegistroDeuda()
        {
            LibreDeuda _libreDeuda = new LibreDeuda();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            _libreDeuda.idUsuario = idusuarioLogueado;
            /////// Tipo de Tarea 1 = registro Deuda //// 2 = Pago Deuda
            _libreDeuda.idTipoTarea = 1;
            _libreDeuda.Monto = Convert.ToDecimal(txMonto.Text);
            string fecha = dtFecha.Value.ToShortDateString();
            _libreDeuda.Fecha = Convert.ToDateTime(fecha);
            _libreDeuda.Motivo = txMotivo.Text;
            _libreDeuda.idCliente = Convert.ToInt32(lblidCliente.Text);
            _libreDeuda.FechaActual = DateTime.Now;
            return _libreDeuda;
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

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {

        }

        private LibreDeuda CargarEntidadRegistroPago()
        {
            LibreDeuda _libreDeuda = new LibreDeuda();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            _libreDeuda.idUsuario = idusuarioLogueado;
            /////// Tipo de Tarea 1 = registro Deuda //// 2 = Pago Deuda
            _libreDeuda.idTipoTarea = 2;
            _libreDeuda.Monto = Convert.ToDecimal(txMonto.Text);
            string fecha = dtFecha.Value.ToShortDateString();
            _libreDeuda.Fecha = Convert.ToDateTime(fecha);
            _libreDeuda.Motivo = txMotivo.Text;
            _libreDeuda.idCliente = Convert.ToInt32(lblidCliente.Text);
            _libreDeuda.FechaActual = DateTime.Now;
            return _libreDeuda;
        }
    }
}
