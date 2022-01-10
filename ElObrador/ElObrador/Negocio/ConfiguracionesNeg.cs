using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElObrador.Dao;
using ElObrador.Entidades;

namespace ElObrador.Negocio
{
    public class ConfiguracionesNeg
    {
        public static bool RegistrarValorAlquiler(List<Stock> listaValoresObtenidos, decimal NuevoValor)
        {
            bool exito = false;
            try
            {
                exito = ConfiguracionesDao.RegistrarValorAlquiler(listaValoresObtenidos, NuevoValor);
            }
            catch (Exception ex)
            { }
            return exito;
        }
    }
}
