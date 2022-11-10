using System.Collections.Generic;

namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public class Marca
    {
        //ATRIBUTOS
        public string nombre { get; set; }
        public List<Modelo> modelos { get; set; }

        public Marca()
        {
        }

        //METODOS

        // --> Metodo Constructor
        public Marca(string nombre, List<Modelo> modelos)
        {
            this.nombre = nombre;
            this.modelos = modelos;
        }

        // --> Devuelve si un modelo es de esta marca
        public bool esDeEstaMarca(Modelo modelo)
        {
            return modelos.Contains(modelo);
        }

        // --> Getters&Setters
        public string getNombre() { return nombre; }
    }
}
