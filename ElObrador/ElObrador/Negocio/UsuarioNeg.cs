using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElObrador.Dao;
using ElObrador.Entidades;

namespace ElObrador.Negocio
{
    public class UsuarioNeg
    {
        public static List<MenuPorPerfilUsuario> BuscarMenuPorPerfilUsuario(object idPerfil)
        {
            List<Entidades.MenuPorPerfilUsuario> lista = new List<Entidades.MenuPorPerfilUsuario>();
            lista = UsuarioDao.BuscarMenuPorPerfilUsuario(idPerfil);
            return lista;
        }

        public static List<Usuario> LoginUsuario(string usuario, string contraseña)
        {
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            lista = UsuarioDao.LoginUsuario(usuario, contraseña);
            if (lista.Count > 0)
            {
                int idUsuario = Convert.ToInt32(lista[0].idUsuario.ToString());
                UsuarioDao.ActualizarUltimaConexion(idUsuario);
            }
            return lista;
        }
    }
}
