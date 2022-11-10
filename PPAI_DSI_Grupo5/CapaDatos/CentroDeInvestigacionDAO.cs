using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class CentroDeInvestigacionDAO
    {
        internal static CentroDeInvestigacion getCentro(string centroName)
        {

            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM CentroDeInvestigacion WHERE nombre = '{centroName}'";

            DataTable res = db.Query(sql);

            List<CentroDeInvestigacion> centros = new List<CentroDeInvestigacion>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                CentroDeInvestigacion centro = new CentroDeInvestigacion();
                centro.nombre = res.Rows[i]["nombre"].ToString();
                centro.tiempoAntelacionReserva = int.Parse(res.Rows[i]["tiempoAntelacionReserva"].ToString());
                centro.cientificos = AsignacionCientificoCIDAO.getAsignacionesPorCentro(centro.nombre);
                centros.Add(centro);
            }
            return centros.First();

        }

        internal static List<CentroDeInvestigacion> getCentros()
        {

            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM CentroDeInvestigacion";

            DataTable res = db.Query(sql);

            List<CentroDeInvestigacion> centros = new List<CentroDeInvestigacion>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                CentroDeInvestigacion centro = new CentroDeInvestigacion();
                centro.nombre = res.Rows[i]["nombre"].ToString();
                centro.tiempoAntelacionReserva = int.Parse(res.Rows[i]["tiempoAntelacionReserva"].ToString());
                centros.Add(centro);
            }
            return centros;

        }
    }
}
