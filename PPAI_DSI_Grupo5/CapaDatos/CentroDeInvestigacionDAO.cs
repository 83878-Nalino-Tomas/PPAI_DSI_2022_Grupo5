using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class CentroDeInvestigacionDAO
    {
        internal static Estado getCentro(string centro)
        {

            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Estado WHERE idEstado = 'centro}

            DataTable res = db.Query(sql);

            List<Estado> estados = new List<Estado>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Estado estado = new Estado();
                estado.nombre = res.Rows[i]["nombre"].ToString();
                estado.descripcion = res.Rows[i]["descripcion"].ToString();
                estado.ambito = res.Rows[i]["ambito"].ToString();
                estados.Add(estado);
            }
            return estados.First();

        }

        internal static List<Estado> getCentros()
        {

            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Estado";

            DataTable res = db.Query(sql);

            List<Estado> estados = new List<Estado>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Estado estado = new Estado();
                estado.nombre = res.Rows[i]["nombre"].ToString();
                estado.descripcion = res.Rows[i]["descripcion"].ToString();
                estado.ambito = res.Rows[i]["ambito"].ToString();
                estados.Add(estado);
            }
            return estados;

        }
    }
}
