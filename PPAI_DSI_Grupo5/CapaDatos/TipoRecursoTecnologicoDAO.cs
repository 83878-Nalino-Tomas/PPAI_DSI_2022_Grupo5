using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class TipoRecursoTecnologicoDAO
    {
        public static List<TipoRecursoTecnologico> getTipoRecursos()
        {
            ConexionDb db = new ConexionDb();
            string sql = "SELECT * FROM TipoRecursoTecnologico";

            DataTable res = db.Query(sql);

            List<TipoRecursoTecnologico> recursos = new List<TipoRecursoTecnologico>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                TipoRecursoTecnologico recurso = new TipoRecursoTecnologico();
                recurso.nombre = res.Rows[i]["nombre"].ToString();
                recurso.descripcion = res.Rows[i]["descripcion"].ToString();
                recursos.Add(recurso);
            }
            return recursos;
        }

        internal static TipoRecursoTecnologico getTipoRecurso(string nombreRecurso)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM TipoRecursoTecnologico WHERE nombre = '{nombreRecurso}'";

            DataTable res = db.Query(sql);

            List<TipoRecursoTecnologico> recursos = new List<TipoRecursoTecnologico>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                TipoRecursoTecnologico recurso = new TipoRecursoTecnologico();
                recurso.nombre = res.Rows[i]["nombre"].ToString();
                recurso.descripcion = res.Rows[i]["descripcion"].ToString();
                recursos.Add(recurso);
            }
            return recursos.First();
        }
    }
}
