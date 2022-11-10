using System;

namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public abstract class Estado
    {
        //ATRIBUTOS
        public int idEstado { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string ambito { get; set; }
        private string esCancelable;
        private string es_Reservable;


        //METODOS

        // --> Metodo Constructor
        public Estado(string nombre, string descripcion, string ambito)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.ambito = ambito;
        }

        public Estado()
        {
        }

        // --> Devuelve si el estado es RESERVADO
        public bool esReservado() { return nombre == "Reservado"; }

        // --> Devuelve si el estado es RESERVABLE
        internal bool esReservable() { return nombre == "Disponible"; }

        // --> Devuelve si el estado es de ambito TURNO
        public bool esAmbitoTurno() { return ambito == "Turno"; }

        //-- > Getters&Setters
        public string getNombre() { return nombre; }

        internal abstract void generarReservaRTSeleccionado(RecursoTecnologico recursoTecnologicoSeleccionado, Turno turnoSeleccionado);
    }
}
