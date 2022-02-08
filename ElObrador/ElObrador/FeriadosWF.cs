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
    public partial class FeriadosWF : Form
    {
        public FeriadosWF()
        {
            InitializeComponent();
        }

        private void FeriadosWF_Load(object sender, EventArgs e)
        {
            string año = Convert.ToString(DateTime.Now.Year);
            txtAño.Text = año;
            dgvLista.Rows.Clear();
            List<Feriados> _feriados = ReportesDao.BuscarFeriadosAnioActual(año);
            if (_feriados.Count > 0)
            {
                foreach (var item in _feriados)
                {
                    dgvLista.Rows.Add(item.idFeriado, item.Motivo, item.FechaString);
                }
            }
            else
            {
                const string message2 = "Atención: no hay feriados o días no laborables ingresados para visualizar";
                const string caption2 = "Atención";
                var result2 = MessageBox.Show(message2, caption2,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Exclamation);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtAño_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAño.Text != "")
                {
                    string año = txtAño.Text;
                    BuscarFeriados(año);
                }
            }
        }
        private void BuscarFeriados(string año)
        {
            dgvLista.Rows.Clear();
            List<Feriados> _feriados = ReportesDao.BuscarFeriadosAnioActual(año);
            if (_feriados.Count > 0)
            {
                foreach (var item in _feriados)
                {
                    dgvLista.Rows.Add(item.idFeriado, item.Motivo, item.FechaString);
                }
            }
            else
            {
                const string message2 = "Atención: no hay feriados o días no laborables ingresados para visualizar";
                const string caption2 = "Atención";
                var result2 = MessageBox.Show(message2, caption2,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Exclamation);
            }
        }
        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            if (txtAño.Text != "")
            {
                string año = txtAño.Text;
                BuscarFeriados(año);
            }
        }

        private void btnNuevoFeriado_Click(object sender, EventArgs e)
        {
            panelFeriados.Visible = false;
            panelNuevo.Visible = true;
            dtFecha.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelFeriados.Visible = true;
            panelNuevo.Visible = false;
            dtFecha.Value = DateTime.Now;
            txtMotivo.Clear();
        }
    }
}
