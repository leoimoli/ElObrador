using ElObrador.Clases_Maestras;
using ElObrador.Entidades;
using ElObrador.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElObrador
{
    public partial class LoginWF : Form
    {
        public LoginWF()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Login();
        }
        #region Funciones
        private void Login()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                string usuario = txtUsuario.Text;
                string contraseña = txtClave.Text;
                string cifrar = Cifrar(contraseña);

                //string descifrar = Descifrar(cifrar);
                contraseña = cifrar;
                usuarios = UsuarioNeg.LoginUsuario(usuario, contraseña);
                if (usuarios.Count == 0)

                {
                    const string message2 = "Usuario/contraseña ingresado incorrecta.";
                    const string caption2 = "Error";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Exclamation);
                }
                if (usuarios[0].Estado == 0)
                {
                    const string message2 = "Atención: El Usuario ingresado se encuentra inactivo. Consultelo con el administrador.";
                    const string caption2 = "Atención";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Exclamation);
                }
                else
                {
                    Sesion.UsuarioLogueado = usuarios.First();
                    MasterInicioWF _inicio = new MasterInicioWF();
                    _inicio.Show();
                    Hide();
                }
                //}              
            }
            catch (Exception ex)
            {

            }
        }
        public string Cifrar(string clave)
        {
            byte[] llave; //Arreglo donde guardaremos la llave para el cifrado 3DES.
            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(clave); //Arreglo donde guardaremos la cadena descifrada.
            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();
            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
            tripledes.Clear();
            return Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
        }
        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ConexionesWF _cone = new ConexionesWF();
            _cone.Show();
        }
    }
}
