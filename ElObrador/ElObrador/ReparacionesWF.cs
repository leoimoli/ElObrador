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

                bool Exito = ReparacionesNeg.RegistrarIngresoEnTaller(_taller);
                if (Exito == true)
                {
                    ProgressBar();
                    const string message2 = "Se registro el ingreso a taller exitosamente.";
                    const string caption2 = "Éxito";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                    //LimpiarCampos();
                    //FuncionListarMaterialesEnTaller();
                }
            }
            catch (Exception ex)
            { }
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
            _taller.idCliente = Convert.ToInt32(lblidCliente.Text);
            _taller.Material = txtDescripcionProducto.Text;
            _taller.Codigo = txtCodigo.Text;
            _taller.Modelo = txtModelo.Text;
            _taller.TipoServicio = cmbTipoServicio.Text;
            _taller.Fecha = dtFecha.Value;
            _taller.Diagnostico = txtDiagnostico.Text;
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
                    //string Apellido = item.Apellido;
                    //string Nombre = item.Nombre;
                    //string Persona = Apellido + "," + Nombre;
                    //string Domicilio = item.Calle + "N°" + item.Altura;
                    //dgvReparaciones.Rows.Add(item.IdCliente, Persona, Domicilio, item.Email, item.Telefono);
                }
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
                    //string Apellido = item.Apellido;
                    //string Nombre = item.Nombre;
                    //string Persona = Apellido + "," + Nombre;
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
            }
            dgvReparaciones.ReadOnly = true;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            textBox1.Focus();
            CargarComboServicio();
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
                //FuncionListarClientes();
                FuncionBuscartexto();
            }
            catch (Exception ex)
            { }
        }
        private void FuncionBuscartexto()
        {
            textBox1.AutoCompleteCustomSource = Clases_Maestras.AutoCompletePorApellido.Autocomplete();
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
}
