using ElObrador.Clases_Maestras;
using ElObrador.Dao;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Feriados _feriados = CargarEntidad();
                bool Exito = FeriadosNeg.CargarFeriados(_feriados);
                if (Exito == true)
                {
                    ProgressBar();
                    const string message2 = "Se registro el feriado/día no laboral exitosamente.";
                    const string caption2 = "Éxito";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                    LimpiarCamposExito();
                    //FuncionListarClientes();
                    //FuncionCancelar();
                }
            }
            catch (Exception ex)
            { }
        }
        private void LimpiarCamposExito()
        {
            dtFecha.Value = DateTime.Now;
            txtMotivo.Clear();
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
            panelNuevo.Visible = false;
            panelFeriados.Visible = true;
            if (txtAño.Text != "")
            {
                string año = txtAño.Text;
                BuscarFeriados(año);
            }
        }
        private Feriados CargarEntidad()
        {
            Feriados _feriados = new Feriados();
            int idusuarioLogueado = Sesion.UsuarioLogueado.idUsuario;
            _feriados.idUsuario = idusuarioLogueado;
            _feriados.Motivo = txtMotivo.Text;
            string fechaActual = dtFecha.Value.ToShortDateString();
            _feriados.FechaString = fechaActual;
            _feriados.Fecha = Convert.ToDateTime(_feriados.FechaString);
            return _feriados;
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
        public static int idFeriadoSeleccionado = 0;
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLista.CurrentCell.ColumnIndex == 3)
                {
                    idFeriadoSeleccionado = Convert.ToInt32(this.dgvLista.CurrentRow.Cells[0].Value.ToString());
                    DateTime FechaFeriado = Convert.ToDateTime(this.dgvLista.CurrentRow.Cells[2].Value.ToString());
                    if (FechaFeriado < DateTime.Now)
                    {
                        const string message = "No se puede eliminar un feriado o día no laboral fecha menor a la actual.";
                        const string caption = "Atención";
                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.OK,
                                                   MessageBoxIcon.Exclamation);
                        throw new Exception();
                    }
                    else
                    {
                        const string message = "¿Usted desea eliminar el 'feriado/Día No Laboral' seleccionado?";
                        const string caption = "Consulta";
                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                        {
                            if (result == DialogResult.Yes)
                            {
                                bool exito = FeriadosDao.EliminarFeriado(idFeriadoSeleccionado);
                                const string message2 = "Se elimino el feriado/día no laboral exitosamente.";
                                const string caption2 = "Éxito";
                                var result2 = MessageBox.Show(message2, caption2,
                                                             MessageBoxButtons.OK,
                                                             MessageBoxIcon.Asterisk);
                                LimpiarCamposExito();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void dgvLista_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvLista.Columns[e.ColumnIndex].Name == "Quitar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell BotonVer = this.dgvLista.Rows[e.RowIndex].Cells["Quitar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\" + @"icons8-eliminar-30.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 20, e.CellBounds.Top + 4);
                this.dgvLista.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvLista.Columns[e.ColumnIndex].Width = icoAtomico.Width + 40;
                e.Handled = true;
            }
        }
    }
}
