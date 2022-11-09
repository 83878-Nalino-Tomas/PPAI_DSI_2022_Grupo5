using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                turno.fechaGeneracion = DateTime.Parse(res.Rows[i]["nombre"].ToString());
                turno.fechaHoraInicio = DateTime.Parse(res.Rows[i]["nombre"].ToString());
                turno.fechaHoraFin = DateTime.Parse(res.Rows[i]["nombre"].ToString());
                turno.diaSemana = (DayOfWeek)int.Parse(res.Rows[i]["nombre"].ToString());
                turnos.Add(turno);
            }
            return turnos;
        }
    }
}
