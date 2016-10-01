using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.reportes
{
    public class InformePrueba
    {
        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int edad;

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }
        public InformePrueba()
        {
            this.edad = 23;
            this.nombre = "Eduardo Alfonso";
        }
    }
}
