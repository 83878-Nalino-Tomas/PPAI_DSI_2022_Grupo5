using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class CambioEstadoRTDAO
    {
        internal static List<CambioEstadoRT> getCambiosParaRecurso(int recurso)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM CambioEstadoRT WHERE recursoTecnologico = {recurso}";

            DataTable res = db.Query(sql);

            List<CambioEstadoRT> cambios = new List<CambioEstadoRT>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                CambioEstadoRT cambio = new CambioEstadoRT();
                cambio.fechaHoraDesde = DateTime.Parse(res.Rows[i]["fechaHoraDesde"].ToString());
                if (res.Rows[i]["fechaHoraHasta"].ToString() == String.Empty)
                {
                    Console.WriteLine("Sin fecha hasta");
                }
                else
                {
                    cambio.fechaHoraHasta = DateTime.Parse(res.Rows[i]["fechaHoraHasta"].ToString());
                }
                cambio.estado = EstadoDAO.getEstadoRT(res.Rows[i]["estado"].ToString());
                cambios.Add(cambio);
            }
            return cambios;
        }
    }
}
