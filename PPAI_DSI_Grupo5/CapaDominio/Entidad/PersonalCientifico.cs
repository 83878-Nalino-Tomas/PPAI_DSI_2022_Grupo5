using System;

namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public class PersonalCientifico
    {
        //ATRIBUTOS
        public int legajo { get; set; }
        private string nombre;
        private string apellido;
        private double documento;
        private string correoInstitucional;
        public string correoPersonal { get; set; }
        private double telefono;

        public PersonalCientifico()
        {
        }

        //METODOS

        // --> Metodo Constructor
        public PersonalCientifico(int legajo, string nombre, string apellido, double documento,
            string correoInstitucional, string correoPersonal, double telefono)
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.correoInstitucional = correoInstitucional;
            this.correoPersonal = correoPersonal;
            this.telefono = telefono;
        }

        // --> Getters&Setters
        public string getMail() { return correoPersonal; }

        internal void asignarTurno(Turno turnoSeleccionado)
        {
            throw new NotImplementedException();
        }
    }
}
