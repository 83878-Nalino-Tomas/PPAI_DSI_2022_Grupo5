using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class SesionDAO
    {
        public static Sesion getSesionActual()
        {
            ConexionDb db = new ConexionDb();
            string sql = "SELECT * FROM Sesion WHERE fechaFin IS NULL";

            DataTable res = db.Query(sql);

            List<Sesion> sesiones = new List<Sesion>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Sesion sesion = new Sesion();
                sesion.fechaInicio = DateTime.Parse(res.Rows[i]["fechaInicio"].ToString());
                sesion.fechaFin = null;
                sesion.usuarioActual = UsuarioDAO.getUsuario(res.Rows[i]["usuarioActual"].ToString());
                sesiones.Add(sesion);
            }
            return sesiones.First();
        }
    }
}
