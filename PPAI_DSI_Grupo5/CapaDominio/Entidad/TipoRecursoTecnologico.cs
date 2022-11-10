using System.Collections.Generic;

namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public class TipoRecursoTecnologico
    {
        //ATRIBUTOS
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public List<Caracteristica> caracteristicas { get; set; }

        //METODOS

        // --> Metodo Constructor
        public TipoRecursoTecnologico(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public TipoRecursoTecnologico()
        {
        }

        // --> Retorna True si el tipo pasado como parametro coincide con el TipoRecursoTecnologico
        public bool esSeleccionado(string tipo)
        {
            return nombre == tipo;
        }

        // --> Getters&Setters
        public string getNombre() { return nombre; }
    }
}
