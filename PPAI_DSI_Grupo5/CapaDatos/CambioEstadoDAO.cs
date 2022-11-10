using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class CambioEstadoDAO
    {
        internal static List<CambioEstadoRT> getCambiosParaRecurso(int recurso)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM CambioEstado WHERE recursoTecnologico = {recurso}";

            DataTable res = db.Query(sql);

            List<CambioEstadoRT> cambios = new List<CambioEstadoRT>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                CambioEstadoRT cambio = new CambioEstadoRT();
                cambio.fechaHoraDesde = DateTime.Parse(res.Rows[i]["fechaHoraDesde"].ToString());
                cambio.fechaHoraHasta = DateTime.Parse(res.Rows[i]["fechaHoraHasta"].ToString());
                cambio.estado = EstadoDAO.getEstado(res.Rows[i]["estado"].ToString());
                cambios.Add(cambio);
            }
            return cambios;
        }
    }
}
