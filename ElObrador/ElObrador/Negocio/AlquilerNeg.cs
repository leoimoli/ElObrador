using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElObrador.Dao;
using ElObrador.Entidades;

namespace ElObrador.Negocio
{
    public class AlquilerNeg
    {
        public static int RegistrarAlquiler(List<Alquiler> listaAlquiler)
        {
            int idAlquiler = 0;
            try
            {
                idAlquiler = AlquilerDao.RegistrarAlquiler(listaAlquiler);
            }
            catch (Exception ex)
            { }
            return idAlquiler;
        }
    }
}
