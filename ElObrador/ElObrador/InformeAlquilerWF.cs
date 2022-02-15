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
    public partial class InformeAlquilerWF : Form
    {
        private string material;
        private string montoAlquiler;
        private string apellidoNombre;
        private string domicilio;
        private string email;
        private string telefono;

        public InformeAlquilerWF(string material, string montoAlquiler, string apellidoNombre, string domicilio, string email, string telefono)
        {
            InitializeComponent();
            this.material = material;
            this.montoAlquiler = montoAlquiler;
            this.apellidoNombre = apellidoNombre;
            this.domicilio = domicilio;
            this.email = email;
            this.telefono = telefono;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InformeAlquilerWF_Load(object sender, EventArgs e)
        {
            lblMaterial.Text = material;
            lblMonto.Text = montoAlquiler;
            lblApellido.Text = apellidoNombre;
            lblDomicilio.Text = domicilio;
            lblTelefono.Text = telefono;
            lblEmail.Text = email;
        }
    }
}
