using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class UsuarioDAO
    {
        public static List<Usuario> getUsuarios()
        {
            //string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            //SqlConnection connect = new SqlConnection(cadenaConexion);
            //try
            //{
            //    SqlCommand cmd = new SqlCommand();

            //    string consulta = "SELECT * FROM Escuelas";

            //    cmd.Parameters.Clear();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = consulta;

            //    connect.Open();
            //    cmd.Connection = connect;

            //    DataTable tabla = new DataTable();
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    adapter.Fill(tabla);
            //    return tabla;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    connect.Close();
            //}

            ConexionDb db = new ConexionDb();
            string sql = "SELECT * FROM Usuario";

            DataTable res = db.Query(sql);

            List<Usuario> usuarios = new List<Usuario>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Usuario user = new Usuario();
                user.nombreUsuario = res.Rows[i]["nombreUsuario"].ToString();
                user.clave = res.Rows[i]["clave"].ToString();
                user.habilitado = bool.Parse(res.Rows[i]["habilitado"].ToString());
                user.cientifico = PersonalCientificoDAO.getCientifico(int.Parse(res.Rows[i]["cientifico"].ToString()));
                usuarios.Add(user);
            }
            return usuarios;
        }

        public static Usuario getUsuario(string username)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Usuario WHERE nombreUsuario = '{username}'";

            DataTable res = db.Query(sql);

            List<Usuario> usuarios = new List<Usuario>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Usuario user = new Usuario();
                user.nombreUsuario = res.Rows[i]["nombreUsuario"].ToString();
                user.clave = res.Rows[i]["clave"].ToString();
                user.habilitado = bool.Parse(res.Rows[i]["habilitado"].ToString());
                user.cientifico = PersonalCientificoDAO.getCientifico(int.Parse(res.Rows[i]["cientifico"].ToString()));
                usuarios.Add(user);
            }
            return usuarios.First();
        }
    }
}
