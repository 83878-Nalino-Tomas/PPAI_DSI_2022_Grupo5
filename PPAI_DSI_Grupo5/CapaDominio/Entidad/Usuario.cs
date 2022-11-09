﻿using PPAI_DSI_Grupo5.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public class Usuario
    {
        //ATRIBUTOS
        public string nombreUsuario { get; set; }
        public string clave { get; set; }
        public bool habilitado { get; set; }
        public PersonalCientifico cientifico { get; set; }

        //METODOS

        // --> Metodo Constructor
        public Usuario(string nombreUsuario, string clave, bool habilitado, PersonalCientifico cientifico)
        {
            this.nombreUsuario = nombreUsuario;
            this.clave = clave;
            this.habilitado = habilitado;
            this.cientifico = cientifico;
        }

        // --> Metodo Constructor
        public Usuario(string nombreUsuario, string clave, bool habilitado)
        {
            this.nombreUsuario = nombreUsuario;
            this.clave = clave;
            this.habilitado = habilitado;
        }

        public Usuario()
        {
        }

        //Getters&Setters
        public PersonalCientifico obtenerCientifico() { return cientifico; }
    }
}
