using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class Cliente:EntidadPersistente
    {
        private String codigo;

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private String contrato;

        public String Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }

        private String direccion;

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
            
        }

        private List<PersonaCliente> comerciales;

        public List<PersonaCliente> Comerciales
        {
            get { return comerciales; }
            set { comerciales = value; }
        }

        private String cuentaCUC;

        public String CuentaCUC
        {
            get { return cuentaCUC; }
            set { cuentaCUC = value; }
        }
        private String cuentaCUP;

        public String CuentaCUP
        {
            get { return cuentaCUP; }
            set { cuentaCUP = value; }
        }

        public Cliente(String codigo, String nombre, String contrato, String direccion, List<PersonaCliente> comerciales, String cuentaCUP, String cuentaCUC): base()
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.contrato = contrato;
            this.direccion = direccion;
            this.comerciales = comerciales;
            this.cuentaCUP = cuentaCUP;
            this.cuentaCUC = cuentaCUC;

        }

        public override string ToString()
        {
            return this.nombre;
        }

    }
}
