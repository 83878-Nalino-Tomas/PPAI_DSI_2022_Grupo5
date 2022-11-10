using PPAI_DSI_Grupo5.CapaDatos;
using System;
using System.Collections.Generic;

namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public class Modelo
    {
        //ATRIBUTOS
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }


        //METODOS

        // --> Metodo Constructor
        public Modelo(string nombre)
        {
            this.nombre = nombre;
        }

        public Modelo()
        {
        }

        // --> Getters&Setters
        public string getNombre() { return this.nombre; }              
    }
}