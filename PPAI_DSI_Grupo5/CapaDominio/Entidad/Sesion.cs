using System;

namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public class Sesion
    {
        //ATRIBUTOS
        public DateTime? fechaFin { get; set; }
        public DateTime fechaInicio { get; set; }
        public Usuario usuarioActual { get; set; }

        //METODOS

        // --> Metodo Constructor
        public Sesion(DateTime fechaFin, DateTime fechaInicio, Usuario usuarioActual)
        {
            this.fechaFin = fechaFin;
            this.fechaInicio = fechaInicio;
            this.usuarioActual = usuarioActual;
        }

        public Sesion()
        {
        }

        //--> Obtener el cientifico logueado
        public PersonalCientifico verificarCientificoLogueado() { return usuarioActual.obtenerCientifico(); }
    }
}
