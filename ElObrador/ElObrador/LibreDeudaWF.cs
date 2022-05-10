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
            lblidCliente.Text = Convert.ToString(this.idClienteSeleccionado);
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

        private void FuncionesCheckRegistroDeuda()
        {
            grbRegistrarDeuda.Visible = true;
            chcPagarDeuda.Checked = false;
            grbGrilla.Visible = false;
            grbPagoDeuda.Visible = false;
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txMonto.Clear();
            txMotivo.Clear();
            dtFecha.Value = DateTime.Now;
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
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
            grbRegistrarDeuda.Visible = false;
            chcRegistrarDeuda.Checked = false;
            grbGrilla.Visible = false;
            grbPagoDeuda.Visible = true;
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
                        //FuncionListarClientes();
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
    }
}
