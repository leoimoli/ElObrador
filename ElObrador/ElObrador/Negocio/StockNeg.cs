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
        public static List<Stock> ListaMaterialesDeLaCategoria(int idCategoriaSeleccionado)
        {
            List<Stock> _listaMateriales = new List<Stock>();
            try
            {
                _listaMateriales = StockDao.ListaMaterialesDeLaCategoria(idCategoriaSeleccionado);
            }
            catch (Exception ex)
            {
            }
            return _listaMateriales;
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
        public static List<Stock> ListarStock()
        {
            List<Stock> _listaProductos = new List<Stock>();
            try
            {
                _listaProductos = StockDao.ListarStock();
            }
            catch (Exception ex)
            {
            }
            return _listaProductos;
        }

        public static List<Stock> BuscarProductoPorId(int idMaterialSeleccionado)
        {
            List<Stock> _listaProductos = new List<Stock>();
            try
            {
                _listaProductos = StockDao.BuscarProductoPorId(idMaterialSeleccionado);
            }
            catch (Exception ex)
            {
            }
            return _listaProductos;
        }

        public static bool EditarProducto(Stock stock, int idMaterialSeleccionado)
        {
            bool exito = false;
            try
            {
                exito = StockDao.EditarProducto(stock, idMaterialSeleccionado);

            }
            catch (Exception ex)
            { }
            return exito;
        }
    }
}
