using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial2
{
    public class UsuarioDAO
    {
        public static Usuario GetUser(String fullname, string password)
        {
            string sql = String.Format("SELECT * FROM appuser WHERE fullname = '{0}' AND password = '{1}';", fullname,
                password);

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            Usuario u = new Usuario();
            foreach (DataRow fila in dt.Rows)
            {
                u.usuario = fila[0].ToString();
                u.contrasena = fila[1].ToString();
                u.tipo = fila[2].ToString();
            }
            return u;
        }
        public static List<Usuario> GetLista()
        {
            string sql = "SELECT * FROM appuser";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            
            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow fila in dt.Rows)
            {
                Usuario u = new Usuario();
                u.usuario = fila[0].ToString();
                u.contrasena = fila[1].ToString();
                u.tipo = fila[2].ToString();
                lista.Add(u);
            }

            return lista;
        }
        public static void CrearNuevo(string fullname, string username, string password, string usertype)
        {
            string sql = String.Format(
                "INSERT INTO appuser(fullname, username, password, userType) VALUES ('{0}', '{1}', '{2}', '{3}');",
                fullname, username, password, usertype);

            ConnectionDB.ExecuteNonQuery(sql);
        }
        public static void ActualizarPermisos(string usertype, string fullname)
        {
            string sql = string.Format(
                "UPDATE appuser SET usertype='{0}' WHERE fullname='{1}';",
                usertype, fullname);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }
        public static void actualizarContra(string idUser, string nuevapassword)
        {
            string sql = String.Format(
                
            "UPDATE appuser SET password = 'nueva' WHERE idUser = 1;",
            nuevapassword, idUser);
            ConnectionDB.ExecuteQuery(sql);

        }
    }
}