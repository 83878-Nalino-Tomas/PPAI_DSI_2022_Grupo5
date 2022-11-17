using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class CambioEstadoTurnoDAO
    {
        internal static List<CambioEstadoTurno> getCambiosParaTurno(int turno)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM CambioEstadoTurno WHERE turno = {turno}";

            DataTable res = db.Query(sql);

            List<CambioEstadoTurno> cambios = new List<CambioEstadoTurno>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                CambioEstadoTurno cambio = new CambioEstadoTurno();
                cambio.fechaHoraDesde = DateTime.Parse(res.Rows[i]["fechaHoraDesde"].ToString());
                if (res.Rows[i]["fechaHoraHasta"].ToString() == String.Empty)
                {
                    Console.WriteLine("Sin fecha hasta");
                }
                else
                {
                    cambio.fechaHoraHasta = DateTime.Parse(res.Rows[i]["fechaHoraHasta"].ToString());
                }
                cambio.estado = EstadoDAO.getEstadoTurno(res.Rows[i]["estado"].ToString());
                cambios.Add(cambio);
            }
            return cambios;
        }

        internal static void UpdateCambioTurno(Turno turno, CambioEstadoTurno cambioEstadoTurno)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"UPDATE CambioEstadoTurno SET fechaHoraHasta = '{cambioEstadoTurno.fechaHoraHasta}' WHERE turno = {turno.id} AND fechaHoraDesde = '{cambioEstadoTurno.fechaHoraDesde}'";

            db.NonQuery(sql);
        }

        internal static void InsertCambioTurno(Turno turno, Estado est)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"INSERT INTO CambioEstadoTurno (fechaHoraDesde, estado, turno) VALUES ('{DateTime.Now}', {est.idEstado}, {turno.id})";

            db.NonQuery(sql);
        }
    }
}
