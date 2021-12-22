using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElObrador.Dao;
using ElObrador.Entidades;

namespace ElObrador.Negocio
{
    public class CategoriaNeg
    {
        public static bool GuardarCategoria(Categoria categoria)
        {
            bool exito = false;
            try
            {
                ValidarDatos(categoria);
                bool CategoriaExistente = CategoriaDao.ValidarCategoriaExistente(categoria.Nombre, categoria.idGrupo);
                if (CategoriaExistente == true)
                {
                    const string message = "Ya existe una Categoria registrado con el nombre ingresado.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    exito = CategoriaDao.InsertarCategoria(categoria);
                }
            }
            catch (Exception ex)
            { }
            return exito;
        }

        private static void ValidarDatos(Categoria categoria)
        {
            if (String.IsNullOrEmpty(categoria.Nombre))
            {
                const string message = "El campo nombre es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }

            if (categoria.idGrupo == 0)
            {
                const string message = "El campo Grupo es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
    }
}
