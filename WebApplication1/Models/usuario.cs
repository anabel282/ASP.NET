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
        private string _pass;
        private string _alias;
        private DateTime _fNacimiento;
        private string _dni;
        

        public Usuario()
        {
            this.CodUsuario = new Guid("-1");
            this.Nombre = "";
            this.Apellidos = "";
            this.Pass = "";
            this.Alias = "";
            this.Dni = "";
            this.FNacimiento = new DateTime();
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

        public string Pass
        {
            get
            {
                return _pass;
            }

            set
            {
                _pass = value;
            }
        }

        public string Alias
        {
            get
            {
                return _alias;
            }

            set
            {
                _alias = value;
            }
        }

        public DateTime FNacimiento
        {
            get
            {
                return _fNacimiento;
            }

            set
            {
                _fNacimiento = value;
            }
        }

        public string Dni
        {
            get
            {
                return _dni;
            }

            set
            {
                _dni = value;
            }
        }
    }
}