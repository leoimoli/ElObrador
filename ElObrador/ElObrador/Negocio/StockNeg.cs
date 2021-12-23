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
    public class StockNeg
    {
        public static bool CargarProducto(Stock stock)
        {
            bool exito = false;
            try
            {
                ValidarDatos(stock);
                bool ProveedorExistente = StockDao.ValidarProductoExistente(stock.Codigo);
                if (ProveedorExistente == true)
                {
                    const string message = "Ya existe un Material registrado con el codigo ingresado.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    exito = StockDao.InsertarProducto(stock);
                }
            }
            catch (Exception ex)
            { }
            return exito;
        }

       

        private static void ValidarDatos(Stock stock)
        {
            if (String.IsNullOrEmpty(stock.Descripcion))
            {
                const string message = "El campo Descripción es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(stock.Codigo))
            {
                const string message = "El campo Codigo es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
    }
}
