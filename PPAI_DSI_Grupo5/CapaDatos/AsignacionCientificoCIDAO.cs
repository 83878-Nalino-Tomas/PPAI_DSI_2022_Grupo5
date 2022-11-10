using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class AsignacionCientificoCIDAO
    {
        internal static List<AsignacionCientificoCI> getAsignacionesPorCentro(string centro)
        {

            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM AsignacionCientificoCI WHERE centroInvestigacion = '{centro}'";

            DataTable res = db.Query(sql);

            List<AsignacionCientificoCI> asignaciones = new List<AsignacionCientificoCI>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                AsignacionCientificoCI asignacion = new AsignacionCientificoCI();
                asignacion.fechaDesde = DateTime.Parse(res.Rows[i]["fechaDesde"].ToString());
                asignacion.fechaHasta = DateTime.Parse(res.Rows[i]["fechaHasta"].ToString());
                asignacion.personalCientifico = PersonalCientificoDAO.getCientifico(int.Parse(res.Rows[i]["personalCientifico"].ToString()));
                asignacion.turnos = TurnoDAO.getTurnosParaAsignacion(int.Parse(res.Rows[i]["idAsignacion"].ToString()));
                asignaciones.Add(asignacion);
            }
            return asignaciones;

        }
    }
}
