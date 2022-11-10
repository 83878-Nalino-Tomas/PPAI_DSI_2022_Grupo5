using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class TurnoDAO
    {
        internal static List<Turno> getTurnosParaRecurso(int recurso)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Turno WHERE recursoTecnologico = {recurso}";

            DataTable res = db.Query(sql);

            List<Turno> turnos = new List<Turno>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Turno turno = new Turno();
                turno.id = int.Parse(res.Rows[i]["id"].ToString());
                turno.fechaGeneracion = DateTime.Parse(res.Rows[i]["fechaGeneracion"].ToString());
                turno.fechaHoraInicio = DateTime.Parse(res.Rows[i]["fechaHoraInicio"].ToString());
                turno.fechaHoraFin = DateTime.Parse(res.Rows[i]["fechaHoraFin"].ToString());
                turno.diaSemana = (DayOfWeek)int.Parse(res.Rows[i]["diaSemana"].ToString());
                turno.cambioEstadoTurno = CambioEstadoDAO.getCambiosParaTurno(int.Parse(res.Rows[i]["id"].ToString()));
                turnos.Add(turno);
            }
            return turnos;
        }

        internal static List<Turno> getTurnosParaAsignacion(int v)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Turno WHERE asignacionCI = {v}";

            DataTable res = db.Query(sql);

            List<Turno> turnos = new List<Turno>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Turno turno = new Turno();
                turno.id = int.Parse(res.Rows[i]["id"].ToString());
                turno.fechaGeneracion = DateTime.Parse(res.Rows[i]["fechaGeneracion"].ToString());
                turno.fechaHoraInicio = DateTime.Parse(res.Rows[i]["fechaHoraInicio"].ToString());
                turno.fechaHoraFin = DateTime.Parse(res.Rows[i]["fechaHoraFin"].ToString());
                turno.diaSemana = (DayOfWeek)int.Parse(res.Rows[i]["diaSemana"].ToString());
                turno.cambioEstadoTurno = CambioEstadoDAO.getCambiosParaTurno(int.Parse(res.Rows[i]["id"].ToString()));
                turnos.Add(turno);
            }
            return turnos;
        }
    }
}
