using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElObrador.Clases_Maestras;
using ElObrador.Entidades;
using ElObrador.Negocio;

namespace ElObrador
{
    public partial class MasterInicioWF : Form
    {
        public MasterInicioWF()
        {
            InitializeComponent();
            AbrirFormEnPanel(new InicioWF());
            var imagen = new Bitmap(ElObrador.Properties.Resources.hogar__3_);
            ImagenPagina.Image = imagen;
            lblPantalla.Text = "Inicio";
            List<MenuPorPerfilUsuario> MenuPorPerfilUsuario = new List<MenuPorPerfilUsuario>();
            MenuPorPerfilUsuario = UsuarioNeg.BuscarMenuPorPerfilUsuario(Sesion.UsuarioLogueado.idPerfil);
            if (MenuPorPerfilUsuario.Count > 0)
            {
                foreach (var item in MenuPorPerfilUsuario)
                {
                    if (item.NombreMenu == "btnStock")
                    {
                        btnStock.Visible = true;
                        btnPanelStock.Visible = true;
                    }
                    if (item.NombreMenu == "btnAlquiler")
                    {
                        btnAlquiler.Visible = true;
                        btnPanelObras.Visible = true;
                    }
                    if (item.NombreMenu == "btnProveedores")
                    {
                        btnProveedores.Visible = true;
                        btnPanelProveedores.Visible = true;
                    }
                    if (item.NombreMenu == "btnReportes")
                    {
                        btnReportes.Visible = true;
                        btnPanelReportes.Visible = true;
                    }
                    if (item.NombreMenu == "btnUsuarios")
                    {
                        btnUsuarios.Visible = true;
                        btnPanelUsuarios.Visible = true;
                    }
                    if (item.NombreMenu == "btnConfiguracion")
                    {
                        btnConfiguaracion.Visible = true;
                        btnPanelConfiguracion.Visible = true;
                    }
                    if (item.NombreMenu == "btnTaller")
                    {
                        btnTaller.Visible = true;
                        btnPanelTaller.Visible = true;
                    }
                    if (item.NombreMenu == "btnReparaciones")
                    {
                        btnReparaciones.Visible = true;
                        btnPanelReparaciones.Visible = true;
                    }
                    if (item.NombreMenu == "btnClientes")
                    {
                        btnClientes.Visible = true;
                        btnPanelClientes.Visible = true;
                    }
                }
            }
            else
            {
                const string message2 = "Error: No se pudieron obtener los menú para el usuario logueado. Comuniquese con el administrador";
                const string caption2 = "Error";
                var result2 = MessageBox.Show(message2, caption2,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Exclamation);
            }
        }
        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        private void AbrirFormEnPanel(object formhija)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }
        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new InicioWF());
            var imagen = new Bitmap(ElObrador.Properties.Resources.hogar__3_);
            ImagenPagina.Image = imagen;
            lblPantalla.Text = "Inicio";
        }
        private void MasterInicioWF_Load(object sender, EventArgs e)
        {
            label6.Text = Sesion.UsuarioLogueado.Apellido + "  " + Sesion.UsuarioLogueado.Nombre;
        }
    }
}
