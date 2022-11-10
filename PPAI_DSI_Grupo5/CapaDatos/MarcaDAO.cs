using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class MarcaDAO
    {
        internal static List<Marca> getMarcas()
        {

            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Marca";

            DataTable res = db.Query(sql);

            List<Marca> marcas = new List<Marca>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Marca marca = new Marca();
                marca.nombre = res.Rows[i]["nombre"].ToString();
                marca.modelos = ModeloDAO.getModelosPorMarca(marca.nombre);
                marcas.Add(marca);
            }
            return marcas;

        }
    }
}
