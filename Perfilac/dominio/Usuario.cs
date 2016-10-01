using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class Usuario:EntidadPersistente
    {

        public Usuario(String user,String pass,String primerNombre,String segundoNombre,String primerApellido,String segundoApellido)
        {
            this.user = user;
            this.pass = pass;
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;

        }

        private String user;

        public String User
        {
            get { return user; }
            set { user = value; }
        }
        private String pass;

        public String Pass
        {
            get { return pass; }
            set { pass = value; }
        }


        private String primerNombre;

        public String PrimerNombre
        {
            get { return primerNombre; }
            set { primerNombre = value; }
        }
        private String segundoNombre;

        public String SegundoNombre
        {
            get { return segundoNombre; }
            set { segundoNombre = value; }
        }
        private String primerApellido;

        public String PrimerApellido
        {
            get { return primerApellido; }
            set { primerApellido = value; }
        }
        private String segundoApellido;

        public String SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }

        public override string ToString()
        {
            return (this.user == null ? "" : this.user + " ");
        }
    }
}
