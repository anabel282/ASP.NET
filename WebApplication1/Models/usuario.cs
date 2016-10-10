using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Usuario
    {
        private Guid _codUsuario;
        private string _nombre;
        private string _apellidos;


        public Usuario()
        {
            this.CodUsuario = new Guid("-1");
            this.Nombre = "";
            this.Apellidos = "";
        }

        public Guid CodUsuario
        {
            get
            {
                return _codUsuario;
            }

            set
            {
                _codUsuario = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return _apellidos;
            }

            set
            {
                _apellidos = value;
            }
        }



    }
}