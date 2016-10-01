using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class PersonaCliente:EntidadPersistente
    {
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

        private String ci;

        public String CI
        {
            get { return ci; }
            set { ci = value; }
        }

        private String telefono;

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private String cargo;

        public String Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }


        public PersonaCliente(String primerNombre,String segundoNombre,String primerApellido,String segundoApellido,String ci,String telefono,String cargo):base()
        {
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.ci = ci;
            this.telefono = telefono;
            this.cargo = cargo;
        }

        public String nombreCompleto()
        {
            return (this.primerNombre == null ? "" : this.primerNombre + " ") + (this.segundoNombre == null ? "" : this.segundoNombre + " ") + (this.primerApellido == null ? "" : this.primerApellido + " ") + (this.segundoApellido == null ? "" : this.segundoApellido);
        }
        public override string ToString()
        {
            return (this.primerNombre == null ? "" : this.primerNombre + " ") + (this.segundoNombre == null ? "" : this.segundoNombre + " ") + (this.primerApellido == null ? "" : this.primerApellido + " ") + (this.segundoApellido == null ? "" : this.segundoApellido);
        }

       
    }
}
