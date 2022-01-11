using ElObrador.Dao;
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

namespace ElObrador
{
    public partial class HistorialPrecioWF : Form
    {
        private int idMaterial1;

        public HistorialPrecioWF(int idMaterial1)
        {
            InitializeComponent();
            this.idMaterial1 = idMaterial1;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HistorialPrecioWF_Load(object sender, EventArgs e)
        {
            try
            {
                lblidMaterial.Text = Convert.ToString(idMaterial1);
                List<Stock> _listaHistorial = StockDao.BuscarHistorialPrecioPorProducto(idMaterial1);
                if (_listaHistorial.Count > 0)
                {
                    foreach (var item in _listaHistorial)
                    {
                        lblMaterial.Text = item.Descripcion;
                        dataGridView1.Rows.Add(item.idHistorial, item.MontoAlquiler, item.FechaDeAlta, item.NombreUsuario);
                    }
                }
                else
                {
                    lblMaterial.Font = new Font(lblMaterial.Font.FontFamily, lblMaterial.Font.Size - 1.5f, lblMaterial.Font.Style);
                    lblMaterial.Text = "El material seleccionado, no posee un historial para mostrar.";
                    dataGridView1.Visible = false;
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
