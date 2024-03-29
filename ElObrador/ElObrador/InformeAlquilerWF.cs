﻿using System;
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
        private string ProvLoc;
        private string email;
        private string telefono;
        private List<Entidades.Alquiler> _Alquiler;

        public InformeAlquilerWF(List<Entidades.Alquiler> _Alquiler, string material, string montoAlquiler, string apellidoNombre, string domicilio, string ProvLoc, string email, string telefono)
        {
            InitializeComponent();
            this.material = material;
            this.montoAlquiler = montoAlquiler;
            this.apellidoNombre = apellidoNombre;
            this.domicilio = domicilio;
            this.ProvLoc = ProvLoc;
            this.email = email;
            this.telefono = telefono;
            this._Alquiler = _Alquiler;
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
            if (domicilio == " N°")
            { lblDomicilio.Text = "N/E"; }
            else
            { lblDomicilio.Text = domicilio; }
            lblProvLoc.Text = ProvLoc;
            lblTelefono.Text = telefono;
            lblEmail.Text = email;
            foreach (var item in _Alquiler)
            {
                dgvMateriales.Rows.Add(item.Codigo, item.DescripcionProducto);
            }
        }
    }
}
