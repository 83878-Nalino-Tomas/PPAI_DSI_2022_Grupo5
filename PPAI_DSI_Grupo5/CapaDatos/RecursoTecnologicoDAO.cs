using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System.Collections.Generic;
using System.Data;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class RecursoTecnologicoDAO
    {
        public static List<RecursoTecnologico> getRecursosDisponibles()
        {
            ConexionDb db = new ConexionDb();
            string sql = "SELECT * FROM RecursoTecnologico WHERE estado = 1";

            DataTable res = db.Query(sql);

            List<RecursoTecnologico> recursos = new List<RecursoTecnologico>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                RecursoTecnologico recurso = new RecursoTecnologico();
                recurso.numeroRT = int.Parse(res.Rows[i]["numeroRT"].ToString());
                recurso.tipoRecurso = TipoRecursoTecnologicoDAO.getTipoRecurso(res.Rows[i]["tipoRecurso"].ToString());
                recurso.modeloDelRT = ModeloDAO.getModelo(res.Rows[i]["modeloDelRT"].ToString());
                recurso.turnos = TurnoDAO.getTurnosParaRecurso(recurso.numeroRT);
                recurso.cambioEstadoRT = CambioEstadoDAO.getCambiosParaRecurso(recurso.numeroRT);
                recursos.Add(recurso);
            }
            return recursos;
        }
    }
}
