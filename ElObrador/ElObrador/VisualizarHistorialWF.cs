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
    public partial class VisualizarHistorialWF : Form
    {
        private string material;
        private DateTime fecha;
        private int idTaller;
        private string descripcion;

        public VisualizarHistorialWF(string material, DateTime fecha, int idTaller, string descripcion)
        {
            InitializeComponent();
            this.material = material;
            this.fecha = fecha;
            this.idTaller = idTaller;
            this.descripcion = descripcion;            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VisualizarHistorialWF_Load(object sender, EventArgs e)
        {
            lblHistorial.Text = this.material;
            txtDiagnostico.Text = this.descripcion;
            dtFecha.Value = this.fecha;
        }
    }
}
